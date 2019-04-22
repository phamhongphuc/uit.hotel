using GraphQL.Types;
using uit.hotel.Businesses;
using uit.hotel.Models;
using uit.hotel.ObjectTypes;
using uit.hotel.Queries.Base;

namespace uit.hotel.Queries.Query
{
    public class InitializeQuery : QueryType<Employee>
    {
        public InitializeQuery()
        {
            Field<NonNullGraphType<BooleanGraphType>>(
                "IsInitialized",
                "Kiểm tra",
                resolve: context => InitializeBusiness.IsInitialized()
            );
        }
    }
}