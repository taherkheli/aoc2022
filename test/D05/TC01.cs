using aoc.D05;
using Xunit;

namespace aoc.test.D05
{
  public class TC01
  {
    [Fact]
    public void InitialI()
    {
      var expected = "CMZ";
      var data = Parser.Parse(@"./D05/initial.txt");
      var p= new Processor(data);
      var actual = p.GetTopCrates();
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void PartI()
    {
      var expected = "JDTMRWCQJ";
      var data = Parser.Parse(@"./D05/input.txt");
      var p = new Processor(data);
      var actual = p.GetTopCrates();
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void InitialII()
    {
      var expected = "MCD";
      var data = Parser.Parse(@"./D05/initial.txt");
      var p = new Processor(data);
      var actual = p.GetTopCratesII();
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void PartII()
    {
      var expected = "VHJDDCWRD";
      var data = Parser.Parse(@"./D05/input.txt");
      var p = new Processor(data);
      var actual = p.GetTopCratesII();
      Assert.Equal(expected, actual);
    }
  }
}
