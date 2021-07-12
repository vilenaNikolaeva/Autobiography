using Autobiography.Domain;
using AutoMapper;
using Web.ViewModels;

namespace Web.AutoMapper
{
    public class ExperienceProfile : Profile
    {
        public ExperienceProfile()
        {
            CreateMap<CreateExperienceViewModel, Experience>();
            CreateMap<Experience, CreateExperienceViewModel>();

            CreateMap<UpdateExperienceViewModel, Experience>();

            CreateMap<Experience, ExperienceViewModel>();
        }
    }
}
