using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace RPG.Objects
{
    public class ObjectManager
    {
        public List<DynamicObject> dynamicObjects = new List<DynamicObject>();
        public GameObject[,] staticObjects;

        public ObjectManager() { }

        public void Draw(Game1 game)
        {
            // Draw all objects
            if (staticObjects != null)
            {
                foreach (GameObject obj in staticObjects)
                {
                    // Draw if not null
                    if (obj != null) obj.Draw(game);
                }
            }
            foreach (GameObject obj in dynamicObjects) obj.Draw(game);
        }

        public void Update(GameTime gameTime, Game1 game)
        {
            // Update all dynamic objects
            foreach (DynamicObject obj in dynamicObjects) obj.Update(gameTime, game);
        }

        public void AddDynamic(DynamicObject obj) => dynamicObjects.Add(obj); // Adds dynamic object to list

        public void InitStatic(int x, int y) => staticObjects = new GameObject[x, y]; // Initializes object array with given dimensions
        public GameObject GetStatic(int x, int y) => staticObjects[x, y]; // Gets object at position
        public void AddStatic(GameObject obj)
        {
            // Get object grid position
            int x = (int)(obj.position.X / Drawing.Grid);
            int y = (int)(obj.position.Y / Drawing.Grid);
            // Set grid position to object
            staticObjects[x, y] = obj;
        }

        // Returns calculated position for object attempting to move
        public Vector2 TryMove(GameObject movingObj, Vector2 movementFactor)
        {
            // Get position
            Vector2 position = movingObj.position + movementFactor;
            // Get new bounds
            Rectangle newBounds = movingObj.Bounds;
            newBounds.X += (int)movementFactor.X;
            newBounds.Y += (int)movementFactor.Y;

            // For each adjacent static object within bounds
            int leftX = Math.Clamp(newBounds.Left / Drawing.Grid, 0, staticObjects.GetLength(0) - 1);
            int rightX = Math.Clamp(newBounds.Right / Drawing.Grid, 0, staticObjects.GetLength(0) - 1);
            int topY = Math.Clamp(newBounds.Top / Drawing.Grid, 0, staticObjects.GetLength(1) - 1);
            int bottomY = Math.Clamp(newBounds.Bottom / Drawing.Grid, 0, staticObjects.GetLength(1) - 1);
            for (int x = leftX; x <= rightX; x++)
            {
                for (int y = topY; y <= bottomY; y++)
                {
                    // Get static object and skip if null
                    GameObject obj = staticObjects[x, y];
                    if (obj == null) continue;

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
                            if (newCenter.X > objCenter.X) position.X = newBounds.X = objBounds.Right;
                            // If left of object
                            else position.X = newBounds.X = objBounds.Left - newBounds.Width;
                        }
                        // If greater vertical displacement
                        else
                        {
                            // If above object
                            if (newCenter.Y > objCenter.Y) position.Y = newBounds.Y = objBounds.Bottom;
                            // If below object
                            else position.Y = newBounds.Y = objBounds.Top - newBounds.Height;
                        }
                    }
                }
            }

            // For each dynamic object
            foreach (GameObject obj in dynamicObjects)
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
                        if (newCenter.X > objCenter.X) position.X = newBounds.X = objBounds.Right;
                        // If left of object
                        else position.X = newBounds.X = objBounds.Left - newBounds.Width;
                    }
                    // If greater vertical displacement
                    else
                    {
                        // If above object
                        if (newCenter.Y > objCenter.Y) position.Y = newBounds.Y = objBounds.Bottom;
                        // If below object
                        else position.Y = newBounds.Y = objBounds.Top - newBounds.Height;
                    }
                }
            }

            // Return new position
            return position;
        }
    }
}
