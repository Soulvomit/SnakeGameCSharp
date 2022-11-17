using SnakeGameLib;
using SnakeGameLib.Enums;

namespace SnakeGameTest.StepDefinitions
{
    [Binding]
    public class GenerateAppleStepDefinitions
    {
        private Game g;
        [Given(@"a new game has started")]
        public void GivenANewGameHasStarted()
        {
            //arrange
            g = new Game(mapX: 60, mapY: 30, startingSpeed: 6, framesPerSecond: 60, gameType: EGameType.Teleport,
                deductSpeedMS: 10000, deductAmount: 200, speedIncreaseThreshold: 200);
            //pre-assertation
            Assert.IsTrue(g.GameState == EGameState.NotRunning);
            Assert.IsNull(g.ApplePosition);
        }
        [When(@"the game initializes")]
        public void WhenTheGameInitializes()
        {
            //act
            g.Initialize();
            //pre-assertation
            Assert.IsNotNull(g.ApplePosition);
        }
        [Given(@"the snake eats the apple")]
        public void GivenTheSnakeEatsTheApple()
        {
            //arrange
            g = new Game(mapX: 60, mapY: 30, startingSpeed: 6, framesPerSecond: 60, gameType: EGameType.Teleport,
                deductSpeedMS: 10000, deductAmount: 200, speedIncreaseThreshold: 200);
            g.Initialize();
            g.Update();
            g.ApplePosition = new byte[] { 33, 16 };
            //pre-assertation
            Assert.IsNotNull(g.ApplePosition);
        }
        [When(@"the game updates apple position")]
        public void WhenTheGameUpdatesApplePosition()
        {
            //act
            g.Update();
            //pre-assertation
            Assert.IsNotNull(g.ApplePosition);
        }
        [Then(@"generate one apple within the bounds of the game field")]
        public void ThenGenerateOneAppleWithinTheBoundsOfTheGameField()
        {
            //assert
            Assert.IsTrue(g.ApplePosition[0] <= g.MapX);
            Assert.IsTrue(g.ApplePosition[0] >= 1);
            Assert.IsTrue(g.ApplePosition[1] <= g.MapY);
            Assert.IsTrue(g.ApplePosition[1] >= 1);
        }
    }
}
