using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RPG.Tiles
{
    public class Tile
    {
        // Position
        public Texture2D Tileset { get; set; }
        public Vector2 TilesetPos { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        // Bounds
        public Rectangle Bounds
        {
            get { return new Rectangle(X, Y, Drawing.Grid, Drawing.Grid); }
        }

        public Tile(Texture2D tileset, Vector2 tilesetPos, int x, int y)
        {
            Tileset = tileset;
            TilesetPos = tilesetPos;
            X = x;
            Y = y;
        }

        public void Draw(Game1 game)
        {
            Drawing.DrawTile(Tileset, TilesetPos, Bounds, game, SortingLayers.Tiles);
        }
    }
}
