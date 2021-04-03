using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace RPG.Objects
{
    public class ObjectManager
    {
        public List<GameObject> DynamicObjects { get; private set; } = new List<GameObject>();
        public GameObject[,] StaticObjects { get; private set; }

        public ObjectManager() {}

        public void Draw(Game1 game)
        {
            // Draw all objects
            if (StaticObjects != null)
            {
                foreach (GameObject obj in StaticObjects)
                {
                    // Draw if not null
                    if (obj != null) obj.Draw(game);
                }
            }
            foreach (GameObject obj in DynamicObjects) obj.Draw(game);
        }

        public void Update(GameTime gameTime, Game1 game)
        {
            // Update all dynamic objects
            foreach (GameObject obj in DynamicObjects) obj.Update(gameTime, game);
        }

        public void AddDynamic(GameObject obj) => DynamicObjects.Add(obj);

        public void InitStatic(int x, int y) => StaticObjects = new GameObject[x, y]; // Initializes object array with given dimensions
        public GameObject GetStatic(int x, int y) => StaticObjects[x, y]; // Gets object at position
        public void SetStatic(int x, int y, GameObject obj) => StaticObjects[x, y] = obj; // Sets given position to given object

        // Returns calculated position for object attempting to move
        public Vector2 TryMove(GameObject movingObj, Vector2 movementFactor)
        {
            // Get position
            Vector2 position = movingObj.Position + movementFactor;
            // Get new bounds
            Rectangle newBounds = movingObj.Bounds;
            newBounds.X += (int)movementFactor.X;
            newBounds.Y += (int)movementFactor.Y;

            // For each adjacent static object within bounds
            int leftX = newBounds.Left / Drawing.Grid;
            int rightX = newBounds.Right / Drawing.Grid;
            int topY = newBounds.Top / Drawing.Grid;
            int bottomY = newBounds.Bottom / Drawing.Grid;
            for (int x = leftX; x <= rightX; x++)
            {
                for (int y = topY; y <= bottomY; y++)
                {
                    // Get static object and skip if null
                    GameObject obj = StaticObjects[x, y];
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
            foreach (GameObject obj in DynamicObjects)
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
