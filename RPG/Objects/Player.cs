using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace RPG.Objects
{
    public class Player : DynamicObject
    {
        private float elapsedTime = 0;
        private const float frameTime = 0.2f;
        private int animFrame = 0;
        private int tilesetIndex = 0;
        private Vector2 lastMovementDirection;

        public Player(float x, float y) : base(x, y, Drawing.Grid, Drawing.Grid, new Vector2(0, 0), 100) {}

        public override void Draw(Game1 game)
        {
            Drawing.DrawTile(Drawing.PlayerTexture, tilesetIndex, Bounds, game, SortingLayers.Player);
        }

        public override void Update(GameTime gameTime, Game1 game)
        {
            ProcessKeyboardState(game.KeyboardState);
            Animate(gameTime);

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

        private void Animate(GameTime gameTime)
        {
            // Increment elapsed time
            elapsedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

            // If not moving
            if (movementDirection == new Vector2(0, 0))
            {
                // Reset to base tile
                if (tilesetIndex % 4 != 0) tilesetIndex = tilesetIndex / 4 * 4;
            }

            // If new movement direction
            if (movementDirection != lastMovementDirection)
            {
                // Update movement direction and elapsed time
                lastMovementDirection = movementDirection;
                elapsedTime = frameTime;
            }

            // If moving and frame elapsed
            if (movementDirection != new Vector2(0, 0) && elapsedTime >= frameTime)
            {
                // Get base sprite
                if (movementDirection.X > 0) tilesetIndex = 8;
                else if (movementDirection.X < 0) tilesetIndex = 12;
                else if (movementDirection.Y > 0) tilesetIndex = 0;
                else if (movementDirection.Y < 0) tilesetIndex = 4;

                // Increment tileset index by anim frame
                tilesetIndex += animFrame % 4;

                // Increment anim frame and elapsed time
                animFrame++;
                elapsedTime = 0;
            }
        }
    }
}
