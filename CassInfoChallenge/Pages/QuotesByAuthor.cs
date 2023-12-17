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
  public partial class QuotesByAuthor
  {
    private bool loading = true;

    public AuthorQuotes Quotes { get; set; }

    [Inject]
    public IQuoteService QuoteService { get; set; }

    protected override async Task OnInitializedAsync()
    {
      await SearchQuotes();
    }
  }
}
