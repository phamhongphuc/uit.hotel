using GraphQL.Types;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;
using uit.ooad.Queries.Base;

namespace uit.ooad.Queries.Mutation
{
    public class PatronKindMutation : QueryType<PatronKind>
    {
        public PatronKindMutation()
        {
            Field<NonNullGraphType<PatronKindType>>(
                _Creation,
                "Tạo và trả về một loại khách hàng mới",
                _InputArgument<PatronKindCreateInput>(),
                _CheckPermission_TaskObject(
                    p => p.PermissionManagePatronKind,
                    context => PatronKindBusiness.Add(_GetInput(context))
                )
            );

            Field<NonNullGraphType<PatronKindType>>(
                _Updation,
                "Cập nhật và trả về một loại khách hàng vừa cập nhật",
                _InputArgument<PatronKindUpdateInput>(),
                _CheckPermission_TaskObject(
                    p => p.PermissionManagePatronKind,
                    context => PatronKindBusiness.Update(_GetInput(context))
                )
            );

            Field<NonNullGraphType<StringGraphType>>(
                _Deletion,
                "Xóa một loại khách hàng",
                _IdArgument(),
                _CheckPermission_String(
                    p => p.PermissionManagePatronKind,
                    context =>
                    {
                        PatronKindBusiness.Delete(_GetId<int>(context));
                        return "Xóa thành công";
                    }
                )
            );
        }
    }
}
