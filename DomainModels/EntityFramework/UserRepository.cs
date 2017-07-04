using DomainModels.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels.Models;

namespace DomainModels.EntityFramework
{
    public class UserRepository : IUserRepository
    {
        private CalcContext context { get; set; }

        public UserRepository()
        {
            this.context = new CalcContext();
        }

        public void Delete(User elem)
        {
            elem.IsDeleted = true;
            context.Entry(elem).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public User Get(long Id)
        {
            return context.Users.FirstOrDefault(u => u.Id == Id && u.IsDeleted == false);
        }

        public IEnumerable<User> GetAll()
        {
            return context.Users.Where(u => u.IsDeleted == false).ToList();
        }

        public void Update(User elem)
        {
            context.Entry(elem).State = System.Data.Entity.EntityState.Modified;     
            context.SaveChanges();
        }

        public bool Valid(string userName, string password)
        {
            return context.Users.Count(u => !u.IsDeleted && u.Login == userName && u.Password == password) == 1;
        }

        public User Create()
        {
            throw new NotImplementedException();

        }

        public User GetByName(string name)
        {
            return context.Users.FirstOrDefault(u => !u.IsDeleted && u.Login == name);
        }
    }
}
