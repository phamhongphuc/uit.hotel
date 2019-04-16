using System;
using System.Linq;
using Realms;
using uit.hotel.Businesses;

namespace uit.hotel.Models
{
    public class PatronKind : RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [Backlink(nameof(Patron.PatronKind))]
        public IQueryable<Patron> Patrons { get; }

        public PatronKind GetManaged()
        {
            var patronKind = PatronKindBusiness.Get(Id);
            if (patronKind == null)
                throw new Exception("Mã loại khách hàng không tồn tại");
            return patronKind;
        }
    }
}
