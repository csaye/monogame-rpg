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

        private static Texture2D tilesTexture;
        private static Texture2D blankTexture;
        private static SpriteFont arialFont;

        public static void InitializeGraphics(Game1 game)
        {
            game.Graphics.PreferredBackBufferWidth = Width;
            game.Graphics.PreferredBackBufferHeight = Height;
            game.Graphics.ApplyChanges();

            blankTexture = new Texture2D(game.GraphicsDevice, 1, 1);
            blankTexture.SetData(new[] { Color.White });

            arialFont = game.Content.Load<SpriteFont>("Arial");

            tilesTexture = game.Content.Load<Texture2D>("Tiles");
        }

        public static void DrawRect(Rectangle rect, Color color, Game1 game, float depth)
        {
            game.SpriteBatch.Draw(blankTexture, rect, null, color, 0, new Vector2(0, 0), SpriteEffects.None, depth);
        }

        public static void DrawSprite(Texture2D texture, Rectangle rect, Game1 game, float depth)
        {
            game.SpriteBatch.Draw(texture, rect, null, Color.White, 0, new Vector2(0, 0), SpriteEffects.None, depth);
        }

        public static void DrawTile(TileType tileType, Rectangle rect, Game1 game, float depth)
        {
            Rectangle sourceRect = GetSourceRect(tileType);
            game.SpriteBatch.Draw(tilesTexture, rect, sourceRect, Color.White, 0, new Vector2(0, 0), SpriteEffects.None, depth);
        }

        public static void DrawText(string text, Vector2 position, Color color, Game1 game, float depth)
        {
            game.SpriteBatch.DrawString(arialFont, text, position, color, 0, new Vector2(0, 0), 1, SpriteEffects.None, depth);
        }

        private static Rectangle GetSourceRect(TileType tileType)
        {
            switch (tileType)
            {
                case TileType.Grass: return new Rectangle(0, 0, TileGrid, TileGrid);
                case TileType.Dirt: return new Rectangle(TileGrid, 0, TileGrid, TileGrid);
                case TileType.Water: return new Rectangle(0, TileGrid, TileGrid, TileGrid);
                case TileType.Sand: return new Rectangle(TileGrid, TileGrid, TileGrid, TileGrid);
            }

            return new Rectangle();
        }
    }
}
