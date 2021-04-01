using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RPG
{
    public static class Drawing
    {
        public static void DrawRect(Rectangle rect, Color color, Game1 game, float depth)
        {
            Texture2D texture = new Texture2D(game.GraphicsDevice, 1, 1);
            texture.SetData(new[] { Color.White });
            game.SpriteBatch.Draw(texture, rect, null, color, 0, new Vector2(0, 0), SpriteEffects.None, depth);
        }
    }
}
