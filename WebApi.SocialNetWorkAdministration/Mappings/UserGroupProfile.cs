using AutoMapper;
using NewsPortal.DAL.Dto;
using NewsPortal.DAL.Request.UserGroup;
using NewsPortal.DAL.Response.UserGroup;
using Model.Domain;

namespace NewsPortal.WebApi.Mappings
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
