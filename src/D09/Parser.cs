namespace aoc.D09
{
  public static class Parser
  {
    public static List<Move> Parse(string path)
    {
      var moves = new List<Move>();
      var lines = File.ReadAllLines(path);

      foreach (var line in lines)
      {
        var s_arr = line.Split(' ');
        var move = new Move();
        move.steps = int.Parse(s_arr[1]);

        move.dir = s_arr[0] switch
        {
          "U" => Direction.Up,
          "D" => Direction.Down,
          "R" => Direction.Right,
          "L" => Direction.Left,
          _ => Direction.Neutral,
        };

        moves.Add(move);
      }

      return moves;
    }
  }
}
