using Microsoft.Xna.Framework;

namespace RPG.Objects
{
    public abstract class GameObject
    {
        // Position
        public float X { get; private set; }
        public float Y { get; private set; }
        public Vector2 Position
        {
            get { return new Vector2(X, Y); }
            set { X = value.X; Y = value.Y; }
        }

        // Size
        public int W { get; private set; }
        public int H { get; private set; }
        public Vector2 Size
        {
            get { return new Vector2(W, H); }
            set { W = (int)value.X; H = (int)value.Y; }
        }

        // Bounds
        public Rectangle Bounds
        {
            get { return new Rectangle((int)X, (int)Y, W, H); }
        }

        public GameObject(float x, float y, int w, int h)
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
