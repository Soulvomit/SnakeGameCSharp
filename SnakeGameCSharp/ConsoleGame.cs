using System.Runtime.Versioning;
using SnakeGameLib;
using SnakeGameLib.Enums;

namespace SnakeGameConsole
{
    internal class ConsoleGame: Game
    {
        #region Ctor
        internal ConsoleGame(byte mapX = 60, byte mapY = 30, byte startingSpeed = 6, short framesPerSecond = 60,
                           EGameType teleport = EGameType.Teleport, int deductSpeedMS = 10000, int deductAmount = 200, 
                           int speedIncreaseThreshold = 200): 
            base(mapX, mapY, startingSpeed, framesPerSecond, teleport, deductSpeedMS, deductAmount, speedIncreaseThreshold)
        {
        }
        #endregion

        #region Initialize
        /// <summary>
        /// Initializes the console game. Should only be called once in a games life cycle.
        /// </summary>
        [SupportedOSPlatform("windows")] public override void Initialize()
        {
            //init
            Snake = new ConsoleSnake((byte)((MapX / 2) + 1), (byte)((MapY / 2) + 1));
            base.Initialize();
            //setup console and draw initial
            Console.CursorVisible = false;
            Console.SetWindowSize(MapX + 1, MapY + 1);
            Console.BufferHeight = MapY + 1;
            Console.BufferWidth = MapX + 1;
            DrawInitial();
            //start input listener on seperate thread
            new Thread(() =>
            {
                while (GameState == EGameState.Running)
                {
                    ConsoleKeyInfo input = Console.ReadKey(true);
                    if (PausedState != EPauseState.Paused)
                    {
                        if (input.Key == ConsoleKey.W)
                            Snake.DirectionQueue.Enqueue(EDirectionType.UP);
                        if (input.Key == ConsoleKey.S)
                            Snake.DirectionQueue.Enqueue(EDirectionType.DOWN);
                        if (input.Key == ConsoleKey.D)
                            Snake.DirectionQueue.Enqueue(EDirectionType.RIGHT);
                        if (input.Key == ConsoleKey.A) 
                            Snake.DirectionQueue.Enqueue(EDirectionType.LEFT);
                    }
                    if (input.Key == ConsoleKey.Spacebar) 
                    { 
                        if(PausedState == EPauseState.Paused)
                            PausedState = EPauseState.Unpaused;
                        else
                            PausedState = EPauseState.Paused;
                    }
                    if (input.Key == ConsoleKey.Tab)
                    {
                        if (DebugState == EDebugState.Debugging)
                            DebugState = EDebugState.NotDebugging;
                        else
                            DebugState = EDebugState.Debugging;
                    }
                }
            }).Start();
        }
        #endregion

        #region Draw
        /// <summary>
        /// Draws a frame, based on the timing of drawTimer.
        /// </summary>
        internal void Draw()
        {
            ((ConsoleSnake)Snake).Draw();
            DrawFood();
            DrawInfo();
            if (DebugState == EDebugState.Debugging) DrawDebugInfo();
            drawTimer.Restart();
        }
        private void DrawInitial()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine(new string(' ', MapX));
            
            for (byte y = 0; y < MapY - 1; y++)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write(" ");
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.WriteLine(new string(' ', MapX - 1));
            }
        }
        private void DrawFood()
        {
            if (ApplePosition != null)
            {
                Console.SetCursorPosition(ApplePosition[0], ApplePosition[1]);
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("@");
            }
        }
        private void DrawDebugInfo()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(new string(' ', MapX));
            Console.SetCursorPosition(1, 0);

            EDirectionType? nextDir = null;
            if (Snake.DirectionQueue.Count > 0) nextDir = Snake.DirectionQueue.Peek();

            Console.WriteLine("PAUSED[" + PausedState + "] " +
                "POSITION[" + Snake.BodyPositions.First()[0] + "," +
                Snake.BodyPositions.First()[1] + "] " +
                "DIR[" + Snake.Direction + "] " +
                "KEYPRESSED[" + nextDir + "]");
        }
        private void DrawInfo()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(new string(' ', MapX));
            Console.SetCursorPosition(1, 0);
            Console.WriteLine("PAUSED[" + PausedState + "] " +
                "POINTS[" + Snake.Points + "] " +
                "SPEED[" + Speed + "] " +
                "LENGTH[" + Snake.BodyPositions.Count + "] " +
                "TIMER[" + (DeductSpeedMS - pointDeductTimer.ElapsedMilliseconds) / 1000 + "]");
        }
        #endregion

        #region EndGame
        /// <summary>
        /// Handles end of console game procedures.
        /// </summary>
        internal void EndGame()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(100);
                Console.SetCursorPosition(0, 0);
                Console.WriteLine(new string(' ', MapX));
                Thread.Sleep(100);
                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write(" ");
                Console.WriteLine("GAME OVER!!!");
            }
        }
        #endregion

        #region Run
        /// <summary>
        /// Runs the console game. Should only be called after Initialize.
        /// </summary>
        [SupportedOSPlatform("windows")] internal void Run()
        {
            Initialize();
            while (GameState == EGameState.Running)
            {
                if (updateTimer.ElapsedMilliseconds > (1000 / 60) * (60 / Speed) &&
                    PausedState != EPauseState.Paused) Update();
                if (drawTimer.ElapsedMilliseconds > 1000 / FPS) Draw();
            }
            EndGame();
        }
        #endregion
    }
}