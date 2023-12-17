using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CassInfoChallenge.Core.Data;

namespace CassInfoChallenge.Services
{
  public interface IQuoteService
  {
    Task<Quote> GetRandomQuote();
    Task<AuthorQuotes> GetQuotes(string author, int limit);
  }
}
