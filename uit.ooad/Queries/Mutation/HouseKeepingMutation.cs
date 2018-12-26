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
                _CheckPermission(
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
                _CheckPermission(
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
                _InputArgument<HouseKeepingCreateInput>(),
                _CheckPermission(
                    p => p.PermissionCleaning,
                    context => HouseKeepingBusiness.Add(_GetInput(context))
                )
            );
        }
    }
}
