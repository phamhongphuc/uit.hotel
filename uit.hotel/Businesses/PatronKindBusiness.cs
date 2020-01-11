using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uit.hotel.DataAccesses;
using uit.hotel.Models;

namespace uit.hotel.Businesses
{
    public static class PatronKindBusiness
    {
        public static Task<PatronKind> Add(PatronKind patronKind)
        {
            CheckUniqueName(patronKind);
            return PatronKindDataAccess.Add(patronKind);
        }

        public static Task<PatronKind> Update(PatronKind patronKind)
        {
            var patronKindInDatabase = GetAndCheckValid(patronKind.Id);
            CheckUniqueName(patronKind, true);

            return PatronKindDataAccess.Update(patronKindInDatabase, patronKind);
        }

        public static void Delete(int patronKindId)
        {
            var patronKindInDatabase = GetAndCheckValid(patronKindId);
            if (patronKindInDatabase.Patrons.Count() > 0)
                throw new Exception("Loại khách hàng đang được sử dụng. Không thể cập xóa");

            PatronKindDataAccess.Delete(patronKindInDatabase);
        }

        private static void CheckUniqueName(PatronKind patronKind, bool isUpdate = false)
        {
            var numberOfPatronKinds = Get().Where(p => p.Name == patronKind.Name && (isUpdate ? p.Id != patronKind.GetManaged().Id : true)).Count();
            if (numberOfPatronKinds == 1)
                throw new Exception("Loại khách hàng " + patronKind.Name + " đã được tạo.");
            else if (numberOfPatronKinds > 1)
                throw new Exception("Cơ sở dữ liệu lỗi!");
        }

        private static PatronKind GetAndCheckValid(int patronKindId)
        {
            var patronKindInDatabase = Get(patronKindId);
            if (patronKindInDatabase == null)
                throw new Exception("Loại khách hàng có ID: " + patronKindId + " không tồn tại");
            return patronKindInDatabase;
        }

        public static PatronKind Get(int patronKindId) => PatronKindDataAccess.Get(patronKindId);
        public static IEnumerable<PatronKind> Get() => PatronKindDataAccess.Get();
    }
}
