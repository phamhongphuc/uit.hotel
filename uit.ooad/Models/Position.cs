using Realms;

namespace uit.ooad.Models
{
    public class Position : RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool PermissionCreateAccount { get; set; }
    }
}
