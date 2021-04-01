using Microsoft.Xna.Framework;

namespace RPG.Objects
{
    public class Rock : GameObject
    {
        private Rectangle Bounds
        {
            get { return new Rectangle(X, Y, W, H); }
        }

        public Rock(int x, int y) : base(x, y, 32, 32) {}

        public override void Draw(Game1 game)
        {
            Drawing.DrawRect(Bounds, Color.Gray, game);
        }
    }
}
