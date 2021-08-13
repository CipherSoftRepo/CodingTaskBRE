namespace CodingTaskBRE
{
    public class Other : PhysicalProduct
    {
        public Other(string name)
        {
            Name = name;
            base.GetSlip();
            base.AddCommission();
        }
    }
}
