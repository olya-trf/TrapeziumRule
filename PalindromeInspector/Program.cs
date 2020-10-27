/* Определить метод, определяющий является ли строка (слово)
палиндромом */

using System;

namespace PalindromeInspector
{
    class Program
    {
        static string PalindromeReverse(string str)
        {
            string rts = "";
            for (int i = str.Length - 1; i >= 0; --i)
            {
                rts = rts + str[i];
            }
            return rts;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите слово для проверки > ");
            var str = Console.ReadLine();
            var rts = PalindromeReverse(str);
            if (str.ToLower() != rts.ToLower()) Console.WriteLine(str + " -- не палиндром.");
            else Console.WriteLine(str + " -- палиндром.");
        }
    }
}
