using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.ooad.test.Helper;

namespace uit.ooad.test._GraphQL._Patron
{
    [TestClass]
    public class _PatronKind
    {
        [TestMethod]
        public void PatronKinds()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/PatronKind/query.patronKinds.gql",
                @"/_GraphQL/PatronKind/query.patronKinds.schema.json"
            );
        }

        [TestMethod]
        public void PatronKind()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/PatronKind/query.patronKind.gql",
                @"/_GraphQL/PatronKind/query.patronKind.schema.json",
                @"/_GraphQL/PatronKind/query.patronKind.variable.json"
            );
        }

        [TestMethod]
        public void CreatePatronKind()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/PatronKind/mutation.createPatronKind.gql",
                @"/_GraphQL/PatronKind/mutation.createPatronKind.schema.json",
                @"/_GraphQL/PatronKind/mutation.createPatronKind.variable.json",
                p => p.PermissionManagePatronKind = true
            );
        }
    }
}
