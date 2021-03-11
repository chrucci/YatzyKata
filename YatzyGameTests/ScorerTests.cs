using System.Collections.Generic;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using YatzyGame;

namespace YatzyGameTests
{
    public class ScorerTests
    {
        [Test]
        public void Score_Chance_ReturnsSumOfAllDice()
        {
            var dice = CreateDice(1,2,3,4,5);
            var expected = 15;
            Assert.AreEqual(expected, Scorer.Score(dice, Category.Chance));
        }
        
        [Test]
        public void Score_ChanceWithDifferentNumbers_ReturnsSumOfAllDice()
        {
            var dice = CreateDice(2,2,3,4,5);
            var expected = 16;
            Assert.AreEqual(expected, Scorer.Score(dice, Category.Chance));
        }

        [Test]
        public void Score_YatzyWithMatchingDice_Returns50()
        {
            var dice = CreateDice(2,2,2,2,2);
            var expected = 50;
            Assert.AreEqual(expected, Scorer.Score(dice, Category.Yatzy));
        }

        [Test]
        public void Score_YatzyWithNonMatchingDice_Returns0()
        {
            var dice = CreateDice(2,2,2,2,3);
            var expected = 0;
            Assert.AreEqual(expected, Scorer.Score(dice, Category.Yatzy));
        }

        [Test]
        public void Score_OnesWithoutAnyOnes_ReturnsZero()
        {
            var dice = CreateDice(2,2,2,2,3);
            var expected = 0;
            Assert.AreEqual(expected, Scorer.Score(dice, Category.Ones));
        }

        [Test]
        public void Score_OnesSomeOnes_ReturnsSumOfOnlyOnes()
        {
            var dice = CreateDice(2,1,2,1,3);
            var expected = 2;
            Assert.AreEqual(expected, Scorer.Score(dice, Category.Ones));
        }

        [Test]
        public void Score_OnesAllOnes_ReturnsSumOfOnlyOnes()
        {
            var dice = CreateDice(1,1,1,1,1);
            var expected = 5;
            Assert.AreEqual(expected, Scorer.Score(dice, Category.Ones));
        }

        [Test]
        public void Score_TwosWithoutAnyOnes_ReturnsZero()
        {
            var dice = CreateDice(1,1,1,1,3);
            var expected = 0;
            Assert.AreEqual(expected, Scorer.Score(dice, Category.Twos));
        }

        [Test]
        public void Score_TwosSomeOnes_ReturnsSumOfOnlyOnes()
        {
            var dice = CreateDice(2,1,2,1,3);
            var expected = 4;
            Assert.AreEqual(expected, Scorer.Score(dice, Category.Twos));
        }

        [Test]
        public void Score_TwosAllOnes_ReturnsSumOfOnlyOnes()
        {
            var dice = CreateDice(2,2,2,2,2);
            var expected = 10;
            Assert.AreEqual(expected, Scorer.Score(dice, Category.Twos));
        }

        [Test]
        public void Score_ThreesWithoutAnyOnes_ReturnsZero()
        {
            var dice = CreateDice(1,1,1,1,2);
            var expected = 0;
            Assert.AreEqual(expected, Scorer.Score(dice, Category.Threes));
        }

        [Test]
        public void Score_ThreesSomeOnes_ReturnsSumOfOnlyOnes()
        {
            var dice = CreateDice(2,1,3,1,3);
            var expected = 6;
            Assert.AreEqual(expected, Scorer.Score(dice, Category.Threes));
        }

        [Test]
        public void Score_ThreesAllOnes_ReturnsSumOfOnlyOnes()
        {
            var dice = CreateDice(3,3,3,3,3);
            var expected = 15;
            Assert.AreEqual(expected, Scorer.Score(dice, Category.Threes));
        }

        [Test]
        public void Score_FoursWithoutAnyOnes_ReturnsZero()
        {
            var dice = CreateDice(1,1,1,1,2);
            var expected = 0;
            Assert.AreEqual(expected, Scorer.Score(dice, Category.Fours));
        }

        [Test]
        public void Score_FoursSomeOnes_ReturnsSumOfOnlyOnes()
        {
            var dice = CreateDice(2,1,4,4,3);
            var expected = 8;
            Assert.AreEqual(expected, Scorer.Score(dice, Category.Fours));
        }

        [Test]
        public void Score_FoursAllOnes_ReturnsSumOfOnlyOnes()
        {
            var dice = CreateDice(4,4,4,4,4);
            var expected = 20;
            Assert.AreEqual(expected, Scorer.Score(dice, Category.Fours));
        }        
        
        [Test]
        public void Score_FivesWithoutAnyOnes_ReturnsZero()
        {
            var dice = CreateDice(1,1,1,1,2);
            var expected = 0;
            Assert.AreEqual(expected, Scorer.Score(dice, Category.Fives));
        }

        [Test]
        public void Score_FivesSomeOnes_ReturnsSumOfOnlyOnes()
        {
            var dice = CreateDice(5,1,5,4,3);
            var expected = 10;
            Assert.AreEqual(expected, Scorer.Score(dice, Category.Fives));
        }

        [Test]
        public void Score_FivesAllOnes_ReturnsSumOfOnlyOnes()
        {
            var dice = CreateDice(5,5,5,5,5);
            var expected = 25;
            Assert.AreEqual(expected, Scorer.Score(dice, Category.Fives));
        }      
        
        [Test]
        public void Score_SixesWithoutAnyOnes_ReturnsZero()
        {
            var dice = CreateDice(1, 1, 1, 1, 2);
            var expected = 0;
            Assert.AreEqual(expected, Scorer.Score(dice, Category.Sixes));
        }

        [Test]
        public void Score_SixesSomeOnes_ReturnsSumOfOnlyOnes()
        {
            var dice = CreateDice(5,1,6,4,6);
            var expected = 12;
            Assert.AreEqual(expected, Scorer.Score(dice, Category.Sixes));
        }

        [Test]
        public void Score_SixesAllOnes_ReturnsSumOfOnlyOnes()
        {
            var dice = CreateDice(6,6,6,6,6);
            var expected = 30;
            Assert.AreEqual(expected, Scorer.Score(dice, Category.Sixes));
        }

        [Test]
        public void Score_PairWithoutAnyPairs_ReturnsZero()
        {
            var dice = CreateDice(6,1,2,3,4);
            var expected = 0;
            Assert.AreEqual(expected, Scorer.Score(dice, Category.Pair));
        }

        [Test]
        public void Score_PairWithOnePair_ReturnsSumOfPair()
        {
            var dice = CreateDice(6,1,1,3,4);
            var expected = 2;
            Assert.AreEqual(expected, Scorer.Score(dice, Category.Pair));
        }

        [Test]
        public void Score_PairWithTwoPairs_ReturnsSumOfHigherPair()
        {
            var dice = CreateDice(1,5,1,6,6);
            var expected = 12;
            Assert.AreEqual(expected, Scorer.Score(dice, Category.Pair));
        }

        [Test]
        public void Score_PairWithOneValueAsThreeOfAKind_ReturnsSumOfThatValueAsPair()
        {
            var dice = CreateDice(6,5,1,6,6);
            var expected = 12;
            Assert.AreEqual(expected, Scorer.Score(dice, Category.Pair));
        }

        List<int> CreateDice(int first, int second, int third, int fourth, int fifth)
        {
            return new List<int>() {first, second, third, fourth, fifth};
        }
    }
}