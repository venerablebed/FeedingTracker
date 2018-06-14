using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FeedingTracker
{
	public partial class FeedingDeets : ContentPage
	{

        public bool BreastMilk { get; set; }
        public bool Formula { get; set; }
        public bool DiaperWet { get; set; }
        public bool DiaperDirty { get; set; }
        public bool DiaperClean { get; set; }

        private string _startTime;
        private string _stopTime;    

        public FeedingDeets (string start, string stop)
		{
            InitializeComponent();

            _startTime = start;
            _stopTime = stop;
        }

        private void btnSaveFeeding_Clicked(object sender, EventArgs e)
        {
            var swBreast = this.FindByName<Switch>("switchBreastMilk");
            var swFormula = this.FindByName<Switch>("switchFormula");
            var swDiaperWet = this.FindByName<Switch>("switchDiaperWet");
            var swDiaperDirty = this.FindByName<Switch>("switchDiaperDirty");
            var swDiaperClean = this.FindByName<Switch>("switchDiaperClean");

            string milkType = string.Empty;
            string diaperState = string.Empty;

            if (swBreast.IsToggled)
            {
                milkType = "Breast";
            }

            if (swFormula.IsToggled)
            {
                milkType = "Formula";
            }

            if (swDiaperClean.IsToggled)
            {
                diaperState = "Clean";
            }

            if (swDiaperWet.IsToggled)
            {
                diaperState = "Wet";
            }

            if (swDiaperDirty.IsToggled)
            {
                if (!string.IsNullOrEmpty(diaperState))
                {
                    diaperState = $"{diaperState} and Dirty";
                }
                else
                {
                    diaperState = "Dirty";
                }
            }

            var picker = this.FindByName<Picker>("pickAmount");

            try
            {
                //Log.Logger.Information($"{_startTime},{milkType}, {picker.SelectedItem.ToString()}, {diaperState}, {_stopTime}");
                //Log.CloseAndFlush();

                App.Database.
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception writing feeding record: {ex}");
            }

            Navigation.PopToRootAsync();
        }
        
    }
}