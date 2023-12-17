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
  public partial class FetchQuote
  {
    private bool loading = true;

    private double latitude = -77.0352;
    private double longitude = 38.8894;

    private Quote quoteData;
    //private Forecast forecast;

    [Inject]
    public IQuoteService QuoteService { get; set; }

  }
}
