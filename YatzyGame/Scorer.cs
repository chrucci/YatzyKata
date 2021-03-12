using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace YatzyGame
{
    public static class Scorer
    {
        private const int CountOfCardsInPair = 2;
        private const int CountOfCardsIn3OfAKind = 3;
        private const int CountOfCardsIn4OfAKind = 4;
        public static int Score(List<int> dice, Category category)
        { 
            var result = 0;
            var countTracker = CountDiceValues(dice);
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
                case Category.Fours:
                    result = ScoreSinglesCategory(dice, 4);
                    break;
                case Category.Fives:
                    result = ScoreSinglesCategory(dice, 5);
                    break;
                case Category.Sixes:
                    result = ScoreSinglesCategory(dice, 6);
                    break;
                case Category.Pair:

                    for (int i = 0; i < countTracker.Length; i++)
                    {
                        if (countTracker[i] >= CountOfCardsInPair)
                            result = CalculatePairScore(i);
                    }
                    break;
                case Category.TwoPairs:

                    var foundFirstPair = false;
                    var tempResult = 0;
                    for (int i = 0; i < countTracker.Length; i++)
                    {
                        if (countTracker[i] >= CountOfCardsInPair)
                        {
                            if (foundFirstPair) result = CalculatePairScore(i) + tempResult;
                            tempResult = CalculatePairScore(i);
                            foundFirstPair = true;
                        }
                    }
                    break;
                case Category.ThreeOfAKind:
                    for (int i = 0; i < countTracker.Length; i++)
                    {
                        if (countTracker[i] >= CountOfCardsIn3OfAKind)
                            result = CalculateThreeOfAKindScore(i);
                    }
                    
                    break;
                default:
                    throw new NotImplementedException("category");
            }
            
            return result;
        }

        private static int[] CountDiceValues(List<int> dice)
        {
            var countTracker = new int[] {0, 0, 0, 0, 0, 0};
            foreach (var roll in dice)
            {
                countTracker[roll - 1]++;
            }

            return countTracker;
        }

        private static int CalculateTupleScore(int i, int cardsInTuple)
        {
            return (i + 1) * cardsInTuple;
        }
        
        private static int CalculatePairScore(int i)
        {
            return CalculateTupleScore(i, CountOfCardsInPair);
        }
        
        private static int CalculateThreeOfAKindScore(int i)
        {
            return CalculateTupleScore(i, CountOfCardsIn3OfAKind);
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