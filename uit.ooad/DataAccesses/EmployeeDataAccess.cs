using System.Collections.Generic;
using System.Threading.Tasks;
using uit.ooad.Models;

namespace uit.ooad.DataAccesses
{
    public class EmployeeDataAccess : RealmDatabase
    {
        public static async Task<Employee> Add(Employee Employee)
        {
            await Database.WriteAsync(realm => Employee = realm.Add(Employee));
            return Employee;
        }

        public static Employee Get(string EmployeeId) => Database.Find<Employee>(EmployeeId);

        public static IEnumerable<Employee> Get() => Database.All<Employee>();
    }
}
