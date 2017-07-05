﻿using DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Repository
{
    public interface ILikeRepository : IEntityRepository<UserFavoriteResult>
    {
        IEnumerable<UserFavoriteResult> GetByUserId(long userId);
    }
}
