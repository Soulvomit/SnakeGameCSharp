using System.Diagnostics;
using SnakeGameLib.Enums;

namespace SnakeGameLib
{
    public class Game
    {
        #region Privates
        //controls the update timing of the game
        protected readonly Stopwatch updateTimer;
        //controls the draw timing of the game
        protected readonly Stopwatch drawTimer;
        //controls the point deduct timing of the game
        protected readonly Stopwatch pointDeductTimer;
        //random generator for new apple position
        protected readonly Random applePositionGenerator;
        #endregion

        #region Properties
        //the games snake
        public Snake Snake { get; protected set; }
        //the games map width
        public byte MapX { get; protected set; }
        //the games map height
        public byte MapY { get; protected set; }
        //position of the current apple
        public byte[]? ApplePosition { get; set; } = null;
        //current game speed
        public byte Speed { get; set; }
        //the speed the game starts at
        public byte StartingSpeed { get; protected set; }
        //how fast/slow the game should draw each frame eg. frames per second (FPS)
        public short FPS { get; set; }
        //how fast the game deducts points from player
        public int DeductSpeedMS { get; protected set; }
        //the amount of points to deduct from player
        public int DeductAmount { get; protected set; }
        //how many points is needed to increase/decrease speed
        public int SpeedIncreaseThreshold { get; protected set; }
        //flags the game running/not running state 
        public EGameState GameState { get; protected set; } = EGameState.NotRunning;
        //flags whether teleportation is allowed 
        public EGameType GameType { get; protected set; }
        //flags the game pause/unpase state
        public EPauseState PausedState { get; set; }
        //flags the game debugging/non-debugging state
        public EDebugState DebugState { get; set; }
        #endregion

        #region Ctor
        public Game(byte mapX, byte mapY, byte startingSpeed, short framesPerSecond, EGameType gameType, 
            int deductSpeedMS, int deductAmount, int speedIncreaseThreshold)
        {
            Snake = new Snake((byte)((mapX / 2) + 1), (byte)((mapY / 2) + 1), 5);
            MapX = mapX;
            MapY = mapY;
            DeductSpeedMS = deductSpeedMS;
            DeductAmount = deductAmount;
            SpeedIncreaseThreshold = speedIncreaseThreshold;
            StartingSpeed = startingSpeed;
            Speed = startingSpeed;
            FPS = framesPerSecond;
            GameType = gameType;
            updateTimer = new Stopwatch();
            drawTimer = new Stopwatch();
            pointDeductTimer = new Stopwatch();
            applePositionGenerator = new Random();
        }
        #endregion

        #region Initialize
        /// <summary>
        /// Initializes the game. Should only be called once in a games life cycle.
        /// </summary>
        public virtual void Initialize()
        {
            //init snake
            Snake.Initialize();
            //generate first apple position
            ApplePosition = new byte[2] { (byte)applePositionGenerator.Next(1,MapX),
                                        (byte)applePositionGenerator.Next(1, MapY) };
            //start timers
            updateTimer.Start();
            drawTimer.Start();
            pointDeductTimer.Start();
            //flag the game as running
            GameState = EGameState.Running;
            PausedState = EPauseState.Unpaused;
            DebugState = EDebugState.NotDebugging;
        }
        #endregion

        #region Update
        /// <summary>
        /// Updates the game, based on the timing of updateTimer.
        /// </summary>
        public virtual void Update()
        {
            //update snake
            Snake.Update();
            //check if snake head collides with food
            if (ApplePosition != null &&
                Snake.BodyPositions.First()[0] == ApplePosition[0] &&
                Snake.BodyPositions.First()[1] == ApplePosition[1])
            {
                //offset food with snake direction
                if (Snake.Direction == EDirectionType.UP) ApplePosition[1]--;
                else if (Snake.Direction == EDirectionType.DOWN) ApplePosition[1]++;
                else if (Snake.Direction == EDirectionType.LEFT) ApplePosition[0]--;
                else if (Snake.Direction == EDirectionType.RIGHT) ApplePosition[0]++;
                //make snake longer, add points 
                Snake.BodyPositions.AddFirst(ApplePosition);
                Snake.Points += Speed * Snake.BodyPositions.Count;
                //generate tentative food within bounds and not on snake
                byte[] tentativeFoodPosition;
                //confirm tentative food
                do tentativeFoodPosition = new byte[2] { (byte)applePositionGenerator.Next(1,MapX),
                                        (byte)applePositionGenerator.Next(1, MapY) };
                while (tentativeFoodPosition[0] == Snake.BodyPositions.First()[0] &&
                       tentativeFoodPosition[1] == Snake.BodyPositions.First()[1] &&
                       Snake.Collide(tentativeFoodPosition));
                //add new food
                ApplePosition = tentativeFoodPosition;
                pointDeductTimer.Restart();
            }
            //
            if (pointDeductTimer.ElapsedMilliseconds > DeductSpeedMS)
            {
                Snake.Points -= DeductAmount;
                pointDeductTimer.Restart();
            }
            //check if snake is out of bounds, teleport if it is
            if (GameType == EGameType.Teleport)
            {
                if (Snake.BodyPositions.First()[0] <= 0)
                    Snake.BodyPositions.First()[0] = (byte)(MapX - 1);
                else if (Snake.BodyPositions.First()[0] >= MapX)
                    Snake.BodyPositions.First()[0] = 1;
                else if (Snake.BodyPositions.First()[1] <= 0)
                    Snake.BodyPositions.First()[1] = (byte)(MapY - 1);
                else if (Snake.BodyPositions.First()[1] >= MapY)
                    Snake.BodyPositions.First()[1] = 1;
            }
            //else if snake is out of bounds, end game if it is
            else
            {
                if (Snake.BodyPositions.First()[0] <= 0) GameState = EGameState.NotRunning;
                else if (Snake.BodyPositions.First()[0] >= MapX) GameState = EGameState.NotRunning;
                else if (Snake.BodyPositions.First()[1] <= 0) GameState = EGameState.NotRunning;
                else if (Snake.BodyPositions.First()[1] >= MapY) GameState = EGameState.NotRunning;
            }
            //check if snake collided with self
            if (Snake.CollisionWithSelf) GameState = EGameState.NotRunning;
            //set game speed
            Speed = (byte)(StartingSpeed + (Snake.Points / SpeedIncreaseThreshold));
            //reset update timer
            updateTimer.Restart();
        }
        #endregion
    }
}
