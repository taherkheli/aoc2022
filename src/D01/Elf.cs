namespace aoc.D01
{
  public class Elf
  {
    List<int> _calories;

    public Elf(List<int> calories)
    {
      _calories = calories;
    }

    public int Calories()
    {
      int result = 0;

      for (int i = 0; i < _calories.Count; i++)
        result += _calories[i];
            
      return result;
    }
  }
}