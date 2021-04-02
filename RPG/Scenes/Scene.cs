using Microsoft.Xna.Framework;
using RPG.Objects;
using RPG.Tiles;

namespace RPG.Scenes
{
    public abstract class Scene
    {
        public ObjectManager ObjectManager { get; } = new ObjectManager();
        public TileManager TileManager { get; } = new TileManager();

        public Scene() {}

        public virtual void Draw(Game1 game)
        {
            // Draw tiles
            TileManager.Draw(game);

            // Draw objects
            ObjectManager.Draw(game);
        }

        public virtual void Update(GameTime gameTime, Game1 game)
        {
            // Update objects
            ObjectManager.Update(gameTime, game);
        }
    }
}
