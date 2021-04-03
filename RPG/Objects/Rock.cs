using Microsoft.Xna.Framework;

namespace RPG.Objects
{
    public class Rock : GameObject
    {
        public Rock(int x, int y) : base(x, y, Drawing.Grid, Drawing.Grid) {}

        public override void Draw(Game1 game)
        {
            Drawing.DrawSprite(Drawing.RockTexture, Bounds, game, SortingLayers.Objects);
        }

        public override void Update(GameTime gameTime, Game1 game) {}
    }
}
