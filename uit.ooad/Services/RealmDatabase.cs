using Realms;
using System;
using System.IO;
using uit.ooad.Interfaces;

namespace uit.ooad.Services
{
    public class RealmDatabase : IRealmDatabase
    {
        static readonly RealmConfiguration Config;

        static RealmDatabase()
        {
            string folder = Path.Combine(Environment.CurrentDirectory, "Database");
            string file = Path.Combine(folder, "realm.realm");
            Directory.CreateDirectory(folder);

            Config = new RealmConfiguration(file)
            {
                ShouldDeleteIfMigrationNeeded = true,
            };
        }

        public RealmDatabase() => Database = Realm.GetInstance(Config);

        public Realm Database { get; }
    }
}
