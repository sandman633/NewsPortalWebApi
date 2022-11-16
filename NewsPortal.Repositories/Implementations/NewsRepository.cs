using AutoMapper;
using NewsPortal.Model.Domain;
using Microsoft.EntityFrameworkCore;
using NewsPortal.DAL.Dto;
using Repositories.Interfaces;
using System.Linq;
using NewsPortal.Model;

namespace Repositories.Implementations
{
    public class NewsRepository : BaseRepository<NewsDto, News>, INewsRepository
    {
        public NewsRepository(WebApiContext context) : base(context)
        {
        }
        public override IQueryable<News> DefaultIncludeProperties(DbSet<News> dbSet)
        {
            return base.DefaultIncludeProperties(dbSet).Include(er => er.User).Include(er => er.Сomments);
        }
    }
}
