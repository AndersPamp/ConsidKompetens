namespace ConsidKompetens_Core.Response_Request
{
  public class Response
  {
    public bool Success { get; set; }
    public dynamic ErrorMessage { get; set; }
    public string BearerToken { get; set; }
    public ResponseData Data { get; set; }
  }
}