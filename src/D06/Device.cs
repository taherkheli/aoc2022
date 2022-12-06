namespace aoc.D06
{
  public class Device
  {
    public int PacketStartMarker(string s, int windowSize)
    {
      int index = -1;
      var input = s.ToCharArray();
      var window = new List<char>();
      
      for (int i = 0; i < windowSize; i++)      
        window.Add(input[i]);
      
      if (SequenceHasRepeatingCharacters(window) == false)
        index = windowSize;
      else
      {
        for (int i = windowSize; i < input.Length; i++)
        {
          window.RemoveAt(0);
          window.Add(input[i]);
          if (SequenceHasRepeatingCharacters(window) == false)
          {
            index = i + 1;
            break;
          }
        }
      }

      return index;
    }

    private bool SequenceHasRepeatingCharacters(List<char> w)
    {
      var result = false;

      foreach (var c in w)
      { 
        int count = w.FindAll( a => a == c).Count;
        if (count > 1)
        {
          result = true;
          break;
        }
      }

      return result;
    }
  }
}
