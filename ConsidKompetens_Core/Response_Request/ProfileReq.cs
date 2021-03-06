﻿using System.Collections.Generic;
using ConsidKompetens_Core.DTO;
using ConsidKompetens_Core.Models;

namespace ConsidKompetens_Core.Response_Request
{
  public class ProfileReq
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string AboutMe { get; set; }
    public string Position { get; set; }
    public int OfficeModelId { get; set; }
    public string LinkedInUrl { get; set; }
    public string ResumeUrl { get; set; }
    public ushort Experience { get; set; }
    public List<CompetenceModel> Competences{ get; set; }
  }
}
