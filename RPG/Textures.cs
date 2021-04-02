using Microsoft.Xna.Framework.Graphics;

namespace RPG
{
    public static class Textures
    {
        public static Texture2D GrassTexture { get; private set; }

        public static void LoadTextures(Game1 game)
        {
            GrassTexture = game.Content.Load<Texture2D>("Grass");
        }
    }
}
