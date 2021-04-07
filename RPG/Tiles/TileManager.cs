namespace RPG.Tiles
{
    public class TileManager
    {
        public Tile[,] Tiles { get; private set; }

        public TileManager() { }

        public void Draw(Game1 game)
        {
            // If no tiles, return
            if (Tiles == null) return;

            // Draw all tiles
            foreach (Tile tile in Tiles)
            {
                tile.Draw(game);
            }
        }

        public void InitTiles(int x, int y) => Tiles = new Tile[x, y]; // Initializes tile array with given dimensions
        public Tile GetTile(int x, int y) => Tiles[x, y]; // Gets tile at position
        public void SetTile(int x, int y, Tile tile) => Tiles[x, y] = tile; // Sets given position to given tile
    }
}
