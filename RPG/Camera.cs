using Microsoft.Xna.Framework;
using System;

namespace RPG
{
    public class Camera
    {
        public Matrix Transform { get; private set; }
        public Vector2 Position { get; private set; }

        public Camera() { }

        public void Update(GameTime gameTime, Game1 game)
        {
            // If no camera in scene, return
            if (game.Camera == null) return;

            // Get screen mid dimensions and scene dimensions
            int midWidth = Drawing.Width / 2;
            int midHeight = Drawing.Height / 2;
            int sceneWidth = game.CurrentScene.Width;
            int sceneHeight = game.CurrentScene.Height;

            Vector2 playerPosition = game.Player.Position;
            Vector2 playerSize = game.Player.Size;

            // Clamp target within scene bounds
            int targetX = Math.Clamp((int)(playerPosition.X + (playerSize.X / 2)), midWidth, sceneWidth - midWidth);
            int targetY = Math.Clamp((int)(playerPosition.Y + (playerSize.Y / 2)), midHeight, sceneHeight - midHeight);
            
            // Set position
            Position = new Vector2(targetX - midWidth, targetY - midHeight);

            // Flip target x and y
            targetX *= -1;
            targetY *= -1;

            Matrix position = Matrix.CreateTranslation(targetX, targetY, 0); // Position matrix
            Matrix offset = Matrix.CreateTranslation(midWidth, midHeight, 0); // Offset matrix

            // Update transform matrix
            Transform = position * offset;
        }
    }
}
