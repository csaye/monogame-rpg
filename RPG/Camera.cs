using Microsoft.Xna.Framework;
using RPG.Objects;
using System;

namespace RPG
{
    public class Camera
    {
        public GameObject Target { get; set; }
        public Matrix Transform { get; private set; }

        public Camera(GameObject target)
        {
            Target = target;
        }

        public void Update(GameTime gameTime, Game1 game)
        {
            // Get screen mid dimensions and scene dimensions
            int midWidth = Drawing.Width / 2;
            int midHeight = Drawing.Height / 2;
            int sceneWidth = game.SceneManager.CurrentScene.Width;
            int sceneHeight = game.SceneManager.CurrentScene.Height;

            // Clamp target within scene bounds
            int targetX = Math.Clamp(Target.X + (Target.Width / 2), midWidth, sceneWidth - midWidth);
            int targetY = Math.Clamp(Target.Y + (Target.Height / 2), midHeight, sceneHeight - midHeight);

            // Flip target x and y
            targetX *= -1;
            targetY *= -1;

            // Position matrix
            Matrix position = Matrix.CreateTranslation(targetX, targetY, 0);

            // Offset matrix
            Matrix offset = Matrix.CreateTranslation(midWidth, midHeight, 0);

            // Update transform matrix
            Transform = position * offset;
        }
    }
}
