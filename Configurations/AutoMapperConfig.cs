using AutoMapper;
using CVApplicationsManager.Models;
using CVApplicationsManager.Views;

namespace CVApplicationsManager.Configurations
{
    public class AutoMapperConfig : Profile
    {
        protected internal AutoMapperConfig()
        {
            CreateMap<CvApplicationModel,CvApplicationViewModel>().ReverseMap();
            CreateMap<DegreesModel, DegreesViewModel>().ReverseMap();
        }
    }
}
