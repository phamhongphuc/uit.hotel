using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uit.hotel.Models;

namespace uit.hotel.DataAccesses
{
    public class PositionDataAccess : RealmDatabase
    {
        private static int NextId => Get().Count() == 0 ? 1 : Get().Max(i => i.Id) + 1;

        public static async Task<Position> Add(Position position)
        {
            await Database.WriteAsync(realm =>
            {
                position.Id = NextId;
                position.IsActive = true;
                position = realm.Add(position);
            });
            return position;
        }

        public static async Task<Position> Update(Position positionInDatabase, Position position)
        {
            await Database.WriteAsync(realm =>
            {
                positionInDatabase.Name = position.Name;
                positionInDatabase.PermissionCleaning = position.PermissionCleaning;
                positionInDatabase.PermissionGetAccountingVoucher = position.PermissionGetAccountingVoucher;
                positionInDatabase.PermissionGetMap = position.PermissionGetMap;
                positionInDatabase.PermissionGetMap = position.PermissionGetMap;
                positionInDatabase.PermissionGetPatron = position.PermissionGetPatron;
                positionInDatabase.PermissionGetPrice = position.PermissionGetPrice;
                positionInDatabase.PermissionGetService = position.PermissionGetService;
                positionInDatabase.PermissionManageEmployee = position.PermissionManageEmployee;
                positionInDatabase.PermissionManageMap = position.PermissionManageMap;
                positionInDatabase.PermissionManagePatron = position.PermissionManagePatron;
                positionInDatabase.PermissionManagePatronKind = position.PermissionManagePatronKind;
                positionInDatabase.PermissionManagePosition = position.PermissionManagePosition;
                positionInDatabase.PermissionManagePrice = position.PermissionManagePrice;
                positionInDatabase.PermissionManageRentingRoom = position.PermissionManageRentingRoom;
                positionInDatabase.PermissionManageService = position.PermissionManageService;
            });
            return positionInDatabase;
        }

        public static async void SetIsActive(Position positionInDatabase, bool isActive)
        {
            await Database.WriteAsync(realm => positionInDatabase.IsActive = isActive);
        }

        public static async void SetIsActiveAndMoveEmployee(Position positionInDatabase, Position positionNew)
        {
            await Database.WriteAsync(realm =>
            {
                foreach (var employee in positionInDatabase.Employees)
                    if (employee.IsActive)
                        employee.Position = positionNew;
                positionInDatabase.IsActive = false;
            });
        }

        public static async void Delete(Position positionInDatabase)
        {
            await Database.WriteAsync(realm => realm.Remove(positionInDatabase));
        }

        public static async void UpdateForHelper(Action<Position> setPermission, Position position)
            => await Database.WriteAsync(realm => { setPermission(position); });

        public static Position Get(int positionId) => Database.Find<Position>(positionId);

        public static IEnumerable<Position> Get() => Database.All<Position>();
    }
}
