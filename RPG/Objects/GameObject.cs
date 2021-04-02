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
        public int W { get; set; }
        public int H { get; set; }
        public Vector2 Size
        {
            get { return new Vector2(W, H); }
            set { W = (int)value.X; H = (int)value.Y; }
        }

        // Bounds
        public Rectangle Bounds
        {
            get { return new Rectangle(X, Y, W, H); }
        }

        public GameObject(int x, int y, int w, int h)
        {
            X = x;
            Y = y;
            W = w;
            H = h;
        }

        public abstract void Draw(Game1 game);
        public abstract void Update(GameTime gameTime, Game1 game);
    }
}
