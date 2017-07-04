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

        public Calc(string path)
        {
            Operations = new List<IOperation>();

            if (string.IsNullOrWhiteSpace(path))
                return;

            var exts = Directory.GetFiles(path, "*.dll");

            foreach (var dllName in exts)
            {
                var assembly = Assembly.LoadFrom(dllName);
                GetOperations(assembly);
                
            }
        }

        private void GetOperations(Assembly assembly)
        {
            //exeption при FactorialLibrary
            try
            {
                // получаем всем типы/классы из нее
                var types = assembly.GetTypes();

                // перебираем типы
                var searchInterface = typeof(IOperation);
                foreach (var t in types)
                {
                    var r = Directory.GetCurrentDirectory();
                    if (t.IsAbstract || t.IsInterface)

                        continue;

                    // находим тех, кто реализует интерфейc IOperation
                    var interfs = t.GetInterfaces();

                    if (interfs.Contains(searchInterface))
                    {
                        // создаем экземпляр найденного класса

                        var instance = Activator.CreateInstance(t) as IOperation;
                        if (instance != null)
                        {
                            // добавляем его в наш список операций
                            Operations.Add(instance);

                        }
                    }
                }
            }
            catch { }
        }

        public IList<IOperation> Operations { get; private set; }

        private double Execute(Func<IOperation, bool> selector, double[] args)
        {

            //Находим операцию по имени
            var oper = Operations.FirstOrDefault(selector);

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