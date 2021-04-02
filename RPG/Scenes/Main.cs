using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RPG.Objects;
using RPG.Tiles;

namespace RPG.Scenes
{
    public class Main : Scene
    {
        private Camera camera;

        private int[,] tiles = new int[,]
        {
            {2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2},
            {2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2},
            {2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2},
            {2, 2, 2, 2, 2, 2, 2, 3, 3, 3, 2, 2, 2, 2, 2, 2},
            {2, 2, 2, 2, 2, 2, 2, 3, 0, 3, 3, 2, 2, 2, 2, 2},
            {2, 2, 2, 2, 2, 2, 3, 0, 0, 0, 3, 2, 2, 2, 2, 2},
            {2, 2, 2, 2, 2, 2, 3, 0, 0, 0, 3, 2, 2, 2, 2, 2},
            {2, 2, 2, 2, 2, 2, 3, 0, 0, 1, 3, 2, 2, 2, 2, 2},
            {2, 2, 2, 2, 2, 3, 1, 1, 1, 1, 3, 2, 2, 2, 2, 2},
            {2, 2, 2, 2, 2, 3, 1, 1, 1, 1, 3, 2, 2, 2, 2, 2},
            {2, 2, 2, 2, 2, 2, 3, 1, 1, 1, 3, 2, 2, 2, 2, 2},
            {2, 2, 2, 2, 2, 2, 2, 3, 3, 3, 2, 2, 2, 2, 2, 2},
            {2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2},
            {2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2},
            {2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2},
            {2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2}
        };

        public Main()
        {
            // Initialize tiles
            for (int x = 0; x < Drawing.GridWidth; x++)
            {
                for (int y = 0; y < Drawing.GridHeight; y++)
                {
                    TileManager.Add(new Tile(Drawing.TilesTexture, tiles[y, x], x * Drawing.Grid, y * Drawing.Grid));
                }
            }

            // Initialize objects
            ObjectManager.Add(new Rock(Drawing.Grid * 2, Drawing.Grid * 2));

            // Initialize player and camera
            Player player = new Player(0, 0);
            ObjectManager.Add(player);
            camera = new Camera(player);
        }

        public override void Draw(Game1 game)
        {
            game.SpriteBatch.Begin(SpriteSortMode.BackToFront, null, SamplerState.PointClamp, transformMatrix: camera.Transform);

            // Draw tiles
            TileManager.Draw(game);

            // Draw objects
            ObjectManager.Draw(game);

            game.SpriteBatch.End();
        }

        public override void Update(GameTime gameTime, Game1 game)
        {
            camera.Update(gameTime, game);

            base.Update(gameTime, game);
        }
    }
}
