using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcBase.Models
{
    public class MinOperation : Operation
    {
        public override long Code
        {
            get
            {
                return 2;
            }
        }

        public override string Name
        {
            get
            {
                return "min";
            }
        }

        public override double Execute(double[] args)
        {
            return args[0] - args[1];
        }

        public override string Author
        {
            get
            {
                return "I";
            }
        }

        public override string DisplayName
        {
            get
            {
                return "Умножение";
            }
        }
    }
}
