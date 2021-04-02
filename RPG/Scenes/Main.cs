using Microsoft.Xna.Framework;
using RPG.Objects;
using RPG.Tiles;

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
                    TileManager.Add(new Tile(Drawing.TilesTexture, new Vector2(0, 0), x, y));
                }
            }

            // Initialize objects
            ObjectManager.Add(new Rock(32 * 2, 32 * 2));
            ObjectManager.Add(new Player(0, 0));
        }
    }
}
