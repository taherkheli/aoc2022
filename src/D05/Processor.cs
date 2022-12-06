using System;

namespace aoc.D05
{
  public class Processor
  {
    private List<Move> _moves = new List<Move>();
    private List<List<char>> _cfg = new List<List<char>>(); 

    public Processor(Data data)
    {
      _moves = data.moves.ToList();
      _cfg = (List<List<char>>)data.CurrentCfg;
    }

    public string GetTopCrates()
    {
      foreach (var move in _moves)
      {
        var srcList = _cfg[move.src - 1];
        var destList = _cfg[move.dest - 1];

        for (int i = 0; i < move.count; i++)
        {
          var index = srcList.Count() - 1;
          var temp = srcList[index];
          srcList.RemoveAt(index);
          destList.Add(temp);
        }
      }

      var list = new List<char>();

      foreach (var crate in _cfg)      
        list.Add(crate[crate.Count() - 1]);

      return String.Concat(list);
    }

    public string GetTopCratesII()
    {
      foreach (var move in _moves)
      {
        var srcList = _cfg[move.src - 1];
        var destList = _cfg[move.dest - 1];
        var index = srcList.Count - move.count;
        var temp = srcList.TakeLast(move.count).ToList();
        srcList.RemoveRange(index, move.count);
        destList.AddRange(temp);
      }

      var list = new List<char>();

      foreach (var crate in _cfg)
        list.Add(crate[crate.Count() - 1]);

      return String.Concat(list);
    }
  }
}
