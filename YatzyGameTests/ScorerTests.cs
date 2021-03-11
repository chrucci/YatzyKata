using System.Collections.Generic;
using NUnit.Framework;
using YatzyGame;

namespace YatzyGameTests
{
    public class ScorerTests
    {
        [Test]
        public void Score_Chance_ReturnsSumOfAllDice()
        {
            var dice = new List<int>() {1,2,3,4,5};
            var expected = 15;
            Assert.AreEqual(expected, Scorer.Score(dice, Category.Chance));
        }
        
        [Test]
        public void Score_ChanceWithDifferentNumbers_ReturnsSumOfAllDice()
        {
            var dice = new List<int>() {2,2,3,4,5};
            var expected = 16;
            Assert.AreEqual(expected, Scorer.Score(dice, Category.Chance));
        }

        [Test]
        public void Score_YatzyWithMatchingDice_Returns50()
        {
            var dice = new List<int>() {2,2,2,2,2};
            var expected = 50;
            Assert.AreEqual(expected, Scorer.Score(dice, Category.Yatzy));
        }

        [Test]
        public void Score_YatzyWithNonMatchingDice_Returns0()
        {
            var dice = new List<int>() {2,2,2,2,3};
            var expected = 0;
            Assert.AreEqual(expected, Scorer.Score(dice, Category.Yatzy));
        }
    }
}