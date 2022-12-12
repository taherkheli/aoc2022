namespace aoc.D09
{
  public class Grid
  {
    private List<Move> _moves = new List<Move>();
    private List<Point> _points = new List<Point>();
    private Rope _rope;

    public Grid(List<Move> moves, int ropeSize)
    {
      _moves = moves;
      var p = new Point(0, 0);      
      _points.Add(p);
      _rope = new Rope(p, ropeSize);
    }

    public int Execute()
    {
      foreach (var move in _moves)
        for (int i = 0; i < move.steps; i++)
          HandleStep(move.dir);

      var list = _points.FindAll(p => p.TailVisits > 0);

      return list.Count();
    }

    private void HandleStep(Direction dir)
    {
      for (int i = 0; i < _rope.Knots.Length - 1; i++)
      {
        var updated = new Point[2];
        var tempH = _rope.Knots[i];
        var tempT = _rope.Knots[i + 1];

        switch (dir)
        {
          case Direction.Up:
            updated = UpUpdate(tempH, tempT);
            break;
          case Direction.Down:
            updated = DownUpdate(tempH, tempT);
            break;
          case Direction.Left:
            updated = LeftUpdate(tempH, tempT);
            break;
          case Direction.Right:
            updated = RightUpdate(tempH, tempT);
            break;
          case Direction.Neutral:
          default:
            throw new Exception("No clue :(");
        }

        if (i == 0)
          _rope.Knots[0] = updated[0];

        _rope.Knots[i + 1] = updated[1];

        if (i + 1 == _rope.Knots.Length - 1)
          _rope.Knots[i + 1].TailVisits++;
      }
    
     //if ((updated[1].X == tempT.X) && (updated[1].Y == tempT.Y))  //temp tail did not even move
        //  break;
        //else
        //{
        //  if(  (Math.Abs(updated[1].X - tempT.X) == 1) ||
        //       (Math.Abs(updated[1].Y - tempT.Y) == 1)
        //    )
        //  {
        //    _rope.Knots[i + 1] = updated[1];
        //    continue;
        //  }
        //  else 
        //  {
        //    if (updated[1].X - tempT.X > 1)
        //    {
        //      dir = Direction.Right;
        //      _rope.Knots[i + 1] = updated[1];
        //    }
        //    else if (updated[1].X - tempT.X < -1)
        //    {
        //      dir = Direction.Left;
        //      _rope.Knots[i + 1] = updated[1];
        //    }
        //    else if (updated[1].Y - tempT.Y > 1)
        //    {
        //      dir = Direction.Up;
        //      _rope.Knots[i + 1] = updated[1];
        //    }
        //    else if (updated[1].Y - tempT.Y < -1)
        //    {
        //      dir = Direction.Down;
        //      _rope.Knots[i + 1] = updated[1];
      
    }

    private Point[] UpUpdate(Point tempH, Point tempT)
    {
      var temp = _points.Find(p => (p.X == tempH.X) && (p.Y == tempH.Y + 1));

      if (temp == null)
      {
        temp = new Point(tempH.X, tempH.Y + 1);
        _points.Add(temp);
      }
      
      tempH = temp;

      if ((tempH.Y - tempT.Y) > 1)  //tail will move
      {
        var tempX = 0;
        var tempY = tempT.Y + 1;

        if (tempH.X < tempT.X)     //slant backward x
          tempX = tempT.X - 1;
        else
        {
          if (tempH.X == tempT.X)  //horizontal
            tempX = tempT.X;
          else                     //slant forward x
            tempX = tempT.X + 1;
        }

        temp = _points.Find(p => (p.X == tempX) && (p.Y == tempY));

        if (temp == null)
        {
          temp = new Point(tempX, tempY);
          _points.Add(temp);
          tempT = temp;
        }
        
        tempT = temp;        
      }

      return (new Point[] { tempH, tempT });
    }

    private Point[] DownUpdate(Point tempH, Point tempT)
    {
      var temp = _points.Find(p => (p.X == tempH.X) && (p.Y == tempH.Y - 1));

      if (temp == null)
      {
        temp = new Point(tempH.X, tempH.Y - 1);
        _points.Add(temp);
      }
      
      tempH = temp;

      if (Math.Abs(tempH.Y - tempT.Y) > 1)  //tail will move
      {
        var tempX = 0;
        var tempY = tempT.Y - 1;

        if (tempH.X < tempT.X)
          tempX = tempT.X - 1;
        else
        {
          if (tempH.X == tempT.X)
            tempX = tempT.X;
          else
            tempX = tempT.X + 1;
        }

        temp = _points.Find(p => (p.X == tempX) && (p.Y == tempY));

        if (temp == null)
        {
          temp = new Point(tempX, tempY);
          _points.Add(temp);
        }
        
        tempT = temp;
      }
      
      return (new Point[] { tempH, tempT });
    }

    private Point[] LeftUpdate(Point tempH, Point tempT)
    {
      var temp = _points.Find(p => (p.X == tempH.X - 1) && (p.Y == tempH.Y));

      if (temp == null)
      {
        temp = new Point(tempH.X - 1, tempH.Y);
        _points.Add(temp);
      }
      
      tempH = temp;

      if (Math.Abs(tempH.X - tempT.X) > 1)  //tail will move
      {
        var tempX = tempT.X - 1;
        var tempY = 0;

        if (tempH.Y > tempT.Y)      //slant up
          tempY = tempT.Y + 1;
        else
        {
          if (tempH.Y == tempT.Y)  //horizontal
            tempY = tempT.Y;
          else                     //slant down
            tempY = tempT.Y - 1;
        }

        temp = _points.Find(p => (p.X == tempX) && (p.Y == tempY));

        if (temp == null)
        {
          temp = new Point(tempX, tempY);
          _points.Add(temp);
        }

        tempT = temp;
      }

      return (new Point[] { tempH, tempT });      
    }

    private Point[] RightUpdate(Point tempH, Point tempT)
    {
      var temp = _points.Find(p => (p.X == tempH.X + 1) && (p.Y == tempH.Y));

      if (temp == null)
      {
        temp = new Point(tempH.X + 1, tempH.Y);
        _points.Add(temp);
      }

      tempH = temp;

      if ((tempH.X - tempT.X) > 1)  //tail will move
      {
        var tempX = tempT.X + 1;
        var tempY = 0;

        if (tempH.Y > tempT.Y)      //slant up
          tempY = tempT.Y + 1;
        else
        {
          if (tempH.Y == tempT.Y)  //horizontal
            tempY = tempT.Y;
          else                     //slant down
            tempY = tempT.Y - 1;
        }

        temp = _points.Find(p => (p.X == tempX) && (p.Y == tempY));

        if (temp == null)
        {
          temp = new Point(tempX, tempY);
          _points.Add(temp);
        }

        tempT = temp;
      }

      return (new Point[] { tempH, tempT });
    }
  }
}
