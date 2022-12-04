namespace aoc.D04
{
  public static class PairAnalyzer
  {
    public static int GetFullyCotainedPairsCount(List<Pair> pairs)
    {
      int count = 0;

      foreach (Pair pair in pairs)
      {
        if (OnePairIsFullyContained(pair))
          count++;
      }

      return count;
    }

    public static int GetOverlappingPairsCount(List<Pair> pairs)
    {
      int count = 0;

      foreach (Pair pair in pairs)
      {
        if (PairsOverlap(pair))
          count++;
      }

      return count;
    }

    private static bool OnePairIsFullyContained(Pair pair)
    {
      bool result = true;

      if ( pair.Elf1.Count < pair.Elf2.Count )
      {
        foreach (var item in pair.Elf1)
        {
          if (pair.Elf2.Contains(item) == false)
          {
            result = false;
            break;
          }
        }
      }
      else
      {
        foreach (var item in pair.Elf2)
        {
          if (pair.Elf1.Contains(item) == false)
          {
            result = false;
            break;
          }
        }
      }

      return result;
    }

    private static bool PairsOverlap(Pair pair)
    {
      bool result = false;

      if (pair.Elf1.Count < pair.Elf2.Count)
      {
        foreach (var item in pair.Elf1)
        {
          if (pair.Elf2.Contains(item) == true)
          {
            result = true;
            break;
          }
        }
      }
      else
      {
        foreach (var item in pair.Elf2)
        {
          if (pair.Elf1.Contains(item) == true)
          {
            result = true;
            break;
          }
        }
      }

      return result;
    }
  }
}
