using Android.App;
using Android.OS;
using AsyncWeatherApp.Contracts;
using System.Threading.Tasks;
using AsyncWeatherApp.IO;
using AsyncWeatherApp.IoC;

namespace AsyncWeatherApp
{
	[Activity (Label = "Weather Activity")]			
	public class WeatherActivity : BaseListActivity
    {
        #region injected

        public IOpenWeatherClient WeatherClient { get; set; }

        #endregion

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
		    return await WeatherClient.GetData(location);
		}
	}
}

