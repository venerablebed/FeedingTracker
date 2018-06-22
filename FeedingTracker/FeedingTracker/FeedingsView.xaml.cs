using FeedingTracker.Droid;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FeedingTracker
{
    public class FeedingsViewItem
    {
        public string Name { get; set; }
        public string Detail { get; set; }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FeedingsView : ContentPage
    {
        public List<FeedingsViewItem> ConvertedFeedings { get; set; }

        public FeedingsView()
        {
            InitializeComponent();

            CreateFeedingDict();
			
			MyListView.ItemsSource = ConvertedFeedings;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        void CreateFeedingDict()
        {
            var feedings = App.Database.GetFeedings();

            ConvertedFeedings = new List<FeedingsViewItem>();

            foreach (Feeding feed in feedings)
            {
                var date = feed.Start_Time.ToLocalTime().ToString("MM-dd-yyyy");
                var startTime = feed.Start_Time.ToLocalTime().ToString("h:mm tt");
                var endTime = feed.End_Time.Value.ToLocalTime().ToString("h:mm tt");
                var milk = (feed.Milk_Type == "Breast" ? $"{feed.Milk_Type} Milk" : feed.Milk_Type);
                //var elapsedTime = (feed.End_Time.Value - feed.Start_Time).Duration().TotalMinutes.ToString("%f.2");

                var newItem = new FeedingsViewItem {
                    Name = $"{date}   {startTime} -> {endTime}",
                    Detail = $"{feed.Amount} oz - {milk} - Diaper {feed.Diaper_State}"
                };

                ConvertedFeedings.Add(newItem);
            }
        }
    }
}
