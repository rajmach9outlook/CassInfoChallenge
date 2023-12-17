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
  public class QuoteService : IQuoteService
  {
    private readonly HttpClient _httpClient;

    public QuoteService(HttpClient httpClient)
    {
      _httpClient = httpClient;
    }
    
    /// <summary>
    /// Get random quote
    /// </summary>
    /// <returns></returns>
    public async Task<Quote> GetRandomQuote()
    {
      HttpResponseMessage response = await _httpClient.GetAsync($"random");

      if (!response.IsSuccessStatusCode) return null;

      var stream = await response.Content.ReadAsStreamAsync();

      return await JsonSerializer.DeserializeAsync<Quote>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
    }

    /// <summary>
    /// Get quotes by author
    /// </summary>
    /// <returns></returns>
    public async Task<AuthorQuotes> GetQuotes(string author, int limit)
    {
      HttpResponseMessage response = await _httpClient.GetAsync($"search/quotes?query=author:{author}&limit={limit}");

      if (!response.IsSuccessStatusCode) return null;

      var stream = await response.Content.ReadAsStreamAsync();

      return await JsonSerializer.DeserializeAsync<AuthorQuotes>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
    }
  }
}
