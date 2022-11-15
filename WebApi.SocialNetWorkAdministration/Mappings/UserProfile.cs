using AutoMapper;
using NewsPortal.DAL.Dto;
using NewsPortal.DAL.Request.User;
using Model.Domain;
using NewsPortal.NewsPortal.DAL.Dto;

namespace NewsPortal.WebApi.Mappings
{
    /// <summary>
    /// Mapping profile for "User" entity.
    /// </summary>
    public class UserProfile : Profile
    {
        /// <summary>
        /// Initializes the instance <see cref="UserProfile"/>.
        /// </summary>
        public UserProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserDto, UserResponse>().ReverseMap();
            CreateMap<NewUserRequest, UserDto>().ReverseMap();
            CreateMap<UpdateUserRequest, UserDto>().ReverseMap();
            CreateMap<UserDto, AuthenticatedUserDto>().ReverseMap();
        }
    }
}
