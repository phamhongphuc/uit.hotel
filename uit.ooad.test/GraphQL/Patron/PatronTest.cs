using System;
using System.IO;
using GraphQL;
using GraphQL.Types;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using uit.ooad.Businesses;
using uit.ooad.GraphQLHelper;
using uit.ooad.Queries.Authentication;
using uit.ooad.Schemas;
using uit.ooad.test.Helper;

namespace uit.ooad.test.GraphQL.Patron
{
    [TestClass]
    public class PatronTest
    {
        public PatronTest()
        {
            PatronKindBusiness.Add(new Models.PatronKind()
            {
                Id = 1,
                Name = "Tên loại khách hàng",
                Description = "Mô tả loại khách hàng"
            });
            PatronBusiness.Add(new Models.Patron()
            {
                Identification = "Id khách hàng",
                Name = "Tên khách hàng",
                Email = "Email khách hàng",
                Gender = true,
                Birthdate = DateTime.Now,
                PhoneNumber = 0123456,
                Nationality = "Quốc tịch",
                Domicile = "Nguyên quán",
                Residence = "Thường trú",
                Company = "Công ty",
                Note = "Ghi chú",
                PatronKind = PatronKindBusiness.Get(1)
            });
        }
        [TestMethod]
        public void Patrons()
        {
            SchemaHelper.Execute(
                @"/GraphQL/Patron/query.patrons.gql",
                @"/GraphQL/Patron/query.patrons.schema.json"
            );
        }
    }
}
