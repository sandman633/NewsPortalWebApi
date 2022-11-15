using AutoMapper;
using NewsPortal.DAL.Dto;
using NewsPortal.DAL.Request.GroupPolicy;
using NewsPortal.DAL.Response.GroupPolicy;
using Model.Domain;

namespace NewsPortal.WebApi.Mappings
{
    public class GroupPolicyProfile : Profile
    {
        /// <summary>
        /// Initializes the instance <see cref="GroupPolicyProfile"/>.
        /// </summary>
        public GroupPolicyProfile()
        {
            CreateMap<GroupPolicy, GroupPolicyDto>().ReverseMap();
            CreateMap<GroupPolicyDto, GroupPolicyResponse>().ReverseMap();
            CreateMap<NewGroupPolicyRequest, GroupPolicyDto>().ReverseMap();
            CreateMap<UpdateGroupPolicyRequest, GroupPolicyDto>().ReverseMap();
        }
    }
}
