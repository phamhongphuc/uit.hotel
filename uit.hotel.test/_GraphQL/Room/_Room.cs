using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.hotel.Businesses;
using uit.hotel.DataAccesses;
using uit.hotel.Models;
using uit.hotel.test.Helper;

namespace uit.hotel.test._GraphQL
{
    [TestClass]
    public class _Room : RealmDatabase
    {
        [TestMethod]
        public void Mutation_CreateRoom()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Room/mutation.createRoom.gql",
                @"/_GraphQL/Room/mutation.createRoom.schema.json",
                new
                {
                    input = new
                    {
                        name = "Phòng 2",
                        roomKind = new
                        {
                            id = 1
                        },
                        floor = new
                        {
                            id = 1
                        }
                    }
                },
                p => p.PermissionManageMap = true
            );
        }

        [TestMethod]
        public void Mutation_CreateRoom_InvalidFloor()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Tầng có Id: 100 không hợp lệ!",
                @"/_GraphQL/Room/mutation.createRoom.gql",
                new
                {
                    input = new
                    {
                        name = "Phòng 100",
                        roomKind = new
                        {
                            id = 1
                        },
                        floor = new
                        {
                            id = 100
                        }
                    }
                },
                p => p.PermissionManageMap = true
            );
        }

        [TestMethod]
        public void Mutation_CreateRoom_InvalidFloor_InActive()
        {
            Database.WriteAsync(realm => realm.Add(new Floor
            {
                Id = 101,
                Name = "Tầng tạo ra để xóa",
                IsActive = false
            })).Wait();

            SchemaHelper.ExecuteAndExpectError(
                "Tầng có ID: 101 đã ngưng hoại động",
                @"/_GraphQL/Room/mutation.createRoom.gql",
                new
                {
                    input = new
                    {
                        name = "Phòng 101",
                        roomKind = new
                        {
                            id = 1
                        },
                        floor = new
                        {
                            id = 101
                        }
                    }
                },
                p => p.PermissionManageMap = true
            );
        }

        [TestMethod]
        public void Mutation_CreateRoom_InvalidRoomKind()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Mã loại phòng không tồn tại",
                @"/_GraphQL/Room/mutation.createRoom.gql",
                new
                {
                    input = new
                    {
                        name = "Phòng không tồn tại",
                        roomKind = new
                        {
                            id = 100
                        },
                        floor = new
                        {
                            id = 1
                        }
                    }
                },
                p => p.PermissionManageMap = true
            );
        }

        [TestMethod]
        public void Mutation_CreateRoom_InvalidRoomKind_InActive()
        {
            Database.WriteAsync(realm => realm.Add(new RoomKind
            {
                Id = 103,
                Name = "Tên loại phòng",
                AmountOfPeople = 1,
                NumberOfBeds = 1,
                IsActive = false
            })).Wait();

            SchemaHelper.ExecuteAndExpectError(
                "Loại phòng có ID: 103 đã ngưng hoại động",
                @"/_GraphQL/Room/mutation.createRoom.gql",
                new
                {
                    input = new
                    {
                        name = "Phòng 103",
                        roomKind = new
                        {
                            id = 103
                        },
                        floor = new
                        {
                            id = 1
                        }
                    }
                },
                p => p.PermissionManageMap = true
            );
        }

        [TestMethod]
        public void Mutation_DeleteRoom()
        {
            Database.WriteAsync(realm => realm.Add(new Room
            {
                Id = 10,
                IsActive = true,
                Name = "Tên phòng",
                Floor = FloorBusiness.Get(1),
                RoomKind = RoomKindBusiness.Get(1)
            })).Wait();
            SchemaHelper.Execute(
                @"/_GraphQL/Room/mutation.deleteRoom.gql",
                @"/_GraphQL/Room/mutation.deleteRoom.schema.json",
                new { id = 10 },
                p => p.PermissionManageMap = true
            );
        }

        [TestMethod]
        public void Mutation_DeleteRoom_InvalidId()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Phòng có Id: 100 không tồn tại",
                @"/_GraphQL/Room/mutation.deleteRoom.gql",
                new { id = 100 },
                p => p.PermissionManageMap = true
            );
        }

        [TestMethod]
        public void Mutation_DeleteRoom_InvalidRoomHasBooking()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Phòng đã có giao dịch trước đó. Không thể cập nhật/xóa!",
                @"/_GraphQL/Room/mutation.deleteRoom.gql",
                new { id = 1 },
                p => p.PermissionManageMap = true
            );
        }

        [TestMethod]
        public void Mutation_DeleteRoom_InvalidRoom_InActive()
        {
            Database.WriteAsync(realm => realm.Add(new Room
            {
                Id = 11,
                IsActive = false,
                Name = "Tên phòng",
                Floor = FloorBusiness.Get(1),
                RoomKind = RoomKindBusiness.Get(1)
            })).Wait();

            SchemaHelper.ExecuteAndExpectError(
                "Phòng 11 đã ngưng hoại động. Không thể cập nhật/xóa!",
                @"/_GraphQL/Room/mutation.deleteRoom.gql",
                new { id = 11 },
                p => p.PermissionManageMap = true
            );
        }

        [TestMethod]
        public void Mutation_SetIsActiveRoom()
        {
            Database.WriteAsync(realm => realm.Add(new Room
            {
                Id = 20,
                IsActive = true,
                Name = "Tên phòng",
                Floor = FloorBusiness.Get(1),
                RoomKind = RoomKindBusiness.Get(1)
            })).Wait();
            SchemaHelper.Execute(
                @"/_GraphQL/Room/mutation.setIsActiveRoom.gql",
                @"/_GraphQL/Room/mutation.setIsActiveRoom.schema.json",
                new { id = 20, isActive = true },
                p => p.PermissionManageMap = true
            );
        }

        [TestMethod]
        public void Mutation_SetIsActiveRoom_InvalidFloor_InActive()
        {
            Database.WriteAsync(realm =>
            {
                realm.Add(new Floor
                {
                    Id = 110,
                    Name = "Tầng tạo ra để xóa",
                    IsActive = false
                });
                realm.Add(new Room
                {
                    Id = 21,
                    IsActive = true,
                    Name = "Tên phòng",
                    Floor = FloorBusiness.Get(110),
                    RoomKind = RoomKindBusiness.Get(1)
                });
            }).Wait();

            SchemaHelper.ExecuteAndExpectError(
                "Loại phòng thuộc tầng đã bị vô hiệu hóa. Không thể kích hoạt",
                @"/_GraphQL/Room/mutation.setIsActiveRoom.gql",
                new { id = 21, isActive = true },
                p => p.PermissionManageMap = true
            );
        }

        [TestMethod]
        public void Mutation_SetIsActiveRoom_InvalidId()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Id: 100 không tồn tại",
                @"/_GraphQL/Room/mutation.setIsActiveRoom.gql",
                new { id = 100, isActive = true },
                p => p.PermissionManageMap = true
            );
        }

        [TestMethod]
        public void Mutation_UpdateRoom()
        {
            Database.WriteAsync(realm => realm.Add(new Room
            {
                Id = 30,
                IsActive = true,
                Name = "Tên phòng",
                Floor = FloorBusiness.Get(1),
                RoomKind = RoomKindBusiness.Get(1)
            })).Wait();
            SchemaHelper.Execute(
                @"/_GraphQL/Room/mutation.updateRoom.gql",
                @"/_GraphQL/Room/mutation.updateRoom.schema.json",
                new
                {
                    input = new
                    {
                        id = 30,
                        name = "Phòng 30",
                        roomKind = new
                        {
                            id = 1
                        },
                        floor = new
                        {
                            id = 1
                        }
                    }
                },
                p => p.PermissionManageMap = true
            );
        }

        [TestMethod]
        public void Mutation_UpdateRoom_InvalidFloor()
        {
            Database.WriteAsync(realm => realm.Add(new Room
            {
                Id = 31,
                IsActive = false,
                Name = "Tên phòng",
                Floor = FloorBusiness.Get(1),
                RoomKind = RoomKindBusiness.Get(1)
            })).Wait();
            SchemaHelper.ExecuteAndExpectError(
                "Phòng 31 đã ngưng hoại động. Không thể cập nhật/xóa!",
                @"/_GraphQL/Room/mutation.updateRoom.gql",
                new
                {
                    input = new
                    {
                        id = 31,
                        name = "Phòng 31",
                        roomKind = new
                        {
                            id = 1
                        },
                        floor = new
                        {
                            id = 1
                        }
                    }
                },
                p => p.PermissionManageMap = true
            );
        }

        [TestMethod]
        public void Mutation_UpdateRoom_InvalidFloor_InActive()
        {
            Database.WriteAsync(realm =>
            {
                realm.Add(new Floor
                {
                    Id = 102,
                    Name = "Tầng tạo ra để kiểm tra inactive",
                    IsActive = false
                });
                realm.Add(new Room
                {
                    Id = 32,
                    IsActive = true,
                    Name = "Tên phòng",
                    Floor = FloorBusiness.Get(1),
                    RoomKind = RoomKindBusiness.Get(1)
                });
            }).Wait();
            SchemaHelper.ExecuteAndExpectError(
                "Tầng có ID: 102 đã ngưng hoại động",
                @"/_GraphQL/Room/mutation.updateRoom.gql",
                new
                {
                    input = new
                    {
                        id = 32,
                        name = "Phòng 32",
                        roomKind = new
                        {
                            id = 1
                        },
                        floor = new
                        {
                            id = 102
                        }
                    }
                },
                p => p.PermissionManageMap = true
            );
        }

        [TestMethod]
        public void Mutation_UpdateRoom_InvalidId()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Phòng có Id: 100 không tồn tại",
                @"/_GraphQL/Room/mutation.updateRoom.gql",
                new
                {
                    input = new
                    {
                        id = 100,
                        name = "Phòng không tồn tại 2",
                        roomKind = new
                        {
                            id = 1
                        },
                        floor = new
                        {
                            id = 1
                        }
                    }
                },
                p => p.PermissionManageMap = true
            );
        }

        [TestMethod]
        public void Mutation_UpdateRoom_InvalidRoomHasBooking()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Phòng đã có giao dịch trước đó. Không thể cập nhật/xóa!",
                @"/_GraphQL/Room/mutation.updateRoom.gql",
                new
                {
                    input = new
                    {
                        id = 1,
                        name = "Phòng không tồn tại 3",
                        roomKind = new
                        {
                            id = 1
                        },
                        floor = new
                        {
                            id = 1
                        }
                    }
                },
                p => p.PermissionManageMap = true
            );
        }

        [TestMethod]
        public void Mutation_UpdateRoom_InvalidRoomKind()
        {
            Database.WriteAsync(realm => realm.Add(new Room
            {
                Id = 33,
                IsActive = true,
                Name = "Tên phòng",
                Floor = FloorBusiness.Get(1),
                RoomKind = RoomKindBusiness.Get(1)
            })).Wait();

            SchemaHelper.ExecuteAndExpectError(
                "Mã loại phòng không tồn tại",
                @"/_GraphQL/Room/mutation.updateRoom.gql",
                new
                {
                    input = new
                    {
                        id = 33,
                        name = "Phòng 33",
                        roomKind = new
                        {
                            id = 100
                        },
                        floor = new
                        {
                            id = 1
                        }
                    }
                },
                p => p.PermissionManageMap = true
            );
        }

        [TestMethod]
        public void Mutation_UpdateRoom_InvalidRoomKind_InActive()
        {
            Database.WriteAsync(realm =>
            {
                realm.Add(new RoomKind
                {
                    Id = 102,
                    Name = "Tên loại phòng",
                    AmountOfPeople = 1,
                    NumberOfBeds = 1,
                    IsActive = false
                });
                realm.Add(new Room
                {
                    Id = 34,
                    IsActive = true,
                    Name = "Tên phòng",
                    Floor = FloorBusiness.Get(1),
                    RoomKind = RoomKindBusiness.Get(1)
                });
            }).Wait();

            SchemaHelper.ExecuteAndExpectError(
                "Loại phòng có ID: 102 đã ngưng hoại động",
                @"/_GraphQL/Room/mutation.updateRoom.gql",
                new
                {
                    input = new
                    {
                        id = 34,
                        name = "Phòng 34",
                        roomKind = new
                        {
                            id = 102
                        },
                        floor = new
                        {
                            id = 1
                        }
                    }
                },
                p => p.PermissionManageMap = true
            );
        }

        [TestMethod]
        public void Mutation_UpdateRoom_InvalidRoom_InActive()
        {
            Database.WriteAsync(realm => realm.Add(new Room
            {
                Id = 35,
                IsActive = false,
                Name = "Tên phòng",
                Floor = FloorBusiness.Get(1),
                RoomKind = RoomKindBusiness.Get(1)
            })).Wait();
            SchemaHelper.ExecuteAndExpectError(
                "Phòng 35 đã ngưng hoại động. Không thể cập nhật/xóa!",
                @"/_GraphQL/Room/mutation.updateRoom.gql",
                new
                {
                    input = new
                    {
                        id = 35,
                        name = "Phòng 35",
                        roomKind = new
                        {
                            id = 1
                        },
                        floor = new
                        {
                            id = 1
                        }
                    }
                },
                p => p.PermissionManageMap = true
            );
        }

        [TestMethod]
        public void Query_Room()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Room/query.room.gql",
                @"/_GraphQL/Room/query.room.schema.json",
                new { id = 1 },
                p => p.PermissionGetMap = true
            );
        }

        [TestMethod]
        public void Query_Rooms()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Room/query.rooms.gql",
                @"/_GraphQL/Room/query.rooms.schema.json",
                null,
                p => p.PermissionGetMap = true
            );
        }
    }
}
