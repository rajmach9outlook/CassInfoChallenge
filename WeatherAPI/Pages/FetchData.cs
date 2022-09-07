using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using WeatherAPI.Core.Data;
using WeatherAPI.Services;

namespace WeatherAPI.Pages
{
  public partial class FetchData
  {
    private bool loading = true;

    private double latitude = -77.0352;
    private double longitude = 38.8894;

    private Weather weatherData;
    private Forecast forecast;

    [Inject]
    public IWeatherDataService WeatherDataService { get; set; }

  }
}
