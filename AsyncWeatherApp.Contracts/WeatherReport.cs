using System.Collections.Generic;
using Newtonsoft.Json;

namespace AsyncWeatherApp.Contracts
{
    public class WeatherReport
    {
        public WeatherReport()
        {
            List = new List<WeatherDay>();
        }
        [JsonProperty( PropertyName = "cod" )]
        public string Cod { get; set; }
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }
        [JsonProperty(PropertyName = "city")]
        public WeatherCity City { get; set; }
        [JsonProperty(PropertyName = "cnt")]
        public int Cnt { get; set; }
        [JsonProperty(PropertyName = "list")]
        public List<WeatherDay> List { get; set; }
    }

}