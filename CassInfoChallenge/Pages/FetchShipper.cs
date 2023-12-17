using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using CassInfoChallenge.Core.Data;
using CassInfoChallenge.Services;

namespace CassInfoChallenge.Pages
{
  public partial class FetchShipper
  {
    private bool loading = true;

    public IEnumerable<Shipper> Shippers { get; set; }

    [Inject]
    public IShipperDataService ShipperService { get; set; }

    protected override async Task OnInitializedAsync()
    {
      await SearchShippers();
    }
  }
}
