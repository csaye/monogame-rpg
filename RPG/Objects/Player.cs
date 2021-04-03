﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace RPG.Objects
{
    public class Player : GameObject
    {
        private Vector2 movementDirection = new Vector2(0, 0);
        private float movementSpeed = 120;

        public Player(float x, float y) : base(x, y, Drawing.Grid, Drawing.Grid) {}

        public override void Draw(Game1 game)
        {
            Drawing.DrawRect(Bounds, Color.Red, game, SortingLayers.Player);
        }

        public override void Update(GameTime gameTime, Game1 game)
        {
            ProcessKeyboardState(game.KeyboardState);

            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Update position
            Vector2 movementFactor = movementDirection * delta * movementSpeed;
            Position = game.ObjectManager.TryMove(this, movementFactor);

            // Constrain to scene bounds
            int sceneWidth = game.SceneManager.CurrentScene.Width;
            int sceneHeight = game.SceneManager.CurrentScene.Height;
            if (X > sceneWidth - Width) X = sceneWidth - Width;
            else if (X < 0) X = 0;
            if (Y > sceneHeight - Height) Y = sceneHeight - Height;
            else if (Y < 0) Y = 0;
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
