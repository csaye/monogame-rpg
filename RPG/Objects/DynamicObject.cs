using Microsoft.Xna.Framework;
using System;

namespace RPG.Objects
{
    public abstract class DynamicObject : GameObject
    {
        protected Vector2 movementDirection;
        protected float movementSpeed;

        public DynamicObject(float x, float y, float width, float height, Vector2 movementDirection, float movementSpeed)
            : base(x, y, width, height)
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
            int sceneWidth = game.CurrentScene.Width;
            int sceneHeight = game.CurrentScene.Height;
            position.X = Math.Clamp(position.X, 0, sceneWidth - size.X);
            position.Y = Math.Clamp(position.Y, 0, sceneHeight - size.Y);
        }
    }
}
