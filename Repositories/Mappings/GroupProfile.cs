using AutoMapper;
using DAL.Dto;
using DAL.Request.Group;
using DAL.Response.Group;
using Model.Domain;

namespace Repositories.Mappings
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
