using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.ooad.test.Helper;

namespace uit.ooad.test._GraphQL._Authentication
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
        public void Login_InValidPassword()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Tài khoản hoặc mật khẩu không chính xác",
                @"/_GraphQL/Authentication/mutation.login.gql",
                @"/_GraphQL/Authentication/mutation.login.variable.fail.json"
            );
        }

        [TestMethod]
        public void ChangePassword()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Authentication/mutation.changePassword.gql",
                @"/_GraphQL/Authentication/mutation.changePassword.schema.json",
                @"/_GraphQL/Authentication/mutation.changePassword.variable.json",
                p => p.PermissionManageAccount = true
            );
        }
    }
}
