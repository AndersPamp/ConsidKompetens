using System.ComponentModel.DataAnnotations.Schema;

namespace ConsidKompetens_Core.DTO
{
  public class CompetenceDto:BaseDto
  {
    public int CompId { get; set; }
    
    public string Value { get; set; }
  }
}
