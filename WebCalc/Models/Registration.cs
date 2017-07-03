using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCalc.Models
{
    public class Registration
    {
        public string Name { get; set; }
        public string FIO { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

    }
}