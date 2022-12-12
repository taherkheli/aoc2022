namespace aoc.D08
{
  public class Grid
  {
    private int _rows;
    private int _cols;
    int[,] _points;

    public Grid(string path)
    {
      var lines = File.ReadAllLines(path);
      _rows = lines.Count();
      _cols = lines[0].Length;
      _points = new int[_rows, _cols];

      for (int r = 0; r < _rows; r++)
        for (int c = 0; c < _cols; c++)
          _points[r, c] = int.Parse(lines[r][c].ToString());
    }

    public int GetVisibeTrees()
    {
      int count = 2 * _cols + 2 * (_rows - 2);

      for (int r = 1; r < _rows - 1; r++)
      {
        for (int c = 1; c < _cols - 1; c++)
        {
          var top = VisibleFromTop(r, c);
          var bottom = VisibleFromBottom(r, c);
          var left = VisibleFromLeft(r, c);
          var right = VisibleFromRight(r, c);

          if (top || bottom || left || right)
            count++;
        }
      }

      return count;
    }

    public int GetHighestScenicScore()
    {
      List<int> scenicScores = new List<int>();

      for (int r = 0; r < _rows; r++)
      {
        for (int c = 0; c < _cols; c++)
        {
          var top = ScenicScoreTop(r, c);
          var bottom = ScenicScoreBottom(r, c);
          var left = ScenicScoreLeft(r, c);
          var right = ScenicScoreRight(r, c);
          scenicScores.Add(top * bottom * left * right);
        }
      }

      scenicScores.Sort();

      return scenicScores[scenicScores.Count - 1];
    }

    private bool VisibleFromTop(int r, int c)
    {
      var visible = true;
      var temp = _points[r, c];

      for (int i = r - 1; i > -1; i--)
      {
        if (temp > _points[i, c])
          continue;
        else
        {
          visible = false;
          break;
        }
      }

      return visible;
    }

    private bool VisibleFromBottom(int r, int c)
    {
      var visible = true;
      var temp = _points[r, c];

      for (int i = r+1; i < _rows; i++)
        {
        if (temp > _points[i, c])
          continue;
        else
        {
          visible = false;
          break;
        }
      }

      return visible;
    }

    private bool VisibleFromLeft(int r, int c)
    {
      var visible = true;
      var temp = _points[r, c];

      for (int i = c-1; i > -1; i--)
      {
        if (temp > _points[r, i])
          continue;
        else
        {
          visible = false;
          break;
        }
      }

      return visible;
    }

    private bool VisibleFromRight(int r, int c)
    {
      var visible = true;
      var temp = _points[r, c];

      for (int i = c+1; i < _cols; i++)
      {
        if (temp > _points[r, i])
          continue;
        else
        {
          visible = false;
          break;
        }
      }

      return visible;
    }

    private int ScenicScoreTop(int r, int c)
    {
      int score = 0;
      var temp = _points[r, c];

      for (int i = r - 1; i > -1; i--)
      {
        if (r == 0)
          break;

        if (temp > _points[i, c])
        {
          score++;
          continue;
        }
        else
        {
          score++;
          break;
        }
      }

      return score;
    }

    private int ScenicScoreBottom(int r, int c)
    {
      int score = 0;
      var temp = _points[r, c];

      for (int i = r + 1; i < _rows; i++)
      {
        if (r == _rows - 1)
          break;

        if (temp > _points[i, c])
        {
          score++;
          continue;
        }
        else
        {
          score++;
          break;
        }
      }

      return score;
    }

    private int ScenicScoreLeft(int r, int c)
    {
      int score = 0;
      var temp = _points[r, c];

      for (int i = c - 1; i > -1; i--)
      {
        if (c == 0)
          break;

        if (temp > _points[r, i])
        {
          score++;
          continue;
        }
        else
        {
          score++;
          break;
        }
      }

      return score;
    }

    private int ScenicScoreRight(int r, int c)
    {
      int score = 0;
      var temp = _points[r, c];

      for (int i = c + 1; i < _cols; i++)
      {
        if (c == _cols - 1)
          break;

        if (temp > _points[r, i])
        {
          score++;
          continue;
        }
        else
        {
          score++;
          break;
        }
      }

      return score;
    }
  }
}
