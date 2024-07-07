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

    public static int[] Merge(int[] left, int[] right)
    {
        var values = new int[left.Length + right.Length];
        int leftIndex = 0, rightIndex = 0, mergedIndex = 0;

        while (leftIndex < left.Length && rightIndex < right.Length)
        {
            if (left[leftIndex] < right[rightIndex])
            {
                values[mergedIndex] = left[leftIndex];
                leftIndex++;
            }
            else
            {
                values[mergedIndex] = right[rightIndex];
                rightIndex++;
            }
            mergedIndex++;
        }
        while (leftIndex < left.Length)
        {
            values[mergedIndex] = left[leftIndex];
            leftIndex++;
            mergedIndex++;
        }
        while (rightIndex < right.Length)
        {
            values[mergedIndex] = right[rightIndex];
            rightIndex++;
            mergedIndex++;
        }
        return values;
    }

    public static int[] MergeSort(int[] values)
    {
        if (values.Length < 2)
        {
            return values;
        }
        int mid = values.Length / 2;
        int[] left = new int[mid];
        int[] right = new int[values.Length - mid];
        Array.Copy(values, 0, left, 0, mid);
        Array.Copy(values, mid, right, 0, values.Length - mid);

        left = MergeSort(left);
        right = MergeSort(right);

        return Merge(left, right);
    }

    static void Main(string[] args)
    {
        int[] values = RandArray.GenArray(25000);
        DateTime startTime = DateTime.Now;

        values = MergeSort(values);

        DateTime endTime = DateTime.Now;
        TimeSpan elapsedTime = endTime - startTime;

        string filePath = "Merge.txt";
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine("sortedArray");
            writer.WriteLine(values.Length + " entrys");
            writer.WriteLine("Execution time: {0}", elapsedTime);

            System.Console.WriteLine("Finished");
        }
    }
}
