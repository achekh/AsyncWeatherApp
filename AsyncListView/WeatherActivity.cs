using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AsyncListView
{
	[Activity (Label = "Weather Activity")]			
	public class WeatherActivity : ListActivity
	{
		async protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			var location = Intent.GetStringExtra("Location");
			var wr = await GetData (location);
            ListAdapter = new WeatherAdapter(this, wr.list);
			Title = wr.message;
        }

		async Task<WeatherReport> GetData(string location)
		{
            string contents;
            WeatherReport res = new WeatherReport();
            try
            {
				string Url = String.Format("http://api.openweathermap.org/data/2.5/forecast/daily?q={0}&mode=json&units=metric&cnt=14", location);
                HttpClient hc = new HttpClient();
                Task<string> contentsTask = hc.GetStringAsync(Url); // async method!

                // await! control returns to the caller and the task continues to run on another thread
                contents = await contentsTask;
                res = JsonConvert.DeserializeObject<WeatherReport>(contents);
                Parallel.ForEach(res.list, currentWeather =>
                {
                    var url = String.Format("http://openweathermap.org/img/w/{0}.png", currentWeather.weather[0].icon);
                    var imageUrl = new Java.Net.URL(url);
                    Android.Graphics.Bitmap bitmap = Android.Graphics.BitmapFactory.DecodeStream(imageUrl.OpenStream());
                    currentWeather.weather[0].Image = bitmap;
                });
				if(string.IsNullOrWhiteSpace(res.message)) {
					res.message = string.Concat("Weather for ", location,", metric, for 14 days");
				}
            }
            catch (System.Exception sysExc)
            {
                Console.WriteLine(sysExc.Message);
				res.message = "Oops...";
            }
            return res;
        }
	}
}

