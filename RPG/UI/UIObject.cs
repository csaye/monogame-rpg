using Microsoft.Xna.Framework;

namespace RPG.UI
{
    public abstract class UIObject : Object
    {
        public Vector2 centerPosition;

        // Center position
        public UIObject(float centerX, float centerY, float width, float height)
            : base(centerX - (width / 2), centerY - (height / 2), width, height)
        {
            centerPosition = new Vector2(centerX, centerY);
        }
    }
}
