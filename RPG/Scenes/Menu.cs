using Microsoft.Xna.Framework;

namespace RPG.Scenes
{
    public class Menu : Scene
    {
        public Menu() {}

        public override void Draw(Game1 game)
        {
            Drawing.DrawText("Press 2 to start", new Vector2(0, 0), Color.White, game, SortingLayers.Text);

            base.Draw(game);
        }
    }
}
