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
            context.Entry(elem).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public string[] GetNameOperations()
        {
            return context.Operation.Select(o => o.FullName).ToArray();
        }

        public Operation GetByName(string name)
        {
            return context.Operation.FirstOrDefault(o => o.FullName == name);
        }

        public void SaveOrUpdate(IEnumerable<CalcBase.Models.IOperation> listOperations)
        {   //добавляет постоянно
            /*List<Operation> list = new List<Operation>();
            foreach(var item in listOperations)
            {
                CalcBase.Models.IDisplayOperation operation = item as CalcBase.Models.IDisplayOperation;
                context.Entry(new Operation { Name = item.Name, FullName = operation != null ? operation.DisplayName : item.Name }).State = System.Data.Entity.EntityState.Added;
                context.SaveChanges();
            }*/
            
        }
    }
}
