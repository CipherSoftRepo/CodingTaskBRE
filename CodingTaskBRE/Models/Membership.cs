using System;

namespace CodingTaskBRE
{
    public class Membership : NonPhysicalProduct
    {
        public Membership()
        {
            base.GetSlip();
            Operations.Add("Activate that membership");
            Console.WriteLine("Activate that membership");
            base.DropMail();
        }
    }
}
