using System;
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
                new
                {
                    input = new
                    {
                        id = "nhanvien",
                        password = "123",
                        name = "Tên nhân viên",
                        identityCard = "12345678",
                        gender = true,
                        email = "email@gmail.com",
                        phoneNumber = "123456789",
                        address = "164/54",
                        birthdate = "04-04-1996",
                        startingDate = "10-10-2015",
                        position = new
                        {
                            id = 1
                        }
                    }
                },
                p => p.PermissionManageEmployee = true
            );
        }

        [TestMethod]
        public void Mutation_CreateEmployee_InvalidId()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Id: admin đã có người sử dụng",
                @"/_GraphQL/Employee/mutation.createEmployee.gql",
                new
                {
                    input = new
                    {
                        id = "admin",
                        password = "123",
                        name = "Tên nhân viên",
                        identityCard = "12345678",
                        gender = true,
                        email = "email@gmail.com",
                        phoneNumber = "123456789",
                        address = "164/54",
                        birthdate = "04-04-1996",
                        startingDate = "10-10-2015",
                        position = new
                        {
                            id = 1
                        }
                    }
                },
                p => p.PermissionManageEmployee = true
            );
        }

        [TestMethod]
        public void Mutation_UpdateEmployee()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Employee/mutation.updateEmployee.gql",
                @"/_GraphQL/Employee/mutation.updateEmployee.schema.json",
                new
                {
                    input = new
                    {
                        id = "admin",
                        name = "Tên nhân viên",
                        identityCard = "12345678",
                        address = "164/54",
                        birthdate = DateTimeOffset.Now,
                        email = "email@gmail.com",
                        gender = true,
                        phoneNumber = "123456789",
                        startingDate = DateTimeOffset.Now,
                        position = new { id = 1 }
                    }
                },
                p => p.PermissionManageEmployee = true
            );
        }

        [TestMethod]
        public void Mutation_UpdateEmployee_Inactive_Employee()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Tài khoản inactive đã bị vô hiệu hóa",
                @"/_GraphQL/Employee/mutation.updateEmployee.gql",
                new
                {
                    input = new
                    {
                        id = "inactive",
                        name = "Tên nhân viên",
                        identityCard = "12345678",
                        gender = true,
                        email = "email@gmail.com",
                        phoneNumber = "123456789",
                        address = "164/54",
                        birthdate = "04-04-1996",
                        startingDate = "10-10-2015",
                        position = new { id = 1 }
                    }
                },
                p => p.PermissionManageEmployee = true
            );
        }

        [TestMethod]
        public void Mutation_UpdateEmployee_InvalidId()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Không tồn tại nhân viên này",
                @"/_GraphQL/Employee/mutation.updateEmployee.gql",
                new
                {
                    input = new
                    {
                        id = "không tồn tại",
                        name = "Tên nhân viên",
                        identityCard = "12345678",
                        gender = true,
                        email = "email@gmail.com",
                        phoneNumber = "123456789",
                        address = "164/54",
                        birthdate = "04-04-1996",
                        startingDate = "10-10-2015",
                        position = new { id = 1 }
                    }
                },
                p => p.PermissionManageEmployee = true
            );
        }

        [TestMethod]
        public void Mutation_UpdateEmployee_InvalidPositionId()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Mã chức vụ không tồn tại",
                @"/_GraphQL/Employee/mutation.updateEmployee.gql",
                new
                {
                    input = new
                    {
                        id = "admin",
                        name = "Tên nhân viên",
                        identityCard = "12345678",
                        gender = true,
                        email = "email@gmail.com",
                        phoneNumber = "123456789",
                        address = "164/54",
                        birthdate = "04-04-1996",
                        startingDate = "10-10-2015",
                        position = new { id = 100 }
                    }
                },
                p => p.PermissionManageEmployee = true
            );
        }

        [TestMethod]
        public void Query_Employee()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Employee/query.employee.gql",
                @"/_GraphQL/Employee/query.employee.schema.json",
                new { id = "admin" },
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
