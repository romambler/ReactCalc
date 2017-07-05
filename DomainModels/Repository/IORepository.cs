using DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Repository
{
    public interface IORepository : IEntityRepository<Operation>
    {
        Operation GetByName(string oper);
        Operation GetById(long id);
    }
}
