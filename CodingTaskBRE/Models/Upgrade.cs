using System;

namespace CodingTaskBRE
{
    public class Upgrade : NonPhysicalProduct
    {
        public Upgrade()
        {
            base.GetSlip();
            Operations.Add("Apply the upgrade");
            Console.WriteLine("Apply the upgrade");
            base.DropMail();
        }
    }
}
