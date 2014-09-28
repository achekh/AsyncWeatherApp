using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AsyncListView
{
    class WeatherAdapter : BaseAdapter<WeatherDay>
    {
        List<WeatherDay> _wd;
        Activity _context;
        public WeatherAdapter(Activity context, List<WeatherDay> wr) : base() {
            this._context = context;
            this._wd = wr;
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
            return _wd[position].weather[0].description;
        }
        public override int Count {
            get { return _wd.Count; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView; // re-use an existing view, if one is available
            if (view == null) // otherwise create a new one
                view = _context.LayoutInflater.Inflate(Android.Resource.Layout.ActivityListItem, null);
            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = _wd[position].weather[0].description + System.Environment.NewLine +
                String.Format("High: {0} Low: {1}", _wd[position].temp.max, _wd[position].temp.min);
            var ic = view.FindViewById<ImageView>(Android.Resource.Id.Icon);
            ic.SetImageBitmap(_wd[position].weather[0].Image);
            return view;
        }
    }
}