using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.ooad.Businesses;
using uit.ooad.DataAccesses;
using uit.ooad.Models;
using uit.ooad.test.Helper;

namespace uit.ooad.test._GraphQL
{
    [TestClass]
    public class _Rate : RealmDatabase
    {
        [TestMethod]
        public void Mutation_CreateRate()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Rate/mutation.createRate.gql",
                @"/_GraphQL/Rate/mutation.createRate.schema.json",
                new
                {
                    input = new
                    {
                        dayRate = 1,
                        nightRate = 1,
                        weekRate = 1,
                        monthRate = 1,
                        lateCheckOutFee = 1,
                        earlyCheckInFee = 1,
                        effectiveStartDate = "0001-01-01T00:00:00+00:00",
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
        public void Mutation_CreateRate_InvalidRoomKind()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Mã loại phòng không tồn tại",
                @"/_GraphQL/Rate/mutation.createRate.gql",
                new
                {
                    input = new
                    {
                        dayRate = 1,
                        nightRate = 1,
                        weekRate = 1,
                        monthRate = 1,
                        lateCheckOutFee = 1,
                        earlyCheckInFee = 1,
                        effectiveStartDate = "0001-01-01T00:00:00+00:00",
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
        public void Mutation_CreateRate_InvalidRoomKind_InActive()
        {
            Database.WriteAsync(realm => realm.Add(new RoomKind
            {
                Id = 101,
                Name = "Tên loại phòng",
                AmountOfPeople = 1,
                NumberOfBeds = 1,
                IsActive = false
            })).Wait();

            SchemaHelper.ExecuteAndExpectError(
                "Loại phòng có ID: 101 đã ngưng hoại động",
                @"/_GraphQL/Rate/mutation.createRate.gql",
                new
                {
                    input = new
                    {
                        dayRate = 1,
                        nightRate = 1,
                        weekRate = 1,
                        monthRate = 1,
                        lateCheckOutFee = 1,
                        earlyCheckInFee = 1,
                        effectiveStartDate = "0001-01-01T00:00:00+00:00",
                        roomKind = new
                        {
                            id = 101
                        }
                    }
                },
                p => p.PermissionManageRate = true
            );
        }

        [TestMethod]
        public void Mutation_DeleteRate()
        {
            Database.WriteAsync(realm => realm.Add(new Rate
            {
                Id = 10,
                RoomKind = RoomKindBusiness.Get(1),
                Employee = EmployeeBusiness.Get("admin")
            })).Wait();
            SchemaHelper.Execute(
                @"/_GraphQL/Rate/mutation.deleteRate.gql",
                @"/_GraphQL/Rate/mutation.deleteRate.schema.json",
                new
                {
                    id = 10
                },
                p => p.PermissionManageRate = true
            );
        }

        [TestMethod]
        public void Mutation_DeleteRate_InvalidId()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Giá có Id: 100 không hợp lệ!",
                @"/_GraphQL/Rate/mutation.deleteRate.gql",
                new
                {
                    id = 100
                },
                p => p.PermissionManageRate = true
            );
        }

        [TestMethod]
        public void Mutation_UpdateRate()
        {
            Database.WriteAsync(realm => realm.Add(new Rate
            {
                Id = 20,
                RoomKind = RoomKindBusiness.Get(1),
                Employee = EmployeeBusiness.Get("admin")
            })).Wait();
            SchemaHelper.Execute(
                @"/_GraphQL/Rate/mutation.updateRate.gql",
                @"/_GraphQL/Rate/mutation.updateRate.schema.json",
                new
                {
                    input = new
                    {
                        id = 20,
                        dayRate = 5,
                        nightRate = 5,
                        weekRate = 5,
                        monthRate = 5,
                        lateCheckOutFee = 5,
                        earlyCheckInFee = 5,
                        effectiveStartDate = DateTimeOffset.MinValue,
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
        public void Mutation_UpdateRate_InvalidId()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Giá có Id: 100 không hợp lệ!",
                @"/_GraphQL/Rate/mutation.updateRate.gql",
                new
                {
                    input = new
                    {
                        id = 100,
                        dayRate = 5,
                        nightRate = 5,
                        weekRate = 5,
                        monthRate = 5,
                        lateCheckOutFee = 5,
                        earlyCheckInFee = 5,
                        effectiveStartDate = DateTimeOffset.MinValue,
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
        public void Mutation_UpdateRate_InvalidRoomKind()
        {
            Database.WriteAsync(realm => realm.Add(new Rate
            {
                Id = 21,
                RoomKind = RoomKindBusiness.Get(1),
                Employee = EmployeeBusiness.Get("admin")
            })).Wait();

            SchemaHelper.ExecuteAndExpectError(
                "Mã loại phòng không tồn tại",
                @"/_GraphQL/Rate/mutation.updateRate.gql",
                new
                {
                    input = new
                    {
                        id = 21,
                        dayRate = 5,
                        nightRate = 5,
                        weekRate = 5,
                        monthRate = 5,
                        lateCheckOutFee = 5,
                        earlyCheckInFee = 5,
                        effectiveStartDate = DateTimeOffset.MinValue,
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
        public void Mutation_UpdateRate_InvalidRoomKind_InActive()
        {
            Database.WriteAsync(realm =>
            {
                realm.Add(new Rate
                {
                    Id = 22,
                    RoomKind = RoomKindBusiness.Get(1),
                    Employee = EmployeeBusiness.Get("admin")
                });
                realm.Add(new RoomKind
                {
                    Id = 110,
                    Name = "Tên loại phòng",
                    AmountOfPeople = 1,
                    NumberOfBeds = 1,
                    IsActive = false
                });
            }).Wait();

            SchemaHelper.ExecuteAndExpectError(
                "Loại phòng 110 đã ngưng hoại động",
                @"/_GraphQL/Rate/mutation.updateRate.gql",
                new
                {
                    input = new
                    {
                        id = 22,
                        dayRate = 5,
                        nightRate = 5,
                        weekRate = 5,
                        monthRate = 5,
                        lateCheckOutFee = 5,
                        earlyCheckInFee = 5,
                        effectiveStartDate = DateTimeOffset.MinValue,
                        roomKind = new
                        {
                            id = 110
                        }
                    }
                },
                p => p.PermissionManageRate = true
            );
        }

        [TestMethod]
        public void Query_Rate()
        {
            Database.WriteAsync(realm => realm.Add(new Rate
            {
                Id = 30,
                RoomKind = RoomKindBusiness.Get(1),
                Employee = EmployeeBusiness.Get("admin")
            })).Wait();
            SchemaHelper.Execute(
                @"/_GraphQL/Rate/query.rate.gql",
                @"/_GraphQL/Rate/query.rate.schema.json",
                new { id = 30 },
                p => p.PermissionGetRate = true
            );
        }

        [TestMethod]
        public void Query_Rates()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Rate/query.rates.gql",
                @"/_GraphQL/Rate/query.rates.schema.json",
                null,
                p => p.PermissionGetRate = true
            );
        }
    }
}
