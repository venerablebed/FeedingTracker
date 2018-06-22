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
    public class PumpingsViewItem
    {
        public string Name { get; set; }
        public string Detail { get; set; }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PumpingsView : ContentPage
	{
        public List<PumpingsViewItem> ConvertedPumpings { get; set; }

        public PumpingsView()
        {
            InitializeComponent();

            CreateFeedingDict();

            MyListView.ItemsSource = ConvertedPumpings;
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
            var pumpings = App.Database.GetPumpings();

            ConvertedPumpings = new List<PumpingsViewItem>();

            foreach (Pumping pump in pumpings)
            {
                var newItem = new PumpingsViewItem
                {
                    Name = $"{pump.Time.ToLocalTime().ToString("MM-dd-yyyy h:mm tt")}",
                    Detail = $"{pump.Amount} oz"
                };

                ConvertedPumpings.Add(newItem);
            }
        }

    }
}