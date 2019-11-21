using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.hotel.Businesses;
using uit.hotel.DataAccesses;
using uit.hotel.Models;
using uit.hotel.test.Helper;

namespace uit.hotel.test._GraphQL
{
    [TestClass]
    public class _Price : RealmDatabase
    {
        [TestMethod]
        public void Mutation_CreatePrice()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Price/mutation.createPrice.gql",
                @"/_GraphQL/Price/mutation.createPrice.schema.json",
                new
                {
                    input = new
                    {
                        hourPrice = 1,
                        dayPrice = 1,
                        nightPrice = 1,
                        weekPrice = 1,
                        monthPrice = 1,
                        lateCheckOutFee = 1,
                        earlyCheckInFee = 1,
                        effectiveStartDate = "0001-01-01T00:00:00+00:00",
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
        public void Mutation_CreatePrice_InvalidRoomKind()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Mã loại phòng không tồn tại",
                @"/_GraphQL/Price/mutation.createPrice.gql",
                new
                {
                    input = new
                    {
                        hourPrice = 1,
                        dayPrice = 1,
                        nightPrice = 1,
                        weekPrice = 1,
                        monthPrice = 1,
                        lateCheckOutFee = 1,
                        earlyCheckInFee = 1,
                        effectiveStartDate = "0001-01-01T00:00:00+00:00",
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
        public void Mutation_CreatePrice_InvalidRoomKind_InActive()
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
                @"/_GraphQL/Price/mutation.createPrice.gql",
                new
                {
                    input = new
                    {
                        hourPrice = 1,
                        dayPrice = 1,
                        nightPrice = 1,
                        weekPrice = 1,
                        monthPrice = 1,
                        lateCheckOutFee = 1,
                        earlyCheckInFee = 1,
                        effectiveStartDate = "0001-01-01T00:00:00+00:00",
                        roomKind = new
                        {
                            id = 101
                        }
                    }
                },
                p => p.PermissionManagePrice = true
            );
        }

        [TestMethod]
        public void Mutation_DeletePrice()
        {
            Database.WriteAsync(realm => realm.Add(new Price
            {
                Id = 10,
                RoomKind = RoomKindBusiness.Get(1),
                Employee = EmployeeBusiness.Get("admin")
            })).Wait();
            SchemaHelper.Execute(
                @"/_GraphQL/Price/mutation.deletePrice.gql",
                @"/_GraphQL/Price/mutation.deletePrice.schema.json",
                new
                {
                    id = 10
                },
                p => p.PermissionManagePrice = true
            );
        }

        [TestMethod]
        public void Mutation_DeletePrice_InvalidId()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Giá có Id: 100 không hợp lệ!",
                @"/_GraphQL/Price/mutation.deletePrice.gql",
                new
                {
                    id = 100
                },
                p => p.PermissionManagePrice = true
            );
        }

        [TestMethod]
        public void Mutation_UpdatePrice()
        {
            Database.WriteAsync(realm => realm.Add(new Price
            {
                Id = 20,
                RoomKind = RoomKindBusiness.Get(1),
                Employee = EmployeeBusiness.Get("admin")
            })).Wait();
            SchemaHelper.Execute(
                @"/_GraphQL/Price/mutation.updatePrice.gql",
                @"/_GraphQL/Price/mutation.updatePrice.schema.json",
                new
                {
                    input = new
                    {
                        id = 20,
                        hourPrice = 5,
                        dayPrice = 5,
                        nightPrice = 5,
                        weekPrice = 5,
                        monthPrice = 5,
                        lateCheckOutFee = 5,
                        earlyCheckInFee = 5,
                        effectiveStartDate = DateTimeOffset.MinValue,
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
        public void Mutation_UpdatePrice_InvalidId()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Giá có Id: 100 không hợp lệ!",
                @"/_GraphQL/Price/mutation.updatePrice.gql",
                new
                {
                    input = new
                    {
                        id = 100,
                        hourPrice = 5,
                        dayPrice = 5,
                        nightPrice = 5,
                        weekPrice = 5,
                        monthPrice = 5,
                        lateCheckOutFee = 5,
                        earlyCheckInFee = 5,
                        effectiveStartDate = DateTimeOffset.MinValue,
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
        public void Mutation_UpdatePrice_InvalidRoomKind()
        {
            Database.WriteAsync(realm => realm.Add(new Price
            {
                Id = 21,
                RoomKind = RoomKindBusiness.Get(1),
                Employee = EmployeeBusiness.Get("admin")
            })).Wait();

            SchemaHelper.ExecuteAndExpectError(
                "Mã loại phòng không tồn tại",
                @"/_GraphQL/Price/mutation.updatePrice.gql",
                new
                {
                    input = new
                    {
                        id = 21,
                        hourPrice = 1,
                        dayPrice = 5,
                        nightPrice = 5,
                        weekPrice = 5,
                        monthPrice = 5,
                        lateCheckOutFee = 5,
                        earlyCheckInFee = 5,
                        effectiveStartDate = DateTimeOffset.MinValue,
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
        public void Mutation_UpdatePrice_InvalidRoomKind_InActive()
        {
            Database.WriteAsync(realm =>
            {
                realm.Add(new Price
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
                @"/_GraphQL/Price/mutation.updatePrice.gql",
                new
                {
                    input = new
                    {
                        id = 22,
                        hourPrice = 5,
                        dayPrice = 5,
                        nightPrice = 5,
                        weekPrice = 5,
                        monthPrice = 5,
                        lateCheckOutFee = 5,
                        earlyCheckInFee = 5,
                        effectiveStartDate = DateTimeOffset.MinValue,
                        roomKind = new
                        {
                            id = 110
                        }
                    }
                },
                p => p.PermissionManagePrice = true
            );
        }

        [TestMethod]
        public void Query_Price()
        {
            Database.WriteAsync(realm => realm.Add(new Price
            {
                Id = 30,
                RoomKind = RoomKindBusiness.Get(1),
                Employee = EmployeeBusiness.Get("admin")
            })).Wait();
            SchemaHelper.Execute(
                @"/_GraphQL/Price/query.price.gql",
                @"/_GraphQL/Price/query.price.schema.json",
                new { id = 30 },
                p => p.PermissionGetPrice = true
            );
        }

        [TestMethod]
        public void Query_Prices()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Price/query.prices.gql",
                @"/_GraphQL/Price/query.prices.schema.json",
                null,
                p => p.PermissionGetPrice = true
            );
        }
    }
}
