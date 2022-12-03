namespace aoc.D02
{
  public static class Parser
  {
    public static List<Round> Parse(string path)
    {
      var lines = File.ReadAllLines(path);
      List<Round> rounds = new List<Round>();

      foreach (var line in lines)
      {
        var round = new Round();

        switch (line[0])
        {
          case 'A':
            round.Player1 = Shape.Rock;
            break;

          case 'B':
            round.Player1 = Shape.Paper;
            break;

          case 'C':
            round.Player1 = Shape.Scissors;
            break;

          default:
            throw new Exception("should not have happened");
        }

        switch (line[2])
        {
          case 'X':
            round.Player2 = Shape.Rock;
            break;

          case 'Y':
            round.Player2 = Shape.Paper;
            break;

          case 'Z':
            round.Player2 = Shape.Scissors;
            break;

          default:
            throw new Exception("should not have happened");
        }

        rounds.Add(round);
      }

      return rounds;
    }
  }
}
