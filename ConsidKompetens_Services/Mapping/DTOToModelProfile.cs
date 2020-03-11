using ConsidKompetens_Core.DTO;
using ConsidKompetens_Core.Models;
using Profile = AutoMapper.Profile;

namespace ConsidKompetens_Services.Mapping
{
  public class DTOToModelProfile : Profile
  {
    public DTOToModelProfile()
    {
      CreateMap<CompetenceDTO, CompetenceModel > ();
      CreateMap<ImageDTO, ImageModel>();
      CreateMap<OfficeDTO, OfficeModel>();
      CreateMap<ProfileDTO, ProfileModel>();
      CreateMap<ProjectDTO, ProjectModel>();
      CreateMap<RoleDTO, RoleModel>();
      CreateMap<TechniqueDTO, TechniqueModel>();
      CreateMap<TimePeriodDTO, TimePeriod>();
    }
  }
}
