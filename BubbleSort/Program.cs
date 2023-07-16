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
        for (int i = 0; i < values.Length; i++)
        {
            for (int j = 0; j < values.Length - i - 1; j++)
            {
                if (values[j] > values[j + 1])
                {
                    var tmp = values[j];
                    values[j] = values[j + 1];
                    values[j + 1] = tmp;
                }
            }
        }
        stopwatch.Stop();
        TimeSpan ts = stopwatch.Elapsed;
        System.Console.WriteLine("execution time: {0:00}:{1:00}:{2:00}.{3}",
                                 ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
    }
}
