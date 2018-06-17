﻿using FeedingTracker.Droid;
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
            bool success = false;

            var swBreast = this.FindByName<Switch>("switchBreastMilk");
            var swFormula = this.FindByName<Switch>("switchFormula");
            var swDiaperWet = this.FindByName<Switch>("switchDiaperWet");
            var swDiaperDirty = this.FindByName<Switch>("switchDiaperDirty");
            var swDiaperClean = this.FindByName<Switch>("switchDiaperClean");
            var entAmount = this.FindByName<Entry>("entAmount");

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

            //var picker = this.FindByName<Picker>("pickAmount");
            var amount = double.Parse(entAmount.Text);

            try
            {
                //Log.Logger.Information($"{_startTime},{milkType}, {picker.SelectedItem.ToString()}, {diaperState}, {_stopTime}");
                //Log.CloseAndFlush();

                var feeding = new Feeding();
                feeding.Amount = amount;
                feeding.Date = DateTime.Now.ToString("MM-dd-YYYY");
                feeding.Diaper_State = diaperState;
                feeding.Milk_Type = milkType;
                feeding.Start_Time = _startTime;
                feeding.End_Time = _stopTime;

                if (App.Database.SaveItem(feeding) > 0)
                {
                    success = true;
                    var answer = DisplayAlert("Success", "Feeding saved", "OK");
                }
            }
            catch (Exception ex)
            {
                var answer = DisplayAlert("Error", $"Feeding failed to save. ex = {ex.ToString()}", "OK");
            }

            if (success)
            {
                Navigation.PopToRootAsync();
            }
        }
        
    }
}