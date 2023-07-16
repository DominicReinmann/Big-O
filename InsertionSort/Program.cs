﻿using System.Diagnostics;

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
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        // code goes here
        for (int i = 1; i < values.Length; i++)
        {
            var current = values[i];
            var j = i - 1;
            while (j > -1 && current < values[j])
            {
                values[j + 1] = values[j];
                j--;
            }
            values[j + 1] = current;
        }

        stopwatch.Stop();
        TimeSpan ts = stopwatch.Elapsed;
        System.Console.WriteLine(
            "execution time: {0:00}:{0:00}:{0:00}.{0}",
            ts.Hours,
            ts.Minutes,
            ts.Seconds,
            ts.Milliseconds
        );
    }
}
