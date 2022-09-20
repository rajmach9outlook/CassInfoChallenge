using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using WeatherAPI.Core.Data;
using WeatherAPI.Core.Data.Timezone;
using WeatherAPI.Services;

namespace WeatherAPI.Pages
{
  public partial class TimezoneForecast
  {
    private bool loading = true;

    private Forecast forecast;

    private List<Feature> timezones = new List<Feature>();

    private string zoneid = string.Empty;

    [Inject]
    public IWeatherDataService WeatherDataService { get; set; }

    protected override async Task OnInitializedAsync()
    {
      TimeZones timezoneInfo = await WeatherDataService.GetZones();

      if (timezoneInfo == null) return;

      timezones.AddRange(timezoneInfo.features);
    }
  }
}
