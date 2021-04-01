using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RPG.Objects;

namespace RPG
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        public SpriteBatch SpriteBatch { get; private set; }

        private Vector2 movementDirection = new Vector2(0, 0);
        private Vector2 playerPosition = new Vector2(0, 0);
        private float movementSpeed = 0.1f;

        //private Texture2D playerTexture;
        private Texture2D rockTexture;

        private const int Grid = 32;
        private const int Width = 16;
        private const int Height = 16;

        ObjectManager objectManager = new ObjectManager();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = Grid * Width;
            graphics.PreferredBackBufferHeight = Grid * Height;
            graphics.ApplyChanges();

            objectManager.Add(new Rock(Grid * 4, Grid * 4));
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            //playerTexture = Content.Load<Texture2D>("Computeroid");
            rockTexture = Content.Load<Texture2D>("Rock");
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

            SpriteBatch.Begin();

            // Draw player
            //SpriteBatch.Draw(playerTexture, playerPosition, Color.White);

            // Draw objects
            objectManager.Draw(this);

            SpriteBatch.End();

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

            // Normalize movement direction
            if (movementDirection.Length() > 1) movementDirection.Normalize();
        }
    }
}
