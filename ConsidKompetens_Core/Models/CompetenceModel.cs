using System.ComponentModel.DataAnnotations.Schema;

namespace ConsidKompetens_Core.Models
{
  public class CompetenceModel : BaseEntity
  {
    public int CompId { get; set; } = 0;
    // [ForeignKey("ProfileModel")]
    // public int ProfileModelFK { get; set; }
    public string Value { get; set; }

  }
}
