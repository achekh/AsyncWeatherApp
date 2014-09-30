using Android.App;
using Android.Runtime;
using AsyncWeatherApp.IoC;
using System;

namespace AsyncWeatherApp
{
    [Application(Debuggable = true, Icon = "@drawable/Icon", Label = "Async Weather Application")]
    class AsyncWeatherApplication : Application
    {
        private TinyIoC.TinyIoCContainer _container;

        public AsyncWeatherApplication(IntPtr ptr, JniHandleOwnership ownership) : base(ptr, ownership)
        { }

        public override void OnCreate()
        {
            base.OnCreate();
            _container = ContainerBuilder.Build();

        }

        public void Inject(object receiver)
        {
            _container.BuildUp(receiver);
        }
    }
}