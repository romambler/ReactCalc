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
        string[] GetNameOperations();
        Operation GetByName(string name);
        void SaveOrUpdate(IEnumerable<CalcBase.Models.IOperation> listOperations);
    }
}
