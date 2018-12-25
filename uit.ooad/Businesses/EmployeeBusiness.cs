using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uit.ooad.DataAccesses;
using uit.ooad.Models;
using uit.ooad.Queries.Authentication;

namespace uit.ooad.Businesses
{
    public class EmployeeBusiness
    {
        public static Task<Employee> Add(Employee employee)
        {
            var employeeInDatabase = Get(employee.Id);
            if (employeeInDatabase != null)
                throw new Exception("Id: " + employee.Id + " đã có người sử dụng");

            employee.Position = employee.Position.GetManaged();
            employee.Password = CryptoHelper.Encrypt(employee.Password);

            return EmployeeDataAccess.Add(employee);
        }

        public static Task<Employee> Update(Employee employee)
        {
            var employeeInDatabase = Get(employee.Id);
            if(employeeInDatabase == null)  throw new Exception("không tồn tại nhân viên này");

            if(!employee.IsActive)
                throw new Exception("Tài khoản " + employee.Id + " đã bị vô hiệu hóa");
                
            employee.Position = employee.Position.GetManaged();
            return EmployeeDataAccess.Update(employeeInDatabase, employee);
        }
        
        // password và newPassword đều là chuỗi gốc chưa qua mã hóa
        public static void ChangePassword(string id, string password, string newPassword)
        {
            var employee = Get(id);
            if (employee == null) throw new Exception("Không tim thấy tên đăng nhập trong hệ thống");

            else if (!employee.IsEqualPassword(password)) throw new Exception("Mật khẩu không đúng");
            newPassword = CryptoHelper.Encrypt(newPassword);

            EmployeeDataAccess.ChangePassword(employee, newPassword);
        }

        public static string ResetPassword(string id)
        {
            var employee = Get(id);
            if (employee == null) throw new Exception("Không tim thấy tên đăng nhập trong hệ thống");

            var newPassword = AuthenticationHelper.GetRandomString();
            EmployeeDataAccess.ChangePassword(employee, CryptoHelper.Encrypt(newPassword));

            return newPassword;
        }

        public static void SetIsActiveAccount(string id, bool isActive)
        {
            var employee = Get(id);
            if (employee == null) throw new Exception("Không tim thấy tên đăng nhập trong hệ thống");

            EmployeeDataAccess.SetIsActiveAccount(employee, isActive);
        }

        public static void CheckLogin(string id, string password)
        {
            var employee = Get(id);

            if(!employee.IsActive)
                throw new Exception("Tài khoản " + id + " đã bị vô hiệu hóa");
                
            if (employee != null)
            {
                if (employee.IsEqualPassword(password)) return;
            }
            throw new Exception("Tài khoản hoặc mật khẩu không chính xác");
        }
        public static Employee Get(string employeeId) => EmployeeDataAccess.Get(employeeId);

        public static IEnumerable<Employee> Get() => EmployeeDataAccess.Get();

        public static async void CreateAdminIfNotExists()
        {
            if (Get().Count() != 0) return;

            var position = await PositionBusiness.Add(new Position
            {
                Id = 1,
                Name = "Quản trị viên",
                PermissionUpdateGroundPlan = true,
                PermissionCreateBill = true,
                PermissionCreateBooking = true,
                PermissionCreateOrUpdateEmployee = true,
                PermissionCreateHouseKeeping = true,
                PermissionCreateOrUpdatePatron = true,
                PermissionCreatePosition = true,
                PermissionCreateRate = true,
                PermissionCreateReceipt = true,
                PermissionCreateOrUpdateRoomKind = true,
                PermissionCreateOrUpdateService = true,
                PermissionCreateServicesDetail = true,
                PermissionCreateVolatilityRate = true
            });

            await Add(new Employee
            {
                Id = "admin",
                Name = "Quản trị viên",
                Password = "admin",
                IdentityCard = "123456789",
                Address = "Unknown",
                PhoneNumber = "Unknown",
                Birthdate = DateTime.Now,
                StartingDate = DateTime.Now,
                Position = position,
                IsActive = true,
            });
        }
    }
}
