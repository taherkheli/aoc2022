namespace aoc.D09
{
  public class Rope
  {
    private Point[] _knots; 

    public Rope(Point origin, int size)
    {
      _knots = new Point[size];

      for (int i = 0; i < size; i++)
        _knots[i] = origin;     
    }

    public Point[] Knots { get { return _knots; } set { _knots = value; } }
  }
}
