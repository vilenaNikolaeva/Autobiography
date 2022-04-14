using Autobiography.Domain;
using AutoMapper;
using Web.ViewModels.CoverLetter;

namespace Web.AutoMapper
{
    public class CoverLetterProfile :Profile
    {
        public CoverLetterProfile()
        {
            CreateMap<UpdateCoverLetterVIewModel, CoverLetter>();
            CreateMap<CoverLetter, UpdateCoverLetterVIewModel>();
            CreateMap<CoverLetter, CoverLetterViewModel>();
            CreateMap<CoverLetterViewModel, CoverLetter>();


        }

    }
}
