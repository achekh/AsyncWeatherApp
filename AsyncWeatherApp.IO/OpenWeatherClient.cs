using System.Net.Http;
using AsyncWeatherApp.Contracts;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace AsyncWeatherApp.IO
{
    public class OpenWeatherClient : IOpenWeatherClient
    {
        private const string ForecastQuery =
            "http://api.openweathermap.org/data/2.5/forecast/daily?q={0}&mode=json&units=metric&cnt=14";

        private const string IconQuery = "http://openweathermap.org/img/w/{0}.png";

        public async Task<WeatherReport> GetData(string location)
        {
            var res = new WeatherReport();
            try
            {
                var url = string.Format(ForecastQuery, location);
                var hc = new HttpClient();
                Task<string> contentsTask = hc.GetStringAsync(url); // async method!

                // await! control returns to the caller and the task continues to run on another thread
                string contents = await contentsTask;
                res = JsonConvert.DeserializeObject<WeatherReport>(contents);
                foreach (var weatherDay in res.List)
                {
                    var iconUrl = String.Format(IconQuery, weatherDay.Weather[0].Icon);
                    weatherDay.Weather[0].Image = await hc.GetByteArrayAsync(iconUrl);
                }

                if (string.IsNullOrWhiteSpace(res.Message))
                {
                    res.Message = string.Concat("Weather for ", location, ", metric, for 14 days");
                }
            }
            catch (Exception sysExc)
            {
                res.Message = string.Concat("Oops... ", sysExc.Message);
            }
            return res;
        }
        

    }
}
