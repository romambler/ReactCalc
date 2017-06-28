using ReactCalc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcBase.Models
{
    public class MultOperation : Operation
    {
        public override long Code
        {
            get
            { return 3; }
        }

        public override string Name
        {
            get
            {
                return "mult";
            }
        }

        public override double Execute(double[] args)
        {
            return args[0] * args[1];
        }

        public override string Author
        {
            get
            {
                return "автор минуса";
            }
        }

        public override string DisplayName
        {
            get
            {
                return "Умножение";
            }
        }

        public override string Description
        {
            get
            {
                return "Умножение одного числа на другое";
            }
        }
    }
}
