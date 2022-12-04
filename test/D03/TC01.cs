using aoc.D03;
using Xunit;

namespace aoc.test.D03
{
  public class TC01
  {
    [Fact]
    public void InitialI()
    {
      int expected = 157;
      var rucksacks = Parser.Parse(@"./D03/initial.txt");
      var actual = Calculator.GetSumOfPriorities(rucksacks);
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void PartI()
    {
      int expected = 7674;
      var rucksacks = Parser.Parse(@"./D03/input.txt");
      var actual = Calculator.GetSumOfPriorities(rucksacks);
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void InitialII()
    {
      int expected = 70;
      var rucksacks = Parser.Parse(@"./D03/initial.txt");
      var actual = Calculator.GetSumOfPrioritiesPartII(rucksacks);
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void PartII()
    {
      int expected = 2805;
      var rucksacks = Parser.Parse(@"./D03/input.txt");
      var actual = Calculator.GetSumOfPrioritiesPartII(rucksacks);
      Assert.Equal(expected, actual);
    }
  }
}