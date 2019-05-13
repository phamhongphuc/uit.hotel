using System.Collections.Generic;
using GraphQL.Types;
using uit.hotel.Businesses;
using uit.hotel.Models;
using uit.hotel.ObjectTypes;
using uit.hotel.Queries.Authentication;
using uit.hotel.Queries.Base;

namespace uit.hotel.Queries.Mutation
{
    public class HouseKeepingMutation : QueryType<HouseKeeping>
    {
        public HouseKeepingMutation()
        {
            Field<NonNullGraphType<HouseKeepingType>>(
                "AssignCleaningService",
                "Nhân viên nhận phòng để dọn dẹp",
                _IdArgument(),
                _CheckPermission_TaskObject(
                    p => p.PermissionCleaning,
                    context =>
                    {
                        var employee = AuthenticationHelper.GetEmployee(context);
                        return HouseKeepingBusiness.AssignCleaningService(employee, _GetId<int>(context));
                    }
                )
            );

            Field<NonNullGraphType<HouseKeepingType>>(
                "ConfirmCleaned",
                "Nhân viên xác nhận đã dọn xong",
                _IdArgument(),
                _CheckPermission_TaskObject(
                    p => p.PermissionCleaning,
                    context =>
                    {
                        var employee = AuthenticationHelper.GetEmployee(context);
                        return HouseKeepingBusiness.ConfirmCleaned(employee, _GetId<int>(context));
                    }
                )
            );

            Field<NonNullGraphType<HouseKeepingType>>(
                "ConfirmCleanedAndServices",
                "Nhân viên xác nhận và gửi thông tin kiểm tra phòng check-out",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<ListGraphType<NonNullGraphType<ServicesDetailHouseKeepingInput>>>>
                    { Name = "servicesDetails" },
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "houseKeepingId" }
                ),
                _CheckPermission_TaskObject(
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
