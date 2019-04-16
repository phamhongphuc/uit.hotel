using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.hotel.DataAccesses;
using uit.hotel.Models;
using uit.hotel.test.Helper;

namespace uit.hotel.test._GraphQL
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
                IsActive = true
            })).Wait();

            SchemaHelper.Execute(
                @"/_GraphQL/Position/mutation.deletePosition.gql",
                @"/_GraphQL/Position/mutation.deletePosition.schema.json",
                new { id = 10 },
                p => p.PermissionManagePosition = true
            );
        }

        [TestMethod]
        public void Mutation_DeletePosition_InvalidHasEmployee()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Không thể cập nhật/xóa. Chức vụ đang có nhân viên sử dụng",
                @"/_GraphQL/Position/mutation.deletePosition.gql",
                new { id = 1 },
                p => p.PermissionManagePosition = true
            );
        }

        [TestMethod]
        public void Mutation_DeletePosition_InvalidId()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Chức vụ có ID: 100 không tồn tại",
                @"/_GraphQL/Position/mutation.deletePosition.gql",
                new { id = 100 },
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
                IsActive = true
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
                IsActive = true
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
        public void Mutation_SetIsActivePositionAndMoveEmployee_InvalidId()
        {
            Database.WriteAsync(realm => realm.Add(new Position
            {
                Id = 31,
                Name = "Quản trị viên",
                IsActive = true
            })).Wait();

            SchemaHelper.ExecuteAndExpectError(
                "Chức vụ có ID: 100 không tồn tại",
                @"/_GraphQL/Position/mutation.setIsActivePositionAndMoveEmployee.gql",
                new
                {
                    id = 31,
                    newId = 100,
                    isActive = false
                },
                p => p.PermissionManagePosition = true
            );
        }

        [TestMethod]
        public void Mutation_SetIsActivePositionAndMoveEmployee_InvalidId_InActive()
        {
            Database.WriteAsync(realm => realm.Add(new Position
            {
                Id = 32,
                Name = "Quản trị viên",
                IsActive = false
            })).Wait();

            SchemaHelper.ExecuteAndExpectError(
                "Chức vụ có ID: 32 đã bị vô hiệu hóa",
                @"/_GraphQL/Position/mutation.setIsActivePositionAndMoveEmployee.gql",
                new
                {
                    id = 1,
                    newId = 32,
                    isActive = false
                },
                p => p.PermissionManagePosition = true
            );
        }

        [TestMethod]
        public void Mutation_SetIsActivePositionAndMoveEmployee_InvalidId_Overlap()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Chức vụ trùng nhau. Không thể chuyển",
                @"/_GraphQL/Position/mutation.setIsActivePositionAndMoveEmployee.gql",
                new
                {
                    id = 1,
                    newId = 1,
                    isActive = false
                },
                p => p.PermissionManagePosition = true
            );
        }

        [TestMethod]
        public void Mutation_SetIsActivePositionAndMoveEmployee_InvalidNewId()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Chức vụ có ID: 100 không tồn tại",
                @"/_GraphQL/Position/mutation.setIsActivePositionAndMoveEmployee.gql",
                new
                {
                    id = 100,
                    newId = 2,
                    isActive = false
                },
                p => p.PermissionManagePosition = true
            );
        }

        [TestMethod]
        public void Mutation_SetIsActivePositionAndMoveEmployee_InvalidPosition_IsActive()
        {
            Database.WriteAsync(realm => realm.Add(new Position
            {
                Id = 33,
                Name = "Quản trị viên",
                IsActive = true
            })).Wait();

            SchemaHelper.ExecuteAndExpectError(
                "Chức năng này chỉ được dùng để vô hiệu hóa chức vụ",
                @"/_GraphQL/Position/mutation.setIsActivePositionAndMoveEmployee.gql",
                new
                {
                    id = 33,
                    newId = 1,
                    isActive = true
                },
                p => p.PermissionManagePosition = true
            );
        }

        [TestMethod]
        public void Mutation_SetIsActivePosition_InvalidHasEmployeeActive()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Chức vụ này còn nhân viên đang hoạt động sử dụng",
                @"/_GraphQL/Position/mutation.setIsActivePosition.gql",
                new { id = 1, isActive = true },
                p => p.PermissionManagePosition = true
            );
        }

        [TestMethod]
        public void Mutation_SetIsActivePosition_InvalidId()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Chức vụ có ID: 100 không tồn tại",
                @"/_GraphQL/Position/mutation.setIsActivePosition.gql",
                new { id = 100, isActive = true },
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
                IsActive = true
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
        public void Mutation_UpdatePosition_InvalidEmployee()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Không thể cập nhật/xóa. Chức vụ đang có nhân viên sử dụng",
                @"/_GraphQL/Position/mutation.updatePosition.gql",
                new
                {
                    input = new
                    {
                        id = 1,
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
        public void Mutation_UpdatePosition_InvalidId()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Chức vụ có ID: 100 không tồn tại",
                @"/_GraphQL/Position/mutation.updatePosition.gql",
                new
                {
                    input = new
                    {
                        id = 100,
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
