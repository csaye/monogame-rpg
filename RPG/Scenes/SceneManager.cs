using Microsoft.Xna.Framework;

namespace RPG.Scenes
{
    public class SceneManager
    {
        public Scene CurrentScene { get; set; }

        public SceneManager() { }

        public void Update(GameTime gameTime, Game1 game) => CurrentScene.Update(gameTime, game); // Update current scene
        public void Draw(Game1 game) => CurrentScene.Draw(game); // Draw current scene
        public void DrawUI(Game1 game) => CurrentScene.DrawUI(game); // Draw current scene UI
    }
}
