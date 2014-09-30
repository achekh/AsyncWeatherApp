using Android.App;
using Android.OS;
using AsyncWeatherApp.Contracts;
using System.Threading.Tasks;
using AsyncWeatherApp.IO;

namespace AsyncWeatherApp
{
	[Activity (Label = "Weather Activity")]			
	public class WeatherActivity : ListActivity
	{
		async protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			var location = Intent.GetStringExtra("Location");
			var wr = await GetData (location);
            ListAdapter = new WeatherAdapter(this, wr.List);
			Title = wr.Message;
        }

		async Task<WeatherReport> GetData(string location)
		{
		    var openWeatherClient = new OpenWeatherClient();
		    return await openWeatherClient.GetData(location);
		}
	}
}

