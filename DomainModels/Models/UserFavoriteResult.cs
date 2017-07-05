﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Models
{

    [Table("UserFavoritResult")]
    public class UserFavoriteResult
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public virtual User User { get; set; }
        public long ResultId { get; set; }
        public virtual OperationResult Result { get; set; }


    }
}
