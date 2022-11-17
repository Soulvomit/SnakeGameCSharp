using SnakeGameLib;
using SnakeGameLib.Enums;
using System.Diagnostics;

namespace SnakeGameTest.StepDefinitions.Points
{
    [Binding]
    public class SubtractPointsStepDefinitions
    {
        private Game g;
        private int pointsBeforeDeduct = 400;
        private Stopwatch timer;

        [Given(@"the player has points")]
        public void GivenThePlayerHasPoints()
        {
            //arrange
            timer = new Stopwatch();
            g = new Game(mapX: 60, mapY: 30, startingSpeed: 6, framesPerSecond: 60, gameType: EGameType.Teleport,
                deductSpeedMS: 1, deductAmount: 200, speedIncreaseThreshold: 200);
            g.Initialize();
            g.Snake.Points = pointsBeforeDeduct;
            //pre-assertion
            Assert.IsTrue(g.Snake.Points > 0);
        }

        [When(@"the player is to slow to eat an apple")]
        public void WhenThePlayerIsToSlowToEatAnApple()
        {
            //act
            g.Update();
            timer.Start();
            long elapsedTimeBefore = timer.ElapsedMilliseconds;
            Thread.Sleep(g.DeductSpeedMS);
            long elapsedTimeAfter = timer.ElapsedMilliseconds;
            timer.Stop();
            g.Update();
            //pre-assertion
            Assert.IsTrue(elapsedTimeBefore + g.DeductSpeedMS <= elapsedTimeAfter);

        }

        [Then(@"subtract points from the player")]
        public void ThenSubtractPointsFromThePlayer()
        {
            //assert
            Assert.IsTrue(pointsBeforeDeduct > g.Snake.Points);
        }
    }
}
