public class Program {

  public static class RandArray {
    public static int[] GenArray(int count) {
      Random random = new Random();
      int[] values = new int[count];

      for (int i = 0; i < count; ++i) {
        values[i] = random.Next();
      }
      return values;
    }
  }

  public static void Insertion(int[] values) {
    for (int i = 1; i < values.Length; i++) {
      var current = values[i];
      var j = i - 1;
      while (j > -1 && current < values[j]) {
        values[j + 1] = values[j];
        j--;
      }
      values[j + 1] = current;
    }
  }

  static void Main(string[] args) {
    int[] values = RandArray.GenArray(25000);
    DateTime startTime = DateTime.Now;

    Insertion(values);

    DateTime endTime = DateTime.Now;
    TimeSpan elapsedTime = endTime - startTime;

    string filePath = "Insertion.txt";
    using (StreamWriter writer = new StreamWriter(filePath)) {
      writer.WriteLine("sortedArray");
      writer.WriteLine(values.Length + " entrys");
      writer.WriteLine("Execution time: {0}", elapsedTime);

      System.Console.WriteLine("Finished");
    }
  }
}
