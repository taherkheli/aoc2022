using System.Collections.Generic;

namespace aoc.D02
{
  public static class ScoreCalculator
  {
    public static int GetPlayer2Score(List<Round> rounds)
    {
      int score = 0;

      foreach (Round round in rounds)
      {
        switch (round.Player2)
        {
          case Shape.Rock:
            score += 1;
            switch (round.Player1)
            {
              case Shape.Rock:
                score += 3;
                break;
              case Shape.Paper:
                score += 0;
                break;
              case Shape.Scissors:
                score += 6;
                break;
              default:
                throw new Exception("should not have happened");
            }
            break;

          case Shape.Paper:
            score += 2;
            switch (round.Player1)
            {
              case Shape.Rock:
                score += 6;
                break;
              case Shape.Paper:
                score += 3;
                break;
              case Shape.Scissors:
                score += 0;
                break;
              default:
                throw new Exception("should not have happened");
            }
            break;

          case Shape.Scissors:
            score+=3;
            switch (round.Player1)
            {
              case Shape.Rock:
                score += 0;
                break;
              case Shape.Paper:
                score += 6;
                break;
              case Shape.Scissors:
                score += 3;
                break;
              default:
                throw new Exception("should not have happened");
            }
            break;

          default:
            throw new Exception("should not have happened");
        }
      }

      return score;
    }

    public static int GetPlayer2ScorePartII(List<Round> rounds)
    {
      var updatedRounds = new List<Round>();

      foreach (var round in rounds)
      {
        var updatedShape = Shape.Rock;

        switch (round.Player2)
        {
          case Shape.Rock: //lose
            switch (round.Player1)
            {
              case Shape.Rock:
                updatedShape = Shape.Scissors;
                break;
              case Shape.Paper:
                updatedShape = Shape.Rock;
                break;
              case Shape.Scissors:
                updatedShape = Shape.Paper;
                break;
              default:
                throw new Exception("should not have happened");
            }
            break;
          case Shape.Paper: // draw
            updatedShape = round.Player1;
            break;
          case Shape.Scissors: // win
            switch (round.Player1)
            {
              case Shape.Rock:
                updatedShape = Shape.Paper;
                break;
              case Shape.Paper:
                updatedShape = Shape.Scissors;
                break;
              case Shape.Scissors:
                updatedShape = Shape.Rock;
                break;
              default:
                throw new Exception("should not have happened");
            }
            break;
          default:
            throw new Exception("should not have happened");
        }

        updatedRounds.Add(new Round() { Player1 = round.Player1, Player2 = updatedShape });
      }

      return GetPlayer2Score(updatedRounds);
    }
  }
}
