using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uit.hotel.DataAccesses;
using uit.hotel.Models;

namespace uit.hotel.Businesses
{
    public static class PatronBusiness
    {
        public static Task<Patron> Add(Patron patron)
        {
            var patronInDatabase = GetByIdentification(patron.Identification);
            if (patronInDatabase != null)
                throw new Exception("Số Identification: " + patron.Identification + " đã được đăng ký");

            patron.PatronKind = patron.PatronKind.GetManaged();
            return PatronDataAccess.Add(patron);
        }

        public static Task<Patron> Update(Patron patron)
        {
            var patronInDatabase = Get(patron.Id);

            if (patronInDatabase == null)
                throw new Exception("Không tồn tại khách hàng có Id: " + patron.Id);

            patron.PatronKind = patron.PatronKind.GetManaged();
            return PatronDataAccess.Update(patronInDatabase, patron);
        }

        public static Patron Get(int patronId) => PatronDataAccess.Get(patronId);

        public static Patron GetByIdentification(string patronIdentification) =>
            PatronDataAccess.GetByIdentification(patronIdentification);

        public static IEnumerable<Patron> Get() => PatronDataAccess.Get();

        public static IEnumerable<Patron> Query(string query)
        {
            return Get()
               .Where(p => p.Identification.Contains(query, StringComparison.OrdinalIgnoreCase))
               .ToList();
        }
    }
}
