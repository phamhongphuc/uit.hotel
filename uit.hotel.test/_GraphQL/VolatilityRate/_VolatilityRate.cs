using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.hotel.Businesses;
using uit.hotel.DataAccesses;
using uit.hotel.Models;
using uit.hotel.test.Helper;

namespace uit.hotel.test._GraphQL
{
    [TestClass]
    public class _VolatilityRate : RealmDatabase
    {
        [TestMethod]
        public void Mutation_CreateVolatilityRate()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/VolatilityRate/mutation.createVolatilityRate.gql",
                @"/_GraphQL/VolatilityRate/mutation.createVolatilityRate.schema.json",
                new
                {
                    input = new
                    {
                        hourRate = 1,
                        dayRate = 1,
                        nightRate = 1,
                        weekRate = 1,
                        monthRate = 1,
                        lateCheckOutFee = 1,
                        earlyCheckInFee = 1,
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
                p => p.PermissionManageRate = true
            );
        }

        [TestMethod]
        public void Mutation_CreateVolatilityRate_InvalidRoomKind()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Mã loại phòng không tồn tại",
                @"/_GraphQL/VolatilityRate/mutation.createVolatilityRate.gql",
                new
                {
                    input = new
                    {
                        hourRate = 1,
                        dayRate = 1,
                        nightRate = 1,
                        weekRate = 1,
                        monthRate = 1,
                        lateCheckOutFee = 1,
                        earlyCheckInFee = 1,
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
                p => p.PermissionManageRate = true
            );
        }

        [TestMethod]
        public void Mutation_CreateVolatilityRate_InvalidRoomKind_InActive()
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
                @"/_GraphQL/VolatilityRate/mutation.createVolatilityRate.gql",
                new
                {
                    input = new
                    {
                        hourRate = 1,
                        dayRate = 1,
                        nightRate = 1,
                        weekRate = 1,
                        monthRate = 1,
                        lateCheckOutFee = 1,
                        earlyCheckInFee = 1,
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
                p => p.PermissionManageRate = true
            );
        }

        [TestMethod]
        public void Mutation_DeletelatilityRate()
        {
            Database.WriteAsync(realm => realm.Add(new VolatilityRate
            {
                Id = 10
            })).Wait();
            SchemaHelper.Execute(
                @"/_GraphQL/VolatilityRate/mutation.deleteVolatilityRate.gql",
                @"/_GraphQL/VolatilityRate/mutation.deleteVolatilityRate.schema.json",
                new { id = 10 },
                p => p.PermissionManageRate = true
            );
        }

        [TestMethod]
        public void Mutation_DeletelatilityRate_InvalidId()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Giá có Id: 100 không hợp lệ!",
                @"/_GraphQL/VolatilityRate/mutation.deleteVolatilityRate.gql",
                new { id = 100 },
                p => p.PermissionManageRate = true
            );
        }

        [TestMethod]
        public void Mutation_UpdateVolatilityRate()
        {
            Database.WriteAsync(realm => realm.Add(new VolatilityRate
            {
                Id = 20,
                RoomKind = RoomKindBusiness.Get(1),
                Employee = EmployeeBusiness.Get("admin")
            })).Wait();
            SchemaHelper.ExecuteAndExpectError(
                "Mã loại phòng không tồn tại",
                @"/_GraphQL/VolatilityRate/mutation.updateVolatilityRate.gql",
                new
                {
                    input = new
                    {
                        id = 20,
                        hourRate = 1,
                        dayRate = 1,
                        nightRate = 1,
                        weekRate = 1,
                        monthRate = 1,
                        lateCheckOutFee = 1,
                        earlyCheckInFee = 1,
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
                p => p.PermissionManageRate = true
            );
        }

        [TestMethod]
        public void Mutation_UpdateVolatilityRate_InvalidId()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Giá có Id: 100 không hợp lệ!",
                @"/_GraphQL/VolatilityRate/mutation.updateVolatilityRate.gql",
                new
                {
                    input = new
                    {
                        id = 100,
                        hourRate = 1,
                        dayRate = 1,
                        nightRate = 1,
                        weekRate = 1,
                        monthRate = 1,
                        lateCheckOutFee = 1,
                        earlyCheckInFee = 1,
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
                p => p.PermissionManageRate = true
            );
        }

        [TestMethod]
        public void Mutation_UpdateVolatilityRate_InvalidRoomKind()
        {
            Database.WriteAsync(realm => realm.Add(new VolatilityRate
            {
                Id = 21,
                RoomKind = RoomKindBusiness.Get(1),
                Employee = EmployeeBusiness.Get("admin")
            })).Wait();
            SchemaHelper.Execute(
                @"/_GraphQL/VolatilityRate/mutation.updateVolatilityRate.gql",
                @"/_GraphQL/VolatilityRate/mutation.updateVolatilityRate.schema.json",
                new
                {
                    input = new
                    {
                        id = 21,
                        hourRate = 1,
                        dayRate = 1,
                        nightRate = 1,
                        weekRate = 1,
                        monthRate = 1,
                        lateCheckOutFee = 1,
                        earlyCheckInFee = 1,
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
                p => p.PermissionManageRate = true
            );
        }

        [TestMethod]
        public void Mutation_UpdateVolatilityRate_InvalidRoomKind_InActive()
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
                realm.Add(new VolatilityRate
                {
                    Id = 22,
                    RoomKind = RoomKindBusiness.Get(1),
                    Employee = EmployeeBusiness.Get("admin")
                });
            }).Wait();

            SchemaHelper.ExecuteAndExpectError(
                "Loại phòng 201 đã ngưng hoại động",
                @"/_GraphQL/VolatilityRate/mutation.updateVolatilityRate.gql",
                new
                {
                    input = new
                    {
                        id = 22,
                        hourRate = 1,
                        dayRate = 1,
                        nightRate = 1,
                        weekRate = 1,
                        monthRate = 1,
                        lateCheckOutFee = 1,
                        earlyCheckInFee = 1,
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
                p => p.PermissionManageRate = true
            );
        }


        [TestMethod]
        public void Query_VolatilityRate()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/VolatilityRate/query.volatilityRate.gql",
                @"/_GraphQL/VolatilityRate/query.volatilityRate.schema.json",
                new { id = 1 },
                p => p.PermissionGetRate = true
            );
        }

        [TestMethod]
        public void Query_VolatilityRates()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/VolatilityRate/query.volatilityRates.gql",
                @"/_GraphQL/VolatilityRate/query.volatilityRates.schema.json",
                null,
                p => p.PermissionGetRate = true
            );
        }
    }
}
