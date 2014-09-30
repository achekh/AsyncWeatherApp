
using Android.App;
using Android.OS;

namespace AsyncWeatherApp.IoC
{
    class BaseActivity: Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            ((AsyncWeatherApplication)Application).Inject(this);
        }
    }

    public class BaseListActivity : ListActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            ((AsyncWeatherApplication)Application).Inject(this);
        }
    }

}