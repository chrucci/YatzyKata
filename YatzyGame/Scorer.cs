using System;
using System.Collections.Generic;
using System.ComponentModel;

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
                case Category.Ones:
                    result = ScoreSinglesCategory(dice, 1);
                    break;
                case Category.Twos:
                    result = ScoreSinglesCategory(dice, 2);
                    break;
                case Category.Threes:
                    result = ScoreSinglesCategory(dice, 3);
                    break;
                default:
                    throw new NotImplementedException("category");
            }
            
            return result;
        }

        private static int ScoreSinglesCategory(List<int> dice, int filter)
        {
            var result = 0;
            foreach (var roll in dice)
            {
                if (roll == filter) result += roll;
            }

            return result;
        }
    }
}