using System.Collections.Generic;
using System.Threading.Tasks;
using uit.ooad.DataAccesses;
using uit.ooad.Models;

namespace uit.ooad.Businesses
{
    public class EmployeeBusiness
    {
        public static Task<Employee> Add(Employee Employee) => EmployeeDataAccess.Add(Employee);
        public static Employee Get(string EmployeeId) => EmployeeDataAccess.Get(EmployeeId);
        public static IEnumerable<Employee> Get() => EmployeeDataAccess.Get();
    }
}
