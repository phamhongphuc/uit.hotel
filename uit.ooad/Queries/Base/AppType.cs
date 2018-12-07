using GraphQL.Types;

namespace uit.ooad.Queries.Base
{
    public class AppType : ObjectGraphType
    {
        public void AddFields(params ObjectGraphType[] objectGraphTypes)
        {
            foreach (var objectGraphType in objectGraphTypes)
            foreach (var field in objectGraphType.Fields)
                AddField(field);
        }
    }
}
