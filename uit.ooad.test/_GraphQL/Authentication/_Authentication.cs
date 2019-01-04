using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.ooad.test.Helper;
using uit.ooad.DataAccesses;
using uit.ooad.Models;
using System;
using uit.ooad.Queries.Authentication;
using uit.ooad.Businesses;

namespace uit.ooad.test._GraphQL
{
    [TestClass]
    public class _Authentication : RealmDatabase
    {
        [TestMethod]
        public void Mutation_ChangePassword()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Authentication/mutation.changePassword.gql",
                @"/_GraphQL/Authentication/mutation.changePassword.schema.json",
                @"/_GraphQL/Authentication/mutation.changePassword.variable.json"
            );
        }

        [TestMethod]
        public void Mutation_ChangePassword_InvalidPassword()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Mật khẩu không chính xác",
                @"/_GraphQL/Authentication/mutation.changePassword.gql",
                @"/_GraphQL/Authentication/mutation.changePassword.variable.invalid_password.json"
            );
        }

        [TestMethod]
        public void Mutation_CheckLogin()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Authentication/mutation.checkLogin.gql",
                @"/_GraphQL/Authentication/mutation.checkLogin.schema.json",
                null
            );
        }

        [TestMethod]
        public void Mutation_Login()
        {

            Database.WriteAsync(realm =>
            {
                var position = realm.Add(new Position
                {
                    Id = 2,
                    Name = "Quản trị viên",
                    IsActive = true,
                });

                realm.Add(new Employee
                {
                    Id = "user",
                    Address = "Địa chỉ",
                    IsActive = true,
                    Birthdate = DateTimeOffset.Now,
                    Email = "email@gmail.com",
                    Gender = true,
                    Name = "Quản trị viên",
                    IdentityCard = "123456789",
                    Password = CryptoHelper.Encrypt("123"),
                    PhoneNumber = "+84 0123456789",
                    Position = position,
                    StartingDate = DateTimeOffset.Now
                });
            }).Wait();

            SchemaHelper.Execute(
                @"/_GraphQL/Authentication/mutation.login.gql",
                @"/_GraphQL/Authentication/mutation.login.schema.json",
                @"/_GraphQL/Authentication/mutation.login.variable.json"
            );
        }

        [TestMethod]
        public void Mutation_Login_InvalidPassword()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Tài khoản hoặc mật khẩu không chính xác",
                @"/_GraphQL/Authentication/mutation.login.gql",
                @"/_GraphQL/Authentication/mutation.login.variable.invalid_password.json"
            );
        }
    }
}
