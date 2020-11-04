using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_lab11
{
    public partial class car
    {

        public static int id = 0;
        public string label { get; set; } = "none";
        public string model { get; set; } = "none";
        private int year;
        public int Year
        {
            set
            {
                year = value;
            }
            get { return year; }


        }
        public string color { get; set; } = "none";
        public int price { get; set; } = 0;
        public readonly int regNum; //тока для чтения
        public int car_age { get; set; } = 0;
        static int carCounter { get; set; } = 0; // статическое поле //классическое св-во

        public car() //конструкутор без аргументов
        {
            id++;

            label = "not found";
            model = "not found";
            year = 0;
            color = "not found";
            price = 0;
            regNum = 0000000;

            Console.WriteLine("enter other info please");
        }

        public car(string label, string model, int year,
            string color, int price, int regNum) //закрытый конструктор
        {
            id++;

            this.label = label;
            this.model = model;
            this.year = year;
            this.color = color;
            this.price = price;
            this.regNum = regNum;
            car.addCar();

        }


        static car() //статический конструктор
        {
            Console.WriteLine("the FIRST car!");
        }
        public int carAge() //метод подсчета возраста машины
        {
            car_age = 2020 - year;
            Console.WriteLine($"car age of {label}: " + car_age);
            return car_age;
        }
        static int addCar() //статический метод
        {
            if (carCounter == 0)
            {
                Console.WriteLine("there're no cars in garage");

            }
            return carCounter++;
        }

        public void about()
        {
            Console.WriteLine($"{id}\n{label}\n{model}\n{year}\n{color}\n{price}\n{regNum}\n\n");

        }

        public override int GetHashCode()
        {
            Console.WriteLine($"\nHASHCODE of car {this.label} is: {label.GetHashCode()}\n-------------------\n");
            return label.GetHashCode();
        }

        public override string ToString()
        {
            return $"{id} - {label} - {model} - {year} - {color} - {price} - {regNum}\n";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            car el = obj as car;
            if (el as car == null)
                return false;

            return el.label == this.label && el.model == this.model;
        }



        public const int wheels = 4; //поле-константа
        public static void Wheels(ref int wheels, out int wheels_out)
        {
            wheels_out = wheels;
        }


    }
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

            car car1 = new car("audi", "v3", 2000, "green", 2300, 01294);
            car car2 = new car("opel", "v3", 2003, "black", 1000, 01234);
            car car3 = new car("volvo", "v56", 2005, "silver", 3400, 67329);
            car car4 = new car("bentley", "v1", 2010, "white", 4900, 60029);
            car car5 = new car("lexus", "v6", 2007, "red", 3790, 65748);
            car car6 = new car("bugatti", "m2", 2017, "choco", 1790, 19748);
            car car7 = new car("jeep", "v6", 2007, "red", 2000, 34548);
            car car8 = new car("reno", "v98.0", 2013, "yellow", 3100, 60008);
            List<car> listCars = new List<car> {car1, car2, car3, car4, car5, car6, car7, car8 };



            Console.ReadKey();


        }

    }
}
