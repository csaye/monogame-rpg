using Microsoft.Xna.Framework;

namespace RPG.Objects
{
    public abstract class DynamicObject : GameObject
    {
        protected Vector2 movementDirection;
        protected float movementSpeed;

        public DynamicObject(
            float x, float y, float width, float height,
            Vector2 movementDirection, float movementSpeed
        ) : base(x, y, width, height)
        {
            this.movementDirection = movementDirection;
            this.movementSpeed = movementSpeed;
        }

        public override void Update(GameTime gameTime, Game1 game)
        {
            // Calculate delta
            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Update position
            Vector2 movementFactor = movementDirection * movementSpeed * delta;
            position = game.ObjectManager.TryMove(this, movementFactor);

            // Constrain to scene bounds
            int sceneWidth = game.SceneManager.CurrentScene.Width;
            int sceneHeight = game.SceneManager.CurrentScene.Height;
            if (position.X > sceneWidth - size.X) position.X = sceneWidth - size.X;
            else if (position.X < 0) position.X = 0;
            if (position.Y > sceneHeight - size.Y) position.Y = sceneHeight - size.Y;
            else if (position.Y < 0) position.Y = 0;
        }
    }
}
