using System.Collections.Generic;
using System.Threading.Tasks;
using uit.ooad.Models;

namespace uit.ooad.DataAccesses
{
    public class EmployeeDataAccess : RealmDatabase
    {
        public static async Task<Employee> Add(Employee employee)
        {
            await Database.WriteAsync(realm => employee = realm.Add(employee));
            return employee;
        }

        public static Employee Get(string employeeId) => Database.Find<Employee>(employeeId);

        public static IEnumerable<Employee> Get() => Database.All<Employee>();
    }
}
