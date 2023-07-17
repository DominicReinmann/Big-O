using System.Diagnostics;

public class Program
{
    public static class randArray
    {
        public static int[] genArray(int count)
        {
            Random random = new Random();
            int[] values = new int[count];

            for (int i = 0; i < count; ++i)
            {
                values[i] = random.Next();
            }
            return values;
        }
    }

    static void Main(string[] args)
    {
        int[] values = randArray.genArray(25000);
        DateTime startTime = DateTime.Now;

        DateTime endTime = DateTime.Now;
        TimeSpan elapsedTime = endTime - startTime;

        string filePath = "Insertion.txt";
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine("sortedArray");
            writer.WriteLine(values.Count() + " entrys");
            writer.WriteLine("Execution time: {0}", elapsedTime);

            System.Console.WriteLine("Finished");
        }
    }
}
