namespace aoc.D05
{
  public readonly record struct Data(IEnumerable<Move> moves, IEnumerable<IEnumerable<char>> CurrentCfg);
}
