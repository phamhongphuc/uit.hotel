using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uit.ooad.DataAccesses;
using uit.ooad.Models;

namespace uit.ooad.Businesses
{
    public class PositionBusiness
    {
        public static Task<Position> Add(Position position) => PositionDataAccess.Add(position);

        public static Task<Position> Update(Position position)
        {
            Position positionInDatabase = GetAndCheckValid(position.Id);

            return PositionDataAccess.Update(positionInDatabase, position);
        }

        public static void Delete(int positionId)
        {
            var positionInDatabase = GetAndCheckValid(positionId);
            PositionDataAccess.Delete(positionInDatabase);
        }

        private static Position GetAndCheckValid(int positionId)
        {
            var positionInDatabase = Get(positionId);
            if (positionInDatabase == null)
                throw new Exception("Chức vụ có ID: " + positionId + " không tồn tại");

            if (positionInDatabase.Employees.Count() > 0)
                throw new Exception("Không thể cập nhật/xóa. Chức vụ đang có nhân viên sử dụng");

            return positionInDatabase;
        }

        public static void UpdateForHelper(Action<Position> setPermission, Position position)
            => PositionDataAccess.UpdateForHelper(setPermission, position);

        public static Position Get(int positionId) => PositionDataAccess.Get(positionId);
        
        public static IEnumerable<Position> Get() => PositionDataAccess.Get();
    }
}
