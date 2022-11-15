using AutoMapper;
using NewsPortal.DAL.Dto;
using NewsPortal.DAL.Request.Group;
using NewsPortal.DAL.Response.Group;
using NewsPortal.Model.Domain;

namespace NewsPortal.WebApi.Mappings
{
    public class GroupProfile : Profile
    {
        /// <summary>
        /// Initializes the instance <see cref="GroupProfile"/>.
        /// </summary>
        public GroupProfile()
        {
            CreateMap<Group, GroupDto>().ReverseMap();
            CreateMap<GroupDto,GroupResponse>().ReverseMap();
            CreateMap<NewGroupRequest,GroupDto>().ReverseMap();
            CreateMap<UpdateGroupRequest,GroupDto>()
                .ForMember(x=>x.Id,y=>y.MapFrom(e=>e.GroupId)).ReverseMap();
        }
    }
}
