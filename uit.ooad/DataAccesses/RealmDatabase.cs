using System;
using System.IO;
using Realms;
using uit.ooad.Models;

namespace uit.ooad.DataAccesses
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
                    typeof(Access),
                    typeof(Employee),
                    typeof(Floor),
                    typeof(Room),
                    typeof(RoomType),
                }
            };
        }

        protected static Realm Database => Realm.GetInstance(Config);
    }
}
