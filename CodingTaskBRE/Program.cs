using System;
using System.Collections.Generic;

namespace CodingTaskBRE
{

    public abstract class Product
    {
        public string Name { get; set; }
        public abstract void GetSlip();
        public List<string> Operations { get; set; } = new List<string>();
    }
    public abstract class PhysicalProduct : Product
    {
        public override void GetSlip()
        {
            Operations.Add("Generated a packing slip for shipping.");
            Console.WriteLine("Generated a packing slip for shipping.");
        }
        public virtual void AddCommission()
        {
            Operations.Add("Commission payment to the agent");
            Console.WriteLine("Commission payment to the agent");
        }
    }

    public class Book : PhysicalProduct
    {
        public Book(string name)
        {
            Name = name;
            base.GetSlip();
            base.AddCommission();
            GetSlip();
        }
        public override void GetSlip()
        {
            Operations.Add("Create a duplicate packing slip for the royalty department.");
            Console.WriteLine("Create a duplicate packing slip for the royalty department.");
        }
    }

    public class Other : PhysicalProduct
    {
        public Other(string name)
        {
            Name = name;
            base.GetSlip();
            base.AddCommission();
        }
    }

    public class OrderSystem
    {
        public static Product GetProduct(string[] inputs)
        {
            return null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Book book = new Book("ipsum");
        }
    }
}
