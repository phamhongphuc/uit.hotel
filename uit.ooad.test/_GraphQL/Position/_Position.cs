using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.ooad.DataAccesses;
using uit.ooad.Models;
using uit.ooad.test.Helper;

namespace uit.ooad.test._GraphQL
{
    [TestClass]
    public class _Position : RealmDatabase
    {
        [TestMethod]
        public void Mutation_CreatePosition()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Position/mutation.createPosition.gql",
                @"/_GraphQL/Position/mutation.createPosition.schema.json",
                new
                {
                    input = new
                    {
                        name = "Tên quyền",
                        permissionCleaning = true,
                        permissionGetAccountingVoucher = true,
                        permissionGetHouseKeeping = true,
                        permissionGetMap = true,
                        permissionGetPatron = true,
                        permissionGetRate = true,
                        permissionGetService = true,
                        permissionManageEmployee = true,
                        permissionManageHiringRoom = true,
                        permissionManageMap = true,
                        permissionManagePatron = true,
                        permissionManagePatronKind = true,
                        permissionManagePosition = true,
                        permissionManageRate = true,
                        permissionManageService = true
                    }
                },
                p => p.PermissionManagePosition = true
            );
        }

        [TestMethod]
        public void Mutation_DeletePosition()
        {
            Database.WriteAsync(realm => realm.Add(new Position
            {
                Id = 10,
                Name = "Quản trị viên",
                IsActive = true,
            })).Wait();

            SchemaHelper.Execute(
                @"/_GraphQL/Position/mutation.deletePosition.gql",
                @"/_GraphQL/Position/mutation.deletePosition.schema.json",
                new { id = 10 },
                p => p.PermissionManagePosition = true
            );
        }
        [TestMethod]
        public void Mutation_SetIsActivePosition()
        {
            Database.WriteAsync(realm => realm.Add(new Position
            {
                Id = 20,
                Name = "Quản trị viên",
                IsActive = true,
            })).Wait();

            SchemaHelper.Execute(
                @"/_GraphQL/Position/mutation.setIsActivePosition.gql",
                @"/_GraphQL/Position/mutation.setIsActivePosition.schema.json",
                new { id = 20, isActive = true },
                p => p.PermissionManagePosition = true
            );
        }

        [TestMethod]
        public void Mutation_SetIsActivePositionAndMoveEmployee()
        {
            Database.WriteAsync(realm => realm.Add(new Position
            {
                Id = 30,
                Name = "Quản trị viên",
                IsActive = true,
            })).Wait();

            SchemaHelper.Execute(
                @"/_GraphQL/Position/mutation.setIsActivePositionAndMoveEmployee.gql",
                @"/_GraphQL/Position/mutation.setIsActivePositionAndMoveEmployee.schema.json",
                new
                {
                    id = 30,
                    newId = 2,
                    isActive = false
                },
                p => p.PermissionManagePosition = true
            );
        }

        [TestMethod]
        public void Mutation_UpdatePosition()
        {
            Database.WriteAsync(realm => realm.Add(new Position
            {
                Id = 40,
                Name = "Quản trị viên",
                IsActive = true,
            })).Wait();

            SchemaHelper.Execute(
                @"/_GraphQL/Position/mutation.updatePosition.gql",
                @"/_GraphQL/Position/mutation.updatePosition.schema.json",
                new
                {
                    input = new
                    {
                        id = 40,
                        name = "Tên quyền",
                        permissionCleaning = true,
                        permissionGetAccountingVoucher = true,
                        permissionGetHouseKeeping = true,
                        permissionGetMap = true,
                        permissionGetPatron = true,
                        permissionGetRate = true,
                        permissionGetService = true,
                        permissionManageEmployee = true,
                        permissionManageHiringRoom = false,
                        permissionManageMap = true,
                        permissionManagePatron = true,
                        permissionManagePatronKind = true,
                        permissionManagePosition = true,
                        permissionManageRate = true,
                        permissionManageService = true
                    }
                },
                p => p.PermissionManagePosition = true
            );
        }
        [TestMethod]
        public void Query_Position()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Position/query.position.gql",
                @"/_GraphQL/Position/query.position.schema.json",
                new { id = 1 },
                p => p.PermissionManagePosition = true
            );
        }

        [TestMethod]
        public void Query_Positions()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Position/query.positions.gql",
                @"/_GraphQL/Position/query.positions.schema.json",
                null,
                p => p.PermissionManagePosition = true
            );
        }
    }
}
