﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using RPG.Utility;

namespace RPG.Objects
{
    public class Player : GameObject
    {
        private Vector2 movementDirection = new Vector2(0, 0);
        private float movementSpeed = 100;

        public Player(float x, float y) : base(x, y, 32, 32) { }

        public override void Draw(Game1 game)
        {
            Drawing.DrawRect(Bounds, Color.Red, game, SortingLayers.Player);
        }

        public override void Update(GameTime gameTime, Game1 game)
        {
            ProcessKeyboardState(game);

            // Update position
            Vector2 movementFactor = movementDirection * (float)gameTime.ElapsedGameTime.TotalSeconds * movementSpeed;
            Position = game.ObjectManager.TryMove(this, movementFactor);

            // Constrain to screen bounds
            if (X > game.Width - W) X = game.Width - W;
            else if (X < 0) X = 0;
            if (Y > game.Height - H) Y = game.Width - H;
            else if (Y < 0) Y = 0;
        }

        private void ProcessKeyboardState(Game1 game)
        {
            KeyboardState state = game.KeyboardState;

            // Exit game
            if (state.IsKeyDown(Keys.Escape)) game.Exit();

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