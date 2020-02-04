using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace ConsidKompetens_Web.Communication
{
  public class PageType
  {
    public string Url { get; set; }
    public bool Ok { get; set; }
    public HttpStatusCode Status { get; set; }
    public dynamic Framework { get; set; }

  }
}