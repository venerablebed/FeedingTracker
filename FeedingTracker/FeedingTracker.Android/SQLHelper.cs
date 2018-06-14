using SQLite.Net;
using System.Collections.Generic;
using System.Linq;
using PCLStorage;
using SQLite.Net.Platform.XamarinAndroid;

namespace FeedingTracker.Droid
{
    class SQLHelper
    {
        static object locker = new object();
        SQLiteConnection database;

        public SQLiteConnection GetConnection()
        {
            SQLiteConnection sqlConnection;
            var sqliteFilename = "Feedings.db3";
            IFolder folder = FileSystem.Current.LocalStorage;
            string path = PortablePath.Combine(folder.Path.ToString(), sqliteFilename);
            sqlConnection = new SQLiteConnection(new SQLitePlatformAndroid(), path);
            return sqlConnection;
        }

        public IEnumerable<Feeding> GetItems()
        {
            lock (locker)
            {
                return (from i in database.Table<Feeding>() select i).ToList();
            }
        }

        //public FeedingEntity GetItem(string userName)
        //{
        //    lock (locker)
        //    {
        //        return database.Table<FeedingEntity>().FirstOrDefault(x => x.Username == userName);
        //    }
        //}

        //public FeedingEntity GetItem(string userName, string passWord)
        //{
        //    lock (locker)
        //    {
        //        return database.Table<FeedingEntity>().FirstOrDefault(x => x.Username == userName && x.Password == passWord);
        //    }
        //}

        public int SaveItem(Feeding item)
        {
            lock (locker)
            {
                if (item.Feeding_ID != 0)
                {
                    //Update Item  
                    database.Update(item);
                    return item.Feeding_ID;
                }
                else
                {
                    //Insert item  
                    return database.Insert(item);
                }
            }
        }

        public int DeleteItem(int id)
        {
            lock (locker)
            {
                return database.Delete<Feeding>(id);
            }
        }

    }
}