namespace ConsidKompetens_Core.Models
{
  public class ResponseModel
  {
    public bool Success { get; set; }
    public string ErrorMessage { get; set; }
    public string BearerToken { get; set; }
    public ResponseData Data { get; set; }
  }
}