using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_lab11
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] m = new [] { "December", "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November" };
            int n = 7;
            var selectedN = from t in m // определяем каждый объект из teams как t
                                where t.Length == n //фильтрация по критерию
                                select t; // выбираем объект
            foreach (string s in selectedN)
                Console.WriteLine(s);
            Console.WriteLine();

            var selectedSummerOrWinter = from t in m // определяем каждый объект из teams как t
                            where t == "December" || t== "January" || t == "February" || t == "June" || t == "July" || t == "August"
                                         orderby t
                                         select t; // выбираем объект
            foreach (string s in selectedSummerOrWinter)
                Console.WriteLine(s);
            Console.WriteLine();

            var selectedAlphabet = from t in m // определяем каждый объект из teams как t
                                         orderby t
                                         select t; // выбираем объект
            foreach (string s in selectedAlphabet)
                Console.WriteLine(s);
            Console.WriteLine();

            var selectedUN = from t in m // определяем каждый объект из teams как t
                            where t.Length > 4 && t.Contains("u")    //фильтрация по критерию
                            select t; // выбираем объект
            foreach (string s in selectedUN)
                Console.WriteLine(s);
            Console.WriteLine();




            Console.ReadKey();


        }

    }
}
