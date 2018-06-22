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
	public partial class PumpingDeets : ContentPage
	{
        public PumpingDeets()
        {
            InitializeComponent();
        }

        private void btnSavePumping_Clicked(object sender, EventArgs e)
        {
            bool success = false;
            var newPumping = new Pumping();
            var entAmount = this.FindByName<Entry>("entAmount");
            var amount = double.Parse(entAmount.Text);

            try
            {
                newPumping.Amount = amount;
                newPumping.Time = DateTime.Now;

                if (App.Database.SavePumping(newPumping) > 0)
                {
                    success = true;
                    var answer = DisplayAlert("Success", "Pumping saved", "OK");
                }
            }
            catch (Exception ex)
            {
                var answer = DisplayAlert("Error", $"Pumping failed to save. ex = {ex.ToString()}", "OK");
            }

            if (success)
            {
                Navigation.PopToRootAsync();
            }
        }
    }
}