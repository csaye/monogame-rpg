using Microsoft.Xna.Framework;

namespace RPG.Scenes
{
    public class Transition
    {
        private readonly Rectangle Bounds;
        private readonly Scene Scene;
        private bool sceneLoaded = false;

        public Transition(Rectangle bounds, Scene scene)
        {
            Bounds = bounds;
            Scene = scene;
        }

        public void Update(Game1 game)
        {
            // If scene not already loaded and player within bounds
            if (!sceneLoaded && game.Player.Bounds.Intersects(Bounds))
            {
                // Load scene
                sceneLoaded = true;
                game.LoadScene(Scene);
            }
        }
    }
}
