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
                @"/_GraphQL/Position/mutation.createPosition.variable.json",
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
                @"/_GraphQL/Position/mutation.deletePosition.variable.json",
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
                @"/_GraphQL/Position/mutation.setIsActivePosition.variable.json",
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
                @"/_GraphQL/Position/mutation.setIsActivePositionAndMoveEmployee.variable.json",
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
                @"/_GraphQL/Position/mutation.updatePosition.variable.json",
                p => p.PermissionManagePosition = true
            );
        }
        [TestMethod]
        public void Query_Position()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Position/query.position.gql",
                @"/_GraphQL/Position/query.position.schema.json",
                @"/_GraphQL/Position/query.position.variable.json",
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
