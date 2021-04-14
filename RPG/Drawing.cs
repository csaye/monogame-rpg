using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RPG
{
    public static class Drawing
    {
        // Size of grid
        public const int Grid = 32;
        // Width and height of grid
        public const int GridWidth = 16;
        public const int GridHeight = 16;
        // Width and height of screen
        public const int Width = GridWidth * Grid;
        public const int Height = GridHeight * Grid;

        // Size of tile grid
        public const int TileGrid = 16;

        private static Texture2D blankTexture;
        private static SpriteFont arialFont;

        public static Texture2D TilesTexture { get; private set; }
        public static Texture2D RockTexture { get; private set; }
        public static Texture2D PlayerTexture { get; private set; }

        public static void InitializeGraphics(Game1 game)
        {
            game.Graphics.PreferredBackBufferWidth = Width;
            game.Graphics.PreferredBackBufferHeight = Height;
            game.Graphics.ApplyChanges();

            blankTexture = new Texture2D(game.GraphicsDevice, 1, 1);
            blankTexture.SetData(new[] { Color.White });
        }

        public static void LoadContent(Game1 game)
        {
            arialFont = game.Content.Load<SpriteFont>("Arial");

            PlayerTexture = game.Content.Load<Texture2D>("Sprites/Computeroid");
            TilesTexture = game.Content.Load<Texture2D>("Tiles");
            RockTexture = game.Content.Load<Texture2D>("Rock");
        }

        public static void DrawRect(Rectangle rect, Color color, Game1 game, float depth)
        {
            // Draw rect to sprite batch
            game.SpriteBatch.Draw(blankTexture, rect, null, color, 0, new Vector2(0, 0), SpriteEffects.None, depth);
        }

        public static void DrawSprite(Texture2D texture, Rectangle rect, Game1 game, float depth)
        {
            // Draw sprite to sprite batch
            game.SpriteBatch.Draw(texture, rect, null, Color.White, 0, new Vector2(0, 0), SpriteEffects.None, depth);
        }

        public static void DrawTile(Texture2D tileset, int tilesetIndex, Rectangle rect, Game1 game, float depth)
        {
            // Calculate source position
            int tilesetWidth = tileset.Width / TileGrid;
            int tilesetX = tilesetIndex % tilesetWidth;
            int tilesetY = tilesetIndex / tilesetWidth;
            // Calculate source rect
            Rectangle sourceRect = new Rectangle(tilesetX * TileGrid, tilesetY * TileGrid, TileGrid, TileGrid);
            // Draw tile to sprite batch
            game.SpriteBatch.Draw(tileset, rect, sourceRect, Color.White, 0, new Vector2(0, 0), SpriteEffects.None, depth);
        }

        public static void DrawText(string text, Vector2 position, Color color, Game1 game, float depth, bool centered)
        {
            // Modify text position if centering text
            if (centered) position -= arialFont.MeasureString(text) / 2;
            // Draw string to sprite batch
            game.SpriteBatch.DrawString(arialFont, text, position, color, 0, new Vector2(0, 0), 1, SpriteEffects.None, depth);
        }
    }
}
