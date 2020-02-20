using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace ConsidKompetens_Services.Helpers
{
  public class AllowedExtensionsAttribute : ValidationAttribute
  {
    private readonly string[] _extensions;
    private readonly ILogger<AllowedExtensionsAttribute> _logger;

    public AllowedExtensionsAttribute(string[] extensions, ILogger<AllowedExtensionsAttribute> logger)
    {
      _extensions = extensions;
      _logger = logger;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
      var file = value as IFormFile;
      
      if (file!=null)
      {
        var extension = Path.GetExtension(file.FileName);
        if (!_extensions.Contains(extension.ToLower()))
        {
          return new ValidationResult(_logger.ToString());
        }
      }
      return ValidationResult.Success;
    }
  }
}