using Autobiography.Domain;
using AutoMapper;
using Web.ViewModels;

namespace Web.AutoMapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserViewModel, User>();
            CreateMap<User, CreateUserViewModel>();
            CreateMap<User, UpdateUserViewModel>();
            CreateMap<UpdateUserViewModel, User>();

        }
    }
}
