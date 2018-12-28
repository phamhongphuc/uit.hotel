using System;
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
        public bool PermissionGetRooms { get; set; }
        public bool PermissionManageRoomKind { get; set; }
        public bool PermissionManageRate { get; set; }
        public bool PermissionManageService { get; set; }
        public bool PermissionGetHouseKeeping { get; set; }
        public bool PermissionCleaning { get; set; }
        public bool PermissionManageHiringRoom { get; set; }
        public bool PermissionManagePatron { get; set; }
        public bool PermissionManagePatronKind { get; set; }
        public bool PermissionManagePositions { get; set; }
        public bool PermissionReferDebt { get; set; }
        public bool PermissionChangePersonalPassword { get; set; }
        public bool PermissionManageEmployees { get; set; }
        public bool PermissionReferRevenues { get; set; }
        public bool PermissionCreateBill { get; set; }
        public bool PermissionCreateBooking { get; set; }
        public bool PermissionCreateOrUpdateEmployee { get; set; }
        public bool PermissionCreateOrUpdatePatron { get; set; }
        public bool PermissionCreatePatronKind { get; set; }
        public bool PermissionCreatePosition { get; set; }
        public bool PermissionCreateReceipt { get; set; }
        public bool PermissionCreateServicesDetail { get; set; }

        [Backlink(nameof(Employee.Position))]
        public IQueryable<Employee> Employees { get; }

        public Position GetManaged()
        {
            var position = PositionBusiness.Get(Id);
            if (position == null)
                throw new Exception("Mã chức vụ không tồn tại");
            return position;
        }
    }
}
