using Realms;
using System.Linq;

namespace uit.ooad.Models
{
    public class Floor : RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
