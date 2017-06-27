using ReactCalc.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using FactorialLibrary;
using System.Reflection;
using System.IO;

namespace RectCalc
{
    /// <summary>
    /// Калькулятор
    /// </summary>
    public class Calc
    {

        public Calc()
        {
            Operation = new List<IOperation>();
            Operation.Add(new SumOperation());

            var dllName = Directory.GetCurrentDirectory() + "\\FactorialLibrary.dll";

            if (!File.Exists(dllName))
            {
                return;
            }
            //загружаем сборку
            var assembly = Assembly.LoadFrom(dllName);
            //получаем все типы классов в ней
            var types = assembly.GetTypes();
            //перебираем типы 
            foreach (var t in types)
            {
                //находим тех, кто реализует интерфейс IOperation
                var interfaces = t.GetInterfaces();
                if (interfaces.Contains(typeof(IOperation))) {
                    //создаем экземпляр найденного класса 
                    var instance = Activator.CreateInstance(t) as IOperation;
                    if (instance != null)
                    {
                        //обавляем его в список операций
                        Operation.Add(instance);
                    }
                }
            }

        }

        public IList<IOperation> Operation { get; private set; }

        private double Execute(Func<IOperation, bool> selector, double[] args)
        {

            //Находим операцию по имени
            IOperation oper = Operation.FirstOrDefault(selector);
            
            if (oper != null)
            {
                //вычисляем результат
                var result = oper.Execute(args);
                //отдаем пользователю
                return result;
            }

            throw new NotSupportedException("Не найдена запрашиваемая операция");
        }

        public double Execute(string name, double[] args)
        {
            return Execute(i => i.Name == name, args);
        }

        public double Execute(long code, double[] args)
        {
            return Execute(i => i.Code == code, args);
        }

        public double Execute(Func<double[], double> fun, double[] args)
        {
            return fun(args);
        }

        /// <summary>
        /// Сложение
        /// </summary>
        /// <param name="x">Первое слагаемое</param>
        /// <param name="y">Второе слагаемое</param>
        /// <returns>Сумма чисел</returns>
        [Obsolete("Используйте Execute('sum', x, y). Данная функция будет удалена в версии 4.0")]
        public double Sum(double x, double y)
        {
            return Execute("sum", new[] { x, y });
        }

        /// <summary>
        /// Деление
        /// </summary>
        /// <param name="x">Делимое</param>
        /// <param name="y">Делитель</param>
        /// <returns>Результат деления</returns>
        public double Div(double x, double y)
        {
            return x / y;
        }

        /// <summary>
        /// Извлечение квадратного корня
        /// </summary>
        /// <param name="x">Число</param>
        /// <returns>Результат извлечения квадратного корня</returns>
        public double Sqrt(double x)
        {
            return Math.Sqrt(x);
        }

        /// <summary>
        /// Возведение числа в квадрат
        /// </summary>
        /// <param name="x">Число возводящее в квадрат</param>
        /// <returns>Результат возведения в квадрат</returns>
        public double Sqr(double x)
        {
            return Math.Pow(x, 2);
        }
    }
}