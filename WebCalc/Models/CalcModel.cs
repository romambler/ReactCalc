using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCalc.Models
{
    public class CalcModel
    {
        public string Operation { get; set; }
        public double? x { get; set; }
        public double? y { get; set; }
        public double? Result { get; set; }
        public double[] Arguments { get { return new[] { x ?? 0, y ?? 0 }; } }
    }
}