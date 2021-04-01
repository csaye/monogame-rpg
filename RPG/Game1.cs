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
        public KeyboardState KeyboardState { get; private set; }

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

            objectManager.Add(new Player(0, 0));
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
            // Get keyboard state
            KeyboardState = Keyboard.GetState();

            // Update objects
            objectManager.Update(gameTime, this);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            SpriteBatch.Begin(SpriteSortMode.BackToFront);

            // Draw objects
            objectManager.Draw(this);

            SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
