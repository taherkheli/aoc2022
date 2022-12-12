using aoc.D08;
using Xunit;

namespace aoc.test.D08
{
  public class TC01
  {
    [Theory]
    [InlineData("initial.txt", 21)]
    [InlineData("input.txt", 1681)]
    public void TestI(string fileName, int expected)
    {
      var grid = new Grid(@"./D08/"+ fileName);
      var actual = grid.GetVisibeTrees();
      Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("initial.txt", 8)]
    [InlineData("input.txt", 201684)]
    public void TestII(string fileName, int expected)
    {
      var grid = new Grid(@"./D08/" + fileName);
      var actual = grid.GetHighestScenicScore();
      Assert.Equal(expected, actual);
    }
  }
}
