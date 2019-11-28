using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.hotel.Businesses;
using uit.hotel.DataAccesses;
using uit.hotel.Models;
using uit.hotel.test.Helper;

namespace uit.hotel.test._GraphQL
{
    [TestClass]
    public class _Patron : RealmDatabase
    {
        [TestMethod]
        public void Mutation_CreatePatron()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Patron/mutation.createPatron.gql",
                @"/_GraphQL/Patron/mutation.createPatron.schema.json",
                new
                {
                    input = new
                    {
                        identification = "1234243",
                        name = "Tên khách hàng",
                        email = "email khách hàng",
                        gender = true,
                        birthdate = DateTimeOffset.FromUnixTimeSeconds(857293200),
                        residence = "Hộ khẩu",
                        domicile = "Nguyên quán",
                        phoneNumbers = "0123456789",
                        nationality = "Quốc tịch",
                        company = "BOSCH",
                        note = "Ghi chú",
                        patronKind = new
                        {
                            id = 1
                        }
                    }
                },
                p => p.PermissionManagePatron = true
            );
        }

        [TestMethod]
        public void Mutation_CreatePatron_InvalidIdentification()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Số Identification: 1234243 đã được đăng ký",
                @"/_GraphQL/Patron/mutation.createPatron.gql",
                new
                {
                    input = new
                    {
                        identification = "1234243",
                        name = "Tên khách hàng",
                        email = "email khách hàng",
                        gender = true,
                        birthdate = DateTimeOffset.FromUnixTimeSeconds(857293200),
                        residence = "Hộ khẩu",
                        domicile = "Nguyên quán",
                        phoneNumbers = "0123456789",
                        nationality = "Quốc tịch",
                        company = "BOSCH",
                        note = "Ghi chú",
                        patronKind = new
                        {
                            id = 1
                        }
                    }
                },
                p => p.PermissionManagePatron = true
            );
        }

        [TestMethod]
        public void Mutation_CreatePatron_InvalidPatronKind()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Mã loại khách hàng không tồn tại",
                @"/_GraphQL/Patron/mutation.createPatron.gql",
                new
                {
                    input = new
                    {
                        identification = "1234243543",
                        name = "Tên khách hàng",
                        email = "email khách hàng",
                        gender = true,
                        birthdate = DateTimeOffset.FromUnixTimeSeconds(857293200),
                        residence = "Hộ khẩu",
                        domicile = "Nguyên quán",
                        phoneNumbers = "0123456789",
                        nationality = "Quốc tịch",
                        company = "BOSCH",
                        note = "Ghi chú",
                        patronKind = new
                        {
                            id = 100
                        }
                    }
                },
                p => p.PermissionManagePatron = true
            );
        }

        [TestMethod]
        public void Mutation_UpdatePatron()
        {
            Database.WriteAsync(realm => realm.Add(new Patron
            {
                Id = 10,
                Identification = "123456789",
                Name = "Tên khách hàng",
                Email = "Email khách hàng",
                Gender = true,
                Birthdate = DateTimeOffset.Now,
                Nationality = "Quốc tịch",
                Domicile = "Nguyên quán",
                Residence = "Thường trú",
                Company = "Công ty",
                Note = "Ghi chú",
                PatronKind = PatronKindBusiness.Get(1),
                PhoneNumbers = "0123456789"
            })).Wait();

            SchemaHelper.Execute(
                @"/_GraphQL/Patron/mutation.updatePatron.gql",
                @"/_GraphQL/Patron/mutation.updatePatron.schema.json",
                new
                {
                    input = new
                    {
                        id = 10,
                        identification = "1234243",
                        name = "Tên khách hàng",
                        email = "email khách hàng",
                        gender = true,
                        birthdate = DateTimeOffset.FromUnixTimeSeconds(857293200),
                        residence = "Hộ khẩu",
                        domicile = "Nguyên quán",
                        phoneNumbers = "0123456789",
                        nationality = "Quốc tịch",
                        company = "BOSCH",
                        note = "Ghi chú",
                        patronKind = new
                        {
                            id = 1
                        }
                    }
                },
                p => p.PermissionManagePatron = true
            );
        }

        [TestMethod]
        public void Mutation_UpdatePatron_InvalidId()
        {
            SchemaHelper.ExecuteAndExpectError(
                "Không tồn tại khách hàng có Id: 100",
                @"/_GraphQL/Patron/mutation.updatePatron.gql",
                new
                {
                    input = new
                    {
                        id = 100,
                        identification = "1234243",
                        name = "Tên khách hàng",
                        email = "email khách hàng",
                        gender = true,
                        birthdate = DateTimeOffset.FromUnixTimeSeconds(857293200),
                        residence = "Hộ khẩu",
                        domicile = "Nguyên quán",
                        phoneNumbers = "0123456789",
                        nationality = "Quốc tịch",
                        company = "BOSCH",
                        note = "Ghi chú",
                        patronKind = new
                        {
                            id = 1
                        }
                    }
                },
                p => p.PermissionManagePatron = true
            );
        }

        [TestMethod]
        public void Mutation_UpdatePatron_InvalidPatronKind()
        {
            Database.WriteAsync(realm => realm.Add(new Patron
            {
                Id = 11,
                Identification = "123456789",
                Name = "Tên khách hàng",
                Email = "Email khách hàng",
                Gender = true,
                Birthdate = DateTimeOffset.Now,
                Nationality = "Quốc tịch",
                Domicile = "Nguyên quán",
                Residence = "Thường trú",
                Company = "Công ty",
                Note = "Ghi chú",
                PatronKind = PatronKindBusiness.Get(1),
                PhoneNumbers = "0123456789"
            })).Wait();

            SchemaHelper.ExecuteAndExpectError(
                "Mã loại khách hàng không tồn tại",
                @"/_GraphQL/Patron/mutation.updatePatron.gql",
                new
                {
                    input = new
                    {
                        id = 11,
                        identification = "1234243",
                        name = "Tên khách hàng",
                        email = "email khách hàng",
                        gender = true,
                        birthdate = DateTimeOffset.FromUnixTimeSeconds(857293200),
                        residence = "Hộ khẩu",
                        domicile = "Nguyên quán",
                        phoneNumbers = "0123456789",
                        nationality = "Quốc tịch",
                        company = "BOSCH",
                        note = "Ghi chú",
                        patronKind = new
                        {
                            id = 100
                        }
                    }
                },
                p => p.PermissionManagePatron = true
            );
        }

        [TestMethod]
        public void Query_Patron()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Patron/query.patron.gql",
                @"/_GraphQL/Patron/query.patron.schema.json",
                new { id = 1 },
                p => p.PermissionGetPatron = true
            );
        }

        [TestMethod]
        public void Query_Patrons()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Patron/query.patrons.gql",
                @"/_GraphQL/Patron/query.patrons.schema.json",
                null,
                p => p.PermissionGetPatron = true
            );
        }
    }
}
