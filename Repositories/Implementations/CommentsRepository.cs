using AutoMapper;
using NewsPortal.Model.Domain;
using Microsoft.EntityFrameworkCore;
using NewsPortal.DAL.Dto;
using Repositories.Interfaces;
using System.Linq;
using NewsPortal.Model;

namespace Repositories.Implementations
{
    public class CommentsRepository : BaseRepository<CommentsDto, Comments>, ICommentsRepository
    {
        public CommentsRepository(WebApiContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IQueryable<Comments> DefaultIncludeProperties(DbSet<Comments> dbSet)
        {
            return base.DefaultIncludeProperties(dbSet).Include(er => er.LinkedComment).Include(er => er.User).Include(er => er.News).Include(er => er.LinkedComment.User);
        }


    }
}
