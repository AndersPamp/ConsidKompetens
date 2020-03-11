using ConsidKompetens_Core.DTO;
using ConsidKompetens_Core.Models;
using Profile = AutoMapper.Profile;

namespace ConsidKompetens_Services.Mapping
{
  public class ModelToDTOProfile : Profile
  {
    public ModelToDTOProfile()
    {
      CreateMap<CompetenceModel, CompetenceDTO>();
      CreateMap<ImageModel, ImageDTO>();
      CreateMap<OfficeModel, OfficeDTO>();
      CreateMap<ProfileModel, ProfileDTO>();
      CreateMap<ProjectModel, ProjectDTO>();
      CreateMap<RoleModel, RoleDTO>();
      CreateMap<TechniqueModel, TechniqueDTO>();
      CreateMap<TimePeriod, TimePeriodDTO>();
    }
  }
}
