using System;
using System.Linq;
using Realms;

namespace uit.ooad.Models
{
    public class PatronKind : RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [Backlink(nameof(Patron.PatronKind))]
        public IQueryable<Patron> Patrons { get; }
    }
}
