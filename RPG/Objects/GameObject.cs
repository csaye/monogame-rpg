using Microsoft.Xna.Framework;

namespace RPG.Objects
{
    public abstract class GameObject
    {
        // Position
        public float X { get; set; }
        public float Y { get; set; }
        public Vector2 Position
        {
            get { return new Vector2(X, Y);  }
            set { X = value.X; Y = value.Y; }
        }

        // Size
        public float Width { get; set; }
        public float Height { get; set; }
        public Vector2 Size
        {
            get { return new Vector2(Width, Height); }
            set { Width = value.X; Height = value.Y; }
        }

        // Bounds
        public Rectangle Bounds
        {
            get { return new Rectangle(Position.ToPoint(), Size.ToPoint()); }
        }

        public GameObject(float x, float y, float width, float height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public abstract void Draw(Game1 game); // Draw object
        public abstract void Update(GameTime gameTime, Game1 game); // Update object
    }
}
