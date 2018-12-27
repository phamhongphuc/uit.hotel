using System.Collections.Generic;
using GraphQL.Types;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;
using uit.ooad.Queries.Authentication;
using uit.ooad.Queries.Base;

namespace uit.ooad.Queries.Mutation
{
    public class HouseKeepingMutation : QueryType<HouseKeeping>
    {
        public HouseKeepingMutation()
        {
            Field<HouseKeepingType>(
                "AssignCleaningService",
                "Nhân viên nhận phòng để dọn dẹp",
                _IdArgument(),
                _CheckPermission_Object(
                    p => p.PermissionCleaning,
                    context =>
                    {
                        var employee = AuthenticationHelper.GetEmployee(context);
                        return HouseKeepingBusiness.AssignCleaningService(employee, _GetId<int>(context));
                    }
                )
            );

            Field<HouseKeepingType>(
                "ConfirmCleaned",
                "Nhân viên xác nhận đã dọn xong",
                _IdArgument(),
                _CheckPermission_Object(
                    p => p.PermissionCleaning,
                    context =>
                    {
                        var employee = AuthenticationHelper.GetEmployee(context);
                        return HouseKeepingBusiness.ConfirmCleaned(employee, _GetId<int>(context));
                    }
                )
            );

            Field<HouseKeepingType>(
                "ConfirmCleanedAndServices",
                "Nhân viên xác nhận và gửi thông tin kiểm tra phòng check-out",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<ListGraphType<NonNullGraphType<ServicesDetailCreateInput>>>>
                        { Name = "servicesDetails" },
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "houseKeepingId" }
                ),
                _CheckPermission_Object(
                    p => p.PermissionCleaning,
                    context =>
                    {
                        var employee = AuthenticationHelper.GetEmployee(context);
                        var servicesDetails = context.GetArgument<List<ServicesDetail>>("servicesDetails");
                        var houseKeepingId = context.GetArgument<int>("houseKeepingId");

                        return HouseKeepingBusiness.ConfirmCleanedAndServices(
                            employee, servicesDetails, houseKeepingId);
                    }
                )
            );
        }
    }
}
