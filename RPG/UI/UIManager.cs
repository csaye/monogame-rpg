using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace RPG.UI
{
    public class UIManager
    {
        public List<UIObject> uiObjects = new List<UIObject>();

        public void Add(UIObject obj) => uiObjects.Add(obj); // Adds UI object to list

        public void DrawUI(Game1 game)
        {
            // Draw all UI objects
            foreach (UIObject obj in uiObjects) obj.Draw(game);
        }

        public void Update(GameTime gameTime, Game1 game)
        {
            // Update all UI objects
            foreach (UIObject obj in uiObjects) obj.Update(gameTime, game);
        }
    }
}
