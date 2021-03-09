using Autobiography.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.ViewModels;

namespace Web.AutoMapper
{
    public class SkillProfile : Profile
    {
        public SkillProfile()
        {
            CreateMap<CreateSkillViewModel, Skill>();
            CreateMap<Skill, CreateSkillViewModel>();

            CreateMap<UpdateSkillViewModel, Skill>();

            CreateMap<Skill, SkillViewModel>();
        }
    }
}
