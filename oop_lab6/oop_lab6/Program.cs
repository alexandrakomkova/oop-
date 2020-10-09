using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_lab5
{
    class Program
    {
        enum animals
        {
            frog, //0
            horse, //1
            snake, //2
            lion //3
        }
        struct Choco
        {
            public string color;
            public int gr;

            public void about()
            {
                Console.WriteLine($"color of chocolate is {color} & wheight is {gr}gr");
            }
        }

       partial interface IInfo
        {
            // реализация метода по умолчанию
            void info();

        }
        abstract class Goods
        {
            public string name { get; set; } = "bag of sweets";

            public void info()
            {
                Console.WriteLine($" -- you have a new good in the shop: {name} -- ");
            }


        }


         partial class Flowers : Goods
        {

            public Flowers(string flower_name)
            {
                this.name = flower_name;
            }

            //public override int GetHashCode()
            //{
            //    Console.WriteLine($"\nHASHCODE of car {this.name} is: {name.GetHashCode()}\n-------------------\n");
            //    return name.GetHashCode();
            //}

            //public override string ToString()
            //{
            //    return $"{name}\n";
            //}

            //public override bool Equals(object obj)
            //{
            //    if (obj == null)
            //        return false;
            //    Flowers el = obj as Flowers;
            //    if (el as Flowers == null)
            //        return false;

            //    return el.name == this.name;
            //}


        }
         class Watches : Goods, IInfo
        {

            public string color;
            public int model;
            public Watches(string watches_label, string color, int model)
            {
                this.name = watches_label;
                this.model = model;
                this.color = color;
            }
            public new void info()
            {
                Console.WriteLine($" -- the description: {name} {model} {color} -- ");
            }
            public override string ToString()
            {
                return $"{name} - {model} - {color}\n";
            }

        }
         class Cake
        {

            public string cake_name;
            public Cake(string cake_name)
            {

                this.cake_name = cake_name;
            }
            public void info()
            {
                Console.WriteLine($" -- the description: {cake_name} -- ");
            }
            public override string ToString()
            {
                return $"{cake_name}\n";
            }
        }
        sealed class Candy : IInfo
        {

            public string candy_name;
            public Candy(string candy_name)
            {
                // bag = any_bag;
                this.candy_name = candy_name;
            }

            public void info()
            {
                Console.WriteLine($" -- the description: {candy_name} -- ");
            }
            public override string ToString()
            {
                return $"{candy_name}\n";
            }
        }
        class Sweets : Goods
        {
            public Cake cake;
            public Candy candy;
            public Sweets(Cake ck, Candy cd)
            {
                cake = ck;
                candy = cd;

                //Console.WriteLine($"in the sweet bag you have ");

            }
            public void Info(Cake ck, Candy cd)
            {

                Console.WriteLine($" -- in the bag: {ck.cake_name} & {cd.candy_name} -- ");
            }
            public override string ToString()
            {
                return $"congrats!! you have a {name}\n";
            }
        }
        class Print
        {
            public void IAmPrinting(Goods someobj)
            {
                Console.WriteLine($" -- type of obj is: " + someobj.GetType() + " -- ");
                Console.WriteLine(someobj.ToString());

            }
        }

        class Gift : Goods
        {
            public Gift()
            {
                
                _container = new List<Goods>();
            }
            private List<Goods> _container;
            public Goods this[int index]
            {
                get { return _container[index]; }
                set { _container[index] = value; }
            }
            public void Add(Goods someobj) => _container.Add(someobj);
        }
        static void Main(string[] args)
        {
            // Товар (Продукт, (Кондитерское изделие (Торт, Конфеты)), Цветы,  Часы)



            //Cake cake1 = new Cake("banana cake");
            //Candy candy1 = new Candy("choco candy");
            //cake1.info();
            //Sweets bag1 = new Sweets(cake1, candy1);
            //bag1.info();
            //bag1.Info(cake1, candy1);

            Flowers flower1 = new Flowers("rose");
            flower1.info();
            //Console.WriteLine(flower1.ToString());

            //Watches watches1 = new Watches("rolex", "silver", 2020);
            //watches1.info();

            //dynamic[] arrayOfGoods = new dynamic[] { watches1, flower1, bag1 };
            //Print print = new Print();
            //print.IAmPrinting(watches1);
            //print.IAmPrinting(flower1);
            //print.IAmPrinting(bag1);

            //Choco white;
            //white.color = "white";
            //white.gr = 180;
            //white.about();

            Gift gift = new Gift();
            gift.Add(flower1);
            Console.WriteLine(gift[0].ToString());


            Console.ReadKey();
        }
    }
}
