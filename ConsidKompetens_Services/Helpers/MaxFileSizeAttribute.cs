using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace ConsidKompetens_Services.Helpers
{
  public class MaxFileSizeAttribute : ValidationAttribute
  {
    private readonly uint _maxFileSizeAttribute;
    
    private readonly ILogger<MaxFileSizeAttribute> _logger;

    public MaxFileSizeAttribute(uint maxFileSizeAttribute, ILogger<MaxFileSizeAttribute> logger)
    {
      _maxFileSizeAttribute = maxFileSizeAttribute;
      _logger = logger;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
      if (value is IFormFile file)
      {
        if (file.Length > _maxFileSizeAttribute)
        {
          return new ValidationResult(_logger.ToString());
        }
      }
      return ValidationResult.Success;
    }
  }
}