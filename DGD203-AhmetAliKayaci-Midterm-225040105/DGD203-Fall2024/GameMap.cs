namespace SuperHeroSimulation
{
    public class GameMap
    {
        #region VARIABLES
        public Vector2Int PlayerPosition { get; set; }
        #endregion

        #region CONSTRUCTOR
        public GameMap(Vector2Int startPosition)
        {
            PlayerPosition = startPosition;
        }
        #endregion

        #region METHODS
        public void MovePlayer(string direction)
        {
            switch (direction.ToLower())
            {
                case "left":
                    PlayerPosition = new Vector2Int(PlayerPosition.X - 1, PlayerPosition.Y);
                    break;
                case "right":
                    PlayerPosition = new Vector2Int(PlayerPosition.X + 1, PlayerPosition.Y);
                    break;
                case "up":
                    PlayerPosition = new Vector2Int(PlayerPosition.X, PlayerPosition.Y + 1);
                    break;
                case "down":
                    PlayerPosition = new Vector2Int(PlayerPosition.X, PlayerPosition.Y - 1);
                    break;
                default:
                    Console.WriteLine("Invalid direction!");
                    break;
            }
        }

        public void DisplayPlayerPosition()
        {
            Console.WriteLine($"Player position: ({PlayerPosition.X}, {PlayerPosition.Y})");
        }
        #endregion
    }
}