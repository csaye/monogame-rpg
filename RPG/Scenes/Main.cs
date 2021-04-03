using RPG.Objects;
using RPG.Tiles;

namespace RPG.Scenes
{
    public class Main : Scene
    {
        private readonly int[,] tiles = new int[,]
        {
            {0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0},
            {0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0},
            {0,1,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0},
            {0,1,0,0,0,1,0,0,0,0,0,0,0,3,3,3,3,3,0,0,0,1,0,0},
            {1,1,1,1,1,1,0,0,0,0,3,3,3,3,2,2,2,3,0,0,0,1,0,0},
            {0,1,0,0,0,0,0,0,0,3,3,2,2,2,2,2,2,3,0,0,0,1,0,0},
            {0,1,0,0,0,0,3,3,3,3,2,2,2,2,2,2,2,3,3,0,0,1,0,0},
            {0,1,0,0,0,0,3,3,2,2,2,2,2,2,2,2,2,2,3,0,0,1,0,0},
            {0,1,0,0,0,0,3,2,2,2,2,2,2,2,2,2,2,2,3,0,0,1,0,0},
            {0,1,0,0,0,3,3,2,2,2,2,2,2,2,2,2,2,2,3,0,0,1,0,0},
            {0,1,0,0,3,3,2,2,2,2,2,2,2,2,2,2,2,2,3,3,0,1,0,0},
            {0,1,0,3,3,2,2,2,2,2,2,2,2,2,2,2,2,2,2,3,0,1,0,0},
            {0,1,0,3,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,3,0,1,0,0},
            {0,1,0,3,2,2,2,2,2,2,2,2,2,2,2,2,2,2,3,3,0,1,0,0},
            {0,1,0,3,2,2,2,2,2,2,2,2,2,2,2,2,2,3,3,0,0,1,0,0},
            {0,1,0,3,3,2,2,2,2,2,2,2,2,2,2,2,3,0,0,0,0,1,0,0},
            {0,1,0,0,3,2,2,2,2,2,2,3,3,3,3,3,0,0,0,0,0,1,0,0},
            {0,1,0,0,3,3,2,2,2,2,3,3,0,0,0,0,0,0,0,0,0,1,0,0},
            {0,1,0,0,3,3,3,3,3,3,3,0,0,0,0,0,0,0,0,0,0,1,0,0},
            {0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1},
            {0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0}
        };

        public Main()
        {
            // Get tile width and height from array
            int tilesWidth = tiles.GetLength(1);
            int tilesHeight = tiles.GetLength(0);

            // Set scene width and height
            Width = Drawing.Grid * tilesWidth;
            Height = Drawing.Grid * tilesHeight;

            // Initialize tiles
            TileManager.InitTiles(tilesWidth, tilesHeight);
            for (int x = 0; x < tilesWidth; x++)
            {
                for (int y = 0; y < tilesHeight; y++)
                {
                    Tile tile = new Tile(Drawing.TilesTexture, tiles[y, x], x * Drawing.Grid, y * Drawing.Grid);
                    TileManager.SetTile(x, y, tile);
                }
            }

            // Initialize objects
            ObjectManager.InitStatic(tilesWidth, tilesHeight);
            ObjectManager.SetStatic(2, 2, new Rock(2 * Drawing.Grid, 2 * Drawing.Grid));
            
            // Initialize player and camera
            Player player = new Player(0, 0);
            ObjectManager.AddDynamic(player);
            Camera = new Camera(player);
        }
    }
}
