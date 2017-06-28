using System;
using System.Linq;

namespace RectCalc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            double x = 0;
            double y = 0;
            Calc calc = new Calc();
            var oper = "sum";

            if (args.Length == 0)
            {
                Console.WriteLine("Введите операцию");
                oper = Console.ReadLine();

                Console.Write("Х = ");
                x = ToNumb(Console.ReadLine());

                Console.Write("Y = ");
                y = ToNumb(Console.ReadLine());
            }
            else
            {
                x = ToNumb(args[0]);
                y = ToNumb(args[1]);
                oper = args.Last();
            }
            

            try
            {
                var result = calc.Execute(oper, new[] { x, y });
                Console.WriteLine("{0} = {1}", calc.LastOperationName, result);
            } catch(NotSupportedException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.Read();
        }

        static double ToNumb(string arg, int def = 0)
        {
            double num;
            arg = arg.Replace(".", ",");
            if (!double.TryParse(arg, out num))
            {
                num = def;
            }

            return num;
        }
        
    }
}
