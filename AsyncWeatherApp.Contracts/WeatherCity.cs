using System.Collections.Generic;
using Newtonsoft.Json;

namespace AsyncWeatherApp.Contracts
{
    public class WeatherCity
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "coord")]
        public Coord Location { get; set; }
    }

    public class Coord
    {
        [JsonProperty(PropertyName = "lat")]
        public float Lat { get; set; }
        [JsonProperty(PropertyName = "lon")]
        public float Lon { get; set; }
    }

    public class WeatherDay
    {
        public WeatherDay(){
            Weather = new List<Weatherinfo>();
        }
        [JsonProperty(PropertyName = "dt")]
        public int Dt { get; set; }
        [JsonProperty(PropertyName = "temp")]
        public Temps Temp { get; set; }
        [JsonProperty(PropertyName = "pressure")]
        public float Pressure { get; set; }
        [JsonProperty(PropertyName = "humidity")]
        public int Humidity { get; set; }
        [JsonProperty(PropertyName = "weather")]
        public List<Weatherinfo> Weather { get; set; }
    }

    public class Temps
    {
        [JsonProperty(PropertyName = "day")]
        public float Day { get; set; }
        [JsonProperty(PropertyName = "night")]
        public float Night { get; set; }
        [JsonProperty(PropertyName = "min")]
        public float Min { get; set; }
        [JsonProperty(PropertyName = "max")]
        public float Max { get; set; }
        [JsonProperty(PropertyName = "eve")]
        public float Eve { get; set; }
        [JsonProperty(PropertyName = "morn")]
        public float Morn { get; set; }
    }

    public class Weatherinfo
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "main")]
        public string Main { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "icon")]
        public string Icon { get; set; }
        [JsonIgnore]
        public byte[] Image { get; set; }
    }
}