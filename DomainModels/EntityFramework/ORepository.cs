using DomainModels.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels.Models;

namespace DomainModels.EntityFramework
{
    public class ORepository : IORepository
    {
        private CalcContext context { get; set; }

        public ORepository()
        {
            this.context = new CalcContext();
        }

        public Operation Create()
        {
            return new Operation
            {
                UId = Guid.NewGuid()
            };
        }

        public void Delete(Operation elem)
        {
            throw new NotImplementedException();
        }

        public Operation Get(long id)
        {
            return context.Operation.FirstOrDefault(o => o.Id == id);
        }

        public IEnumerable<Operation> GetAll()
        {
            return context.Operation.ToList();
        }

        public void Update(Operation elem)
        {
            context.Entry(elem).State = elem.Id == 0
                ? System.Data.Entity.EntityState.Added
                : System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public Operation GetByName(string name)
        {
            return context.Operation.FirstOrDefault(u => u.Name == name);
        }

        public Operation GetById(long id)
        {
            return context.Operation.FirstOrDefault(u => u.Id == id);
        }
    }
}
