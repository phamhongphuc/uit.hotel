using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.hotel.Businesses;
using uit.hotel.DataAccesses;
using uit.hotel.Models;
using uit.hotel.test.Helper;

namespace uit.hotel.test._GraphQL
{
    [TestClass]
    public class _PriceVolatility : RealmDatabase
    {
        [TestMethod]
        public void Mutation_CreatePriceVolatility()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/PriceVolatility/mutation.createPriceVolatility.gql",
                @"/_GraphQL/PriceVolatility/mutation.createPriceVolatility.schema.json",
                new
                {
                    input = new
                    {
                        name = "Giá biến động",
                        hourPrice = 1,
                        dayPrice = 1,
                        nightPrice = 1,
                        effectiveStartDate = "0001-01-01T00:00:00+00:00",
                        effectiveEndDate = "0001-01-01T00:00:00+00:00",
                        effectiveOnMonday = true,
                        effectiveOnTuesday = true,
                        effectiveOnWednesday = true,
                        effectiveOnThursday = true,
                        effectiveOnFriday = true,
                        effectiveOnSaturday = true,
                        effectiveOnSunday = true,
                        roomKind = new
                        {
                            id = 1
                        }
                    }
                },
                p => p.PermissionManagePrice = true
            );
        }

        [TestMethod]
        public void Mutation_CreatePriceVolatility_InvalidRoomKind()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Mã loại phòng không tồn tại",
                @"/_GraphQL/PriceVolatility/mutation.createPriceVolatility.gql",
                new
                {
                    input = new
                    {
                        name = "Giá biến động",
                        hourPrice = 1,
                        dayPrice = 1,
                        nightPrice = 1,
                        effectiveStartDate = "0001-01-01T00:00:00+00:00",
                        effectiveEndDate = "0001-01-01T00:00:00+00:00",
                        effectiveOnMonday = true,
                        effectiveOnTuesday = true,
                        effectiveOnWednesday = true,
                        effectiveOnThursday = true,
                        effectiveOnFriday = true,
                        effectiveOnSaturday = true,
                        effectiveOnSunday = true,
                        roomKind = new
                        {
                            id = 100
                        }
                    }
                },
                p => p.PermissionManagePrice = true
            );
        }

        [TestMethod]
        public void Mutation_CreatePriceVolatility_InvalidRoomKind_InActive()
        {
            Database.WriteAsync(realm => realm.Add(new RoomKind
            {
                Id = 200,
                Name = "Tên loại phòng",
                AmountOfPeople = 1,
                NumberOfBeds = 1,
                IsActive = false
            })).Wait();

            SchemaHelper.ExecuteAndExpectError(
                "Loại phòng 200 đã ngưng hoại động",
                @"/_GraphQL/PriceVolatility/mutation.createPriceVolatility.gql",
                new
                {
                    input = new
                    {
                        name = "Giá biến động",
                        hourPrice = 1,
                        dayPrice = 1,
                        nightPrice = 1,
                        effectiveStartDate = "0001-01-01T00:00:00+00:00",
                        effectiveEndDate = "0001-01-01T00:00:00+00:00",
                        effectiveOnMonday = true,
                        effectiveOnTuesday = true,
                        effectiveOnWednesday = true,
                        effectiveOnThursday = true,
                        effectiveOnFriday = true,
                        effectiveOnSaturday = true,
                        effectiveOnSunday = true,
                        roomKind = new
                        {
                            id = 200
                        }
                    }
                },
                p => p.PermissionManagePrice = true
            );
        }

        [TestMethod]
        public void Mutation_DeletelatilityPrice()
        {
            Database.WriteAsync(realm => realm.Add(new PriceVolatility
            {
                Id = 10,
                RoomKind = RoomKindBusiness.Get(1)
            })).Wait();
            SchemaHelper.Execute(
                @"/_GraphQL/PriceVolatility/mutation.deletePriceVolatility.gql",
                @"/_GraphQL/PriceVolatility/mutation.deletePriceVolatility.schema.json",
                new { id = 10 },
                p => p.PermissionManagePrice = true
            );
        }

        [TestMethod]
        public void Mutation_DeletelatilityPrice_InvalidId()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Giá có Id: 100 không hợp lệ!",
                @"/_GraphQL/PriceVolatility/mutation.deletePriceVolatility.gql",
                new { id = 100 },
                p => p.PermissionManagePrice = true
            );
        }

        [TestMethod]
        public void Mutation_UpdatePriceVolatility()
        {
            Database.WriteAsync(realm => realm.Add(new PriceVolatility
            {
                Id = 20,
                RoomKind = RoomKindBusiness.Get(1),
                Employee = EmployeeBusiness.Get("admin")
            })).Wait();
            SchemaHelper.ExecuteAndExpectError(
                "Mã loại phòng không tồn tại",
                @"/_GraphQL/PriceVolatility/mutation.updatePriceVolatility.gql",
                new
                {
                    input = new
                    {
                        id = 20,
                        hourPrice = 1,
                        dayPrice = 1,
                        nightPrice = 1,
                        effectiveStartDate = "0001-01-01T00:00:00+00:00",
                        effectiveEndDate = "0001-01-01T00:00:00+00:00",
                        effectiveOnMonday = true,
                        effectiveOnTuesday = true,
                        effectiveOnWednesday = true,
                        effectiveOnThursday = true,
                        effectiveOnFriday = true,
                        effectiveOnSaturday = true,
                        effectiveOnSunday = true,
                        roomKind = new
                        {
                            id = 100
                        }
                    }
                },
                p => p.PermissionManagePrice = true
            );
        }

        [TestMethod]
        public void Mutation_UpdatePriceVolatility_InvalidId()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Giá có Id: 100 không hợp lệ!",
                @"/_GraphQL/PriceVolatility/mutation.updatePriceVolatility.gql",
                new
                {
                    input = new
                    {
                        id = 100,
                        hourPrice = 1,
                        dayPrice = 1,
                        nightPrice = 1,
                        effectiveStartDate = "0001-01-01T00:00:00+00:00",
                        effectiveEndDate = "0001-01-01T00:00:00+00:00",
                        effectiveOnMonday = true,
                        effectiveOnTuesday = true,
                        effectiveOnWednesday = true,
                        effectiveOnThursday = true,
                        effectiveOnFriday = true,
                        effectiveOnSaturday = true,
                        effectiveOnSunday = true,
                        roomKind = new
                        {
                            id = 1
                        }
                    }
                },
                p => p.PermissionManagePrice = true
            );
        }

        [TestMethod]
        public void Mutation_UpdatePriceVolatility_InvalidRoomKind()
        {
            Database.WriteAsync(realm => realm.Add(new PriceVolatility
            {
                Id = 21,
                RoomKind = RoomKindBusiness.Get(1),
                Employee = EmployeeBusiness.Get("admin")
            })).Wait();
            SchemaHelper.Execute(
                @"/_GraphQL/PriceVolatility/mutation.updatePriceVolatility.gql",
                @"/_GraphQL/PriceVolatility/mutation.updatePriceVolatility.schema.json",
                new
                {
                    input = new
                    {
                        id = 21,
                        hourPrice = 1,
                        dayPrice = 1,
                        nightPrice = 1,
                        effectiveStartDate = "0001-01-01T00:00:00+00:00",
                        effectiveEndDate = "0001-01-01T00:00:00+00:00",
                        effectiveOnMonday = true,
                        effectiveOnTuesday = true,
                        effectiveOnWednesday = true,
                        effectiveOnThursday = true,
                        effectiveOnFriday = true,
                        effectiveOnSaturday = true,
                        effectiveOnSunday = true,
                        roomKind = new
                        {
                            id = 1
                        }
                    }
                },
                p => p.PermissionManagePrice = true
            );
        }

        [TestMethod]
        public void Mutation_UpdatePriceVolatility_InvalidRoomKind_InActive()
        {
            Database.WriteAsync(realm =>
            {
                realm.Add(new RoomKind
                {
                    Id = 201,
                    Name = "Tên loại phòng",
                    AmountOfPeople = 1,
                    NumberOfBeds = 1,
                    IsActive = false
                });
                realm.Add(new PriceVolatility
                {
                    Id = 22,
                    RoomKind = RoomKindBusiness.Get(1),
                    Employee = EmployeeBusiness.Get("admin")
                });
            }).Wait();

            SchemaHelper.ExecuteAndExpectError(
                "Loại phòng 201 đã ngưng hoại động",
                @"/_GraphQL/PriceVolatility/mutation.updatePriceVolatility.gql",
                new
                {
                    input = new
                    {
                        id = 22,
                        hourPrice = 1,
                        dayPrice = 1,
                        nightPrice = 1,
                        effectiveStartDate = "0001-01-01T00:00:00+00:00",
                        effectiveEndDate = "0001-01-01T00:00:00+00:00",
                        effectiveOnMonday = true,
                        effectiveOnTuesday = true,
                        effectiveOnWednesday = true,
                        effectiveOnThursday = true,
                        effectiveOnFriday = true,
                        effectiveOnSaturday = true,
                        effectiveOnSunday = true,
                        roomKind = new
                        {
                            id = 201
                        }
                    }
                },
                p => p.PermissionManagePrice = true
            );
        }

        [TestMethod]
        public void Query_PriceVolatility()
        {
            Database.WriteAsync(realm =>
            {
                realm.Add(new RoomKind
                {
                    Id = 301,
                    Name = "Tên loại phòng",
                    AmountOfPeople = 1,
                    NumberOfBeds = 1,
                    IsActive = false
                });
                realm.Add(new PriceVolatility
                {
                    Id = 23,
                    RoomKind = RoomKindBusiness.Get(1),
                    Employee = EmployeeBusiness.Get("admin")
                });
            }).Wait();

            SchemaHelper.Execute(
                @"/_GraphQL/PriceVolatility/query.priceVolatility.gql",
                @"/_GraphQL/PriceVolatility/query.priceVolatility.schema.json",
                new { id = 23 },
                p => p.PermissionGetPrice = true
            );
        }

        [TestMethod]
        public void Query_PriceVolatilities()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/PriceVolatility/query.priceVolatilities.gql",
                @"/_GraphQL/PriceVolatility/query.priceVolatilities.schema.json",
                null,
                p => p.PermissionGetPrice = true
            );
        }
    }
}
