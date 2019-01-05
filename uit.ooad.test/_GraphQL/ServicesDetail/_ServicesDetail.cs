using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.ooad.Businesses;
using uit.ooad.DataAccesses;
using uit.ooad.Models;
using uit.ooad.test.Helper;

namespace uit.ooad.test._GraphQL
{
    [TestClass]
    public class _ServicesDetail : RealmDatabase
    {
        [TestMethod]
        public void Mutation_CreateServicesDetail()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/ServicesDetail/mutation.createServicesDetail.gql",
                @"/_GraphQL/ServicesDetail/mutation.createServicesDetail.schema.json",
                new
                {
                    input = new
                    {
                        number = 1,
                        service = new
                        {
                            id = 1
                        },
                        booking = new
                        {
                            id = 1
                        }
                    }
                },
                p => p.PermissionManageHiringRoom = true
            );
        }

        [TestMethod]
        public void Mutation_DeleteServicesDetail()
        {
            Database.WriteAsync(realm => realm.Add(new ServicesDetail
            {
                Id = 10,
                Booking = BookingBusiness.Get(1)
            })).Wait();
            SchemaHelper.Execute(
                @"/_GraphQL/ServicesDetail/mutation.deleteServicesDetail.gql",
                @"/_GraphQL/ServicesDetail/mutation.deleteServicesDetail.schema.json",
                new { id = 10 },
                p => p.PermissionCleaning = true
            );
        }

        [TestMethod]
        public void Mutation_UpdateServicesDetail()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/ServicesDetail/mutation.updateServicesDetail.gql",
                @"/_GraphQL/ServicesDetail/mutation.updateServicesDetail.schema.json",
                new
                {
                    input = new
                    {
                        id = 2,
                        number = 2,
                        service = new
                        {
                            id = 1
                        }
                    }
                },
                p => p.PermissionCleaning = true
            );
        }

        [TestMethod]
        public void Query_ServicesDetail()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/ServicesDetail/query.servicesDetail.gql",
                @"/_GraphQL/ServicesDetail/query.servicesDetail.schema.json",
                new { id = 1 },
                p => p.PermissionGetService = true
            );
        }

        [TestMethod]
        public void Query_ServicesDetails()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/ServicesDetail/query.servicesDetails.gql",
                @"/_GraphQL/ServicesDetail/query.servicesDetails.schema.json",
                null,
                p => p.PermissionGetService = true
            );
        }
    }
}
