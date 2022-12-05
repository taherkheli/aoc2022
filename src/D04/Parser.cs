namespace aoc.D04
{
  public static class Parser
  {
    public static IEnumerable<Pair> Parse(string path)
    {
      var pairs = new List<Pair>();
      var lines = File.ReadAllLines(path);

      foreach (var line in lines)
      {
        var elf1 = new List<int>();
        var elf2 = new List<int>();

        var fragments = line.Split(',');
        var limits1 = fragments[0].Split('-');
        var limits2 = fragments[1].Split('-');
        var start1 = int.Parse(limits1[0]);
        var end1 = int.Parse(limits1[1]);
        var start2 = int.Parse(limits2[0]);
        var end2 = int.Parse(limits2[1]);

        int val = start1;
        for (int i = 0; i < end1 - start1 + 1; i++)
        {
          elf1.Add(val);
          val++;
        }

        val = start2;
        for (int i = 0; i < end2 - start2 + 1; i++)
        {
          elf2.Add(val);
          val++;
        }

        pairs.Add(new Pair(elf1, elf2));
      }

      return pairs;
    }
  }
}
