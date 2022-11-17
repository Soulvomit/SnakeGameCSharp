using SnakeGameLib;
using SnakeGameLib.Enums;

namespace SnakeGameTest.StepDefinitions
{
    [Binding]
    public class GameSpeedStepDefinitions
    {
        private Game g;
        private byte speedBefore;
        private byte speedAfter;
        private int pointsBefore;
        private int pointsAfter;

        [Given(@"points are added to the player total")]
        public void GivenPointsAreAddedToThePlayerTotal()
        {
            //arrange
            g = new Game(mapX: 60, mapY: 30, startingSpeed: 6, framesPerSecond: 60, gameType: EGameType.Teleport,
                deductSpeedMS: 10000, deductAmount: 200, speedIncreaseThreshold: 200);
            g.Initialize();
            pointsBefore = g.Snake.Points;
            speedBefore = g.Speed;
            g.Snake.Points += g.SpeedIncreaseThreshold + 1;
            pointsAfter = g.Snake.Points;
            //pre-assertation
            Assert.IsTrue(pointsBefore < pointsAfter);
        }

        [Given(@"point threshold is reached")]
        public void GivenPointThresholdIsReached()
        {
            //pre-assertation
            Assert.IsTrue(g.Snake.Points > g.SpeedIncreaseThreshold);
        }

        [When(@"the game updates game speed")]
        public void WhenTheGameUpdatesGameSpeed()
        {
            //act   
            g.Update();
            speedAfter = g.Speed;
            //pre-assertation
            Assert.IsTrue(speedBefore != speedAfter);
        }

        [Then(@"the game will increase in speed")]
        public void ThenTheGameWillIncreaseInSpeed()
        {
            //assert
            Assert.IsTrue(speedBefore < speedAfter);
        }

        [Given(@"points are subtracted from the player total")]
        public void GivenPointsAreSubtractedFromThePlayerTotal()
        {
            //arrange
            g = new Game(mapX: 60, mapY: 30, startingSpeed: 6, framesPerSecond: 60, gameType: EGameType.Teleport,
                deductSpeedMS: 10000, deductAmount: 200, speedIncreaseThreshold: 200);
            g.Initialize();
            g.Snake.Points += g.SpeedIncreaseThreshold * 2 + 1;
            pointsBefore = g.Snake.Points;
            g.Update();
            speedBefore = g.Speed;
            g.Snake.Points -= g.SpeedIncreaseThreshold;
            pointsAfter = g.Snake.Points;
            //pre-assertation 
            Assert.IsTrue(pointsBefore > pointsAfter);
        }

        [Then(@"the game will decrease in speed")]
        public void ThenTheGameWillDecreaseInSpeed()
        {
            //assert
            Assert.IsTrue(speedBefore > speedAfter);
        }
    }
}
