using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RPG.Tiles;

namespace RPG
{
    public static class Drawing
    {
        public static int Grid { get; } = 32;
        public static int Width { get; } = 16 * 32;
        public static int Height { get; } = 16 * 32;

        public static int TileGrid { get; } = 16;

        private static Texture2D blankTexture;
        private static SpriteFont arialFont;

        public static Texture2D TilesTexture { get; private set; }
        public static Texture2D RockTexture { get; private set; }

        public static void InitializeGraphics(Game1 game)
        {
            game.Graphics.PreferredBackBufferWidth = Width;
            game.Graphics.PreferredBackBufferHeight = Height;
            game.Graphics.ApplyChanges();

            blankTexture = new Texture2D(game.GraphicsDevice, 1, 1);
            blankTexture.SetData(new[] { Color.White });

            arialFont = game.Content.Load<SpriteFont>("Arial");

            TilesTexture = game.Content.Load<Texture2D>("Tiles");
            RockTexture = game.Content.Load<Texture2D>("Rock");
        }

        public static void DrawRect(Rectangle rect, Color color, Game1 game, float depth)
        {
            game.SpriteBatch.Draw(blankTexture, rect, null, color, 0, new Vector2(0, 0), SpriteEffects.None, depth);
        }

        public static void DrawSprite(Texture2D texture, Rectangle rect, Game1 game, float depth)
        {
            game.SpriteBatch.Draw(texture, rect, null, Color.White, 0, new Vector2(0, 0), SpriteEffects.None, depth);
        }

        public static void DrawTile(Texture2D tileset, Vector2 tilesetPos, Rectangle rect, Game1 game, float depth)
        {
            Rectangle sourceRect = new Rectangle((int)tilesetPos.X * TileGrid, (int)tilesetPos.Y * TileGrid, TileGrid, TileGrid);
            game.SpriteBatch.Draw(tileset, rect, sourceRect, Color.White, 0, new Vector2(0, 0), SpriteEffects.None, depth);
        }

        public static void DrawText(string text, Vector2 position, Color color, Game1 game, float depth)
        {
            game.SpriteBatch.DrawString(arialFont, text, position, color, 0, new Vector2(0, 0), 1, SpriteEffects.None, depth);
        }
    }
}
