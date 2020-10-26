/* 11. Написать программу, вычисляющую интеграл функции 
 * с использованмем численных методов (прямоугольников и трапеций).
 * Обеспечить сравнение точности вычисления значения (найти ошибку). */

using System;

namespace ConsoleApp1
{
    class Program
    {
        static double Function(double x) // Подынтегральная функция 
        {
            var result = x;
            result = Math.Cos(2 * x);
            return result;
        }
        static void ReadValueFromConsole(out double value, string Message)
        {
            string str;
            do
            {
                Console.Write(Message);
                str = Console.ReadLine();
            }
            while (!double.TryParse(str, out value));
        }
        static double GetIntegralValue(double a, double b, double n, double eps)
        {
            double eps1 = 10 * eps;
            double s2 = 0;
            double sum = 0;

            while (eps1 > eps)
            {
                double s1 = s2;
                s2 = 0.5 * (Function(b) + Function(a));
                var h = (b - a) / n;
                double x = a + h;

                for (int k = 1; k < n - 1; k++)
                {
                    s2 = s2 + Function(x);
                    x = x + h;
                }

                eps1 = h * Math.Abs(s2 - 2 * s1) / 3;
                n = 2 * n;
                sum = h * s2;
            }

            return sum;
        }

        static void Main(string[] args)
        {
            ReadValueFromConsole(out double a, "Введите значение a > ");  // Левый конец инетрвала инт-ия
            ReadValueFromConsole(out double b, "Введите значение b > "); // Правый конец интервала инт-ия
            ReadValueFromConsole(out var n, "Введите значение n > "); // Количество равных интервалов разбиения
            ReadValueFromConsole(out var eps, "Введите значение eps > "); // Значение погрешности

            var sum = GetIntegralValue(a, b, n, eps);

            Console.WriteLine("Интеграл функции f(x) = {0}", sum);
        }
    }
}
