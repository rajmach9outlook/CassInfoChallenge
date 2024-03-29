using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CassInfoChallenge.Services;

namespace CassInfoChallenge
{
  public class Program
  {
    public static async Task Main(string[] args)
    {
      var builder = WebAssemblyHostBuilder.CreateDefault(args);
      builder.RootComponents.Add<App>("app");

      //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
      builder.Services.AddHttpClient<IQuoteService, QuoteService>(client => client.BaseAddress = new Uri("https://api.quotable.io/"));
      builder.Services.AddHttpClient<IShipperDataService, ShipperDataService>(client => client.BaseAddress = new Uri("http://localhost:54251/"));

      await builder.Build().RunAsync();
    }
  }
}
