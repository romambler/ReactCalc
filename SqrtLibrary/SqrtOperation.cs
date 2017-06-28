using ReactCalc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqrtLibrary
{
    public class SqrtOperation : Operation
    {
        public override long Code
        {
            get
            {
                return 2000;
            }
        }

        public override string Name
        {
            get
            {
                return "sqrt";
            }
        }

        public override double Execute(double[] args)
        {
            return Math.Sqrt(args[0]);
        }

        public override string Author
        {
            get
            {
                return "Apple";
            }
        }

        public override string DisplayName
        {
            get
            {
                return "Квадратный корень";
            }
        }

        public override string Description
        {
            get
            {
                return "Извлечение квадратного корня из числа, число должно быть >= 0";
            }
        }
    }
}
