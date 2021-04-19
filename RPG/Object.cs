using Microsoft.Xna.Framework;

namespace RPG
{
    public abstract class Object
    {
        protected Vector2 position;
        protected Vector2 size;

        public Vector2 Position => position;
        public Vector2 Size => size;

        public Rectangle Bounds
        {
            get { return new Rectangle(position.ToPoint(), size.ToPoint()); }
        }

        public Object(float x, float y, float width, float height)
        {
            position = new Vector2(x, y);
            size = new Vector2(width, height);
        }

        public abstract void Draw(Game1 game); // Draw object
        public abstract void Update(GameTime gameTime, Game1 game); // Update object
    }
}
