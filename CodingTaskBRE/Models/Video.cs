using System;

namespace CodingTaskBRE
{
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
}
