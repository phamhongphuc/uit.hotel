using System;
using GraphQL.Types;
using uit.hotel.Businesses;
using uit.hotel.Models;
using uit.hotel.ObjectTypes;
using uit.hotel.Queries.Authentication;
using uit.hotel.Queries.Base;

namespace uit.hotel.Queries.Mutation
{
    public class EmployeeMutation : QueryType<Employee>
    {
        public EmployeeMutation()
        {
            Field<NonNullGraphType<EmployeeType>>(
                _Creation,
                "Tạo và trả về một nhân viên mới",
                _InputArgument<EmployeeCreateInput>(),
                _CheckPermission_TaskObject(
                    p => p.PermissionManageEmployee,
                    context => EmployeeBusiness.Add(_GetInput(context))
                )
            );

            Field<NonNullGraphType<EmployeeType>>(
                _Updation,
                "Chỉnh sửa thông tin nhân viên",
                _InputArgument<EmployeeUpdateInput>(),
                _CheckPermission_TaskObject(
                    p => p.PermissionManageEmployee,
                    context => EmployeeBusiness.Update(_GetInput(context))
                )
            );

            Field<NonNullGraphType<StringGraphType>>(
                "ResetPassword",
                "Reset lại mật khẩu cho nhân viên khi quên mật khẩu",
                _IdArgument(),
                _CheckPermission_String(
                    p => p.PermissionManageEmployee,
                    context =>
                    {
                        var id = AuthenticationHelper.GetEmployeeId(context);

                        var newPassword = EmployeeBusiness.ResetPassword(id, _GetId<string>(context));

                        return "Mật khẩu mới: " + newPassword;
                    }
                )
            );

            Field<NonNullGraphType<StringGraphType>>(
                "SetIsActiveAccount",
                "Vô hiệu hóa/ kích hoạt tài khoản",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" },
                    new QueryArgument<NonNullGraphType<BooleanGraphType>> { Name = "isActive" }
                ),
                _CheckPermission_String(
                    p => p.PermissionManageEmployee,
                    context =>
                    {
                        var id = AuthenticationHelper.GetEmployeeId(context);
                        var employeeId = context.GetArgument<string>("id");
                        var isActive = context.GetArgument<bool>("isActive");

                        EmployeeBusiness.SetIsActiveAccount(id, employeeId, isActive);
                        return "Thành công";
                    }
                )
            );
        }
    }
}
