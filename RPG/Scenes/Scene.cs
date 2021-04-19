using Microsoft.Xna.Framework;
using RPG.Objects;
using RPG.Tiles;
using RPG.UI;

namespace RPG.Scenes
{
    public abstract class Scene
    {
        public ObjectManager ObjectManager { get; protected set; }
        public TileManager TileManager { get; protected set; }
        public UIManager UIManager { get; protected set; }
        public Camera Camera { get; protected set; }
        public Player Player { get; protected set; }

        // Width and height of scene, used for camera
        public int Width { get; protected set;  }
        public int Height { get; protected set; }

        public Scene() { }

        public virtual void Draw(Game1 game)
        {
            if (ObjectManager != null) TileManager.Draw(game); // Draw tiles
            if (ObjectManager != null) ObjectManager.Draw(game); // Draw objects
        }

        public virtual void DrawUI(Game1 game)
        {
            if (UIManager != null) UIManager.DrawUI(game); // Draw UI
        }

        public virtual void Update(GameTime gameTime, Game1 game)
        {
            if (ObjectManager != null) ObjectManager.Update(gameTime, game); // Update objects
            if (UIManager != null) UIManager.Update(gameTime, game); // Update UI
            if (Camera != null) Camera.Update(gameTime, game); // Update camera
            if (Player != null) Player.Update(gameTime, game); // Update player
        }
    }
}
