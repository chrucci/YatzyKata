using System;
using System.Collections.Generic;

namespace YatzyGame
{
    public static class Scorer
    {
        public static int Score(List<int> dice, Category category)
        { 
            var result = 0;
            switch (category)
            {
                case Category.Chance:
                    foreach (var roll in dice)
                    {
                        result += roll;
                    }
                    break;
                case Category.Yatzy:
                    var firstValue = dice[0];
                    result = (firstValue == dice[1] &&
                            firstValue == dice[2] &&
                            firstValue == dice[3] &&
                            firstValue == dice[4])
                        ? 50
                        : 0;
                    break;
            }
            
            return result;
        }
    }
}