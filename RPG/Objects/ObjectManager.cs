using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace RPG.Objects
{
    public class ObjectManager
    {
        private List<GameObject> gameObjects = new List<GameObject>();

        public ObjectManager() {}

        public void Draw(Game1 game)
        {
            foreach (GameObject obj in gameObjects)
            {
                obj.Draw(game);
            }
        }

        public void Update(GameTime gameTime, Game1 game)
        {
            foreach (GameObject obj in gameObjects)
            {
                obj.Update(gameTime, game);
            }
        }

        public void Add(GameObject obj)
        {
            gameObjects.Add(obj);
        }
    }
}
