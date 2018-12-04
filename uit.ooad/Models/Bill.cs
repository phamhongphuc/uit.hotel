using System;
using Realms;

namespace uit.ooad.Models
{
    public class Bill : RealmObject
    {
        [PrimaryKey]
        public string Id { get; set; }
        public DateTimeOffset Time { get; set; }
    }
}
