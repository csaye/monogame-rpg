using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RPG
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private Vector2 movementDirection = new Vector2(0, 0);
        private Vector2 playerPosition = new Vector2(0, 0);
        private float movementSpeed = 0.1f;

        Texture2D playerTexture;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            playerTexture = Content.Load<Texture2D>("Computeroid");
        }

        protected override void Update(GameTime gameTime)
        {
            ProcessKeyboardState();

            // Update player position
            playerPosition += movementDirection * gameTime.ElapsedGameTime.Milliseconds * movementSpeed;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            // Draw player
            spriteBatch.Draw(playerTexture, playerPosition, Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void ProcessKeyboardState()
        {
            // Get keyboard state
            KeyboardState state = Keyboard.GetState();

            // Exit game
            if (state.IsKeyDown(Keys.Escape)) Exit();

            // Get vertical movement
            if (state.IsKeyDown(Keys.S)) movementDirection.Y = 1;
            else if (state.IsKeyDown(Keys.W)) movementDirection.Y = -1;
            else movementDirection.Y = 0;

            // Get horizontal movement
            if (state.IsKeyDown(Keys.D)) movementDirection.X = 1;
            else if (state.IsKeyDown(Keys.A)) movementDirection.X = -1;
            else movementDirection.X = 0;
        }
    }
}
