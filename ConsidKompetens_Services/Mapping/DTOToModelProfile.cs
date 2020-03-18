using ConsidKompetens_Core.DTO;
using ConsidKompetens_Core.Models;
using ConsidKompetens_Core.Response_Request;
using Profile = AutoMapper.Profile;

namespace ConsidKompetens_Services.Mapping
{
  public class DTOToModelProfile : Profile
  {
    public DTOToModelProfile()
    {
      CreateMap<CompetenceDto, CompetenceModel > ();
      CreateMap<ImageDto, ImageModel>();
      CreateMap<OfficeDto, OfficeModel>();
      CreateMap<ProfileDto, ProfileModel>();
      CreateMap<ProjectDto, ProjectModel>();
      CreateMap<RoleDto, RoleModel>();
      CreateMap<TechniqueDto, TechniqueModel>();
      CreateMap<TimePeriodDto, TimePeriod>();
      CreateMap<ProfileReq, ProfileModel>();
    }
  }
}
