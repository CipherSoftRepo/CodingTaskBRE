using System;

namespace CodingTaskBRE
{
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
}
