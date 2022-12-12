using aoc.D07;
using Xunit;

namespace aoc.test.D07
{
  public class TC01
  {
    [Theory]
    [InlineData("initial.txt", 95437)]
    [InlineData("input.txt", 1454188)]
    public void PartI(string fileName , int expected) 
    {
      var shell = new Shell(@"./D07/" + fileName);
      var actual = shell.PartI();
      Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("initial.txt", 24933642)]
    [InlineData("input.txt", 4183246)]
    public void PartII(string fileName, int expected)
    {
      var shell = new Shell(@"./D07/" + fileName);
      var actual = shell.PartII();
      Assert.Equal(expected, actual);
    }
  }
}
