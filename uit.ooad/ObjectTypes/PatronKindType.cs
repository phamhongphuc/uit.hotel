using System.Linq;
using GraphQL.Types;
using uit.ooad.Models;

namespace uit.ooad.ObjectTypes
{
    public class PatronKindType : ObjectGraphType<PatronKind>
    {
        public PatronKindType()
        {
            Name = nameof(PatronKind);
            Description = "Thông tin  một loại khách hàng";

            Field(x => x.Id).Description("Id của loại khách hàng");
            Field(x => x.Name).Description("Tên loại khách hàng");
            Field(x => x.Description).Description("Thông tin mô tả loại khách hàng");

            Field<ListGraphType<PatronType>>(
                nameof(PatronKind.Patrons),
                resolve: context => context.Source.Patrons.ToList(),
                description: "Danh sách các khách hàng thuộc loại khách hàng"
            );
        }
    }
}
