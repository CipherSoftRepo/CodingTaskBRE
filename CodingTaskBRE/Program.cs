using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingTaskBRE
{

    public abstract class Product : IProduct
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

    public abstract class NonPhysicalProduct : Product
    {
        public override void GetSlip()
        {
            Operations.Add("Generated a packing slip.");
            Console.WriteLine("Generated a packing slip.");
        }
        public virtual void DropMail()
        {
            Operations.Add("Mail Sent");
            Console.WriteLine("Mail Sent");
        }

    }

    class Video : NonPhysicalProduct
    {
        public Video(string videoName)
        {
            Name = videoName;

            GetSlip();
        }
        public override void GetSlip()
        {
            base.GetSlip();
            if (Name.ToLowerInvariant().Equals("learning to ski"))
            {
                Operations.Add("'First Aid' video added to the packing slip");
                Console.WriteLine("'First Aid' video added to the packing slip");
            }
        }
    }
    class Membership : NonPhysicalProduct
    {
        public Membership()
        {
            base.GetSlip();
            Operations.Add("Activate that membership");
            Console.WriteLine("Activate that membership");
            base.DropMail();
        }
    }
    class Upgrade : NonPhysicalProduct
    {
        public Upgrade()
        {
            base.GetSlip();
            Operations.Add("Apply the upgrade");
            Console.WriteLine("Apply the upgrade");
            base.DropMail();
        }
    }


    public class OrderSystem
    {
        public enum ProductTypes
        {
            Video,
            Membership,
            Upgrade,
            Book,
            Other
        }

        public static Product GetOrderedProduct(string[] inputs)
        {
            ProductTypes type;
            try
            {
                type = (ProductTypes)Enum.Parse(typeof(ProductTypes), inputs[0], ignoreCase: true);
            }
            catch
            {
                type = ProductTypes.Other;
            }
            Product product;
            string name = inputs.Length > 1 ? string.Join(' ', inputs, 1, inputs.Length - 1) : string.Empty;
            switch (type)
            {
                case ProductTypes.Membership:
                    {
                        product = new Membership();
                        break;
                    }
                case ProductTypes.Upgrade:
                    {
                        product = new Upgrade();
                        break;
                    }
                case ProductTypes.Video:
                    {
                        product = new Video(name);
                        break;
                    }
                case ProductTypes.Book:
                    {
                        product = new Book(name);
                        break;
                    }
                case ProductTypes.Other:
                default:
                    {
                        product = new Other(name);
                        break;
                    }
            }
            return product;

        }
    }

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
