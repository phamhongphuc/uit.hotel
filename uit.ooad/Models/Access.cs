using System.Linq;
using Realms;

namespace uit.ooad.Models
{
    public class Access : RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool CreateAccount { get; set; }

        [Backlink(nameof(Employee.Access))]
        public IQueryable<Employee> Staffs { get; }
    }
}
