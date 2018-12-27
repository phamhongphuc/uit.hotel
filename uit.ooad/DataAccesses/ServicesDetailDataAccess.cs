using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Realms;
using uit.ooad.Models;

namespace uit.ooad.DataAccesses
{
    public class ServicesDetailDataAccess : RealmDatabase
    {
        public static ServicesDetail Add(Realm realm, ServicesDetail servicesDetail)
        {
            servicesDetail.Id = NextId;
            servicesDetail.Time = DateTimeOffset.Now;
            return realm.Add(servicesDetail);
        }

        public static ServicesDetail Get(int servicesDetailId) => Database.Find<ServicesDetail>(servicesDetailId);

        public static IEnumerable<ServicesDetail> Get() => Database.All<ServicesDetail>();
        public static int NextId => Get().Count() == 0 ? 1 : Get().Max(i => i.Id) + 1;
    }
}
