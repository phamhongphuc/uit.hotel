using System;
using System.Linq;
using Realms;
using uit.ooad.Businesses;

namespace uit.ooad.Models
{
    public class Service : RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public long UnitRate { get; set; }
        public string Unit { get; set; }
        public bool IsActive { get; set; }

        [Backlink(nameof(ServicesDetail.Service))]
        public IQueryable<ServicesDetail> ServicesDetails { get; }

        public Service GetManaged()
        {
            var service = ServiceBusiness.Get(Id);
            if (service == null)
                throw new Exception("Mã dịch vụ không tồn tại");
            return service;
        }
    }
}
