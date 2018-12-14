using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.test.Helper;

namespace uit.ooad.test._GraphQL.Employee
{
    [TestClass]
    public class _Employee
    {
        [TestMethod]
        public void Employees()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Employee/query.employees.gql",
                @"/_GraphQL/Employee/query.employees.schema.json"
            );
        }
        [TestMethod]
        public void Employee()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Employee/query.employee.gql",
                @"/_GraphQL/Employee/query.employee.schema.json",
                @"/_GraphQL/Employee/query.employee.variable.json"
            );
        }
        [TestMethod]
        public void CreateEmployee()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Employee/mutation.createEmployee.gql",
                @"/_GraphQL/Employee/mutation.createEmployee.schema.json",
                @"/_GraphQL/Employee/mutation.createEmployee.variable.json",
                p => p.PermissionCreateEmployee = true
            );
        }
    }
}
