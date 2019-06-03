using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.hotel.DataAccesses;
using uit.hotel.Models;
using uit.hotel.test.Helper;

namespace uit.hotel.test._GraphQL
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
                new
                {
                    input = new
                    {
                        name = "Tên loại khách hàng 1",
                        description = "Mô tả"
                    }
                },
                p => p.PermissionManagePatronKind = true
            );
        }

        [TestMethod]
        public void Mutation_DeletePatronKind()
        {
            Database.WriteAsync(realm => realm.Add(new PatronKind
            {
                Id = 10,
                Name = "Tên loại khách hàng 10",
                Description = "Mô tả loại khách hàng"
            })).Wait();
            SchemaHelper.Execute(
                @"/_GraphQL/PatronKind/mutation.deletePatronKind.gql",
                @"/_GraphQL/PatronKind/mutation.deletePatronKind.schema.json",
                new { id = 10 },
                p => p.PermissionManagePatronKind = true
            );
        }

        [TestMethod]
        public void Mutation_DeletePatronKind_ValidId()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Loại khách hàng có ID: 100 không tồn tại",
                @"/_GraphQL/PatronKind/mutation.deletePatronKind.gql",
                new { id = 100 },
                p => p.PermissionManagePatronKind = true
            );
        }

        [TestMethod]
        public void Mutation_DeletePatronKind_ValidHasPatron()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Loại khách hàng đang được sử dụng. Không thể cập xóa",
                @"/_GraphQL/PatronKind/mutation.deletePatronKind.gql",
                new { id = 1 },
                p => p.PermissionManagePatronKind = true
            );
        }

        [TestMethod]
        public void Mutation_UpdatePatronKind()
        {
            Database.WriteAsync(realm => realm.Add(new PatronKind
            {
                Id = 20,
                Name = "Tên loại khách hàng 20",
                Description = "Mô tả loại khách hàng"
            })).Wait();
            SchemaHelper.Execute(
                @"/_GraphQL/PatronKind/mutation.updatePatronKind.gql",
                @"/_GraphQL/PatronKind/mutation.updatePatronKind.schema.json",
                new
                {
                    input = new
                    {
                        id = 20,
                        name = "Loại khách 20",
                        description = "Loại khách 20"
                    }
                },
                p => p.PermissionManagePatronKind = true
            );
        }

        [TestMethod]
        public void Mutation_UpdatePatronKind_InvalidId()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Loại khách hàng có ID: 100 không tồn tại",
                @"/_GraphQL/PatronKind/mutation.updatePatronKind.gql",
                new
                {
                    input = new
                    {
                        id = 100,
                        name = "Loại khách 2",
                        description = "Loại khách 2"
                    }
                },
                p => p.PermissionManagePatronKind = true
            );
        }

        [TestMethod]
        public void Query_PatronKind()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/PatronKind/query.patronKind.gql",
                @"/_GraphQL/PatronKind/query.patronKind.schema.json",
                new { id = 1 },
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
