using aoc.D01;
using Xunit;

namespace aoc.test.D01
{
  public class TC01
  {
    [Fact]
    public void InitialI()
    {
      int expected = 24000;
      var elves = Parser.Parse(@"./D01/initial.txt");
      var actual = CalorieCounter.GetMaxCalories(elves);
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void PartI()
    {
      int expected = 70764;
      var elves = Parser.Parse(@"./D01/input.txt");
      var actual = CalorieCounter.GetMaxCalories(elves);
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void InitialII()
    {
      int expected = 45000;
      var elves = Parser.Parse(@"./D01/initial.txt");
      var actual = CalorieCounter.GetMaxCaloriesTop3(elves);
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void PartII()
    {
      int expected = 203905;
      var elves = Parser.Parse(@"./D01/input.txt");
      var actual = CalorieCounter.GetMaxCaloriesTop3(elves);
      Assert.Equal(expected, actual);
    }
  }
}