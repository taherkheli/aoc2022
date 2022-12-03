namespace aoc.D01
{
  static public class CalorieCounter
  {
    public static int GetMaxCalories(List<Elf> elves)
    {
      int max = -1;

      foreach (Elf elf in elves)
      {
        if (elf.Calories() > max)
          max = elf.Calories();
      }

      return max;
    }

    public static int GetMaxCaloriesTop3(List<Elf> elves)
    {
      int[] calories = new int[elves.Count];

      for (int i = 0; i < elves.Count; i++)
        calories[i] = elves[i].Calories();

      Array.Sort(calories);
      
      int result = calories[calories.Length - 3] + calories[calories.Length - 2] + calories[calories.Length - 1];

      return result;
    }
  }
}
