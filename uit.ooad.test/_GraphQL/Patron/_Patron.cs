using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.ooad.Businesses;
using uit.ooad.DataAccesses;
using uit.ooad.Models;
using uit.ooad.test.Helper;

namespace uit.ooad.test._GraphQL
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
                        listOfPhoneNumbers = new[] { "1234", "123445" },
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
                ListOfPhoneNumbers = new List<string> { "12324234" }
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
                        listOfPhoneNumbers = new[] { "1234", "123445" },
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
