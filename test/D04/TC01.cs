using aoc.D04;
using Xunit;

namespace aoc.test.D04
{
  public class TC01
  {
    [Fact]
    public void InitialI()
    {
      int expected = 2;
      var pairs = Parser.Parse(@"./D04/initial.txt");
      var actual = PairAnalyzer.GetFullyCotainedPairsCount(pairs);
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void PartI()
    {
      int expected = 573;
      var pairs = Parser.Parse(@"./D04/input.txt");
      var actual = PairAnalyzer.GetFullyCotainedPairsCount(pairs);
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void InitialII()
    {
      int expected = 4;
      var pairs = Parser.Parse(@"./D04/initial.txt");
      var actual = PairAnalyzer.GetOverlappingPairsCount(pairs);
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void PartII()
    {
      int expected = 867;
      var pairs = Parser.Parse(@"./D04/input.txt");
      var actual = PairAnalyzer.GetOverlappingPairsCount(pairs);
      Assert.Equal(expected, actual);
    }
  }
}
