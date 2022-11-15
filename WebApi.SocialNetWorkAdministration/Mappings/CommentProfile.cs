using AutoMapper;
using NewsPortal.DAL.Dto;
using NewsPortal.DAL.Request.Comments;
using NewsPortal.DAL.Response.Comments;
using Model.Domain;

namespace NewsPortal.WebApi.Mappings
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
            CreateMap<Comments, CommentsDto>()
                .ForMember(x => x.CommentState, y => y.MapFrom(src => (short)src.CommentState))
                .ReverseMap();
            CreateMap<NewCommentRequest, CommentsDto>()
                .ForMember(x => x.UserId, y => y.MapFrom(src => src.AuthorId));
            CreateMap<UpdateCommentRequest, CommentsDto>()
                .ForMember(x => x.Id, y => y.MapFrom(src => src.Id));
            CreateMap<CommentsDto, CommentsResponse>()
                .ForMember(x => x.UserName, y => y.MapFrom(src => $"{src.User.Name} {src.User.Surname}"))
                .ForMember(x => x.CommentId, y => y.MapFrom(src => src.Id));
        }
    }
}
