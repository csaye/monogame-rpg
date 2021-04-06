using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace RPG.UI
{
    public class Button : UIObject
    {
        private readonly static Color NormalColor = Color.White;
        private readonly static Color HoverColor = Color.Gray;

        private string Text { get; set; }
        private Color Color { get; set; } = NormalColor;
        private Action<Game1> ClickAction { get; set; }

        public Button(float x, float y, float width, float height, string text, Action<Game1> clickAction) : base(x, y, width, height)
        {
            Text = text;
            ClickAction = clickAction;
        }

        public override void Update(GameTime gameTime, Game1 game)
        {
            ProcessMouseState(game);
        }

        public override void Draw(Game1 game)
        {
            Drawing.DrawRect(Bounds, Color, game, SortingLayers.SubUI);
            Drawing.DrawText(Text, position, Color.Black, game, SortingLayers.PostUI);
        }

        private void ProcessMouseState(Game1 game)
        {
            MouseState mouseState = game.MouseState;
            // If mouse hovering
            if (Bounds.Contains(mouseState.Position))
            {
                Color = HoverColor;
                // If left mouse button clicked, invoke click action
                if (game.LeftMouseButtonClick) ClickAction.Invoke(game);
            }
            // If mouse not hovering
            else Color = NormalColor;
        }
    }
}
