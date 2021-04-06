using Microsoft.Xna.Framework;

namespace RPG
{
    public abstract class Object
    {
        public Vector2 position;
        public Vector2 size;

        public Rectangle Bounds
        {
            get { return new Rectangle(position.ToPoint(), size.ToPoint()); }
        }

        public Object(float x, float y, float width, float height)
        {
            position = new Vector2(x, y);
            size = new Vector2(width, height);
        }

        public abstract void Draw(Game1 game); // Draw UI
        public abstract void Update(GameTime gameTime, Game1 game); // Update UI
    }
}
