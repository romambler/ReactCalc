﻿using DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Repository
{
    public interface IUserRepository : IEntityRepository<User>
    {
        bool Valid(string userName, string password);
        User GetByName(string name);
    }
}
