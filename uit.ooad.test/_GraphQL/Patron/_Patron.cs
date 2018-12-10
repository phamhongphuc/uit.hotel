using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.test.Helper;

namespace uit.ooad.test._GraphQL._Patron
{
    [TestClass]
    public class _Patron
    {
        public _Patron()
        {
            PatronKindBusiness.Add(new PatronKind
            {
                Id = 1,
                Name = "Tên loại khách hàng",
                Description = "Mô tả loại khách hàng"
            });
            PatronBusiness.Add(new Patron
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
