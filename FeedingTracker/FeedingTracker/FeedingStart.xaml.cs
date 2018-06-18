using FeedingTracker.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FeedingTracker
{
	public partial class FeedingStart : ContentPage
	{
        private const string _startButtonLabel = "Start Feeding";
        private const string _stopButtonLabel = "Stop Feeding";
        private const string _startTimeLabel = "Start Time";
        
        Label _lblStartTime;        
        Button _btnStartStop;
        Feeding _inProgressFeeding = null;

        private bool _started = false;

		public FeedingStart()
		{
            InitializeComponent();
            
            _lblStartTime = this.FindByName<Label>("lblStartTime");        
            _btnStartStop = this.FindByName<Button>("btnStartStop");            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            if (CheckForInProgressFeedings() == false)
            {
                ResetControls();
            }
        }

        private void btnStartStop_Clicked(object sender, EventArgs e)
        {
            if (!_started)
            {
                StartFeeding(DateTime.Now);
            }
            else
            {
                StopFeeding();
            }
        }

        private void ResetControls()
        {            
            lblStartTime.Text = _startTimeLabel;                           
            _started = false;
        }

        private void StartFeeding(DateTime startDatetime)
        {            
            _lblStartTime.Text = $"Feeding started at {startDatetime.ToLocalTime().ToString("MM-dd-yyyy h:mm tt")}";            
            _btnStartStop.Text = _stopButtonLabel;

            if (_inProgressFeeding == null)
            {
                SaveStartedFeeding(startDatetime);
            }            

            _started = true;
        }

        private void StopFeeding()
        {
            var stopDatetime = DateTime.Now;            
            _btnStartStop.Text = _startButtonLabel;

            _started = false;

            _inProgressFeeding.End_Time = stopDatetime;
            
            Navigation.PushAsync(new FeedingDeets(_inProgressFeeding));            
        }

        private void btnViewDetails_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FeedingsView());
        }

        void SaveStartedFeeding(DateTime startDatetime)
        {
            var newFeeding = new Feeding();
            newFeeding.Start_Time = startDatetime;

            _inProgressFeeding = newFeeding;

            App.Database.SaveItem(_inProgressFeeding);
        }

        bool CheckForInProgressFeedings()
        {
            var inProgressFeedings = App.Database.GetInProgressFeedings();

            if (inProgressFeedings != null && inProgressFeedings.Count > 0)
            {
                _inProgressFeeding = inProgressFeedings[0];
                StartFeeding(_inProgressFeeding.Start_Time);

                return true;
            }

            return false;
        }
    }
}
