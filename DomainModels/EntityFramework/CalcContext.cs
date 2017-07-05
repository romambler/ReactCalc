using DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.EntityFramework
{
    public class CalcContext : DbContext
    {
        public CalcContext() : base("CalcConn")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Operation> Operation { get; set; }
        public DbSet<OperationResult> OperationResult { get; set; }
        public DbSet<UserFavoriteResult> UserFavoritResult { get; set; }
    }
}
