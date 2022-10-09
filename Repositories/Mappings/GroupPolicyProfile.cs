﻿using AutoMapper;
using DAL.Dto;
using DAL.Request.GroupPolicy;
using DAL.Response.GroupPolicy;
using Model.Domain;

namespace Repositories.Mappings
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