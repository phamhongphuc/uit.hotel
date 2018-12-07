using System.Security.Claims;
using uit.ooad.Businesses;
using uit.ooad.GraphQL;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;
using uit.ooad.Queries.Authentication;
using uit.ooad.Queries.Base;

namespace uit.ooad.Queries.Mutation
{
    public class PositionMutation : QueryType<Position>
    {
        public PositionMutation()
        {
            Field<PositionType>(
                _Creation,
                "Tạo và trả về một chức vụ mới",
                InputArgument<PositionCreateInput>(),
                _CheckPermission(
                    p => p.PermissionCreatePosition,
                    context => PositionBusiness.Add(GetInput(context))
                )
            );
        }
    }
}
