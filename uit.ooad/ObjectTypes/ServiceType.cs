using System.Linq;
using GraphQL.Types;
using uit.ooad.Models;
using uit.ooad.Queries.Base;

namespace uit.ooad.ObjectTypes
{
    public class ServiceType : ObjectGraphType<Service>
    {
        public ServiceType()
        {
            Name = nameof(Service);
            Description = "Một dịch vụ trong khách sạn";

            Field(x => x.Id).Description("Id của dịch vụ");
            Field(x => x.Name).Description("Tên dịch vụ");
            Field(x => x.UnitRate).Description("Đơn giá");
            Field(x => x.Unit).Description("Đơn vị");
            Field(x => x.IsActive).Description("Trạng thái hoạt động");

            Field<ListGraphType<ServicesDetailType>>(
                nameof(Service.ServicesDetails),
                resolve: context => context.Source.ServicesDetails.ToList(),
                description: "Danh sách chi tiết dịch vụ"
            );
        }
    }

    public class ServiceCreateInput : InputType<Service>
    {
        public ServiceCreateInput()
        {
            Name = _Creation;
            Description = "Input cho một thông tin dịch vụ cần tạo mới";

            Field(x => x.Name).Description("Tên dịch vụ");
            Field(x => x.UnitRate).Description("Đơn giá");
            Field(x => x.Unit).Description("Đơn vị");
            Field(x => x.IsActive).Description("Trạng thái hoạt động");
        }
    }
    public class ServiceUpdateInput : InputType<Service>
    {
        public ServiceUpdateInput()
        {
            Name = _Updation;
            Description = "Input cho một thông tin dịch vụ cần cập nhật";

            Field(x => x.Id).Description("Id của dịch vụ");
            Field(x => x.Name).Description("Tên dịch vụ");
            Field(x => x.UnitRate).Description("Đơn giá");
            Field(x => x.Unit).Description("Đơn vị");
            Field(x => x.IsActive).Description("Trạng thái hoạt động");
        }
    }
    public class ServiceIdInput : InputType<Service>
    {
        public ServiceIdInput()
        {
            Name = _Id;
            Description = "Input cho một thông tin dịch vụ";

            Field(x => x.Id).Description("Id của dịch vụ");
        }
    }
}
