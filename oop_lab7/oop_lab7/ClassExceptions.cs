using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_lab7
{
    class WeightException : Exception
    {
        public WeightException() 
        {
            Console.WriteLine($"Вес товара не может быть равен 0!");
        }
        
    }
}
