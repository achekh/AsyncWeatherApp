using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace AsyncListView
{
	[Activity (Label = "Async ListView", MainLauncher = true)]
	public class MainActivity : Activity
	{
		EditText et;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.CitySelect);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.select);
			et = FindViewById<EditText>(Resource.Id.location);

			button.Click += delegate {
				string location = Convert.ToString(et.Text);
				if (!String.IsNullOrEmpty(location))
				{
					Intent i = new Intent();
					i.SetClass(this, typeof(WeatherActivity));
					i.AddFlags(ActivityFlags.NewTask);
					i.PutExtra("Location", location);
					StartActivity(i);
				}			
			};
		}
	}
}


