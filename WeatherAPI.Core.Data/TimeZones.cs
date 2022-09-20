using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace WeatherAPI.Core.Data.Timezone
{
  public class Context
  {
    [JsonProperty("@version")]
    public string Version { get; set; }
  }

  public class Feature
  {
    public string id { get; set; }
    public string type { get; set; }
    public object geometry { get; set; }
    public Properties properties { get; set; }
  }

  public class Properties
  {
    [JsonProperty("@id")]
    public string Id { get; set; }

    [JsonProperty("@type")]
    public string Type { get; set; }
    public string id { get; set; }
    public string type { get; set; }
    public string name { get; set; }
    public DateTime effectiveDate { get; set; }
    public DateTime expirationDate { get; set; }
    public string state { get; set; }
    public List<string> cwa { get; set; }
    public List<string> forecastOffices { get; set; }
    public List<string> timeZone { get; set; }
    public object observationStations { get; set; }
    public string radarStation { get; set; }
  }

  public class TimeZones
  {
    [JsonProperty("@context")]
    public Context Context { get; set; }
    public string type { get; set; }
    public List<Feature> features { get; set; }
  }
}