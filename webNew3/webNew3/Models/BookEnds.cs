using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webNew3.Models
{
    public struct BookEnd
    {
        static string one = "Книга";
        static string two = "Книги";
        static string five = "Книг";
        static string n = "од.";

        /// <summary>
        /// Вертає називний відмінок, залежно від кількості книг (до 20),
        /// або "од.", якщо книг >20
        /// </summary>
        /// <param name="count">кількість книг</param>
        /// <returns></returns>
        public static string GetRightEnd(int count)
        {
            if (count > 0)
            {
                if (count == 1)
                {
                    return one;
                }
                if (count < 5)
                {
                    return two;
                }
                if (count < 21)
                {
                    return five;
                }
            }
            return n;
        }
    }
}