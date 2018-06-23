using FeedingTracker.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FeedingTracker
{
	public partial class MainNavigation : ContentPage
	{
		public MainNavigation ()
		{
			InitializeComponent ();
        }

        private void btnTrackFeeding_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FeedingStart());
        }

        private void btnViewFeedings_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FeedingsView());
        }

        private void btnTrackPumping_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PumpingDeets());
        }

        private void btnViewPumpings_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PumpingsView());
        }

        private void btnCleanDatabase_Clicked(object sender, EventArgs e)
        {
            int feedingCount = 0;

            var orphanFeedings = App.Database.GetInProgressFeedings();

            if (orphanFeedings != null && orphanFeedings.Count > 0)
            {
                feedingCount = orphanFeedings.Count();
                foreach (Feeding feed in orphanFeedings)
                {
                    App.Database.DeleteFeeding(feed);
                }
                
                var answer = DisplayAlert("Success", $"Cleaned {feedingCount} feedings", "OK");
            }
            else
            {
                var answer = DisplayAlert("Well...", "...there's nothing to clean", "OK");
            }
        }

        async void btnResetDatabase_Clicked(object sender, EventArgs e)
        {
            var feedings = App.Database.GetFeedings();
            var pumpings = App.Database.GetPumpings();

            var answer = await DisplayAlert("Delete?", $"Delete all data? ({feedings.Count} feedings, {pumpings.Count} pumpings)", "OK", "Cancel");
            
            if (answer)
            {
                try
                {
                    foreach (Feeding feed in feedings)
                    {
                        App.Database.DeleteFeeding(feed);
                    }

                    foreach (Pumping pump in pumpings)
                    {
                        App.Database.DeletePumping(pump);
                    }

                    await DisplayAlert("Success", "Successfully deleted all database records.", "OK");
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Uh oh...", $"Error resetting database. ex = {ex.ToString()}", "OK");
                }   
            }

            return;
        }
    }
}