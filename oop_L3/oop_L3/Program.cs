using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_L3
{
    public partial class car 
    {
        
        public static int id =0;  
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
        
        public car( string label, string model, int year,
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
            Console.WriteLine($"car age of {label}: "+car_age);
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
           if(obj == null)
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
            car car1 = new car();
           // car1.about();
            car car2 = new car("opel", "v3", 2003, "black", 1000, 01234);
            
            car car3 = new car("volvo", "v56", 2005, "silver", 3400, 67329);
            car car4 = new car();
            car4.label = "reno";
            car4.Year = 2013;
            car car5 = new car("volvo", "v6", 2007, "red", 3790, 65748);

            // Console.WriteLine();

            
            // car2.carAge();
          //  car2.about();
            // Console.WriteLine(car2.ToString());

            //car3.carAge();
            // car3.about();

            // car4.about();

            // car4.beep();
            // car4.about();

            car[] arrayOfCars = new car[] { car1, car2, car3, car4 };

            Console.WriteLine("enter the label of car: ");
            string enter_label = Console.ReadLine();

            Console.WriteLine("enter the year of car's work: ");
            int enter_year = Convert.ToInt32(Console.ReadLine());
            

            for (int i = 0; i < arrayOfCars.Length; i++)
            {
                if (arrayOfCars[i].label == enter_label)
                {
                    
                }
            }

            for (int i = 0; i < arrayOfCars.Length; i++)
            {
                int yearWork = arrayOfCars[i].carAge();
                if (arrayOfCars[i].label == enter_label && yearWork > enter_year)
                {
                    Console.WriteLine(arrayOfCars[i]);
                }
            }
         
            var car_anon = new {label = "reno", model="vx23", price = 4500, color = "red", regNum = 20309 };
            Console.WriteLine("anon type: "+ car_anon);

            Console.ReadKey();
        }

    }
}
