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

        public bool PermissionUpdateGroundPlan { get; set; }
        public bool PermissionHandleBills { get; set; }
        public bool PermissionGetRooms { get; set; }
        public bool PermissionManageHiringRooms { get; set; }
        public bool PermissionGetHouseKeepings { get; set; }
        public bool PermissionCreateBill { get; set; }
        public bool PermissionCreateBooking { get; set; }
        public bool PermissionCreateOrUpdateEmployee { get; set; }
        public bool PermissionAssignHouseKeeping { get; set; }
        public bool PermissionCreateOrUpdatePatron { get; set; }
        public bool PermissionCreatePatronKind { get; set; }
        public bool PermissionCreatePosition { get; set; }
        public bool PermissionCreateOrUpdateRate { get; set; }
        public bool PermissionCreateReceipt { get; set; }
        public bool PermissionCreateOrUpdateRoomKind { get; set; }
        public bool PermissionCreateOrUpdateService { get; set; }
        public bool PermissionCreateServicesDetail { get; set; }
        public bool PermissionCreateOrUpdateVolatilityRate { get; set; }

        [Backlink(nameof(Employee.Position))]
        public IQueryable<Employee> Employees { get; }

        public Position GetManaged() => PositionBusiness.Get(Id);
    }
}
