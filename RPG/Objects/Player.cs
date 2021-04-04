using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace RPG.Objects
{
    public class Player : DynamicObject
    {
        private int tilesetIndex = 0;

        public Player(float x, float y) : base(x, y, Drawing.Grid, Drawing.Grid, new Vector2(0, 0), 100) {}

        public override void Draw(Game1 game)
        {
            if (movementDirection.X > 0) tilesetIndex = 8;
            else if (movementDirection.X < 0) tilesetIndex = 12;
            else if (movementDirection.Y > 0) tilesetIndex = 0;
            else if (movementDirection.Y < 0) tilesetIndex = 4;
            Drawing.DrawTile(Drawing.PlayerTexture, tilesetIndex, Bounds, game, SortingLayers.Player);
        }

        public override void Update(GameTime gameTime, Game1 game)
        {
            ProcessKeyboardState(game.KeyboardState);

            base.Update(gameTime, game);
        }

        private void ProcessKeyboardState(KeyboardState state)
        {
            // Get vertical movement
            if (state.IsKeyDown(Keys.S)) movementDirection.Y = 1;
            else if (state.IsKeyDown(Keys.W)) movementDirection.Y = -1;
            else movementDirection.Y = 0;

            // Get horizontal movement
            if (state.IsKeyDown(Keys.D)) movementDirection.X = 1;
            else if (state.IsKeyDown(Keys.A)) movementDirection.X = -1;
            else movementDirection.X = 0;

            // Normalize movement direction
            if (movementDirection.Length() > 1) movementDirection.Normalize();
        }
    }
}
