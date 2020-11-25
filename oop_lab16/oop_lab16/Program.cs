using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace oop_lab16
{
    class Program
    {
        static void Main(string[] args)
        {
            

            //Task task = new Task(SieveEratosthenes);
            //task.Start();
            //Console.WriteLine($"state in time: {task.Status}");
            //task.Wait();
            //Console.WriteLine("finish method Main");
            //Console.WriteLine($"id: {task.Id}");
            //Console.WriteLine($"state after finish: {task.Status}");


            //Stopwatch watch = new Stopwatch();
            //watch.Start();
            //task.Start();
            //watch.Stop();

            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;
            

            Task task1 = new Task(() =>
            {
                Console.WriteLine("enter n");
                int n = int.Parse(Console.ReadLine());
                var list = new List<int>();
                for (var i = 2; i < n; i++)
                {
                    list.Add(i);
                }

                if (token.IsCancellationRequested)
                {
                  Console.WriteLine("Операция прервана");
                  return;
                }

                for (var i = 0; i < list.Count; i++)
                {
                    for (var j = 2; j < n; j++)
                    {
                        //удаляем кратные числа из списка
                        list.Remove(list[i] * j);
                    }
                }


                foreach (var i in list)
                {
                    Console.WriteLine(i);
                }

            });
            task1.Start();
            Console.WriteLine("enter X to stop or another symbol to continue");
            string symbol = Console.ReadLine();
            if (symbol == "X")
                cancelTokenSource.Cancel();


            SieveEratosthenesAsync();



            Console.ReadKey();
        }
        static void SieveEratosthenes()
        {
            Console.WriteLine("enter n");
            int n = int.Parse(Console.ReadLine());
            var list = new List<int>();
            for (var i = 2; i < n; i++)
            {
                list.Add(i);
            }

            for (var i = 0; i < list.Count; i++)
            {
                for (var j = 2; j < n; j++)
                {
                    //удаляем кратные числа из списка
                    list.Remove(list[i] * j);
                }
            }

           
            foreach (var i in list) 
            {
                Console.WriteLine(i);
            }

        }
        static async void SieveEratosthenesAsync()
        {
            Console.WriteLine("---- begin SieveEratosthenesAsync"); // выполняется синхронно
            await Task.Run(() => SieveEratosthenes());                // выполняется асинхронно
            Console.WriteLine("---- end SieveEratosthenesAsync");
        }

    }

}
