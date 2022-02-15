﻿using AutoMapper;
using DAL.Dto;
using DAL.Request.Comments;
using DAL.Response.Comments;
using Model.Domain;

namespace Repositories.Mappings
{
    /// <summary>
    /// Mapping profile for "Comments" entity.
    /// </summary>
    public class CommentProfile : Profile
    {
        /// <summary>
        /// Initializes the instance <see cref="CommentProfile"/>.
        /// </summary>
        public CommentProfile()
        {
            CreateMap<Comments, CommentsDto>().ReverseMap();
            CreateMap<NewCommentRequest, CommentsDto>()
                .ForMember(x => x.UserId, y => y.MapFrom(src => src.AuthorId));
            CreateMap<UpdateCommentRequest, CommentsDto>()
                .ForMember(x => x.Id, y => y.MapFrom(src => src.Id))
                .ForMember(x => x.UserId, y => y.MapFrom(src => src.AuthorId));
            CreateMap<CommentsDto, CommentsResponse>()
                .ForMember(x => x.UserName, y => y.MapFrom(src =>  $"{src.User.Name} {src.User.Surname}" ))
                .ForMember(x => x.CommentId, y => y.MapFrom(src => src.Id ));
        }
    }
}
