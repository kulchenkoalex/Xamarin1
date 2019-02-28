using System.Collections.Generic;
using System.Linq;
using SQLite;
using Xamarin.Forms;

namespace HelloApp
{
    public class PhoneRepository
    {
        SQLiteConnection database;
        static object locker = new object();

        public PhoneRepository(string filename)
        {
            string databasePath = DependencyService.Get<ISQLite>().GetDatabasePath(filename);
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Phone>();
            database.CreateTable<Lang>();
        }
        public IEnumerable<Phone> GetItems()
        {
            return (from i in database.Table<Phone>() select i).ToList();
        }
        public Phone GetItem(int id)
        {
            return database.Get<Phone>(id);
        }
        public int DeleteItem(int id)
        {
            lock (locker)
            {
                return database.Delete<Phone>(id);
            }
        }
        public int SaveItem(Phone item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }

        public IEnumerable<Lang> GetItems1()
        {
            return (from i in database.Table<Lang>() select i).ToList();
        }
        public Lang GetItem1(int id)
        {
            return database.Get<Lang>(id);
        }
    }
}