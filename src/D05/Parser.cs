namespace aoc.D05
{
  public static class Parser
  {
    public static Data Parse(string path)
    {
      var moves = new List<Move>();
      var lines = File.ReadAllLines(path);
      var CfgLines = new List<string>();
      bool processMoves = false;

      foreach (var line in lines)
      {
        if (processMoves == false)
        {
          if (line != String.Empty)
            CfgLines.Add(line);
        }
        else
        {
          var arr = line.Split(' ');
          var move = new Move(int.Parse(arr[1].Trim()), int.Parse(arr[3].Trim()), int.Parse(arr[5].Trim()));
          moves.Add(move);
        }

        if (line == String.Empty)
          processMoves = true;
      }

      var Cfg = ProcessCfgLines(CfgLines);

      return new Data(moves, Cfg);
    }

    private static List<List<char>> ProcessCfgLines(List<string> CfgLines)
    {
      var linesUpdated = new List<string>();
      var currentCfg = new List<List<char>>();
      var stacks = (CfgLines[CfgLines.Count() - 1]).Split("   ").Count();

      for (int i = 0; i < stacks; i++)
        currentCfg.Add(new List<char>());

      for (int i = 0; i < CfgLines.Count - 1; i++)
        linesUpdated.Add(CfgLines[i]); 

      int startIndex = linesUpdated.Count - 1;

      for (int i = startIndex; i > -1; i--)  //lines going bottom up
      {
        for (int j = 0, k = 1; j < stacks; j++, k+=4)   //stacks filling for each line
        {
          var c = linesUpdated[i].ToCharArray();

          if (c[k] != ' ')
            currentCfg[j].Add(c[k]);
        }
      }

      return currentCfg;
    }
  }
}
