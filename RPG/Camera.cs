using Microsoft.Xna.Framework;
using RPG.Objects;

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
            Matrix position = Matrix.CreateTranslation(
                -Target.X - (Target.Width / 2),
                -Target.Y - (Target.Height / 2),
                0
            );

            Matrix offset = Matrix.CreateTranslation(
                Drawing.Width / 2,
                Drawing.Height / 2,
                0
            );

            Transform = position * offset;
        }
    }
}
