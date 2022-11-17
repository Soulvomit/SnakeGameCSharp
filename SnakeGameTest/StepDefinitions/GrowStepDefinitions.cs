using SnakeGameLib;
using SnakeGameLib.Enums;

namespace SnakeGameTest.StepDefinitions
{
    [Binding]
    public class GrowStepDefinitions
    {
        private Game g;
        private byte[] applePosition = new byte[] { 33, 16 };
        [Given(@"there is an apple on the game field")]
        public void GivenThereIsAnAppleOnTheGameField()
        {
            //arrange
            g = new Game(mapX: 60, mapY: 30, startingSpeed: 6, framesPerSecond: 60, gameType: EGameType.Teleport,
                deductSpeedMS: 10000, deductAmount: 200, speedIncreaseThreshold: 200);
            g.Initialize();
            g.Update();
            g.ApplePosition[0] = applePosition[0];
            g.ApplePosition[1] = applePosition[1];
            //pre-assertation
            Assert.IsNotNull(g.ApplePosition);
        }

        [When(@"the snake eats an apple")]
        public void WhenTheSnakeEatsAnApple()
        {
            //act
            g.Update();
            //pre-assertation
            Assert.IsTrue(g.Snake.BodyPositions.Count != 5);
        }

        [Then(@"the snake should grow one size larger")]
        public void ThenTheSnakeShouldGrowOneSizeLarger()
        {
            //assert
            Assert.IsTrue(g.Snake.BodyPositions.Count == 6);
        }

        [Then(@"the snake should grow at apple offest position")]
        public void ThenTheSnakeShouldGrowAtAppleOffestPosition()
        {
            //assert
            Assert.IsTrue(g.Snake.BodyPositions.First()[0] == applePosition[0] + 1);
            Assert.IsTrue(g.Snake.BodyPositions.First()[1] == applePosition[1]);
        }
    }
}
