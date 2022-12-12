namespace aoc.D09
{
  public class Point
  {
    private int _x;
    private int _y;
    private int _tailVisits;

    public Point(int x, int y)
    {
      _x = x;
      _y = y;
      _tailVisits = 0;
    }

    public int X
    {
      get
      {
        return _x;
      }
      set
      {
        _x = value;
      }
    }

    public int Y
    {
      get
      {
        return _y;
      }
      set
      {
        _y = value;
      }
    }

    public int TailVisits
    {
      get
      {
        return _tailVisits;
      }
      set
      {
        _tailVisits = value;
      }
    }
  }
}
