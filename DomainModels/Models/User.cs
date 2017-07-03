using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DomainModels.Models
{
    public class User
    {
        [HiddenInput(DisplayValue = false)]
        public long Id { get; set; }

        [HiddenInput(DisplayValue = false)]
        public Guid UId { get; set; }

        [Display(Name = "Логин")]
        public string Login { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string Password { get; set; }

        [Display(Name = "ФИО")]
        public string FIO { get; set; }
    }
}
