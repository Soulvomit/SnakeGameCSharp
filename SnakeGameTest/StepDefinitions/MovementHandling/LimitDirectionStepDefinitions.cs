using SnakeGameLib;
using SnakeGameLib.Enums;

namespace SnakeGameTest.StepDefinitions.MovementHandling
{
    [Binding]
    public class LimitDirectionStepDefinitions
    {
        [When(@"the snake tries to turn")]
        public void WhenTheSnakeTriesToTurn(Table table)
        {
            //arrange
            Game g = new Game(mapX: 60, mapY: 30, startingSpeed: 6, framesPerSecond: 60, gameType: EGameType.Teleport,
                deductSpeedMS: 10000, deductAmount: 200, speedIncreaseThreshold: 200);
            //act
            g.Initialize();
            g.Update();
            //assert
            Assert.IsTrue(g.Snake.Direction == EDirectionType.RIGHT);
            Assert.IsTrue(g.Snake.DirectionQueue.Count == 0);
            if (table.Rows[0]["direction"] == "UP")
            {
                //act
                g.Snake.DirectionQueue.Enqueue(EDirectionType.UP);
                //assert
                Assert.IsTrue(g.Snake.DirectionQueue.Peek() == EDirectionType.UP);
            }
            else if (table.Rows[0]["direction"] == "DOWN")
            {
                //act
                g.Snake.DirectionQueue.Enqueue(EDirectionType.DOWN);
                //assert
                Assert.IsTrue(g.Snake.DirectionQueue.Peek() == EDirectionType.DOWN);
            }
            else if (table.Rows[0]["direction"] == "LEFT")
            {
                //act
                g.Snake.DirectionQueue.Enqueue(EDirectionType.LEFT);
                //assert
                Assert.IsTrue(g.Snake.DirectionQueue.Peek() == EDirectionType.LEFT);
            }
            else if (table.Rows[0]["direction"] == "RIGHT")
            {
                //act
                g.Snake.DirectionQueue.Enqueue(EDirectionType.RIGHT);
                //assert
                Assert.IsTrue(g.Snake.DirectionQueue.Peek() == EDirectionType.RIGHT);
            }
            //assert
            Assert.IsTrue(g.Snake.DirectionQueue.Count == 1);
        }

        [Then(@"limit turn if it is invalid")]
        public void ThenLimitTurnIfItIsInvalid(Table table)
        {
            //arrange
            Game g = new Game(mapX: 60, mapY: 30, startingSpeed: 6, framesPerSecond: 60, gameType: EGameType.Teleport,
                deductSpeedMS: 10000, deductAmount: 200, speedIncreaseThreshold: 200);
            //act
            g.Initialize();
            g.Update();
            //assert
            Assert.IsTrue(g.Snake.Direction == EDirectionType.RIGHT);
            Assert.IsTrue(g.Snake.DirectionQueue.Count == 0);
            if (table.Rows[0]["direction"] == "UP")
            {
                //act
                g.Snake.DirectionQueue.Enqueue(EDirectionType.UP);
                g.Update();
                g.Snake.DirectionQueue.Enqueue(EDirectionType.DOWN);
                g.Update();
                //assert
                Assert.IsTrue(g.Snake.Direction == EDirectionType.UP);
            }
            else if (table.Rows[0]["direction"] == "DOWN")
            {
                //act
                g.Snake.DirectionQueue.Enqueue(EDirectionType.DOWN);
                g.Update();
                g.Snake.DirectionQueue.Enqueue(EDirectionType.UP);
                g.Update();
                //assert
                Assert.IsTrue(g.Snake.Direction == EDirectionType.DOWN);
            }
            else if (table.Rows[0]["direction"] == "LEFT")
            {
                //act
                g.Snake.DirectionQueue.Enqueue(EDirectionType.UP);
                g.Update();
                g.Snake.DirectionQueue.Enqueue(EDirectionType.LEFT);
                g.Update();
                g.Snake.DirectionQueue.Enqueue(EDirectionType.RIGHT);
                g.Update();
                //assert
                Assert.IsTrue(g.Snake.Direction == EDirectionType.LEFT);
            }
            else if (table.Rows[0]["direction"] == "RIGHT")
            {
                //act
                g.Snake.DirectionQueue.Enqueue(EDirectionType.UP);
                g.Update();
                g.Snake.DirectionQueue.Enqueue(EDirectionType.RIGHT);
                g.Update();
                g.Snake.DirectionQueue.Enqueue(EDirectionType.LEFT);
                g.Update();
                //assert
                Assert.IsTrue(g.Snake.Direction == EDirectionType.RIGHT);
            }
        }
    }
}
