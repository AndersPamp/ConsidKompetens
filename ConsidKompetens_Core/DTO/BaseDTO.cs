using System;
using System.Collections.Generic;
using System.Text;

namespace ConsidKompetens_Core.DTO
{
  public class BaseDTO
  {
    public int Id { get; set; }
    public DateTime Created { get; set; }
    public DateTime Modified { get; set; }
  }
}
