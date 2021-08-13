using System.Collections.Generic;

namespace CodingTaskBRE
{
    public abstract class ProductBase : IProduct
    {
        public string Name { get; set; }
        public abstract void GetSlip();
        public List<string> Operations { get; set; } = new List<string>();
    }
}
