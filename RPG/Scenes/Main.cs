using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
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
                    Tile tile = new Tile(x * Drawing.Grid, y * Drawing.Grid, Drawing.TilesTexture, tiles[y, x]);
                    TileManager.SetTile(x, y, tile);
                }
            }

            // Initialize objects
            ObjectManager.InitStatic(tilesWidth, tilesHeight);
            ObjectManager.AddStatic(new Rock(2 * Drawing.Grid, 2 * Drawing.Grid));
            
            // Initialize player and camera
            Player player = new Player(0, 0);
            ObjectManager.AddDynamic(player);
            Camera = new Camera(player);
        }

        public override void Update(GameTime gameTime, Game1 game)
        {
            ProcessMouseState(game);

            base.Update(gameTime, game);
        }

        private void ProcessMouseState(Game1 game)
        {
            // Get mouse states
            MouseState mouseState = game.MouseState;
            MouseState lastMouseState = game.LastMouseState;

            // If left button clicked
            if (mouseState.LeftButton == ButtonState.Released && lastMouseState.LeftButton == ButtonState.Pressed)
            {
                // Get click point
                Point clickPoint = mouseState.Position + Camera.Position.ToPoint();
                int x = clickPoint.X / Drawing.Grid;
                int y = clickPoint.Y / Drawing.Grid;
                // Set click point to path tile
                TileManager.SetTile(x, y, new Tile(x * Drawing.Grid, y * Drawing.Grid, Drawing.TilesTexture, 1));
            }
        }
    }
}
