using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RPG.Tiles
{
    public class Tile
    {
        // Position
        public int X { get; set; }
        public int Y { get; set; }

        // Tileset data
        public Texture2D Tileset { get; set; }
        public int TilesetIndex { get; set; }

        // Bounds
        public Rectangle Bounds
        {
            get { return new Rectangle(X, Y, Drawing.Grid, Drawing.Grid); }
        }

        public Tile(int x, int y, Texture2D tileset, int tilesetIndex)
        {
            X = x;
            Y = y;
            Tileset = tileset;
            TilesetIndex = tilesetIndex;
        }

        public void Draw(Game1 game)
        {
            Drawing.DrawTile(Tileset, TilesetIndex, Bounds, game, SortingLayers.Tiles);
        }
    }
}
