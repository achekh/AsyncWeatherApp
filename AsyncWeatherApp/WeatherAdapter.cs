using Android.App;
using Android.Graphics;
using Android.Views;
using Android.Widget;

using System;
using System.Collections.Generic;

using AsyncWeatherApp.Contracts;

namespace AsyncWeatherApp
{
    class WeatherAdapter : BaseAdapter<WeatherDay>
    {
        readonly List<WeatherDay> _wd;
        readonly Activity _context;

        public WeatherAdapter(Activity context, List<WeatherDay> wr) {
            _context = context;
            _wd = wr;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override WeatherDay this[int position] {
            get { return _wd[position]; }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return _wd[position].Weather[0].Description;
        }

        public override int Count {
            get { return _wd.Count; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView 
                ?? _context.LayoutInflater.Inflate(Android.Resource.Layout.ActivityListItem, null); // re-use an existing view, if one is available

            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = _wd[position].Weather[0].Description + Environment.NewLine +
                String.Format("High: {0} Low: {1}", _wd[position].Temp.Max, _wd[position].Temp.Min);
            var ic = view.FindViewById<ImageView>(Android.Resource.Id.Icon);
            ic.SetImageBitmap(new Func<byte[], Bitmap>(arr => BitmapFactory.DecodeByteArray(arr, 0, arr.Length))(_wd[position].Weather[0].Image));
            return view;
        }
    }
}