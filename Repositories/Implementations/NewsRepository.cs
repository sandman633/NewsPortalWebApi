﻿using AutoMapper;
using Model.Domain;
using Microsoft.EntityFrameworkCore;
using DAL.Dto;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace Repositories.Implementations
{
    public class NewsRepository : BaseRepository<NewsDto, News>, INewsRepository
    {
        public NewsRepository(WebApiContext context, IMapper mapper) : base(context, mapper)
        {

        }


        public override IQueryable<News> DefaultIncludeProperties(DbSet<News> dbSet)
        {
            return base.DefaultIncludeProperties(dbSet).Include(er => er.User).Include(er => er.Сomments);
        }
    }
}
