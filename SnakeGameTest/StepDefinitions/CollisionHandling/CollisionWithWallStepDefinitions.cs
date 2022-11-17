using SnakeGameLib;
using SnakeGameLib.Enums;

namespace SnakeGameTest.StepDefinitions.CollisionHandling
{
    [Binding]
    public class CollisionWithWallStepDefinitions
    {
        private Game g;
        [Given(@"the game is running with teleportation disallowed")]
        public void GivenTheGameIsRunningWithTeleportationDisallowed()
        {
            //arrange
            g = new Game(mapX: 60, mapY: 30, startingSpeed: 6, framesPerSecond: 60, gameType: EGameType.WallCollision,
                deductSpeedMS: 10000, deductAmount: 200, speedIncreaseThreshold: 200);
            g.Initialize();
            //pre-assertation
            Assert.IsTrue(g.GameState == EGameState.Running);
            Assert.IsTrue(g.GameType == EGameType.WallCollision);
        }

        [When(@"the snake collides with the wall")]
        public void WhenTheSnakeCollidesWithTheWall(Table table)
        {
            //act
            g.Update();
            if (table.Rows[0]["wall"] == "RIGHT")
            {
                do g.Update();
                while (g.Snake.BodyPositions.First()[0] != 1);
                //pre-assertation
                Assert.IsTrue(g.Snake.BodyPositions.First()[0] == 1);
            }
            else if (table.Rows[0]["wall"] == "LEFT")
            {
                g.Snake.DirectionQueue.Enqueue(EDirectionType.UP);
                g.Update();
                g.Snake.DirectionQueue.Enqueue(EDirectionType.LEFT);
                g.Update();
                do g.Update();
                while (g.Snake.BodyPositions.First()[0] != g.MapX - 1);
                //pre-assertation
                Assert.IsTrue(g.Snake.BodyPositions.First()[0] == g.MapX - 1);
            }
            else if (table.Rows[0]["wall"] == "TOP")
            {
                g.Snake.DirectionQueue.Enqueue(EDirectionType.UP);
                g.Update();
                do g.Update();
                while (g.Snake.BodyPositions.First()[1] != 1);
                //pre-assertation
                Assert.IsTrue(g.Snake.BodyPositions.First()[1] == 1);
                g.Update();
            }
            else if (table.Rows[0]["wall"] == "BUTTOM")
            {
                g.Snake.DirectionQueue.Enqueue(EDirectionType.DOWN);
                g.Update();
                do g.Update();
                while (g.Snake.BodyPositions.First()[1] != g.MapY - 1);
                //pre-assertation
                Assert.IsTrue(g.Snake.BodyPositions.First()[1] == g.MapY - 1);
                g.Update();
            }
        }

        [Then(@"the game should be terminated")]
        public void ThenTheGameShouldBeTerminated()
        {
            //assert
            Assert.IsTrue(g.GameState == EGameState.NotRunning);
        }

        [Given(@"the game is running with teleportation allowed")]
        public void GivenTheGameIsRunningWithTeleportationAllowed()
        {
            //arrange
            g = new Game(mapX: 60, mapY: 30, startingSpeed: 6, framesPerSecond: 60, gameType: EGameType.Teleport,
                deductSpeedMS: 10000, deductAmount: 200, speedIncreaseThreshold: 200);
            g.Initialize();
            //pre-assertation
            Assert.IsTrue(g.GameState == EGameState.Running);
            Assert.IsTrue(g.GameType == EGameType.Teleport);
        }

        [Then(@"the snake should be teleported to the other side of the game field")]
        public void ThenTheSnakeShouldBeTeleportedToTheOtherSideOfTheGameField()
        {
            //assert
            Assert.IsTrue(g.GameState == EGameState.Running);
            //Assert.IsTrue(g.Snake.BodyPositions.First()[0] == 1);
        }
    }
}
