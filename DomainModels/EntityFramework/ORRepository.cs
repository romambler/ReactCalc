using DomainModels.Models;
using DomainModels.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.EntityFramework
{
    public class ORRepository : IORRepository
    {
        private CalcContext context { get; set; }

        public ORRepository()
        {
            this.context = new CalcContext();
        }

        public void Delete(OperationResult elem)
        {
            var user = context.Entry(elem).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();
        }

        public OperationResult Get(long Id)
        {
            return context.OperationResult.FirstOrDefault(u => u.Id == Id);
        }

        public IEnumerable<OperationResult> GetAll()
        {
            return context.OperationResult.ToList();
        }

        public void Update(OperationResult elem)
        {
            context.Entry(elem).State = elem.Id == 0
                ? System.Data.Entity.EntityState.Added 
                : System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
      
        public OperationResult Create()
        {
            return new OperationResult()
            {
                UId = Guid.NewGuid()
            };

        }

        public double GetOldResult(long operaionId, string inputdata)
        {
            var rec = context.OperationResult.FirstOrDefault(u => u.OperationId == operaionId && u.InputData == inputdata);
            return rec != null ? rec.Result : Double.NaN;
        }

        public IEnumerable<OperationResult> GetByUser(User user)
        {
            if (user == null)
                return new OperationResult[0];

            return context.OperationResult.Where(u => u.AuthorId == user.Id).ToList();
        }
    }
}
