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
            database.CreateTable<Pumping>();
        }

        #region Feedings

        public List<Feeding> GetFeedings()
        {
            return database.Table<Feeding>().ToList<Feeding>();
        }

        public List<Feeding> GetInProgressFeedings()
        {
            return database.Query<Feeding>("SELECT * FROM [Feeding] WHERE [End_Time] is null");
        }

        public int SaveFeeding(Feeding feed)
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

        public int DeleteFeeding(Feeding feed)
        {
            return database.Delete(feed);
        }

        #endregion

        #region Pumpings

        public List<Pumping> GetPumpings()
        {
            return database.Table<Pumping>().ToList<Pumping>();
        }

        public List<Pumping> GetInProgressPumpings()
        {
            return database.Query<Pumping>("SELECT * FROM [Pumping] WHERE [End_Time] is null");
        }

        public int SavePumping(Pumping pump)
        {
            if (pump.ID != 0)
            {
                return database.Update(pump);
            }
            else
            {
                return database.Insert(pump);
            }
        }

        public int DeletePumping(Pumping pump)
        {
            return database.Delete(pump);
        }

        #endregion
    }
}