﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace oop_lab12
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
        
        public void buy_car(int x)
        {
            Console.WriteLine($"total price is: {this.price+x}");

        }

        public override int GetHashCode()
        {
            Console.WriteLine($"\nHASHCODE of car {this.label} is: {label.GetHashCode()}\n-------------------\n");
            return label.GetHashCode();
        }

        public override string ToString()
        {
            return $" {label} - {model} - {year} - {color} - {price} - {regNum}\n";
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

    public static class Reflector
    {
        static bool counter = false;
        public static void nameAssembly(Type t)
        {
            Console.WriteLine($"имя сборки в которой определен класс: {t.FullName} ");
            return;
        }

        public static void nameMethods(Type t)
        {
            MethodInfo[] methods = t.GetMethods(BindingFlags.DeclaredOnly
                | BindingFlags.NonPublic
                | BindingFlags.Public
                | BindingFlags.Instance
                );
            if (counter)
            {

                Console.WriteLine("публичные методы класса: \n");
                for (int i = 0; i < methods.Length; i++)
                {
                    // Console.Write(methods[i].Name + " \n");
                    Console.WriteLine(methods[i].Name);
                }
            }

            return;
        }
        public static void nameField(Type t)
        {
            FieldInfo[] fi = t.GetFields(BindingFlags.Instance
                    | BindingFlags.Static
                    | BindingFlags.Public
                    | BindingFlags.NonPublic);
            if (fi.Length != 0)
            {
                Console.WriteLine("поля класса:");
                for (int i = 0; i < fi.Length; i++)
                {
                    Console.WriteLine(fi[i].Name);
                }
            }

            return;
        }
        public static void nameProperties(Type t)
        {
            PropertyInfo[] pi = t.GetProperties();
            if (pi.Length != 0)
            {
                Console.WriteLine("свойства класса: ");
                for (int i = 0; i < pi.Length; i++)
                {
                    Console.WriteLine(pi[i].Name);
                }
            }
            return;
        }
        public static void nameInterface(Type t)
        {
            foreach (Type i in t.GetInterfaces())
            {
                Console.WriteLine(i.Name);
            }
            return;
        }

        public static void mathodParam(Type t)
        {
            Console.WriteLine("методы с входным парметром String ");
            MethodInfo[] methods = t.GetMethods(BindingFlags.DeclaredOnly
                | BindingFlags.NonPublic
                | BindingFlags.Public
                | BindingFlags.Instance
                );
            for (int i = 0; i < methods.Length; i++)
            {
                ParameterInfo[] parameters = methods[i].GetParameters();
                foreach (ParameterInfo parameter in parameters)
                {
                    if (parameter.ParameterType.Name == "String")
                    {
                        Console.WriteLine(methods[i].Name);
                    }


                }
            }
            return;
        }
        public static void invk(Type t, car elem)
        {
            var obj = elem;
            MethodInfo inf = t.GetMethod("buy_car");
            object[] fd = { 100 };
            var r = inf.Invoke(obj, fd);
            Console.WriteLine(r);
            return;
        }
        public static void create(Type t)
        {
            var instance = Activator.CreateInstance(t);
            Console.WriteLine(instance);
            
        }

    }
   
    class Program
    {
        static void Main(string[] args)
        {
            car car6 = new car("bugatti", "m2", 2017, "black", 1790, 19748);
            Type t = Type.GetType("oop_lab12.car", false, true);
            bool flag = false;

            string writePath = @"D:\Саша Комкова\oop\oop_lab12\oop_lab12\file.txt";
            string pathRead1 = @"D:\Саша Комкова\oop\oop_lab12\oop_lab12\invoke_1.txt";
            string pathRead2 = @"D:\Саша Комкова\oop\oop_lab12\oop_lab12\invoke_2.txt";

            try
            {
                Reflector.nameAssembly(Type.GetType("oop_lab12.car", false, true));
                Reflector.nameMethods(Type.GetType("oop_lab12.car", false, true));
                Reflector.nameInterface(Type.GetType("oop_lab12.car", false, true));
                Reflector.nameField(Type.GetType("oop_lab12.car", false, true));
                Reflector.nameProperties(Type.GetType("oop_lab12.car", false, true));
                Reflector.mathodParam(Type.GetType("oop_lab12.car", false, true));
                Reflector.invk(Type.GetType("oop_lab12.car", false, true), car6);
                Reflector.create(Type.GetType("oop_lab12.car", false, true));

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

    //try
    //{
    //    MethodInfo[] methods = t.GetMethods(BindingFlags.DeclaredOnly
    //    | BindingFlags.NonPublic
    //    | BindingFlags.Public
    //    | BindingFlags.Instance
    //    );
    //    if (methods.Length != 0)
    //    {
    //        //Console.WriteLine("у класса есть публичные методы!!\n");
    //        flag = true;

    //    }

    //    FieldInfo[] fi = t.GetFields(BindingFlags.Instance
    //        | BindingFlags.Static
    //        | BindingFlags.Public
    //        | BindingFlags.NonPublic);
    //    PropertyInfo[] pi = t.GetProperties();

    //    Console.WriteLine("--------------------");
    //    //Assembly assembly = Assembly.LoadFrom(@"E:\ConsoleApp40.exe");
    //    //Type type = assembly.GetType("ConsoleApp40.MyClass");







    //    Console.WriteLine("--------------------");
    //    using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
    //    {
    //        sw.WriteLine($"имя сборки в которой определен класс: {t.FullName} ");
    //        if (flag)
    //        {

    //            sw.WriteLine("публичные методы класса: \n");
    //            for (int i = 0; i < methods.Length; i++)
    //            {
    //                // Console.Write(methods[i].Name + " \n");
    //                sw.WriteLine(methods[i].Name );
    //            }
    //        }
    //        if (fi.Length != 0)
    //        {
    //            sw.WriteLine("поля класса:" );
    //            for (int i = 0; i < fi.Length; i++)
    //            {
    //                sw.WriteLine(fi[i].Name );
    //            }
    //        }
    //        if (pi.Length != 0)
    //        {
    //            sw.WriteLine("свойства класса: ");
    //            for (int i = 0; i < pi.Length; i++)
    //            {
    //                sw.WriteLine(pi[i].Name);
    //            }
    //        }
    //        foreach (Type i in t.GetInterfaces())
    //        {
    //            sw.WriteLine(i.Name);
    //        }
    //        sw.WriteLine("методы с входным парметром String ");
    //        for (int i = 0; i < methods.Length; i++)
    //        {
    //            ParameterInfo[] parameters = methods[i].GetParameters();
    //            foreach (ParameterInfo parameter in parameters)
    //            {
    //                if (parameter.ParameterType.Name == "String")
    //                {
    //                    sw.WriteLine(methods[i].Name );
    //                }


    //            }
    //        }

    //        var obj = car6;
    //        MethodInfo inf = t.GetMethod("buy_car");
    //        object[] fd = { 100 };
    //        var r = inf.Invoke(obj, fd);
    //        sw.WriteLine(r);

    //        //using (StreamReader sr = new StreamReader(pathRead1))
    //        //{
    //        //    var q = sr.ReadToEnd();
    //        //    using (StreamReader sr2 = new StreamReader(pathRead2))
    //        //    {
    //        //        string w = sr2.ReadToEnd();

    //        //        object[] v = (object[])Convert.ChangeType(w, typeof(object[]));

    //        //        MethodInfo m = t.GetMethod("buy_car");

    //        //        var out_str = m.Invoke(q, v);
    //        //        Console.WriteLine(out_str);
    //        //    }
    //        //}

    //        //var q = car6;
    //        //MethodInfo info = t.GetMethod("buy_car");
    //        //object[] f = { 100 };
    //        //var res = info.Invoke(q, f);
    //        //Console.WriteLine(res);
    //    }

    //    Console.WriteLine("Запись выполнена");
    //}
    //catch (Exception e)
    //{
    //    Console.WriteLine(e.Message);
    //}


    //Console.WriteLine($"имя сборки в которой определен класс: {t.FullName} ");

    //MethodInfo[] methods = t.GetMethods(BindingFlags.DeclaredOnly
    //    | BindingFlags.NonPublic
    //    | BindingFlags.Public
    //    | BindingFlags.Instance
    //    );
    //if (methods.Length != 0)
    //{
    //    Console.WriteLine("у класса есть публичные методы!!\n");
    //    flag = true;
    //}
    //if (flag)
    //{
    //    Console.WriteLine("публичные методы класса: ");
    //    for (int i = 0; i < methods.Length; i++)
    //    {
    //        Console.Write(methods[i].Name + " \n");
    //    }
    //}
    //if (fi.Length != 0)
    //{

    //    Console.WriteLine("поля класса: ");
    //    for (int i = 0; i < fi.Length; i++)
    //    {
    //        Console.Write(fi[i].Name + " \n");
    //    }
    //}
    //if (pi.Length != 0)
    //{

    //    Console.WriteLine("свойства класса: ");
    //    for (int i = 0; i < pi.Length; i++)
    //    {
    //        Console.Write(pi[i].Name + " \n");
    //    }
    //}



    Console.ReadKey();
        }
    }
}
