using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;
using uit.ooad.Queries.Base;

namespace uit.ooad.Queries.Mutation
{
    public class PatronMutation : QueryType<Patron>
    {
        public PatronMutation()
        {
            Field<PatronType>(
                _Creation,
                "Tạo và trả về một khách hàng mới",
                InputArgument<PatronCreateInput>(),
                context => PatronBusiness.Add(GetInput(context))
            );
        }
    }
}
