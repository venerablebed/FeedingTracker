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
        public ObservableCollection<string> Items { get; set; }
        public List<FeedingsViewItem> ConvertedFeedings { get; set; }

        public FeedingsView()
        {
            InitializeComponent();

            CreateFeedingDict();

            Items = new ObservableCollection<string>
            {
                "Item 1",
                "Item 2",
                "Item 3",
                "Item 4",
                "Item 5"
            };
			
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
            var feedings = App.Database.GetItems();

            ConvertedFeedings = new List<FeedingsViewItem>();

            foreach (Feeding feed in feedings)
            {
                var newItem = new FeedingsViewItem {
                    Name = $"{feed.Date} {feed.Start_Time} - {feed.End_Time}",
                    Detail = $"{feed.Amount} oz - {feed.Milk_Type} - {feed.Diaper_State}"
                };

                ConvertedFeedings.Add(newItem);
            }
        }
    }
}
