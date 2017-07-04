using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace DomainModels.Models
{

    [Table("Users")]
    public class User
    {

        public User()
        {
            OperationResults = new List<OperationResult>();
            UserFavoriteResults = new List<UserFavoriteResult>();
        }
        public long Id { get; set; }
        
        public Guid UId { get; set; }
        
        public string Login { get; set; }
        
        public string Password { get; set; }
        
        public string FIO { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<OperationResult> OperationResults { get; set; }

        public virtual ICollection<UserFavoriteResult> UserFavoriteResults { get; set; }
    }
}
