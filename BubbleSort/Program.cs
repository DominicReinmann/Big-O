﻿public class Program
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

    static void Bubble(int[] values)
    {
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
    }

    static void Main(string[] args)
    {
        int[] values = randArray.genArray(25000);
        DateTime startTime = DateTime.Now;

        Bubble(values);

        DateTime endTime = DateTime.Now;
        TimeSpan elapsedTime = endTime - startTime;

        string filePath = "Bubble.txt";
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine("sortedArray");
            writer.WriteLine(values.Length + " entrys");
            writer.WriteLine("Execution time: {0}", elapsedTime);

            System.Console.WriteLine("Finished");
        }
    }
}
