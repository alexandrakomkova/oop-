using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_lab1
{
    class Program
    {
        static int height = 166, g = 46;
        static double weight = 48.2;
        static float number = 3.745f;
        static char symbol = '&';
        static string str = "nice to meet you!";
        static string name = "Sanya";
       // static string str_out;
        static int group_num = 9;

        static void task0()
        {
            Console.WriteLine(height);
            Console.Write(weight + "   ");
            Console.WriteLine(number);
            Console.WriteLine(str);
            Console.WriteLine(symbol);
            Console.WriteLine();

            decimal num_dec = (decimal)group_num; //явное преобразование
            byte person_info = (byte)(height + weight); //явное преобразование инт и дабл в байт
            int isymbol = (int)(symbol); //преобр чар в инт
            float fweight = (float)weight;
            char chg = (char)g;

            long lgroup_num = group_num;//неявное преобразование
            float fgroup_num = lgroup_num;
            double dgroup_num = fgroup_num;
            long lheight = height;   // из инт в лонг
            short s_person_info = person_info;

            Console.WriteLine(Convert.ToDouble(group_num)); //?? явное??
            Console.WriteLine(Convert.ToString(group_num)); //?? явное??

            int x = 11;
            object y = x; //упаковка
            int z = (int)y; //распаковка

            var a = 3; //неявно типизированная переменная
            int b = 10;
            Console.WriteLine(a + b);

            int? q = null; //работа с nullable переменной
            char? w = '*';
            if (q.HasValue)
                Console.WriteLine($"the value is: {q.Value}");
            else Console.WriteLine("a is null");
            if (w.HasValue)
                Console.WriteLine($"the value is: {w.Value}");
            else Console.WriteLine("b is null");
            Console.WriteLine();

            ////var value = "";
            ////value = 5; // сначала тип string потом стал int поэтому и бесится

        }
        static void task1()
        {
            string m = "july";
            string s = "11";
            string j = "animals are cute";
            string t = "tiger";
            char[] array_of_char = new char[] { '~', ' ', ' ', ' ', ' ', ' ', '~' };

            if (String.Compare(m, s) == 0)
                Console.WriteLine($"Both strings have same value.");
            else if (String.Compare(m, s) < 0)
                Console.WriteLine($"{m} precedes {s}.");
            else if (String.Compare(m, s) > 0)
                Console.WriteLine($"{m} follows {s}.");


            Console.WriteLine("the result of concat is " + String.Concat(m, s));

            string[] words = j.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string k in words)
            {
                Console.WriteLine("---------------------" + k);
            }

            
            string result = m.Substring(1); //результат с 1 по индексу символа
            Console.WriteLine(result);
            result = m.Substring(1, 1); //результат с 1 по индексу символа и по длине 1
            Console.WriteLine(result);

            string m_s = m.Insert(2, s);
            Console.WriteLine($"the result of insert m in s in the middle is: {m_s}");

            t.CopyTo(0, array_of_char, 1, 5);
            Console.WriteLine(array_of_char);


            Console.WriteLine("the result of delete is: " + j.Remove(8, 3));


            Console.WriteLine($"my name is {name} !"); //интерполяция
            Console.WriteLine();

            string strA = null, strB = "", strC = "11111";
            if (string.IsNullOrEmpty(strA))
                Console.WriteLine($"is strA empty? {string.IsNullOrEmpty(strA)}");
            if (string.IsNullOrEmpty(strB))
                Console.WriteLine($"is strB empty? {string.IsNullOrEmpty(strB)}");
            if (string.IsNullOrEmpty(strC))
                Console.WriteLine($"is str empty? {string.IsNullOrEmpty(strC)}");
            Console.WriteLine();

            StringBuilder str = new StringBuilder("She wants to build a show around you.");
            Console.WriteLine(str);
            str.Remove(10, 27); // удаляем 13 символов, начиная с 7-го
            Console.WriteLine(str);
            str.Append("a"); //добавили в конец
            Console.WriteLine(str);
            str.Insert(11, " cake! "); // c 11 позиции добавлили пару символов
            Console.WriteLine(str);
        }
        static void task2()
        {
            int[,] array = { { 50, 11, 11 }, { 77, 99, 99 }, { 12, 13, 20 }, { 77, 99, 99 } };
            foreach (int i in array)
                Console.Write($"{i} ");
            Console.WriteLine();
            Console.WriteLine();


            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + " ");
                }

                Console.WriteLine();
            }
            Console.WriteLine();

            string[] array_str = { "sun", "cloud", "moon", "rainbow" };
            foreach (string i in array_str)
                Console.Write($"{i} ");
            Console.WriteLine();
            Console.WriteLine("lenght of array_str: " + array_str.Length);
            Console.WriteLine();

            Console.Write("enter the position: ");
            var pos = Console.ReadLine();
            Console.Write("enter the new word to add in array: ");
            var new_word = Console.ReadLine();
            for (int i = 0; i < array_str.Length; i++)
            {
                if (i == Convert.ToInt32(pos) - 1)
                {
                    array_str[i] = new_word;
                }
            }
            foreach (string i in array_str)
                Console.Write($"{i} ");
            Console.WriteLine();
            Console.WriteLine();

            int[][] arr = new int[3][];
            arr[0] = new int[2];
            arr[1] = new int[3];
            arr[2] = new int[4];


            for (int i = 0; i < 2; i++)
            {
                arr[0][i] = i;
                Console.Write(arr[0][i] + " ");
            }
            Console.WriteLine();

            for (int i = 0; i < 3; i++)
            {
                arr[1][i] = i;
                Console.Write(arr[1][i] + " ");
            }
            Console.WriteLine();

            for (int i = 0; i < 4; i++)
            {
                arr[2][i] = i;
                Console.Write(arr[2][i] + " ");
            }
            Console.WriteLine();

            var q = new[] { 1, 2 };
            var p = new[] { "roses are red", "violets are blue" };

            Console.WriteLine();

        }


        static void task3()
        {
            (int, string, char, string, ulong) tuple = (9, "hello!", '&', "12345", 23);
            Console.WriteLine(tuple);
            Console.WriteLine(tuple.Item1);
            Console.WriteLine(tuple.Item3);
            Console.WriteLine(tuple.Item4);
            Console.WriteLine();



            (int it1, string it2, char it3, string it4, ulong it5) = tuple;
            Console.WriteLine(it1);
            Console.WriteLine(it4);

            (int, int) t1 = (1, 65);
            (int, int) t2 = (0, 65);
            if (t1 == t2) { Console.WriteLine("TRUE"); }
            else { Console.WriteLine("FALSE"); }
            Console.WriteLine();



            Console.WriteLine("----------------");
            Console.WriteLine();
        }
        
        
        static void Main(string[] args)
        {
            // task0();
            // task1();
            //task2();
            // task3();
            Tuple<int, int, int, char> function_1(int[] nums, string str)
            {
                Array.Sort(nums);
                var k = Tuple.Create(nums[nums.Length - 1], nums[0], nums.Sum(), str[0]);
                return k;
            }
             function_1(new int[] { 45, 4 }, "berwd");


            int local_first()
            {
                try
                {
                    checked
                    {
                        int qwerty = 2147483647;
                        Console.WriteLine(qwerty++);
                    }
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return 0;
            }
            int local_second()
            {
                try
                {
                    unchecked
                    {
                        int qwerty = 2147483647;
                        Console.WriteLine(qwerty++);
                    }
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return 0;
            }
            local_first();
            local_second();

            


            Console.ReadKey();
        }
        //     private static void test()
        //    {
        //        using (Example mmm = new Example(32222222))
        //        {
        //            // переменная mmm доступна только в блоке using
        //            Console.WriteLine($"Получим число: {mmm.GetState()}");
        //        }
        //        Console.WriteLine("Конец метода test");
        //    }
        //}
        //class Example : IDisposable
        //{
        //    private readonly int _state;
        //    public Example(int state)
        //    {
        //        _state = state;
        //    }
        //    public int GetState() => _state;
        //    public void Dispose() { }
        //}
    }
}
