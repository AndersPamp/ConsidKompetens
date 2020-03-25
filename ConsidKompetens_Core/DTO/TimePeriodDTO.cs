using System;

namespace ConsidKompetens_Core.DTO
{
  public class TimePeriodDto:BaseDto
  {
    public DateTime Start { get; set; }
    public DateTime Stop { get; set; }
  }
}
