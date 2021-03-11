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

        [Test]
        public void Score_OnesWithoutAnyOnes_ReturnsZero()
        {
            var dice = new List<int>() {2,2,2,2,3};
            var expected = 0;
            Assert.AreEqual(expected, Scorer.Score(dice, Category.Ones));
        }

        [Test]
        public void Score_OnesSomeOnes_ReturnsSumOfOnlyOnes()
        {
            var dice = new List<int>() {2,1,2,1,3};
            var expected = 2;
            Assert.AreEqual(expected, Scorer.Score(dice, Category.Ones));
        }

        [Test]
        public void Score_OnesAllOnes_ReturnsSumOfOnlyOnes()
        {
            var dice = new List<int>() {1,1,1,1,1};
            var expected = 5;
            Assert.AreEqual(expected, Scorer.Score(dice, Category.Ones));
        }

        [Test]
        public void Score_TwosWithoutAnyOnes_ReturnsZero()
        {
            var dice = new List<int>() {1,1,1,1,3};
            var expected = 0;
            Assert.AreEqual(expected, Scorer.Score(dice, Category.Twos));
        }

        [Test]
        public void Score_TwosSomeOnes_ReturnsSumOfOnlyOnes()
        {
            var dice = new List<int>() {2,1,2,1,3};
            var expected = 4;
            Assert.AreEqual(expected, Scorer.Score(dice, Category.Twos));
        }

        [Test]
        public void Score_TwosAllOnes_ReturnsSumOfOnlyOnes()
        {
            var dice = new List<int>() {2,2,2,2,2};
            var expected = 10;
            Assert.AreEqual(expected, Scorer.Score(dice, Category.Twos));
        }

        [Test]
        public void Score_ThreesWithoutAnyOnes_ReturnsZero()
        {
            var dice = new List<int>() {1,1,1,1,2};
            var expected = 0;
            Assert.AreEqual(expected, Scorer.Score(dice, Category.Threes));
        }

        [Test]
        public void Score_ThreesSomeOnes_ReturnsSumOfOnlyOnes()
        {
            var dice = new List<int>() {2,1,3,1,3};
            var expected = 4;
            Assert.AreEqual(expected, Scorer.Score(dice, Category.Threes));
        }

        [Test]
        public void Score_ThreesAllOnes_ReturnsSumOfOnlyOnes()
        {
            var dice = new List<int>() {3,3,3,3,3};
            var expected = 15;
            Assert.AreEqual(expected, Scorer.Score(dice, Category.Threes));
        }
    }
}