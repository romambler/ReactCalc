using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 0;
            int y = 0;
            Calc calc = new Calc();
            Console.WriteLine("Hеllo i'm Калькулятор");

            if (args.Length == 2)
            {
                x = ToInt(args[0]);
                y = ToInt(args[1]);
                Console.WriteLine($"summ = {calc.Sum(x, y)}");
            }
            else
            {
                #region Ввод данных
                Console.WriteLine("Введите Х");
                if (!int.TryParse(Console.ReadLine(), out x))
                {
                    x = 5;
                }

                Console.WriteLine("Введите У");
                if (!int.TryParse(Console.ReadLine(), out y))
                {
                    y = 10;
                }

                int result = calc.Sum(x, y);

                Console.WriteLine($"Сумма = {result}");
                #endregion
            }
            Console.ReadLine();
        }

        static int ToInt(string arg, int def = 0)
        {
            int x;
            if (!int.TryParse(arg, out x))
            {
                x = def;
            }
            return x;
        }
    }
}
