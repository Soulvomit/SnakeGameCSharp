using SnakeGameLib;

namespace SnakeGameConsole
{
    internal class ConsoleSnake: Snake
    {
        #region Privates
        //the trailing position of the snake; used for console clean up
        private byte[]? trailPosistion;
        #endregion

        #region Ctor
        internal ConsoleSnake(byte startX, byte startY, byte initialSize = 5): base(startX, startY, initialSize)
        {
        }
        #endregion

        #region Initialize
        /// <summary>
        /// Initialize console snake.
        /// </summary>
        public override void Initialize()
        {
            trailPosistion = null;
            base.Initialize();
        }
        #endregion

        #region Update
        /// <summary>
        /// Updates console snake.
        /// </summary>
        public override void Update()
        {
            //save last body position for cleaup later 
            trailPosistion = new byte[] { BodyPositions.Last()[0], BodyPositions.Last()[1] };

            base.Update();

        }
        #endregion

        #region Draw
        /// <summary>
        /// Draws console snake.
        /// </summary>
        internal void Draw()
        {
            //clean up trail if it exists 
            if (trailPosistion != null)
            {
                Console.SetCursorPosition(trailPosistion[0], trailPosistion[1]);
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.Write(" ");
            }
            //draw body
            foreach (byte[] bodyPart in BodyPositions)
            {
                Console.SetCursorPosition(bodyPart[0], bodyPart[1]);
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.ForegroundColor = ConsoleColor.Magenta;

                if (bodyPart != BodyPositions.First()) Console.Write("O");
                else Console.Write("0");
            }
        }
        #endregion
    }
}
