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

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace AsyncListView
{
    class WeatherCity
    {
        public WeatherCity() {
        }
        [JsonProperty(PropertyName = "id")]
        public string id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string name { get; set; }
        [JsonProperty(PropertyName = "coord")]
        public coord location { get; set; }
    }
    class coord
    {
        [JsonProperty(PropertyName = "lat")]
        public float lat { get; set; }
        [JsonProperty(PropertyName = "lon")]
        public float lon { get; set; }
    }
    class WeatherDay
    {
        public WeatherDay(){
            weather = new List<weatherinfo>();
        }
        [JsonProperty(PropertyName = "dt")]
        public int dt { get; set; }
        [JsonProperty(PropertyName = "temp")]
        public temps temp { get; set; }
        [JsonProperty(PropertyName = "pressure")]
        public float pressure { get; set; }
        [JsonProperty(PropertyName = "humidity")]
        public int humidity { get; set; }
        [JsonProperty(PropertyName = "weather")]
        public List<weatherinfo> weather { get; set; }
    }
    class temps
    {
        [JsonProperty(PropertyName = "day")]
        public float day { get; set; }
        [JsonProperty(PropertyName = "night")]
        public float night { get; set; }
        [JsonProperty(PropertyName = "min")]
        public float min { get; set; }
        [JsonProperty(PropertyName = "max")]
        public float max { get; set; }
        [JsonProperty(PropertyName = "eve")]
        public float eve { get; set; }
        [JsonProperty(PropertyName = "morn")]
        public float morn { get; set; }
    }
    class weatherinfo
    {
        [JsonProperty(PropertyName = "id")]
        public int id { get; set; }
        [JsonProperty(PropertyName = "main")]
        public string main { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string description { get; set; }
        [JsonProperty(PropertyName = "icon")]
        public string icon { get; set; }
        public Android.Graphics.Bitmap Image { get; set; }
    }
}