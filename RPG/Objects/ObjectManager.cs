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

        // Returns whether bounds is obstructed
        public bool BoundsObstructed(GameObject movingObj, Rectangle bounds)
        {
            foreach (GameObject obj in gameObjects)
            {
                // Skip self
                if (movingObj == obj) continue;

                // Return true if bounds intersects object bounds
                if (bounds.Intersects(obj.Bounds)) return true;
            }

            // If no objects intersect, return false
            return false;
        }
    }
}
