using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using WeatherAPI.Core.Data;

namespace WeatherAPI.Services
{
  public class WeatherDataService : IWeatherDataService
  {
    private readonly HttpClient _httpClient;

    public WeatherDataService(HttpClient httpClient)
    {
      _httpClient = httpClient;
    }

    public async Task<Weather> GetWeather(double longitude, double latitude)
    {
      HttpResponseMessage response = await _httpClient.GetAsync($"points/{latitude},{longitude}");

      if (!response.IsSuccessStatusCode) return null;

      var stream = await response.Content.ReadAsStreamAsync();

      return await JsonSerializer.DeserializeAsync<Weather> (stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
    }

    public async Task<Forecast> GetForecast(string uri)
    {
      HttpResponseMessage response = await _httpClient.GetAsync(uri);

      if (!response.IsSuccessStatusCode) return null;

      var stream = await response.Content.ReadAsStreamAsync();

      return await JsonSerializer.DeserializeAsync<Forecast> (stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
    }
  }
}
