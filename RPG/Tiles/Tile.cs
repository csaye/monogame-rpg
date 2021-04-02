using Microsoft.Xna.Framework;

namespace RPG.Tiles
{
    public class Tile
    {
        // Position
        public TileType TileType { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        // Bounds
        public Rectangle Bounds
        {
            get { return new Rectangle(X, Y, Drawing.Grid, Drawing.Grid); }
        }

        public Tile(TileType tileType, int x, int y)
        {
            TileType = tileType;
            X = x;
            Y = y;
        }

        public void Draw(Game1 game)
        {
            Drawing.DrawTile(TileType, Bounds, game, SortingLayers.Tiles);
        }
    }
}
