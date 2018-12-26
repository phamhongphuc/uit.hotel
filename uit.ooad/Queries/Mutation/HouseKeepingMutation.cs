using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;
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
                _InputArgument<HouseKeepingCreateInput>(),
                _CheckPermission(
                    p => p.PermissionCleaning,
                    context => HouseKeepingBusiness.Add(_GetInput(context))
                )
            );

            Field<HouseKeepingType>(
                "ConfirmCleaning",
                "Nhân viên xác nhận đã dọn xong",
                _InputArgument<HouseKeepingCreateInput>(),
                _CheckPermission(
                    p => p.PermissionCleaning,
                    context => HouseKeepingBusiness.Add(_GetInput(context))
                )
            );

            Field<HouseKeepingType>(
                "ConfirmCleaningAndServices",
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
