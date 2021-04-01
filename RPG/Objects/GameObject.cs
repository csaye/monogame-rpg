using System;

namespace RPG.Objects
{
    public abstract class GameObject
    {
        // Position
        public int X { get; private set; }
        public int Y { get; private set; }

        // Size
        public int W { get; private set; }
        public int H { get; private set; }

        public GameObject(int x, int y, int w, int h)
        {
            X = x;
            Y = y;
            W = w;
            H = h;
        }

        public abstract void Draw(Game1 game);
    }
}
