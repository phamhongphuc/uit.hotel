using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.hotel.Businesses;
using uit.hotel.DataAccesses;
using uit.hotel.Models;
using uit.hotel.test.Helper;

namespace uit.hotel.test._GraphQL
{
    [TestClass]
    public class _VolatilityPrice : RealmDatabase
    {
        [TestMethod]
        public void Mutation_CreateVolatilityPrice()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/VolatilityPrice/mutation.createVolatilityPrice.gql",
                @"/_GraphQL/VolatilityPrice/mutation.createVolatilityPrice.schema.json",
                new
                {
                    input = new
                    {
                        hourPrice = 1,
                        dayPrice = 1,
                        nightPrice = 1,
                        weekPrice = 1,
                        monthPrice = 1,
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
        public void Mutation_CreateVolatilityPrice_InvalidRoomKind()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Mã loại phòng không tồn tại",
                @"/_GraphQL/VolatilityPrice/mutation.createVolatilityPrice.gql",
                new
                {
                    input = new
                    {
                        hourPrice = 1,
                        dayPrice = 1,
                        nightPrice = 1,
                        weekPrice = 1,
                        monthPrice = 1,
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
        public void Mutation_CreateVolatilityPrice_InvalidRoomKind_InActive()
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
                @"/_GraphQL/VolatilityPrice/mutation.createVolatilityPrice.gql",
                new
                {
                    input = new
                    {
                        hourPrice = 1,
                        dayPrice = 1,
                        nightPrice = 1,
                        weekPrice = 1,
                        monthPrice = 1,
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
            Database.WriteAsync(realm => realm.Add(new VolatilityPrice
            {
                Id = 10
            })).Wait();
            SchemaHelper.Execute(
                @"/_GraphQL/VolatilityPrice/mutation.deleteVolatilityPrice.gql",
                @"/_GraphQL/VolatilityPrice/mutation.deleteVolatilityPrice.schema.json",
                new { id = 10 },
                p => p.PermissionManagePrice = true
            );
        }

        [TestMethod]
        public void Mutation_DeletelatilityPrice_InvalidId()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Giá có Id: 100 không hợp lệ!",
                @"/_GraphQL/VolatilityPrice/mutation.deleteVolatilityPrice.gql",
                new { id = 100 },
                p => p.PermissionManagePrice = true
            );
        }

        [TestMethod]
        public void Mutation_UpdateVolatilityPrice()
        {
            Database.WriteAsync(realm => realm.Add(new VolatilityPrice
            {
                Id = 20,
                RoomKind = RoomKindBusiness.Get(1),
                Employee = EmployeeBusiness.Get("admin")
            })).Wait();
            SchemaHelper.ExecuteAndExpectError(
                "Mã loại phòng không tồn tại",
                @"/_GraphQL/VolatilityPrice/mutation.updateVolatilityPrice.gql",
                new
                {
                    input = new
                    {
                        id = 20,
                        hourPrice = 1,
                        dayPrice = 1,
                        nightPrice = 1,
                        weekPrice = 1,
                        monthPrice = 1,
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
        public void Mutation_UpdateVolatilityPrice_InvalidId()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Giá có Id: 100 không hợp lệ!",
                @"/_GraphQL/VolatilityPrice/mutation.updateVolatilityPrice.gql",
                new
                {
                    input = new
                    {
                        id = 100,
                        hourPrice = 1,
                        dayPrice = 1,
                        nightPrice = 1,
                        weekPrice = 1,
                        monthPrice = 1,
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
        public void Mutation_UpdateVolatilityPrice_InvalidRoomKind()
        {
            Database.WriteAsync(realm => realm.Add(new VolatilityPrice
            {
                Id = 21,
                RoomKind = RoomKindBusiness.Get(1),
                Employee = EmployeeBusiness.Get("admin")
            })).Wait();
            SchemaHelper.Execute(
                @"/_GraphQL/VolatilityPrice/mutation.updateVolatilityPrice.gql",
                @"/_GraphQL/VolatilityPrice/mutation.updateVolatilityPrice.schema.json",
                new
                {
                    input = new
                    {
                        id = 21,
                        hourPrice = 1,
                        dayPrice = 1,
                        nightPrice = 1,
                        weekPrice = 1,
                        monthPrice = 1,
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
        public void Mutation_UpdateVolatilityPrice_InvalidRoomKind_InActive()
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
                realm.Add(new VolatilityPrice
                {
                    Id = 22,
                    RoomKind = RoomKindBusiness.Get(1),
                    Employee = EmployeeBusiness.Get("admin")
                });
            }).Wait();

            SchemaHelper.ExecuteAndExpectError(
                "Loại phòng 201 đã ngưng hoại động",
                @"/_GraphQL/VolatilityPrice/mutation.updateVolatilityPrice.gql",
                new
                {
                    input = new
                    {
                        id = 22,
                        hourPrice = 1,
                        dayPrice = 1,
                        nightPrice = 1,
                        weekPrice = 1,
                        monthPrice = 1,
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
        public void Query_VolatilityPrice()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/VolatilityPrice/query.volatilityPrice.gql",
                @"/_GraphQL/VolatilityPrice/query.volatilityPrice.schema.json",
                new { id = 1 },
                p => p.PermissionGetPrice = true
            );
        }

        [TestMethod]
        public void Query_VolatilityPrices()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/VolatilityPrice/query.volatilityPrices.gql",
                @"/_GraphQL/VolatilityPrice/query.volatilityPrices.schema.json",
                null,
                p => p.PermissionGetPrice = true
            );
        }
    }
}
