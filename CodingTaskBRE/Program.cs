using System;
using System.Linq;

namespace CodingTaskBRE
{

    class Program
    {
        static void Main(string[] args)
        {
            var enumList = Enum.GetNames(typeof(OrderSystem.ProductTypes)).ToList();
            Console.WriteLine("Enter Product type ({0}) and name (if applicable) seperated by space", string.Join(", ", enumList));
            var input = Console.ReadLine()?.Split(' ');
            var output = OrderSystem.GetOrderedProduct(input);
            Console.WriteLine("Name: {0}\nOperations: {1}", output.Name, string.Join(' ', output.Operations));
            Console.ReadLine();

        }
    }
}
