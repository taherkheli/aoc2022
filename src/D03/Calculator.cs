using System.Security.Cryptography;

namespace aoc.D03
{
  public static class Calculator
  {
    public static int GetSumOfPriorities(List<Rucksack> rucksacks)
    {
      int sum = 0;
      foreach (var rucksack in rucksacks)
      {
        var priorities = GetPriority(GetIntersection(rucksack));
        sum += priorities[0];
      }

      return sum;
    }

    public static int GetSumOfPrioritiesPartII(List<Rucksack> rucksacks)
    {
      var groups = new List<List<Rucksack>>();
      for (int i = 0; i < rucksacks.Count; i+=3)
      {
        var group = new List<Rucksack>();
        group.Add(new Rucksack() { C1 = rucksacks[i].C1, C2 = rucksacks[i].C2 });
        group.Add(new Rucksack() { C1 = rucksacks[i+1].C1, C2 = rucksacks[i+1].C2 });
        group.Add(new Rucksack() { C1 = rucksacks[i+2].C1, C2 = rucksacks[i+2].C2 });
        groups.Add(group);
      }

      int sum = 0;
      foreach (var group in groups)
      {
        var priorities = GetPriority(GetIntersectionPartII(group));
        sum += priorities[0];
      }

      return sum;
    }

    private static char[] GetIntersection(Rucksack rucksack)
    {
      char[] arrayC1 = rucksack.C1.ToCharArray();
      char[] arrayC2 = rucksack.C2.ToCharArray();

      return arrayC1.Intersect(arrayC2).ToArray();
    }

    private static char[] GetIntersectionPartII(List<Rucksack> rucksacks)
    {
      var r1 = rucksacks[0].C1 + rucksacks[0].C2;
      var r2 = rucksacks[1].C1 + rucksacks[1].C2; 
      var r3 = rucksacks[2].C1 + rucksacks[2].C2;
      char[] arrayR1 = r1.ToCharArray();
      char[] arrayR2 = r2.ToCharArray();
      char[] arrayR3 = r3.ToCharArray();

      return arrayR1.Intersect(arrayR2).Intersect(arrayR3).ToArray();
    }

    private static List<int> GetPriority(char[] chars)
    {
      var priorities = new List<int>();
      var lower = "abcdefghijklmnopqrstuvwxyz";
      var upper = lower.ToUpper();
      var alphabet = lower + upper;

      foreach (var c in chars)
        priorities.Add(alphabet.IndexOf(c) + 1);

      return priorities;
    }
  }
}
