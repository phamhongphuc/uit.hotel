using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.ooad.test.Helper;

namespace uit.ooad.test._GraphQL
{
    [TestClass]
    public class _Employee
    {
        [TestMethod]
        public void Mutation_CreateEmployee()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Employee/mutation.createEmployee.gql",
                @"/_GraphQL/Employee/mutation.createEmployee.schema.json",
                @"/_GraphQL/Employee/mutation.createEmployee.variable.json",
                p => p.PermissionManageEmployee = true
            );
        }

        [TestMethod]
        public void Mutation_CreateEmployee_InvalidId()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Id: admin đã có người sử dụng",
                @"/_GraphQL/Employee/mutation.createEmployee.gql",
                @"/_GraphQL/Employee/mutation.createEmployee.variable.invalid_id.json",
                p => p.PermissionManageEmployee = true
            );
        }

        [TestMethod]
        public void Mutation_UpdateEmployee()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Employee/mutation.updateEmployee.gql",
                @"/_GraphQL/Employee/mutation.updateEmployee.schema.json",
                @"/_GraphQL/Employee/mutation.updateEmployee.variable.json",
                p => p.PermissionManageEmployee = true
            );
        }

        [TestMethod]
        public void Mutation_UpdateEmployee_Inactive_Employee()
        {
            
            SchemaHelper.ExecuteAndExpectError(
                "Tài khoản inactive đã bị vô hiệu hóa",
                @"/_GraphQL/Employee/mutation.updateEmployee.gql",
                @"/_GraphQL/Employee/mutation.updateEmployee.variable.inactive_employee.json",
                p => p.PermissionManageEmployee = true
            );
        }

        [TestMethod]
        public void Mutation_UpdateEmployee_InvalidId()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Không tồn tại nhân viên này",
                @"/_GraphQL/Employee/mutation.updateEmployee.gql",
                @"/_GraphQL/Employee/mutation.updateEmployee.variable.invalid_id.json",
                p => p.PermissionManageEmployee = true
            );
        }
        [TestMethod]
        public void Mutation_UpdateEmployee_InvalidPositionId()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Mã chức vụ không tồn tại",
                @"/_GraphQL/Employee/mutation.updateEmployee.gql",
                @"/_GraphQL/Employee/mutation.updateEmployee.variable.invalid_position_id.json",
                p => p.PermissionManageEmployee = true
            );
        }

        [TestMethod]
        public void Query_Employee()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Employee/query.employee.gql",
                @"/_GraphQL/Employee/query.employee.schema.json",
                @"/_GraphQL/Employee/query.employee.variable.json",
                p => p.PermissionManageEmployee = true
            );
        }

        [TestMethod]
        public void Query_Employees()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Employee/query.employees.gql",
                @"/_GraphQL/Employee/query.employees.schema.json",
                null,
                p => p.PermissionManageEmployee = true
            );
        }
    }
}
