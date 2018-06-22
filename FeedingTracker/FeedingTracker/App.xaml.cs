using FeedingTracker.Droid;
using FeedingTracker.Droid.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace FeedingTracker
{
	public partial class App : Application
	{

        static FeedingDatabase database;

        public static FeedingDatabase Database
        {
            get
            {
                if (database == null)
                {
                    var dbfh = new FileHelper();
                    database = new FeedingDatabase(dbfh.GetLocalFilePath("FeedingSQLite.db3"));
                }
                return database;
            }
        }

        public App ()
		{
			InitializeComponent();

            MainPage = new NavigationPage(new MainNavigation());
        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
