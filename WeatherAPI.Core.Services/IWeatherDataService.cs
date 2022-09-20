using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherAPI.Core.Data;
using WeatherAPI.Core.Data.Timezone;

namespace WeatherAPI.Services
{
  public interface IWeatherDataService
  {
    Task<Weather> GetWeather(double longitude, double latitude);

    Task<Forecast> GetWeather(string timeZone);

    Task<Forecast> GetForecast(string uri);

    Task<TimeZones> GetTimezones();
  }
}
