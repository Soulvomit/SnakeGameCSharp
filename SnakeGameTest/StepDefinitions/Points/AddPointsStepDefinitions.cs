using SnakeGameLib;
using SnakeGameLib.Enums;

namespace SnakeGameTest.StepDefinitions.Points
{
    [Binding]
    public class AddPointsStepDefinitions
    {
        private Game g;
        private int pointsAfter;
        private int pointsBefore;
        [Given(@"the snake eats an apple")]
        public void GivenTheSnakeEatsAnApple()
        {
            //arrange - Given the snake eats an apple
            g = new Game(mapX: 60, mapY: 30, startingSpeed: 6, framesPerSecond: 60, gameType: EGameType.Teleport,
                deductSpeedMS: 10000, deductAmount: 200, speedIncreaseThreshold: 200);
            g.Initialize();
            g.Update();
            pointsBefore = g.Snake.Points;
            g.ApplePosition = new byte[] { 33, 16 };
            //pre-assertation

        }

        [When(@"the player is awarded points")]
        public void WhenThePlayerIsAwardedPoints()
        {
            //act
            g.Update();
            pointsAfter = g.Snake.Points;
            //pre-assertation
            Assert.IsTrue(pointsBefore != pointsAfter);
        }
        [Then(@"the player will be awarded points")]
        public void ThenThePlayerWillBeAwardedPoints()
        {
            //assert
            Assert.IsTrue(pointsBefore < pointsAfter);
        }

        [Then(@"the point amount should be speed times length")]
        public void ThenThePointAmountShouldBeSpeedTimesLength()
        {
            //assert
            Assert.IsTrue(g.Snake.Points == g.Speed * g.Snake.BodyPositions.Count);
        }
    }
}
