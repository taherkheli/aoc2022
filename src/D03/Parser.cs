namespace aoc.D03
{
  public static class Parser
  {
    public static List<Rucksack> Parse(string path)
    {
      var rucksacks = new List<Rucksack>();
      var lines = File.ReadAllLines(path);

      foreach (var line in lines)
      {
        int length = line.Length / 2;
        Rucksack rucksack = new Rucksack();
        rucksack.C1 = line.Substring(0, length);
        rucksack.C2 = line.Substring(length, length);   
        rucksacks.Add(rucksack);
      }

      return rucksacks;
    }
  }
}
