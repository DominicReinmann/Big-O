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

  public static void Selection(int[] values) {
    for (int i = 0; i < values.Length; i++) {
      var min = i;
      for (var j = i + 1; j < values.Length; j++) {
        if (values[j] < values[min]) {
          min = j;
        }
      }
      if (min != i) {
        int tmp = values[i];
        values[i] = values[min];
        values[min] = tmp;
      }
    }
  }

  static void Main(string[] args) {
    int[] values = randArray.genArray(25000);
    DateTime startTime = DateTime.Now;
    Selection(values);
    DateTime endTime = DateTime.Now;
    TimeSpan elapsedTime = endTime - startTime;

    string filePath = "Selection.txt";
    using (StreamWriter writer = new StreamWriter(filePath)) {
      writer.WriteLine("sortedArray");
      writer.WriteLine(values.Length + " entrys");
      writer.WriteLine("Execution time: {0}", elapsedTime);

      System.Console.WriteLine("Finished");
    }
  }
}
