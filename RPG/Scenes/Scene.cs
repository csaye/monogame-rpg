using Microsoft.Xna.Framework;
using RPG.Objects;
using RPG.Tiles;
using RPG.UI;

namespace RPG.Scenes
{
    public abstract class Scene
    {
        public ObjectManager ObjectManager { get; } = new ObjectManager();
        public TileManager TileManager { get; } = new TileManager();
        public UIManager UIManager { get; } = new UIManager();
        public Camera Camera { get; protected set; }

        // Width and height of scene, used for camera
        public int Width { get; protected set;  }
        public int Height { get; protected set; }

        public Scene() { }

        public virtual void Draw(Game1 game)
        {
            TileManager.Draw(game); // Draw tiles
            ObjectManager.Draw(game); // Draw objects
        }

        public virtual void DrawUI(Game1 game)
        {
            UIManager.Draw(game); // Draw UI
        }

        public virtual void Update(GameTime gameTime, Game1 game)
        {
            ObjectManager.Update(gameTime, game); // Update objects
            UIManager.Update(gameTime, game); // Update UI

            if (Camera != null) Camera.Update(gameTime, game); // Update camera
        }
    }
}
