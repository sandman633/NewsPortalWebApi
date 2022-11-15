﻿using Model.Domain;
using NewsPortal.DAL.Dto;
using Repositories.Interfaces.CRUD;

namespace Repositories.Interfaces
{
    public interface IGroupRepository : ICrudRepository<GroupDto, Group>
    {
    }
}
