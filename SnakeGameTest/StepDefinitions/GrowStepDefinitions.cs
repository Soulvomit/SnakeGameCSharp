using SnakeGameLib;
using SnakeGameLib.Enums;

namespace SnakeGameTest.StepDefinitions
{
    [Binding]
    public class GrowStepDefinitions
    {
        private Game g;
        private byte[] applePosition = new byte[] { 33, 16 };
        private int startingSize = 5;

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
        public void WhenTheSnakeEatsAnApple(Table table)
        {
            //act
            if (table.Rows[0]["offset_position"] == "LEFT")
            {
                g.ApplePosition[0] = (byte)(applePosition[0] - 2);
                g.ApplePosition[1] = (byte)(applePosition[1] - 1);
                g.Snake.Direction = EDirectionType.UP;
                g.Update();
                g.Snake.Direction = EDirectionType.LEFT;
            }
            else if (table.Rows[0]["offset_position"] == "UP")
            {
                g.ApplePosition[0] = (byte)(applePosition[0] - 1);
                g.ApplePosition[1] = (byte)(applePosition[1] - 1);
                g.Snake.Direction = EDirectionType.UP;
            }
            else if (table.Rows[0]["offset_position"] == "DOWN")
            {
                g.ApplePosition[0] = (byte)(applePosition[0] - 1);
                g.ApplePosition[1] = (byte)(applePosition[1] + 1);
                g.Snake.Direction = EDirectionType.DOWN;
            }
            g.Update();
            //pre-assertation
            Assert.IsTrue(g.Snake.BodyPositions.Count != startingSize);
        }

        [Then(@"the snake should grow one size larger")]
        public void ThenTheSnakeShouldGrowOneSizeLarger()
        {
            //assert
            Assert.IsTrue(g.Snake.BodyPositions.Count == startingSize + 1);
        }

        [Then(@"the snake should grow at apple offset position")]
        public void ThenTheSnakeShouldGrowAtAppleOffsetPosition(Table table)
        {
            //assert
            if (table.Rows[0]["offset_position"] == "RIGHT")
            {
                Assert.IsTrue(g.Snake.BodyPositions.First()[0] == applePosition[0] + 1);
                Assert.IsTrue(g.Snake.BodyPositions.First()[1] == applePosition[1]);
            }
            else if (table.Rows[0]["offset_position"] == "LEFT")
            {
                g.Snake.Direction = EDirectionType.LEFT;
                Assert.IsTrue(g.Snake.BodyPositions.First()[0] == applePosition[0] - 3);
                Assert.IsTrue(g.Snake.BodyPositions.First()[1] == applePosition[1] - 1);
            }
            else if(table.Rows[0]["offset_position"] == "UP")
            {
                g.Snake.Direction = EDirectionType.UP;
                Assert.IsTrue(g.Snake.BodyPositions.First()[0] == applePosition[0] - 1);
                Assert.IsTrue(g.Snake.BodyPositions.First()[1] == applePosition[1] - 2);
            }
            else if(table.Rows[0]["offset_position"] == "DOWN")
            {
                g.Snake.Direction = EDirectionType.DOWN;
                Assert.IsTrue(g.Snake.BodyPositions.First()[0] == applePosition[0] - 1);
                Assert.IsTrue(g.Snake.BodyPositions.First()[1] == applePosition[1] + 2);
            }
        }
    }
}
