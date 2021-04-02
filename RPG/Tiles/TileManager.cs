using System.Collections.Generic;

namespace RPG.Tiles
{
    public class TileManager
    {
        public List<Tile> Tiles { get; set; } = new List<Tile>();

        public TileManager() {}

        public void Draw(Game1 game)
        {
            foreach (Tile tile in Tiles)
            {
                tile.Draw(game);
            }
        }

        public void Add(Tile tile) => Tiles.Add(tile);
    }
}
