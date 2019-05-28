using GraphQL.Types;

namespace uit.hotel.Queries.Base
{
    public class AppType : ObjectGraphType
    {
        protected void AddFields(params ObjectGraphType[] objectGraphTypes)
        {
            foreach (var objectGraphType in objectGraphTypes)
                foreach (var field in objectGraphType.Fields)
                    AddField(field);
        }
    }
}
