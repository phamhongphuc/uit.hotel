using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;
using uit.ooad.Queries.Base;

namespace uit.ooad.Queries.Mutation
{
    public class RateMutation : QueryType<Rate>
    {
        public RateMutation()
        {
            Field<RateType>(
                _Creation,
                "Tạo và trả về một loại giá cơ bản mới",
                InputArgument<RateCreateInput>(),
                _CheckPermission(
                    p => p.PermissionCreateRate,
                    context => RateBusiness.Add(GetInput(context))
                )
            );
        }
    }
}
