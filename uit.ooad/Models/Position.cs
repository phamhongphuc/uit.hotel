using System.Linq;
using Realms;
using uit.ooad.Businesses;

namespace uit.ooad.Models
{
    public class Position : RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool PermissionCreateBill { get; set; }
        public bool PermissionCreateBooking { get; set; }
        public bool PermissionCreateEmployee { get; set; }
        public bool PermissionCreateFloor { get; set; }
        public bool PermissionCreateHouseKeeping { get; set; }
        public bool PermissionCreatePatron { get; set; }
        public bool PermissionCreatePatronKind { get; set; }
        public bool PermissionCreatePosition { get; set; }
        public bool PermissionCreateRate { get; set; }
        public bool PermissionCreateReceipt { get; set; }
        public bool PermissionCreateRoom { get; set; }
        public bool PermissionCreateRoomKind { get; set; }
        public bool PermissionCreateOrUpdateService { get; set; }
        public bool PermissionCreateServicesDetail { get; set; }
        public bool PermissionCreateVolatilityRate { get; set; }

        [Backlink(nameof(Employee.Position))]
        public IQueryable<Employee> Employees { get; }

        public Position GetManaged() => PositionBusiness.Get(Id);
    }
}
