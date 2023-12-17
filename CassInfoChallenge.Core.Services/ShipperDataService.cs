using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using CassInfoChallenge.Core.Data;

namespace CassInfoChallenge.Services
{
  public class ShipperDataService : IShipperDataService
  {
    private readonly HttpClient _httpClient;

    public ShipperDataService(HttpClient httpClient)
    {
      _httpClient = httpClient;
    }

    public async Task<IEnumerable<Shipper>> GetAllShippers()
    {
      return await JsonSerializer.DeserializeAsync<IEnumerable<Shipper>>
                   (await _httpClient.GetStreamAsync($"api/shippers"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
    }

    public async Task<IEnumerable<ShipperShipmentDetail>> GetShipperShipmentsDetail(int id)
    {
      return await JsonSerializer.DeserializeAsync<IEnumerable<ShipperShipmentDetail>>
                   (await _httpClient.GetStreamAsync($"api/shippers/{id}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
    }
  }
}
