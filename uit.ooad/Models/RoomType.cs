using Realms;

namespace uit.ooad.Models
{
    public class RoomType : RealmObject
    {
        [PrimaryKey]
        public string Id { get; set; }
        public string Name { get; set; }
        public int NumberOfBeds { get; set; }
    }
}
