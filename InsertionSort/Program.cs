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
        int[] values = randArray.genArray(2500);
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        // code goes here

        stopwatch.Stop();
        TimeSpan ts = stopwatch.Elapsed;
        System.Console.WriteLine(
            "execution time: {0:00}:{1:00}:{2:00}.{3}",
            ts.Hours,
            ts.Minutes,
            ts.Seconds,
            ts.Milliseconds
        );
    }
}
