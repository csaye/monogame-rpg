using Microsoft.Xna.Framework;
using System;

namespace RPG.Tiles
{
    public class TileManager
    {
        public byte[,] Tiles { get; private set; }

        private const int Grid = Drawing.Grid;

        public TileManager() { }

        public void Draw(Game1 game)
        {
            // If no camera, return
            if (game.Camera == null) return;

            // Get camera view bounds
            Vector2 cameraPosition = game.Camera.Position / Drawing.Grid;
            int minX = (int)Math.Floor(cameraPosition.X);
            int minY = (int)Math.Floor(cameraPosition.Y);
            int maxX = Math.Min(minX + Drawing.GridWidth, Tiles.GetLength(1) - 1);
            int maxY = Math.Min(minY + Drawing.GridHeight, Tiles.GetLength(0) - 1);

            // Draw all tiles visible by camera
            for (int x = minX; x <= maxX; x++)
            {
                for (int y = minY; y <= maxY; y++)
                {
                    byte tile = Tiles[x, y];
                    Rectangle rect = new Rectangle(x * Grid, y * Grid, Grid, Grid);
                    Drawing.DrawTile(Drawing.TilesetTexture, tile, rect, game, SortingLayers.Tiles);
                }
            }
        }

        public void InitTiles(byte[,] tiles) => Tiles = tiles; // Initializes tile array
        public Tile GetTile(int x, int y) => (Tile)Tiles[x, y]; // Gets tile at position
        public void SetTile(int x, int y, Tile tile) => Tiles[x, y] = (byte)tile; // Sets given position to given tile
    }
}
