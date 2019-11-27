using System;
using System.IO;
using System.Threading.Tasks;
using Realms;
using uit.hotel.Models;

namespace uit.hotel.DataAccesses
{
    public class RealmDatabase
    {
        private static readonly RealmConfiguration Config;

        static RealmDatabase()
        {
            var folder = Path.Combine(Environment.CurrentDirectory, "Database");
            var file = Path.Combine(folder, "realm.realm");
            Directory.CreateDirectory(folder);

            Config = new RealmConfiguration(file)
            {
                ShouldDeleteIfMigrationNeeded = true,
                ObjectClasses = new[]
                {
                    typeof(Bill),
                    typeof(Booking),
                    typeof(Employee),
                    typeof(Floor),
                    typeof(Patron),
                    typeof(PatronKind),
                    typeof(Position),
                    typeof(Price),
                    typeof(PriceItem),
                    typeof(PriceVolatility),
                    typeof(Receipt),
                    typeof(Room),
                    typeof(RoomKind),
                    typeof(Service),
                    typeof(ServicesDetail)
                }
            };
        }

        protected static Realm Database => Realm.GetInstance(Config);

        protected static async Task WriteAsync(Action<Realm> action)
        {
            if (Database.IsInTransaction) action(Database);
            else await Database.WriteAsync(action);
        }
    }
}
