using RPG.Objects;

namespace RPG.Scenes
{
    public class Menu : Scene
    {
        public Menu()
        {
            ObjectManager.Add(new Rock(0, 0));
        }
    }
}
