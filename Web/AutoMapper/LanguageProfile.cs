using Autobiography.Domain;
using AutoMapper;
using Web.ViewModels;

namespace Web.AutoMapper
{
    public class LanguageProfile : Profile
    {
        public LanguageProfile()
        {
            CreateMap<CreateLanguageViewModel, Language>();
            CreateMap<Language, CreateLanguageViewModel>();

            CreateMap<UpdateLanguageViewModel, Language>();

            CreateMap<Language, LanguageViewModel>();

        }
    }
}
