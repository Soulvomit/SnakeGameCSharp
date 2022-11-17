using SnakeGameLib.Enums;

namespace SnakeGameLib
{
    public class Snake
    {
        #region Properties
        //current direction of the snake
        public EDirectionType Direction { get; set; }
        //the direction queue that sets the next direction of the snake
        public Queue<EDirectionType> DirectionQueue { get; set; }
        //the body positions of the snake
        public LinkedList<byte[]> BodyPositions { get; set; }
        //flags whether the snak is colliding with itself
        public bool CollisionWithSelf { get; protected set; }
        //current points of the snake
        private int points;
        public int Points
        {
            get
            {
                return points;
            }
            set
            {
                //clamp to zero, because points can never be below zero
                points = Math.Clamp(value, 0, int.MaxValue);
            }
        }
        #endregion

        #region Ctor
        public Snake(byte startX, byte startY, byte initialSize)
        {
            CollisionWithSelf = false;
            DirectionQueue = new Queue<EDirectionType>();
            BodyPositions = new LinkedList<byte[]>();

            for (int i = 0; i < initialSize; i++)
                BodyPositions.AddLast(new byte[2] { (byte)(startX - i), startY });
        }
        #endregion

        #region Initialize
        /// <summary>
        /// Initialize snake.
        /// </summary>
        public virtual void Initialize()
        {
            DirectionQueue.Enqueue(EDirectionType.RIGHT);
        }
        #endregion

        #region Update
        /// <summary>
        /// Updates snake.
        /// </summary>
        public virtual void Update()
        {
            //set a new direction if there are any on queue and direction is valid
            if (DirectionQueue.Count > 0)
            {
                EDirectionType tentativeDirection = DirectionQueue.Dequeue();
                if (tentativeDirection == EDirectionType.UP &&
                    Direction != EDirectionType.DOWN &&
                    Direction != EDirectionType.UP)
                    Direction = tentativeDirection;
                if (tentativeDirection == EDirectionType.DOWN &&
                    Direction != EDirectionType.UP &&
                    Direction != EDirectionType.DOWN)
                    Direction = tentativeDirection;
                if (tentativeDirection == EDirectionType.RIGHT &&
                    Direction != EDirectionType.LEFT &&
                    Direction != EDirectionType.RIGHT)
                    Direction = tentativeDirection;
                if (tentativeDirection == EDirectionType.LEFT &&
                    Direction != EDirectionType.RIGHT &&
                    Direction != EDirectionType.LEFT)
                    Direction = tentativeDirection;
            }

            //move last position to first position 
            BodyPositions.Last()[0] = BodyPositions.First()[0];
            BodyPositions.Last()[1] = BodyPositions.First()[1];
            BodyPositions.AddFirst(BodyPositions.Last());
            BodyPositions.RemoveLast();

            //increment first position in the current direction
            if (Direction == EDirectionType.UP) BodyPositions.First()[1]--;
            else if (Direction == EDirectionType.DOWN) BodyPositions.First()[1]++;
            else if (Direction == EDirectionType.LEFT) BodyPositions.First()[0]--;
            else if (Direction == EDirectionType.RIGHT) BodyPositions.First()[0]++;

            //check if snake collides with itself
            if (Collide(new byte[] { BodyPositions.First()[0], BodyPositions.First()[1] }))
                CollisionWithSelf = true;

        }
        #endregion

        #region Collide
        /// <summary>
        /// Checks for collision with the snake body.
        /// </summary>
        /// <param name="colliderPosition">The position to test for collision with snake.</param>
        /// <param name="ignoreHead">Ignores the first position (head) in collision test.</param>
        /// <returns></returns>
        public virtual bool Collide(byte[] colliderPosition, bool ignoreHead = false)
        {
            foreach (byte[] bodyPart in BodyPositions)
            {
                if (colliderPosition[0] == bodyPart[0] &&
                    colliderPosition[1] == bodyPart[1] &&
                    bodyPart != BodyPositions.First()) return true;
            }
            return false;
        }
        #endregion
    }
}
