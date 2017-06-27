using ReactCalc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcBase.Models
{
    public class DivisionOperation : Operation
    {
        public override long Code
        {
            get { return 2; }
        }

        public override string Name
        {
            get { return "division"; }
        }

        public override double Execute(double[] args)
        {
            return args[0] / args[1];
        }
    }
}
