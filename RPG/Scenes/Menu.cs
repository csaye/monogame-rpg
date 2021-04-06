using RPG.UI;

namespace RPG.Scenes
{
    public class Menu : Scene
    {
        public Menu()
        {
            // Initialize UI
            UIManager.Add(new Button((Drawing.Width / 2) - 64, (Drawing.Height / 2) - 16, 128, 32, "Click to start", LoadMain));
        }

        private void LoadMain(Game1 game)
        {
            // Load main scene
            game.SceneManager.CurrentScene = new Main();
        }
    }
}
