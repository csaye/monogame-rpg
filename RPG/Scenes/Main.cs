using RPG.Objects;
using RPG.Tiles;
using System;

namespace RPG.Scenes
{
    public class Main : Scene
    {
        public Main()
        {
            // Initialize tiles
            for (int x = 0; x < Drawing.Width; x += Drawing.Grid)
            {
                for (int y = 0; y < Drawing.Height; y += Drawing.Grid)
                {
                    float val = Math.Abs((x / Drawing.Grid) - (y / Drawing.Grid));
                    TileType tileType;
                    if (val > 10) tileType = TileType.Grass;
                    else if (val > 6) tileType = TileType.Dirt;
                    else if (val > 2) tileType = TileType.Water;
                    else tileType = TileType.Sand;
                    TileManager.Add(new Tile(tileType, x, y));
                }
            }

            // Initialize objects
            ObjectManager.Add(new Rock(32 * 2, 32 * 2));
            ObjectManager.Add(new Player(0, 0));
        }
    }
}
