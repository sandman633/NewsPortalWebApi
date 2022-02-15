﻿using Model.Domain;
using DAL.Dto;
using Repositories.Interfaces.CRUD;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Interfaces
{
    public interface INewsRepository : ICrudRepository<NewsDto,News>
    {
    }
}
