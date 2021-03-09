using Autobiography.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
