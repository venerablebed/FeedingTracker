using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace FeedingTracker.Droid
{
    class ViewFeedingsAdapter : BaseAdapter<Feeding>
    {
        Feeding[] _feedings;
        Activity context;

        public ViewFeedingsAdapter(Activity context, Feeding[] items) : base()
        {
            this.context = context;
            _feedings = items;
        }

        public override Feeding this[int position]
        {
            get
            {
                return _feedings[position];
            }
        }

        public override int Count {
            get { return _feedings.Length; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView; // re-use an existing view, if one is available
            if (view == null) // otherwise create a new one
                view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem2, null);
            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = GetLine1Text(_feedings[position]);
            view.FindViewById<TextView>(Android.Resource.Id.Text2).Text = GetLine2Text(_feedings[position]);
            return view;
        }

        string GetLine1Text(Feeding currentFeeding)
        {
            return $"{currentFeeding.Date} {currentFeeding.Start_Time} - {currentFeeding.End_Time}";
        }

        string GetLine2Text(Feeding currentFeeding)
        {
            return $"{currentFeeding.Milk_Type}, {currentFeeding.Amount.ToString()}, {currentFeeding.Diaper_State}";
        }
    }
}