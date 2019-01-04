using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using uit.ooad.Businesses;
using uit.ooad.DataAccesses;
using uit.ooad.Models;
using uit.ooad.test.Helper;

namespace uit.ooad.test._GraphQL
{
    [TestClass]
    public class _HouseKeeping : RealmDatabase
    {
        [TestMethod]
        public void Mutation_AssignCleaningService()
        {
            Database.WriteAsync(realm => realm.Add(new HouseKeeping
            {
                Id = 10,
                Status = (int)HouseKeeping.StatusEnum.Pending,
                Employee = EmployeeBusiness.Get("admin"),
                Booking = BookingBusiness.Get(1)
            })).Wait();
            SchemaHelper.Execute(
                @"/_GraphQL/HouseKeeping/mutation.assignCleaningService.gql",
                @"/_GraphQL/HouseKeeping/mutation.assignCleaningService.schema.json",
                new { id = 10 },
                p => p.PermissionCleaning = true
            );
        }

        [TestMethod]
        public void Mutation_ConfirmCleaned()
        {
            Database.WriteAsync(realm => realm.Add(new HouseKeeping
            {
                Id = 20,
                Status = (int)HouseKeeping.StatusEnum.Cleaning,
                Employee = EmployeeBusiness.Get("admin"),
                Booking = BookingBusiness.Get(1)
            })).Wait();
            SchemaHelper.Execute(
                @"/_GraphQL/HouseKeeping/mutation.confirmCleaned.gql",
                @"/_GraphQL/HouseKeeping/mutation.confirmCleaned.schema.json",
                new { id = 20 },
                p => p.PermissionCleaning = true
            );
        }

        [TestMethod]
        public void Mutation_ConfirmCleanedAndServices()
        {
            Database.WriteAsync(realm => realm.Add(new HouseKeeping
            {
                Id = 30,
                Status = (int)HouseKeeping.StatusEnum.Cleaning,
                Type = (int)HouseKeeping.TypeEnum.ExpectedDeparture,
                Employee = EmployeeBusiness.Get("admin"),
                Booking = BookingBusiness.Get(1)
            })).Wait();
            SchemaHelper.Execute(
                @"/_GraphQL/HouseKeeping/mutation.confirmCleanedAndServices.gql",
                @"/_GraphQL/HouseKeeping/mutation.confirmCleanedAndServices.schema.json",
                @"/_GraphQL/HouseKeeping/mutation.confirmCleanedAndServices.variable.json",
                p => p.PermissionCleaning = true
            );
        }

        [TestMethod]
        public void Query_HouseKeeping()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/HouseKeeping/query.houseKeeping.gql",
                @"/_GraphQL/HouseKeeping/query.houseKeeping.schema.json",
                @"/_GraphQL/HouseKeeping/query.houseKeeping.variable.json"
            );
        }

        [TestMethod]
        public void Query_HouseKeepings()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/HouseKeeping/query.houseKeepings.gql",
                @"/_GraphQL/HouseKeeping/query.houseKeepings.schema.json"
            );
        }
    }
}
