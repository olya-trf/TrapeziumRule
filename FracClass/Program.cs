/* Реализовать класс дробей. Определить операторы сложения, вычитания,
умножения и деления дробей. Определить метод упрощения дроби.
Определить метод выделения целой части. Определить свойства:
числитель, знаменатель. */

using System;
using System.ComponentModel.DataAnnotations;

namespace FractionClass
{
    class Fraction
    {
        public double numerator; // Числитель
        public double denominator; // Знаменатель

        public void Print()
        {
            Console.WriteLine("{0}/{1}", numerator, denominator);
        }

        public static Fraction operator +(Fraction x, Fraction y) // Сумма
        {
            var z = new Fraction();
            z.numerator = x.numerator * y.denominator + y.numerator * x.denominator;
            z.denominator = x.denominator * y.denominator;
            // if (z.numerator == 0) return 0;

            return z;
        }

        public static Fraction operator -(Fraction x, Fraction y) // Разность
        {
            var z = new Fraction();
            z.numerator = x.numerator * y.denominator - y.numerator * x.denominator;
            z.denominator = x.denominator * y.denominator;

            return z;
        }
        public static Fraction operator *(Fraction x, Fraction y) // Умножение
        {
            var z = new Fraction();
            z.numerator = x.numerator * y.numerator;
            z.denominator = x.denominator * y.denominator;

            return z;
        }

        public static Fraction operator /(Fraction x, Fraction y) // Деление
        {
            var z = new Fraction();
            z.numerator = x.numerator * y.denominator;
            z.denominator = x.denominator * y.numerator;

            return z;
        }

        public static Fraction SetFormat(Fraction x)
        {
            double max = 0;

            if (x.numerator > x.denominator)
                max = Math.Abs(x.numerator);
            else max = Math.Abs(x.denominator);

            for (var i = max; i >= 2; i--)
            {
                if ((x.numerator % i == 0) & (x.denominator % i == 0))
                {
                    x.numerator = x.numerator / i;
                    x.denominator = x.denominator / i;
                }
            }

            if ((x.denominator < 0))
                {
                    x.numerator = -1 * (x.numerator);
                    x.denominator = Math.Abs(x.denominator);
                }

            return x;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Fraction x = new Fraction();
            x.numerator = -1;
            x.denominator = 2;

            Fraction y = new Fraction();
            y.numerator = 2;
            y.denominator = 4;

            var z1 = x + y;
            var z2 = x - y;
            var z3 = x * y;
            var z4 = x / y;
            // var z5 = SetFormat(z1);

            x.Print();
            y.Print();
            z1.Print();
            z2.Print();
            z3.Print();
            z4.Print();
        }
    }
}
