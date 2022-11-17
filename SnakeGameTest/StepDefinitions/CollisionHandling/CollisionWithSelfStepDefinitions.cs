using SnakeGameLib;
using SnakeGameLib.Enums;
using System;
using TechTalk.SpecFlow;

namespace SnakeGameTest.StepDefinitions.CollisionHandling
{
    [Binding]
    public class CollisionWithSelfStepDefinitions
    {
        private Game g;
        [When(@"the snake collides with its own body")]
        public void WhenTheSnakeCollidesWithItsOwnBody()
        {
            //arrange - GivenTheGameIsRunning
            g = new Game(mapX: 60, mapY: 30, startingSpeed: 6, framesPerSecond: 60, gameType: EGameType.Teleport,
                deductSpeedMS: 10000, deductAmount: 200, speedIncreaseThreshold: 200);
            g.Initialize();
            g.Update();
            g.Snake.DirectionQueue.Enqueue(EDirectionType.UP);
            g.Snake.DirectionQueue.Enqueue(EDirectionType.LEFT);
            g.Snake.DirectionQueue.Enqueue(EDirectionType.DOWN);
            g.Snake.DirectionQueue.Enqueue(EDirectionType.RIGHT);
            //act
            g.Update();
            g.Update();
            g.Update();
            g.Update();
            g.Update();
            //pre-assertiation
            Assert.IsTrue(g.Snake.CollisionWithSelf);
        }

        [Then(@"the game should end")]
        public void ThenTheGameShouldEnd()
        {
            //assert
            Assert.IsTrue(g.GameState == EGameState.NotRunning);
        }
    }
}
