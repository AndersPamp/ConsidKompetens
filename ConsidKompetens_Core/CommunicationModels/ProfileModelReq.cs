using ConsidKompetens_Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsidKompetens_Core.CommunicationModels
{
  public class ProfileModelReq
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string AboutMe { get; set; }
    public string Title { get; set; }
    public int OfficeId { get; set; }
    public string LinkedInUrl { get; set; }
    public string ResumeUrl { get; set; }
    public ushort Experience { get; set; }
    public List<CompetenceModel> Competences{ get; set; }
  }
}
