using Microsoft.Xna.Framework;

namespace RPG.Objects
{
    public abstract class GameObject
    {
        // Position
        public int X { get; set; }
        public int Y { get; set; }
        public Vector2 Position
        {
            get { return new Vector2(X, Y); }
            set { X = (int)value.X; Y = (int)value.Y; }
        }

        // Size
        public int Width { get; set; }
        public int Height { get; set; }
        public Vector2 Size
        {
            get { return new Vector2(Width, Height); }
            set { Width = (int)value.X; Height = (int)value.Y; }
        }

        // Bounds
        public Rectangle Bounds
        {
            get { return new Rectangle(X, Y, Width, Height); }
        }

        public GameObject(int x, int y, int width, int height)
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
