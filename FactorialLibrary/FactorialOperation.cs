using CalcBase.Models;

namespace FactorialLibrary
{
    public class FactorialOperation : IOperation
    {
        public long Code
        {
            get { return 1000; }
        }

        public string Name
        {
            get { return "factorial"; }
        }

        public double Execute(double[] args)
        {
            var x = args[0];
            var count = 1d;
            var result = 1d;
            while (result < x)
            {
                result *= count++;
            }

            return result;
        }
    }
}
