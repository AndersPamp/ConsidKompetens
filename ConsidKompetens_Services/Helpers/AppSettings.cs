using System.Collections.Generic;

namespace ConsidKompetens_Services.Helpers
{
  public class AppSettings
  {
    public string Secret { get; set; }
    public string ImageFilePath { get; set; }
    public string MaxFileSize { get; set; }
    //public List<string> FileExtensions { get; set; }
  }
}