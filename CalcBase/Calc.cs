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
        public string LastOperationName { get; set; }

        public Calc()
        {
            Operation = new List<IOperation>();

            var baseOperations = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.dll");

            if (baseOperations != null)
                foreach (var i in baseOperations)
                    GetOperations(i);

            //директория с расширениями
            var extsDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Extensions");

            if (!Directory.Exists(extsDirectory))
            {
                return;
            }

            var exts = Directory.GetFiles(extsDirectory, "*.dll");

            foreach (var file in exts)
            {
                GetOperations(file);
            }
        }

        private void GetOperations(string dll)
        {
            if (!File.Exists(dll))
                return;

            //загружаем сборку
            var assembly = Assembly.LoadFrom(dll);
            //получаем все типы классов в ней
            var types = assembly.GetTypes();
            //перебираем типы 
            var searchInterface = typeof(IOperation);
            foreach (var t in types)
            {
                //находим тех, кто реализует интерфейс IOperation
                var interfaces = t.GetInterfaces();
                if (interfaces.Contains(searchInterface))
                {
                    try
                    {
                        //создаем экземпляр найденного класса 
                        var instance = Activator.CreateInstance(t) as IOperation;
                        if (instance != null)
                        {
                            //обавляем его в список операций
                            Operation.Add(instance);
                        }
                    }
                    catch { }
                }
            }
        }

        public IList<IOperation> Operation { get; private set; }

        private double Execute(Func<IOperation, bool> selector, double[] args)
        {

            //Находим операцию по имени
            var oper = Operation.FirstOrDefault(selector);

            if (oper != null)
            {
                var displayOper = oper as IDisplayOperation;

                LastOperationName = displayOper != null ? displayOper.DisplayName : oper.Name;

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

        public static double ToNumb(string arg, int def = 0)
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