using System;

namespace ConsidKompetens_Core.Models
{
  public class TimePeriod : BaseEntity
  {
    public DateTime Start { get; set; }
    public DateTime Stop { get; set; }
  }
}