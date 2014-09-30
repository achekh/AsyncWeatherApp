
using AsyncWeatherApp.IO;
using TinyIoC;

namespace AsyncWeatherApp.IoC
{
    public static class ContainerBuilder
    {
        public static TinyIoCContainer Build()
        {
            var container = new TinyIoCContainer();

            container.Register<IOpenWeatherClient, OpenWeatherClient>();

            return container;
        }
    }
}