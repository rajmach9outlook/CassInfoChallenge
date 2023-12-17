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
  public partial class FetchShipments
  {
    private bool loading = true;

    [Parameter]
    public int shipperid { get; set; }
    public IEnumerable<ShipperShipmentDetail> Shipments { get; set; }

    [Inject]
    public IShipperDataService ShipperService { get; set; }

    protected override async Task OnInitializedAsync()
    {
      await SearchShipments();
    }
  }
}