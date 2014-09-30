using System.Threading.Tasks;
using AsyncWeatherApp.Contracts;

namespace AsyncWeatherApp.IO
{
    public interface IOpenWeatherClient
    {
        Task<WeatherReport> GetData(string location);
    }
}