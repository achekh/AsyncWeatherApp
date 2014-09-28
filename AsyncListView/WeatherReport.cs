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
    class WeatherReport
    {
        public WeatherReport()
        {
            list = new List<WeatherDay>();
        }
        [JsonProperty( PropertyName = "cod" )]
        public string cod { get; set; }
        [JsonProperty(PropertyName = "message")]
        public string message { get; set; }
        [JsonProperty(PropertyName = "city")]
        public WeatherCity city { get; set; }
        [JsonProperty(PropertyName = "cnt")]
        public int cnt { get; set; }
        [JsonProperty(PropertyName = "list")]
        public List<WeatherDay> list { get; set; }
    }

}