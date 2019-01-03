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
        public bool PermissionGetGroundPlan { get; set; }
        public bool PermissionManageRoomKind { get; set; }
        public bool PermissionGetRoomKind { get; set; }
        public bool PermissionManageRate { get; set; }
        public bool PermissionGetRate { get; set; }
        public bool PermissionManageService { get; set; }
        public bool PermissionGetService { get; set; }
        public bool PermissionGetHouseKeeping { get; set; }
        public bool PermissionCleaning { get; set; }
        public bool PermissionManageHiringRoom { get; set; }
        public bool PermissionManagePatron { get; set; }
        public bool PermissionGetPatron { get; set; }
        public bool PermissionManagePatronKind { get; set; }
        public bool PermissionGetPatronKind { get; set; }
        public bool PermissionManagePosition { get; set; }
        public bool PermissionGetPosition { get; set; }
        public bool PermissionManageEmployee { get; set; }
        public bool PermissionGetVoucher { get; set; }
        public bool IsActive { get; set; }

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
