using Microsoft.Xna.Framework;

namespace RPG.Scenes
{
    public class SceneManager
    {
        public Scene CurrentScene { get; set; }

        public SceneManager() {}

        public void Update(GameTime gameTime, Game1 game)
        {
            CurrentScene.Update(gameTime, game);
        }

        public void Draw(Game1 game1)
        {
            CurrentScene.Draw(game1);
        }
    }
}
