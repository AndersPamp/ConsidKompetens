using System.Collections.Generic;

namespace ConsidKompetens_Core.Response_Request
{
  public class SearchRequest
  {
    public List<int> OfficeIds { get; set; }
    public string Input { get; set; }
  }
}