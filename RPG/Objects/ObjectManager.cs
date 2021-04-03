using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace RPG.Objects
{
    public class ObjectManager
    {
        private List<GameObject> gameObjects = new List<GameObject>();

        public ObjectManager() {}

        public void Draw(Game1 game)
        {
            // Draw all objects
            foreach (GameObject obj in gameObjects)
            {
                obj.Draw(game);
            }
        }

        public void Update(GameTime gameTime, Game1 game)
        {
            // Update all objects
            foreach (GameObject obj in gameObjects)
            {
                obj.Update(gameTime, game);
            }
        }

        public void Add(GameObject obj) => gameObjects.Add(obj); // Adds given object to objects list

        // Returns calculated position for object attempting to move
        public Vector2 TryMove(GameObject movingObj, Vector2 movementFactor)
        {
            // Get new bounds
            Rectangle newBounds = movingObj.Bounds;
            newBounds.X += (int)Math.Round(movementFactor.X);
            newBounds.Y += (int)Math.Round(movementFactor.Y);

            // For each object
            foreach (GameObject obj in gameObjects)
            {
                // Skip self
                if (movingObj == obj) continue;

                // If new bounds intersects, adjust bounds
                Rectangle objBounds = obj.Bounds;
                if (newBounds.Intersects(objBounds))
                {
                    Point newCenter = newBounds.Center;
                    Point objCenter = objBounds.Center;

                    // If greater horizontal displacement
                    if (Math.Abs(newCenter.X - objCenter.X) > Math.Abs(newCenter.Y - objCenter.Y))
                    {
                        // If right of object
                        if (newCenter.X > objCenter.X) newBounds.X = objBounds.Right;
                        // If left of object
                        else newBounds.X = objBounds.Left - newBounds.Width;
                    }
                    // If greater vertical displacement
                    else
                    {
                        // If above object
                        if (newCenter.Y > objCenter.Y) newBounds.Y = objBounds.Bottom;
                        // If below object
                        else newBounds.Y = objBounds.Top - newBounds.Height;
                    }
                }
            }

            // Return new bounds position
            return new Vector2(newBounds.X, newBounds.Y);
        }
    }
}
