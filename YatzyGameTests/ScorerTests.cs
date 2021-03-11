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
            Assert.AreEqual(expected, Scorer.Score(dice));
        }
    }
}