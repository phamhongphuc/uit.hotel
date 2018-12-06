using GraphQL.Types;

namespace uit.ooad.Queries
{
    public class RootQueryGraphType : ObjectGraphType
    {
        public string GetList(string name)
        {
            return name + "s";
        }
        public string GetCreation(string name)
        {
            return "Create" + name;
        }
        public string GetDeletion(string name)
        {
            return "Delete" + name;
        }
        public string GetUpdation(string name)
        {
            return "Update" + name;
        }
    }
}
