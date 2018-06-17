using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite.Net;

namespace FeedingTracker.Droid.Data
{
    public class FeedingDatabase
    {
        readonly SQLiteConnection database;

        public FeedingDatabase(string dbPath)
        {
            database = new SQLiteConnection(new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid(), dbPath);
            database.CreateTable<Feeding>();
        }

        public List<Feeding> GetItems()
        {
            return database.Table<Feeding>().ToList<Feeding>();
        }

        //public Task<List<TodoItem>> GetItemsNotDoneAsync()
        //{
        //    return database.QueryAsync<TodoItem>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        //}

        //public Task<TodoItem> GetItemAsync(int id)
        //{
        //    return database.Table<TodoItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
        //}

        public int SaveItem(Feeding feed)
        {
            if (feed.ID != 0)
            {
                return database.Update(feed);
            }
            else
            {
                return database.Insert(feed);
            }
        }

        public int DeleteItem(Feeding feed)
        {
            return database.Delete(feed);
        }
    }
}