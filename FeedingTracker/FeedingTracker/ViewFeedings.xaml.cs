using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FeedingTracker
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ViewFeedings : ContentView
	{
		public ViewFeedings ()
		{
			InitializeComponent ();
		}
	}
}