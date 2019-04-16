using GraphQL.Types;
using uit.hotel.Businesses;
using uit.hotel.Models;
using uit.hotel.ObjectTypes;
using uit.hotel.Queries.Base;

namespace uit.hotel.Queries.Query
{
    public class PatronQuery : QueryType<Patron>
    {
        public PatronQuery()
        {
            Field<NonNullGraphType<ListGraphType<NonNullGraphType<PatronType>>>>(
                _List,
                "Trả về một danh sách các khách hàng",
                resolve: _CheckPermission_List(
                    p => p.PermissionGetPatron,
                    context => PatronBusiness.Get()
                )
            );

            Field<NonNullGraphType<PatronType>>(
                _Item,
                "Trả về thông tin một khách hàng",
                _IdArgument(),
                _CheckPermission_Object(
                    p => p.PermissionGetPatron,
                    context => PatronBusiness.Get(_GetId<int>(context))
                )
            );

            Field<NonNullGraphType<ListGraphType<NonNullGraphType<PatronType>>>>(
                _Finding,
                "Trả về danh sách khách hàng theo từ khóa tìm kiếm",
                new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }),
                _CheckPermission_List(
                    p => p.PermissionGetPatron,
                    context =>
                    {
                        var id = context.GetArgument<string>("id");
                        return PatronBusiness.Query(id);
                    }
                )
            );
        }
    }
}
