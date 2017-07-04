using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Repository
{
    public interface IEntityRepository<T>
    {
        T Create();

        T Get(long id);

        void Update(T elem);

        void Delete(T elem);

        IEnumerable<T> GetAll();
    }
}
