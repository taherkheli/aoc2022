using aoc.D02;
using Xunit;

namespace aoc.test.D02
{
  public class TC01
  {
    [Fact]
    public void InitialI()
    {
      int expected = 15;
      var rounds = Parser.Parse(@"./D02/initial.txt");
      var actual = ScoreCalculator.GetPlayer2Score(rounds);
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void PartI()
    {
      int expected = 11603;
      var rounds = Parser.Parse(@"./D02/input.txt");
      var actual = ScoreCalculator.GetPlayer2Score(rounds);
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void InitialII()
    {
      int expected = 12;
      var rounds = Parser.Parse(@"./D02/initial.txt");
      var actual = ScoreCalculator.GetPlayer2ScorePartII(rounds);
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void PartII()
    {
      int expected = 12725;
      var rounds = Parser.Parse(@"./D02/input.txt");
      var actual = ScoreCalculator.GetPlayer2ScorePartII(rounds);
      Assert.Equal(expected, actual);
    }
  }
}