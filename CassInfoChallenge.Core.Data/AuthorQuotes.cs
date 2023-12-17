using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CassInfoChallenge.Core.Data
{
  public class AuthorQuotes
  {
    public Info __info__ { get; set; }
    public int count { get; set; }
    public int totalCount { get; set; }
    public int page { get; set; }
    public int totalPages { get; set; }
    public List<Quote> results { get; set; }
  }

  public class Info
  {
    [JsonProperty("$search")]
    public Search search { get; set; }
  }

  public class QueryString
  {
    public string query { get; set; }
    public string defaultPath { get; set; }
  }

  public class Search
  {
    public QueryString queryString { get; set; }
  }
}
