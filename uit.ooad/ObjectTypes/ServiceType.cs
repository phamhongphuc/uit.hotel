using GraphQL.Types;
using uit.ooad.Models;

namespace uit.ooad.ObjectTypes
{
    public class ServiceType : ObjectGraphType<Service>
    {
        public ServiceType()
        {
            Name = "Service";
            Description = "Một dịch vụ trong khách sạn";

            Field(x => x.Id).Description("Id của dịch vụ");
            Field(x => x.Name).Description("Tên dịch vụ");
            Field(x => x.UnitRate).Description("Đơn giá");
            Field(x => x.Unit).Description("Đơn vị");
            // Field(x => x.ServicesDetails).Description("Danh sách chi tiết dịch vụ");
        }
    }
}
