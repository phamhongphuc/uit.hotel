using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.ooad.test.Helper;

namespace uit.ooad.test._GraphQL._Patron
{
    [TestClass]
    public class _Patron
    {
        [TestMethod]
        public void Patrons()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Patron/query.patrons.gql",
                @"/_GraphQL/Patron/query.patrons.schema.json",
                null,
                p => p.PermissionGetPatron = true
            );
        }

        [TestMethod]
        public void Patron()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Patron/query.patron.gql",
                @"/_GraphQL/Patron/query.patron.schema.json",
                @"/_GraphQL/Patron/query.patron.variable.json",
                p => p.PermissionGetPatron = true
            );
        }

        [TestMethod]
        public void CreatePatron()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Patron/mutation.createPatron.gql",
                @"/_GraphQL/Patron/mutation.createPatron.schema.json",
                @"/_GraphQL/Patron/mutation.createPatron.variable.json",
                p => p.PermissionManagePatron = true
            );
        }

        [TestMethod]
        public void UpdatePatron()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Patron/mutation.updatePatron.gql",
                @"/_GraphQL/Patron/mutation.updatePatron.schema.json",
                @"/_GraphQL/Patron/mutation.updatePatron.variable.json",
                p => p.PermissionManagePatron = true
            );
        }
    }
}
