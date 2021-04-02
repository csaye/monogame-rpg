using Microsoft.Xna.Framework;

namespace RPG.Tiles
{
    public abstract class Tile
    {
        // Position
        public int X { get; set; }
        public int Y { get; set; }

        // Bounds
        public Rectangle Bounds
        {
            get { return new Rectangle(X, Y, Drawing.Grid, Drawing.Grid); }
        }

        public Tile(int x, int y)
        {
            X = x;
            Y = y;
        }

        public abstract void Draw(Game1 game);
    }
}
