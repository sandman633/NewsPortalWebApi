using AutoMapper;
using DAL.Dto;
using DAL.Request.UserGroup;
using DAL.Response.UserGroup;
using Model.Domain;

namespace Repositories.Mappings
{
    public class UserGroupProfile : Profile
    {
        /// <summary>
        /// Initializes the instance <see cref="UserGroupProfile"/>.
        /// </summary>
        public UserGroupProfile()
        {
            CreateMap<UserGroup, UserGroupDto>().ReverseMap();
            CreateMap<UserGroupDto, UserGroupResponse>().ReverseMap();
            CreateMap<NewUserGroupRequest, UserGroupDto>().ReverseMap();
            CreateMap<UpdateUserGroupRequest, UserGroupDto>().ReverseMap();
        }
    }
}
