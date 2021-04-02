using RPG.Objects;

namespace RPG.Scenes
{
    public class Main : Scene
    {
        public Main()
        {
            ObjectManager.Add(new Rock(32 * 2, 32 * 2));
            ObjectManager.Add(new Player(0, 0));
        }
    }
}
