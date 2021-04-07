using RPG.UI;

namespace RPG.Scenes
{
    public class Menu : Scene
    {
        public Menu()
        {
            // Initialize UI
            Button loadButton = new Button(Drawing.Width / 2, Drawing.Height / 2, 128, 32, "Click to start", LoadMain);
            UIManager.Add(loadButton);
            Button quitButton = new Button(Drawing.Grid / 2, Drawing.Grid / 2, Drawing.Grid / 2, Drawing.Grid / 2, "X", QuitGame);
            UIManager.Add(quitButton);
        }

        private void LoadMain(Game1 game)
        {
            // Load main scene
            game.SceneManager.CurrentScene = new Main();
        }

        private void QuitGame(Game1 game) => game.Exit();
    }
}
