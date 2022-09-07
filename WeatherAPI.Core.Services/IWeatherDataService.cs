using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherAPI.Core.Data;

namespace WeatherAPI.Services
{
  public interface IWeatherDataService
  {
    Task<Weather> GetWeather(double longitude, double latitude);

    Task<Forecast> GetForecast(string uri);
  }
}
