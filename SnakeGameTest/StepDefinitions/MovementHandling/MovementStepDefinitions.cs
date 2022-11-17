using SnakeGameLib;
using SnakeGameLib.Enums;

namespace SnakeGameTest.StepDefinitions.MovementHandling
{
    [Binding]
    public class MovementStepDefinitions
    {
        private Game g;
        [When(@"an update cycle has happened")]
        public void WhenAnUpdateCycleHasHappened()
        {
            //arrange
            int updateCounter = 0;
            g = new Game(mapX: 60, mapY: 30, startingSpeed: 6, framesPerSecond: 60, gameType: EGameType.Teleport,
                deductSpeedMS: 10000, deductAmount: 200, speedIncreaseThreshold: 200);
            //act
            g.Initialize();
            g.Update();
            updateCounter++;
            //assert
            Assert.IsTrue(updateCounter == 1);
        }

        [Then(@"snake head should move one position in the current direction")]
        public void ThenSnakeHeadShouldMoveOnePositionInTheCurrentDirection(Table table)
        {
            //arrange
            g = new Game(mapX: 60, mapY: 30, startingSpeed: 6, framesPerSecond: 60, gameType: EGameType.Teleport,
                deductSpeedMS: 10000, deductAmount: 200, speedIncreaseThreshold: 200);
            //act
            g.Initialize();
            g.Update();
            //assert
            if (table.Rows[0]["direction"] == "UP")
            {
                //act
                g.Snake.DirectionQueue.Enqueue(EDirectionType.UP);
                g.Update();
                byte[] positionBeforeUpdate = g.Snake.BodyPositions.First();
                g.Update();
                byte[] positionAfterUpdate = g.Snake.BodyPositions.First();
                //assert
                Assert.IsTrue(positionBeforeUpdate[1] != positionAfterUpdate[1]);
                Assert.IsTrue(positionBeforeUpdate[1] - positionAfterUpdate[1] == 1);
            }
            else if (table.Rows[0]["direction"] == "DOWN")
            {
                //act
                g.Snake.DirectionQueue.Enqueue(EDirectionType.DOWN);
                g.Update();
                byte[] positionBeforeUpdate = g.Snake.BodyPositions.First();
                g.Update();
                byte[] positionAfterUpdate = g.Snake.BodyPositions.First();
                //assert
                Assert.IsTrue(positionBeforeUpdate[1] != positionAfterUpdate[1]);
                Assert.IsTrue(positionBeforeUpdate[1] - positionAfterUpdate[1] == -1);
            }
            else if (table.Rows[0]["direction"] == "LEFT")
            {
                //act
                g.Snake.DirectionQueue.Enqueue(EDirectionType.DOWN);
                g.Update();
                g.Snake.DirectionQueue.Enqueue(EDirectionType.LEFT);
                g.Update();
                byte[] positionBeforeUpdate = g.Snake.BodyPositions.First();
                g.Update();
                byte[] positionAfterUpdate = g.Snake.BodyPositions.First();
                //assert
                Assert.IsTrue(positionBeforeUpdate[0] != positionAfterUpdate[0]);
                Assert.IsTrue(positionBeforeUpdate[0] - positionAfterUpdate[0] == 1);
            }
            else if (table.Rows[0]["direction"] == "RIGHT")
            {
                //act
                byte[] positionBeforeUpdate = g.Snake.BodyPositions.First();
                g.Update();
                byte[] positionAfterUpdate = g.Snake.BodyPositions.First();
                //assert
                Assert.IsTrue(positionBeforeUpdate[0] != positionAfterUpdate[0]);
                Assert.IsTrue(positionBeforeUpdate[0] - positionAfterUpdate[0] == -1);
            }

        }
    }
}
