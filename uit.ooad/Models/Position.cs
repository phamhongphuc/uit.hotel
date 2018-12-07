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
        public bool PermissionCreateEmployee { get; set; }
        public bool PermissionCreatePatron { get; set; }
        public bool PermissionCreateBill { get; set; }
        public bool PermissionCreateFloor { get; set; }

        [Backlink(nameof(Employee.Position))]
        public IQueryable<Employee> Employees { get; }

        public Position GetManaged() => PositionBusiness.Get(Id);
    }
}
