namespace BloomFIlter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int length = 20;
            List<int> nums = new List<int>();
            BloomFlower<int> thing = new BloomFlower<int>(length * 2, 3);
            for (int i = 0;i < length;i++)
            {
                nums.Add(i);
                thing.Insert(i);
            }
            foreach(var item in thing.Filter)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(thing.ProbablyContains(67));
        }
    }
}