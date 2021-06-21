using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace LocalDatabaseTutorial
{
    public class Database
    {
        public readonly SQLiteAsyncConnection database;

        public Database(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Person>().Wait();
        }

        public Task<List<Person>> GetPeopleAsync()
        {
            return database.Table<Person>().ToListAsync();
        }

        public Task<int> SavePersonAsync(Person person)
        {
            return database.InsertAsync(person);
        }
    }
}
