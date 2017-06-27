using ReactCalc.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using CalcBase.Models;

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
            Operation.Add(new MinOperation());
            Operation.Add(new MultOperation());
            Operation.Add(new DivisionOperation());

            var dllName = Directory.GetCurrentDirectory() + "\\FactorialLibrary.dll";

            string[] filesDll = Directory.GetFiles(Directory.GetCurrentDirectory(), "*Library.dll");

            foreach(var file in filesDll)
            {
                //загружаем сборку
                var assembly = Assembly.LoadFrom(file);
                //получаем все типы классов в ней
                var types = assembly.GetTypes();
                //перебираем типы 
                foreach (var t in types)
                {
                    //находим тех, кто реализует интерфейс IOperation
                    var interfaces = t.GetInterfaces();
                    if (interfaces.Contains(typeof(IOperation)))
                    {
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
            return Execute("division", new[] { x, y });
        }

    }
}