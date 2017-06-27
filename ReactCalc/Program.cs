using System;

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

            Console.Write("Х = ");
            x = ToInt(Console.ReadLine());

            Console.Write("Y = ");
            y = ToInt(Console.ReadLine());

            try
            {
                var result = calc.Execute(oper, new[] { x, y });
            } catch(NotSupportedException e)
            {
                Console.WriteLine(e.Message);
            }

            #region
            //while (true)
            //{
            //    Console.WriteLine("Выберите действие:");
            //    Console.WriteLine("1. Сложение \n2. Деление\n3. Излечение квадратного корня \n4. Возведение в квадрат \n5. Выход");

            //    string str = Console.ReadLine();
            //    if (int.TryParse(str, out mode))
            //    {
            //        Console.Clear();

            //        switch (mode)
            //        {
            //            case 1:
            //                Console.WriteLine("Сложение");
            //                Console.Write("Х = ");
            //                x = ToInt(Console.ReadLine());

            //                Console.Write("Y = ");
            //                y = ToInt(Console.ReadLine());

            //                Console.WriteLine("Сумма = {0}", calc.Sum(x, y));
            //                ToСontinued();
            //                break;
            //            case 2:
            //                Console.WriteLine("Деление");
            //                Console.Write("Х = ");
            //                x = ToInt(Console.ReadLine());

            //                Console.Write("Y = ");
            //                y = ToInt(Console.ReadLine());

            //                if (y == 0)
            //                {
            //                    Console.WriteLine("Деление на 0 невозможно!");
            //                }
            //                else
            //                {
            //                    Console.WriteLine("Результат = {0}", calc.Div(x, y));
            //                }

            //                ToСontinued();
            //                break;
            //            case 3:
            //                Console.WriteLine("Извлечение корня");
            //                Console.Write("Х = ");
            //                x = ToInt(Console.ReadLine());

            //                if (x < 0)
            //                {
            //                    Console.WriteLine("Число должно быть >= 0");
            //                }
            //                else
            //                {
            //                    Console.WriteLine("Результат = {0}", calc.Sqrt(x));
            //                }

            //                ToСontinued();
            //                break;
            //            case 4:
            //                Console.WriteLine("Возведение в квадрат");
            //                Console.Write("Х = ");
            //                x = ToInt(Console.ReadLine());

            //                Console.WriteLine("Результат = {0}", calc.Sqr(x));
            //                ToСontinued();
            //                break;
            //            case 5:
            //                return;
            //            default:
            //                Console.WriteLine("Ошибка. Данного пункта не существует.");
            //                break;
            //        }
            //    }
            //    else
            //    {
            //        Console.Clear();
            //        Console.WriteLine("Ошибка. Повторите ввод.");
            //    }
            //}
            #endregion

        }

        static double ToInt(string arg, int def = 0)
        {
            double num;
            arg = arg.Replace(".", ",");
            if (!double.TryParse(arg, out num))
            {
                num = def;
            }

            return num;
        }

        static void ToСontinued()
        {
            Console.Write("Дя продолжения нажмите Enter.");
            Console.ReadLine();
            Console.Clear();
        }

    }
}
