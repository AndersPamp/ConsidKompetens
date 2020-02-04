namespace ConsidKompetens_Web.Communication
{
  public class JsonResponse
  {
    public bool Ok { get; set; }
    public string Message { get; set; }
    public dynamic Data { get; set; }
    public int TotalHits { get; set; }
  }
}