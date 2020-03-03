using System.Collections.Generic;

namespace ConsidKompetens_Services.Helpers
{
  public class AppSettings
  {
    public string Secret { get; set; }
    public string ImageFilePath { get; set; }
    public string MaxFileSize { get; set; }
    public List<string> AllowedFileExtensions { get; set; }
    public string EmailAPIKey { get; set; }
    public string EmailFromAddress { get; set; }
    public string EmailConfirmSubject { get; set; }
    public string EmailResetSubject { get; set; }
    public string EmailConfirmFilePath { get; set; }
    public string IconFilePath { get; set; }
    
  }
}