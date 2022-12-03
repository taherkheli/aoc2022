namespace aoc.D01
{
  public static class Parser
  {
    public static List<Elf> Parse(string path)
    {
      var lines = File.ReadAllLines(path);
      List<Elf> elves = new List<Elf>();

      var temp = new List<int>();

      foreach (var line in lines)
      {
        if (line.Length == 0)
        {
          if (temp.Count > 0)
            elves.Add(new Elf(temp));

          temp = new List<int>();
          continue;
        }

        temp.Add(int.Parse(line.Trim()));
      }

      //last iteration
      if (temp.Count > 0)
        elves.Add(new Elf(temp));

      return elves;
    }
  }
}
