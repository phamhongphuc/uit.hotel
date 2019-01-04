using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.ooad.test.Helper;

namespace uit.ooad.test._GraphQL
{
    [TestClass]
    public class _Authentication
    {
        [TestMethod]
        public void Login()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Authentication/mutation.login.gql",
                @"/_GraphQL/Authentication/mutation.login.schema.json",
                @"/_GraphQL/Authentication/mutation.login.variable.json"
            );
        }

        [TestMethod]
        public void Login_InvalidPassword()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Tài khoản hoặc mật khẩu không chính xác",
                @"/_GraphQL/Authentication/mutation.login.gql",
                @"/_GraphQL/Authentication/mutation.login.variable.in_valid_password.json"
            );
        }

        [TestMethod]
        public void CheckLogin()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Authentication/mutation.checkLogin.gql",
                @"/_GraphQL/Authentication/mutation.checkLogin.schema.json",
                null
            );
        }

        [TestMethod]
        public void ChangePassword()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Authentication/mutation.changePassword.gql",
                @"/_GraphQL/Authentication/mutation.changePassword.schema.json",
                @"/_GraphQL/Authentication/mutation.changePassword.variable.json"
            );
        }

        [TestMethod]
        public void ChangePassword_InvalidPassword()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Mật khẩu không chính xác",
                @"/_GraphQL/Authentication/mutation.changePassword.gql",
                @"/_GraphQL/Authentication/mutation.changePassword.variable.in_valid_password.json"
            );
        }
    }
}
