namespace aoc.D04
{
  public static class PairAnalyzer
  {
    public static int GetFullyCotainedPairsCount(IEnumerable<Pair> pairs)
    {
      int count = 0;

      foreach (var pair in pairs)
        if (OnePairIsFullyContained(pair))
          count++;      

      return count;
    }

    public static int GetOverlappingPairsCount(IEnumerable<Pair> pairs)
    {
      int count = 0;

      foreach (var pair in pairs)
        if (PairsOverlap(pair))
          count++;

      return count;
    }

    private static bool OnePairIsFullyContained(Pair pair)
    {
      bool result = false;
      var intersectionCount = (pair.Elf1.Intersect(pair.Elf2)).Count();

      if ( pair.Elf1.Count() == intersectionCount || pair.Elf2.Count() == intersectionCount)  
        result = true;

      return result;
    }

    private static bool PairsOverlap(Pair pair)
    {
      bool result = false;

      if (pair.Elf1.Intersect(pair.Elf2).Count() > 0)
        result = true;

      return result;
    }
  }
}
