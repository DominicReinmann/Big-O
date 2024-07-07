public class Program
{
    public static class RandArray
    {
        public static int[] GenArray(int count)
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

    public static int GenDigits(int num, int place)
    {
        return (int)(Math.Floor(Math.Abs(num) / Math.Pow(10, place)) % 10);
    }

    public static int GetNumberOfDigits(int num)
    {
        return num == 0 ? 1 : (int)Math.Floor(Math.Log10(Math.Abs(num))) + 1;
    }

    public static int[] RadixSort(int[] values)
    {
        var maxDigit = 0;

        for (int i = 0; i < values.Length; i++)
        {
            maxDigit = Math.Max(maxDigit, GetNumberOfDigits(values[i]));
        }

        for (int i = 0; i < maxDigit; i++)
        {
            var buckets = new List<List<int>>();

            for (int j = 0; j < 10; j++)
            {
                buckets.Add(new List<int>());
            }

            for (int j = 0; j < values.Length; j++)
            {
                var digits = (int)GenDigits(values[j], i);
                buckets[digits].Add(values[j]);
            }

            var index = 0;

            for (int j = 0; j < buckets.Count; j++)
            {
                for (int k = 0; k < buckets[j].Count; k++)
                {
                    values[index++] = buckets[j][k];
                }
            }
        }

        return values;
    }

    static void Main(string[] args)
    {
        int[] values = RandArray.GenArray(250000);
        DateTime startTime = DateTime.Now;

        RadixSort(values);

        DateTime endTime = DateTime.Now;
        TimeSpan elapsedTime = endTime - startTime;

        string filePath = "Radix.txt";
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine("sortedArray");
            writer.WriteLine(values.Count() + " entrys");
            writer.WriteLine("Execution time: {0}", elapsedTime);
        }
        System.Console.WriteLine("Finished");
    }
}
