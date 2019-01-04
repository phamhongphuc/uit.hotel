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
                @"/_GraphQL/Rate/mutation.createRate.variable.json",
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
                @"/_GraphQL/Rate/mutation.deleteRate.variable.json",
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
                @"/_GraphQL/Rate/mutation.updateRate.variable.json",
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
                @"/_GraphQL/Rate/query.rate.variable.json",
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
