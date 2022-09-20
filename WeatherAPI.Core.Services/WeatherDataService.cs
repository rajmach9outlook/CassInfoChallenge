using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using WeatherAPI.Core.Data;
using WeatherAPI.Core.Data.Timezone;

namespace WeatherAPI.Services
{
  public class WeatherDataService : IWeatherDataService
  {
    private readonly HttpClient _httpClient;

    public WeatherDataService(HttpClient httpClient)
    {
      _httpClient = httpClient;
    }

    /// <summary>
    /// Get weather data using longitude and latitude
    /// </summary>
    /// <param name="longitude"></param>
    /// <param name="latitude"></param>
    /// <returns></returns>
    public async Task<Weather> GetWeather(double longitude, double latitude)
    {
      HttpResponseMessage response = await _httpClient.GetAsync($"points/{latitude},{longitude}");

      if (!response.IsSuccessStatusCode) return null;

      var stream = await response.Content.ReadAsStreamAsync();

      return await JsonSerializer.DeserializeAsync<Weather> (stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
    }

    /// <summary>
    /// Get weather forecast using zone id
    /// </summary>
    /// <param name="zone">Zone ID</param>
    /// <returns></returns>
    public async Task<Forecast> GetWeather(string zone)
    {
      HttpResponseMessage response = await _httpClient.GetAsync($"zones/public/{zone}/forecast");

      if (!response.IsSuccessStatusCode) return null;

      var stream = await response.Content.ReadAsStreamAsync();

      return await JsonSerializer.DeserializeAsync<Forecast>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
    }

    /// <summary>
    /// Get weather forecase using uri
    /// </summary>
    /// <param name="uri">API URL</param>
    /// <returns></returns>
    public async Task<Forecast> GetForecast(string uri)
    {
      HttpResponseMessage response = await _httpClient.GetAsync(uri);

      if (!response.IsSuccessStatusCode) return null;

      var stream = await response.Content.ReadAsStreamAsync();

      return await JsonSerializer.DeserializeAsync<Forecast> (stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
    }

    /// <summary>
    /// Get all the zones info
    /// </summary>
    /// <returns></returns>
    public async Task<TimeZones> GetZones()
    {
      HttpResponseMessage response = await _httpClient.GetAsync("zones?type=public");

      if (!response.IsSuccessStatusCode) return null;

      var stream = await response.Content.ReadAsStreamAsync();

      return await JsonSerializer.DeserializeAsync<TimeZones>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = false });
    }
  }
}
