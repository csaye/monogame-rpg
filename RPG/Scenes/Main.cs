using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using RPG.Objects;
using RPG.Tiles;
using RPG.UI;

namespace RPG.Scenes
{
    public class Main : Scene
    {
        private const int Grid = Drawing.Grid;

        private readonly byte[,] tiles = new byte[,]
        {
            {0,5,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0,0},
            {0,5,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0,0},
            {0,5,0,0,0,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5},
            {0,5,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0,0},
            {0,5,0,0,0,5,0,0,0,0,0,0,0,2,2,2,2,2,0,0,0,5,0,0},
            {5,5,5,5,5,5,0,0,0,0,2,2,2,2,1,1,1,2,0,0,0,5,0,0},
            {0,5,0,0,0,0,0,0,0,2,2,1,1,1,1,1,1,2,0,0,0,5,0,0},
            {0,5,0,0,0,0,2,2,2,2,1,1,1,1,1,1,1,2,2,0,0,5,0,0},
            {0,5,0,0,0,0,2,2,1,1,1,1,1,1,1,1,1,1,2,0,0,5,0,0},
            {0,5,0,0,0,0,2,1,1,1,1,1,1,1,1,1,1,1,2,0,0,5,0,0},
            {0,5,0,0,0,2,2,1,1,1,1,1,1,1,1,1,1,1,2,0,0,5,0,0},
            {0,5,0,0,2,2,1,1,1,1,1,1,1,1,1,1,1,1,2,2,0,5,0,0},
            {0,5,0,2,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,0,5,0,0},
            {0,5,0,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,0,5,0,0},
            {0,5,0,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,2,0,5,0,0},
            {0,5,0,2,1,1,1,1,1,1,1,1,1,1,1,1,1,2,2,0,0,5,0,0},
            {0,5,0,2,2,1,1,1,1,1,1,1,1,1,1,1,2,0,0,0,0,5,0,0},
            {0,5,0,0,2,1,1,1,1,1,1,2,2,2,2,2,0,0,0,0,0,5,0,0},
            {0,5,0,0,2,2,1,1,1,1,2,2,0,0,0,0,0,0,0,0,0,5,0,0},
            {0,5,0,0,2,2,2,2,2,2,2,0,0,0,0,0,0,0,0,0,0,5,0,0},
            {0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,5,5,5,5},
            {0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0},
            {5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0}
        };

        public Main()
        {
            // Get tile width and height from array
            int tilesWidth = tiles.GetLength(1);
            int tilesHeight = tiles.GetLength(0);

            // Set scene width and height
            Width = tilesWidth * Grid;
            Height = tilesHeight * Grid;

            // Initialize tiles
            TileManager.InitTiles(tiles);

            // Initialize objects
            ObjectManager.InitStatic(tilesWidth, tilesHeight);
            ObjectManager.AddStatic(new Rock(2 * Grid, 2 * Grid));
            
            // Initialize player and camera
            Player player = new Player(0, 0);
            ObjectManager.AddDynamic(player);
            Camera = new Camera(player);

            // Initialize UI
            Button backButton = new Button(Grid / 2, Grid / 2, Grid / 2, Grid / 2, "X", LoadMenu);
            UIManager.Add(backButton);
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
                TileManager.SetTile(x, y, Tile.Dirt);
            }
        }

        private void LoadMenu(Game1 game)
        {
            // Load menu scene
            game.LoadScene(new Menu());
        }
    }
}
