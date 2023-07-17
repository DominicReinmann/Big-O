public class Program {
  public static class randArray {
    public static int[] genArray(int count) {
      Random random = new Random();
      int[] values = new int[count];

      for (int i = 0; i < count; ++i) {
        values[i] = random.Next();
      }
      return values;
    }
  }

  public static int Partition(int[] values, int left, int right) {
    int pivotValue = values[right];
    int partitionIndex = left;

    for (int i = left; i < right; i++) {
      if (values[i] < pivotValue) {
        Swap(values, i, partitionIndex);
        partitionIndex++;
      }
    }
    Swap(values, right, partitionIndex);
    return partitionIndex;
  }

  public static void Swap(int[] values, int firstIndex, int secondIndex) {
    var tmp = values[firstIndex];
    values[firstIndex] = values[secondIndex];
    values[secondIndex] = tmp;
  }

  public static void QuickSort(int[] values, int left = 0, int right = -1) {
    if (right == -1)
      right = values.Length - 1;

    if (left >= right) {
      return;
    }
    var pivotIndex = Partition(values, left, right);
    QuickSort(values, left, pivotIndex - 1);
    QuickSort(values, pivotIndex + 1, right);
  }

  static void Main(string[] args) {
    int[] values = randArray.genArray(250000);
    DateTime startTime = DateTime.Now;

    QuickSort(values);

    DateTime endTime = DateTime.Now;
    TimeSpan elapsedTime = endTime - startTime;

    string filePath = "Quick.txt";
    using (StreamWriter writer = new StreamWriter(filePath)) {
      writer.WriteLine("sortedArray");
      writer.WriteLine(values.Length + " entrys");
      writer.WriteLine("Execution time: {0}", elapsedTime);

      System.Console.WriteLine("Finished");
    }
  }
}
