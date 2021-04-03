using Microsoft.Xna.Framework;

namespace RPG.Objects
{
    public abstract class GameObject
    {
        // Position
        public Vector2 position;

        // Size
        public Vector2 size;

        // Bounds
        public Rectangle Bounds
        {
            get { return new Rectangle(position.ToPoint(), size.ToPoint()); }
        }

        public GameObject(float x, float y, float width, float height)
        {
            position = new Vector2(x, y);
            size = new Vector2(width, height);
        }

        public abstract void Draw(Game1 game); // Draw object
        public abstract void Update(GameTime gameTime, Game1 game); // Update object
    }
}
