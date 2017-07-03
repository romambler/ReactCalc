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
            var user = context.Users.FirstOrDefault(u => u.Id == elem.Id);
            context.Users.Remove(user);
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
            var user = context.Users.FirstOrDefault(u => u.Id == elem.Id);
            user = elem;         
            context.SaveChanges();
        }

        public bool Valid(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public User Create(User elem)
        {
            context.Users.Add(elem);
            context.SaveChanges();
            return elem;

        }
    }
}
