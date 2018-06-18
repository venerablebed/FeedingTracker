using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FeedingTracker
{
	public partial class FeedingStart : ContentPage
	{
        private const string _startButtonLabel = "Start Feeding";
        private const string _stopButtonLabel = "Stop Feeding";
        private const string _startTimeLabel = "Start Time";
        private const string _stopTimeLabel = "Stop Time";

        private bool _started = false;

		public FeedingStart()
		{
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ResetControls();
        }

        private void btnStartStop_Clicked(object sender, EventArgs e)
        {
            if (!_started)
            {
                StartFeeding();
            }
            else
            {
                StopFeeding();
            }
        }

        private void ResetControls()
        {
            var lblStartTime = this.FindByName<Label>("lblStartTime");
            lblStartTime.Text = _startTimeLabel;

            var lblStopTime = this.FindByName<Label>("lblStopTime");
            lblStopTime.Text = _stopTimeLabel;

            var btnShowDetails = this.FindByName<Button>("btnShowDetails");
            btnShowDetails.IsVisible = false;

            _started = false;
        }

        private void StartFeeding()
        {
            // set the start label equal to the current time
            var lblStartTime = this.FindByName<Label>("lblStartTime");
            lblStartTime.Text = DateTime.Now.ToString("h:mm tt");

            var btnStop = this.FindByName<Button>("btnStartStop");
            btnStop.Text = _stopButtonLabel;

            _started = true;
        }

        private void StopFeeding()
        {
            // set the stop label equal to the current time
            var lblStopTime = this.FindByName<Label>("lblStopTime");
            lblStopTime.Text = DateTime.Now.ToString("h:mm tt");

            var btnStop = this.FindByName<Button>("btnStartStop");
            btnStop.Text = _startButtonLabel;

            // show button to navigate to next view
            var btnShowDetails = this.FindByName<Button>("btnShowDetails");
            btnShowDetails.IsVisible = true;

            _started = false;
        }

        private void btnShowDetails_Clicked(object sender,EventArgs e)
        {
            var lblStartTime = this.FindByName<Label>("lblStartTime");
            var lblStopTime = this.FindByName<Label>("lblStopTime");
            Navigation.PushAsync(new FeedingDeets(lblStartTime.Text, lblStopTime.Text));
        }

        private void btnViewDetails_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FeedingsView());
        }
    }
}
