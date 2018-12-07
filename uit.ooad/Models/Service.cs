using System.Linq;
using Realms;

namespace uit.ooad.Models
{
    public class Service : RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public int UnitRate { get; set; }
        public int Unit { get; set; }

        [Backlink(nameof(ServicesDetail.Service))]
        public IQueryable<ServicesDetail> ServicesDetails { get; }
    }
}
