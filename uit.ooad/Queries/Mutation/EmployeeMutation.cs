using System;
using GraphQL.Types;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;
using uit.ooad.Queries.Authentication;
using uit.ooad.Queries.Base;

namespace uit.ooad.Queries.Mutation
{
    public class EmployeeMutation : QueryType<Employee>
    {
        public EmployeeMutation()
        {
            Field<EmployeeType>(
                _Creation,
                "Tạo và trả về một nhân viên mới",
                _InputArgument<EmployeeCreateInput>(),
                _CheckPermission(
                    p => p.PermissionManageEmployees,
                    context => EmployeeBusiness.Add(_GetInput(context))
                )
            );

            Field<EmployeeType>(
                _Updation,
                "Chỉnh sửa thông tin nhân viên",
                _InputArgument<EmployeeUpdateInput>(),
                _CheckPermission(
                    p => p.PermissionManageEmployees,
                    context => EmployeeBusiness.Update(_GetInput(context))
                )
            );

            Field<StringGraphType>(
                "ResetPassword",
                "Reset lại mật khẩu cho nhân viên khi quên mật khẩu",
                _IdArgument(),
                _CheckPermission(
                    p => p.PermissionManageEmployees,
                    context =>
                    {
                        var id = AuthenticationHelper.GetEmployeeId(context);
                        var employeeId = context.GetArgument<string>("id");

                        if (id == employeeId)
                            throw new Exception("Nhân viên không thể tự reset mật khẩu của chính mình");
                        var newPassword = EmployeeBusiness.ResetPassword(employeeId);

                        return "Mật khẩu mới: " + newPassword;
                    }
                )
            );

            Field<StringGraphType>(
                "SetIsActiveAccount",
                "Vô hiệu hóa/ kích hoạt tài khoản",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" },
                    new QueryArgument<NonNullGraphType<BooleanGraphType>> { Name = "isActive" }
                ),
                _CheckPermission(
                    p => p.PermissionManageEmployees,
                    context =>
                    {
                        var id = AuthenticationHelper.GetEmployeeId(context);
                        var employeeId = context.GetArgument<string>("id");
                        var isActive = context.GetArgument<bool>("isActive");

                        if (id == employeeId)
                            throw new Exception(
                                "Nhân viên không thể tự vô hiệu hóa hoặc kích hoạt tài khoản của chính mình");
                        EmployeeBusiness.SetIsActiveAccount(employeeId, isActive);
                        return "Thành công";
                    }
                )
            );
        }
    }
}
