using AutoMapper;
using Strider.Application.ViewModels;
using Strider.Common;
using Strider.Domain.Models;

namespace Strider.Application.AutoMapperConfig
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap(typeof(Result<>), typeof(Result<>));
            CreateMap<CreatePostViewModel, PostModel>();
            CreateMap<CreateRepostViewModel, PostModel>();
            CreateMap<PostViewModel, PostModel>();
            CreateMap<PostModel, PostViewModel>().ForMember(x => x.DateCreated, opt => opt.MapFrom(x => x.DateCreated.ToString("MMMM dd, yyyy")));
            CreateMap<UserModel, UserViewModel>().ForMember(x => x.DateJoined, opt => opt.MapFrom(x => x.DateJoined.ToString("MMMM dd, yyyy")));
            CreateMap<UserFollowModel, UserFollowViewModel>();
            CreateMap<CreateUserViewModel, UserModel>().ReverseMap();
        }
    }
}
