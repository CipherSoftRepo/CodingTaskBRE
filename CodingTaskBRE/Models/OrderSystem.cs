using System;

namespace CodingTaskBRE
{
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

        public static ProductBase GetOrderedProduct(string[] inputs)
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
            ProductBase product;
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
}
