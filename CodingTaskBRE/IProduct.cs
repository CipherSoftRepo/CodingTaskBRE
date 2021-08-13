using System.Collections.Generic;

namespace CodingTaskBRE
{
    public interface IProduct
    {
        string Name { get; set; }
        List<string> Operations { get; set; }

        void GetSlip();
    }
}