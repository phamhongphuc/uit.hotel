using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.ooad.DataAccesses;
using uit.ooad.Models;
using uit.ooad.test.Helper;

namespace uit.ooad.test._GraphQL
{
    [TestClass]
    public class _PatronKind : RealmDatabase
    {
        [TestMethod]
        public void Mutation_CreatePatronKind()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/PatronKind/mutation.createPatronKind.gql",
                @"/_GraphQL/PatronKind/mutation.createPatronKind.schema.json",
                @"/_GraphQL/PatronKind/mutation.createPatronKind.variable.json",
                p => p.PermissionManagePatronKind = true
            );
        }
        [TestMethod]
        public void Mutation_DeletePatronKind()
        {
            Database.WriteAsync(realm => realm.Add(new PatronKind
            {
                Id = 10,
                Name = "Tên loại khách hàng",
                Description = "Mô tả loại khách hàng"
            }));
            SchemaHelper.Execute(
                @"/_GraphQL/PatronKind/mutation.deletePatronKind.gql",
                @"/_GraphQL/PatronKind/mutation.deletePatronKind.schema.json",
                @"/_GraphQL/PatronKind/mutation.deletePatronKind.variable.json",
                p => p.PermissionManagePatronKind = true
            );
        }

        [TestMethod]
        public void Mutation_UpdatePatronKind()
        {
            Database.WriteAsync(realm => realm.Add(new PatronKind
            {
                Id = 20,
                Name = "Tên loại khách hàng",
                Description = "Mô tả loại khách hàng"
            }));
            SchemaHelper.Execute(
                @"/_GraphQL/PatronKind/mutation.updatePatronKind.gql",
                @"/_GraphQL/PatronKind/mutation.updatePatronKind.schema.json",
                @"/_GraphQL/PatronKind/mutation.updatePatronKind.variable.json",
                p => p.PermissionManagePatronKind = true
            );
        }

        [TestMethod]
        public void Query_PatronKind()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/PatronKind/query.patronKind.gql",
                @"/_GraphQL/PatronKind/query.patronKind.schema.json",
                @"/_GraphQL/PatronKind/query.patronKind.variable.json",
                p => p.PermissionGetPatron = true
            );
        }

        [TestMethod]
        public void Query_PatronKinds()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/PatronKind/query.patronKinds.gql",
                @"/_GraphQL/PatronKind/query.patronKinds.schema.json",
                null,
                p => p.PermissionGetPatron = true
            );
        }
    }
}
