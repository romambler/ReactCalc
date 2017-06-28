using ReactCalc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowLibrary
{
    public class PowOperation : Operation
    {
        private double[] _args;
        public override long Code
        {
            get { return 3000; }
        }

        public override string Name
        {
            get { return "pow"; }
        }

        public override double Execute(double[] args)
        {
            _args = args;
            return Math.Pow(args[0], args[1]);
        }

        public override string Author
        {
            get
            {
                return "We";
            }
        }

        public override string Description
        {
            get
            {
                return "Возведение числа в степень";
            }
        }

        public override string DisplayName
        {
            get
            {
                return string.Format("{0}^{1}", _args[0], _args[1]);
            }
        }
    }
}
