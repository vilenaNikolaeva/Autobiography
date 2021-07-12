using Autobiography.Domain;
using AutoMapper;
using Web.ViewModels;

namespace Web.AutoMapper
{
    public class EducationProfile : Profile
    {
        public EducationProfile()
        {
            CreateMap<CreateEducationViewModel, Education>();
            CreateMap<Education, CreateEducationViewModel>();

            CreateMap<UpdateEducationViewModel, Education>();

            CreateMap<Education, EducationViewModel>();
        }
    }
}
