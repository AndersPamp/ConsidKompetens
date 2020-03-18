using ConsidKompetens_Core.DTO;
using ConsidKompetens_Core.Models;
using Profile = AutoMapper.Profile;

namespace ConsidKompetens_Services.Mapping
{
  public class ModelToDTOProfile : Profile
  {
    public ModelToDTOProfile()
    {
      CreateMap<CompetenceModel, CompetenceDto>();
      CreateMap<ImageModel, ImageDto>();
      CreateMap<OfficeModel, OfficeDto>();
      CreateMap<ProfileModel, ProfileDto>();
      CreateMap<ProjectModel, ProjectDto>();
      CreateMap<RoleModel, RoleDto>();
      CreateMap<TechniqueModel, TechniqueDto>();
      CreateMap<TimePeriod, TimePeriodDto>();
    }
  }
}
