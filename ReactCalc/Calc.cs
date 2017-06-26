using System;

namespace RectCalc
{
    /// <summary>
    /// Калькулятор
    /// </summary>
    public class Calc
    {
        /// <summary>
        /// Сложение
        /// </summary>
        /// <param name="x">Первое слагаемое</param>
        /// <param name="y">Второе слагаемое</param>
        /// <returns>Сумма чисел</returns>
        public double Sum(double x, double y)
        {
            return x + y;
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