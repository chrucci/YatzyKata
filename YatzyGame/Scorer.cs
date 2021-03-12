using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace YatzyGame
{
    public static class Scorer
    {
        private const int CountOfCardsInPair = 2;
        private const int CountOfCardsInThreeOfAKind = 3;
        private const int CountOfCardsInFourOfAKind = 4;
        private const int LengthOfSmallStraight = 4;
        private const int LengthOfLargeStraight = 5;
        public static int Score(List<int> dice, Category category)
        { 
            var result = 0;
            var countTracker = CountDiceValues(dice);
            int tempResult;
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
                    tempResult = 0;
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
                        if (countTracker[i] >= CountOfCardsInThreeOfAKind)
                            result = CalculateThreeOfAKindScore(i);
                    }
                    
                    break;
                case Category.FourOfAKind:
                    for (int i = 0; i < countTracker.Length; i++)
                    {
                        if (countTracker[i] >= CountOfCardsInFourOfAKind)
                            result = CalculateFourOfAKindScore(i);
                    }
                    break;
                case Category.SmallStraight:
                    result = GetScoreForStraight(countTracker, LengthOfSmallStraight);
                    break;
                case Category.LargeStraight:
                    result = GetScoreForStraight(countTracker, LengthOfLargeStraight);
                    break;
                case Category.FullHouse:
                    var pairResult = 0;
                    var tripResult = 0;
                    for (int i = 0; i < countTracker.Length; i++)
                    {
                        if (countTracker[i] == CountOfCardsInPair)
                            pairResult = CalculatePairScore(i);
                    }
                    for (int i = 0; i < countTracker.Length; i++)
                    {
                        if (countTracker[i] >= CountOfCardsInThreeOfAKind)
                            tripResult = CalculateThreeOfAKindScore(i);
                    }

                    if (tripResult != 0 && pairResult != 0) 
                        result = tripResult + pairResult;
                    break;
                default:
                    throw new NotImplementedException("category");
            }
            
            return result;
        }

        private static int GetScoreForStraight(int[] countTracker, int lengthOfStraight)
        {
            int result = 0;
            int tempResult;
            tempResult = 0;
            var inARowCounter = 1;
            var previousValue = -1;
            var diceValue = 0;

            for (int i = countTracker.Length - 1; i >= 0; i--)
            {
                if (countTracker[i] > 0) diceValue = i + 1;
                if (IsThisRollIncremental(previousValue, diceValue))
                {
                    tempResult += diceValue;
                    inARowCounter++;
                }
                else
                {
                    tempResult = 0;
                    inARowCounter = 1;
                    tempResult = diceValue;
                }

                if (inARowCounter == lengthOfStraight)
                {
                    result = tempResult;
                }

                previousValue = diceValue;
            }

            return result;
        }

        private static bool IsThisRollIncremental(int previousValue, int roll)
        {
            return (previousValue - 1) == roll;
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
            return CalculateTupleScore(i, CountOfCardsInThreeOfAKind);
        }

        private static int CalculateFourOfAKindScore(int i)
        {
            return CalculateTupleScore(i, CountOfCardsInFourOfAKind);
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