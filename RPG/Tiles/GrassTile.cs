namespace RPG.Tiles
{
    public class GrassTile : Tile
    {
        public GrassTile(int x, int y) : base(x, y) {}

        public override void Draw(Game1 game)
        {
            Drawing.DrawSprite(Textures.GrassTexture, Bounds, game, SortingLayers.Tiles);
        }
    }
}
