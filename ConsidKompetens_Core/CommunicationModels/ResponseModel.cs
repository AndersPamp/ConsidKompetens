namespace ConsidKompetens_Core.CommunicationModels
{
  public class ResponseModel
  {
    public bool Success { get; set; }
    public dynamic ErrorMessage { get; set; }
    public string BearerToken { get; set; }
    public ResponseData Data { get; set; }
  }
}