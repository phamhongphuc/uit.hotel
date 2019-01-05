using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.ooad.Businesses;
using uit.ooad.DataAccesses;
using uit.ooad.Models;
using uit.ooad.Queries.Authentication;
using uit.ooad.test.Helper;

namespace uit.ooad.test._GraphQL
{
    [TestClass]
    public class _Employee : RealmDatabase
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
        public void Mutation_CreateEmployee_InvalidPosition()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Mã chức vụ không tồn tại",
                @"/_GraphQL/Employee/mutation.createEmployee.gql",
                new
                {
                    input = new
                    {
                        id = "thaotram",
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
                            id = 100
                        }
                    }
                },
                p => p.PermissionManageEmployee = true
            );
        }

        [TestMethod]
        public void Mutation_ResetPassword()
        {
            Database.WriteAsync(realm =>
            {
                realm.Add(new Employee
                {
                    Id = "abc",
                    Address = "Địa chỉ",
                    IsActive = true,
                    Birthdate = DateTimeOffset.Now,
                    Email = "email@gmail.com",
                    Gender = true,
                    Name = "Quản trị viên",
                    IdentityCard = "123456789",
                    Password = CryptoHelper.Encrypt("12345678"),
                    PhoneNumber = "+84 0123456789",
                    Position = PositionBusiness.Get(1),
                    StartingDate = DateTimeOffset.Now
                });
            }).Wait();

            SchemaHelper.Execute(
                @"/_GraphQL/Employee/mutation.resetPassword.gql",
                @"/_GraphQL/Employee/mutation.resetPassword.schema.json",
                new { id = "abc" },
                p => p.PermissionManageEmployee = true
            );
        }

        [TestMethod]
        public void Mutation_ResetPassword_InvalidEmployee()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Nhân viên không thể tự reset mật khẩu của chính mình",
                @"/_GraphQL/Employee/mutation.resetPassword.gql",
                new { id = "admin" },
                p => p.PermissionManageEmployee = true
            );
        }

        [TestMethod]
        public void Mutation_ResetPassword_InvalidEmployeeId()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Không tìm thấy tên đăng nhập trong hệ thống",
                @"/_GraphQL/Employee/mutation.resetPassword.gql",
                new { id = "xyz" },
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
                }, p => p.PermissionManageEmployee = true
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
