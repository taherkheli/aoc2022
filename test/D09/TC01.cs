using aoc.D09;
using Xunit;

namespace aoc.test.D09
{
  public class TC01
  {
    [Theory]
    [InlineData("initial.txt", 2, 13)]
    [InlineData("input.txt", 2, 6522)]
    //[InlineData("initial.txt", 10, 1)]
    public void Test(string fileName, int size, int expected)
    {
      var grid = new Grid(Parser.Parse(@"./D09/" + fileName), size);
      var actual = grid.Execute();
      Assert.Equal(expected, actual);
    }
  }
}
