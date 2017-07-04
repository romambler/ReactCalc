using CalcBase.Models;
using System;

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
                return "Возведение числа в степень";
            }
        }
    }
}
