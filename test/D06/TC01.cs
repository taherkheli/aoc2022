using aoc.D06;
using Xunit;

namespace aoc.test.D06
{
  public class TC01
  {
    [Theory]
    [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 4, 7)]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 4, 5)]
    [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 4, 6)]
    [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 4, 10)]
    [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 4, 11)]
    [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 14, 19)]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 14, 23)]
    [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 14, 23)]
    [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 14, 29)]
    [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 14, 26)]
    public void Initial(string s, int windowSize, int expected)
    {
      var d = new Device();
      var actual = d.PacketStartMarker(s,windowSize);
      Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(4, 1361)]
    [InlineData(14, 3263)]
    public void PartII(int windowSize, int expected)
    {
      var text = File.ReadAllText(@"./D06/input.txt");
      var d = new Device();
      var actual = d.PacketStartMarker(text, windowSize);
      Assert.Equal(expected, actual);
    }
  }
}
