using GraphQL.Types;
using uit.ooad.Models;

namespace uit.ooad.ObjectTypes
{
    public class ServicesDetailType : ObjectGraphType<ServicesDetail>
    {
        public ServicesDetailType()
        {
            Name = "ServicesDetail";
            Description = "Một chi tiết dịch vụ của Thông tin thuê phòng";

            Field(x => x.Id).Description("Id của chi tiết dịch vụ");
            Field(x => x.Time).Description("Thời gian tạo");
            Field(x => x.Number).Description("Số lượng");
            Field(x => x.Booking).Description("Thuộc thông tin thuê phòng nào");
            Field(x => x.Service).Description("Thuộc dịch vụ nào");
        }
    }
}
