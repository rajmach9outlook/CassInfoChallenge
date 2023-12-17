using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CassInfoChallenge.Core.Data
{
  public class Quote
  {
    public string _id { get; set; }
    public string content { get; set; }
    public string author { get; set; }
    public List<string> tags { get; set; }
    public string authorId { get; set; }
    public string authorSlug { get; set; }
    public int length { get; set; }
    public string dateAdded { get; set; }
    public string dateModified { get; set; }

    public string Group
    {
      get {
        if (WordCount <= 10)
          return "Short";
        else if (WordCount > 10 && WordCount <= 20)
          return "Medium";
        else return "Long";
      }
    }

    public int WordCount
    {
      get
      {
        string[] subs = content.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        return subs.Length;
      }
    }
  } 
}
