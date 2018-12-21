using System.Collections.Generic;
using System.Threading.Tasks;
using uit.ooad.Models;

namespace uit.ooad.DataAccesses
{
    public class PatronDataAccess : RealmDatabase
    {
        public static async Task<Patron> Add(Patron patron)
        {
            await Database.WriteAsync(realm => patron = realm.Add(patron));
            return patron;
        }

        public static async Task<Patron> Update(Patron patronInDatabase, Patron patron)
        {
            await Database.WriteAsync(realm =>
            {
                patronInDatabase.Name = patron.Name;
                patronInDatabase.Email = patron.Email;
                patronInDatabase.Gender = patron.Gender;
                patronInDatabase.Birthdate = patron.Birthdate;
                patronInDatabase.PhoneNumber = patron.PhoneNumber;
                patronInDatabase.Nationality = patron.Nationality;
                patronInDatabase.Domicile = patron.Domicile;
                patronInDatabase.Residence = patron.Residence;
                patronInDatabase.Company = patron.Company;
                patronInDatabase.Note = patron.Note;
                patronInDatabase.PatronKind = patron.PatronKind;
            });
            return patronInDatabase;
        }
        public static Patron Get(string patronId) => Database.Find<Patron>(patronId);

        public static IEnumerable<Patron> Get() => Database.All<Patron>();
    }
}
