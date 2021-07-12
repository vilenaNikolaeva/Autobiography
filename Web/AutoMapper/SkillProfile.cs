using Autobiography.Domain;
using AutoMapper;
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
