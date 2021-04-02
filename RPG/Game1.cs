using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RPG.Objects;
using RPG.Scenes;

namespace RPG
{
    public class Game1 : Game
    {
        public GraphicsDeviceManager Graphics { get; private set; }
        public SpriteBatch SpriteBatch { get; private set; }
        public KeyboardState KeyboardState { get; private set; }

        public ObjectManager ObjectManager
        {
            get { return SceneManager.CurrentScene.ObjectManager; }
        }

        //private Texture2D rockTexture;

        public SceneManager SceneManager { get; } = new SceneManager();

        public Game1()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            Drawing.InitializeGraphics(this);

            // Initialize scene manager with menu
            SceneManager.CurrentScene = new Menu();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            //playerTexture = Content.Load<Texture2D>("Computeroid");
            //rockTexture = Content.Load<Texture2D>("Rock");
        }

        protected override void Update(GameTime gameTime)
        {
            // Get keyboard state
            KeyboardState = Keyboard.GetState();
            ProcessKeyboardState(KeyboardState);

            SceneManager.Update(gameTime, this);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // Clear graphics
            GraphicsDevice.Clear(Color.Black);

            SpriteBatch.Begin(SpriteSortMode.BackToFront);

            // Draw current scene
            SceneManager.Draw(this);

            SpriteBatch.End();

            base.Draw(gameTime);
        }

        private void ProcessKeyboardState(KeyboardState state)
        {
            // Exit game
            if (state.IsKeyDown(Keys.Escape)) Exit();

            // Load scene
            if (state.IsKeyDown(Keys.D1)) SceneManager.CurrentScene = new Menu();
            else if (state.IsKeyDown(Keys.D2)) SceneManager.CurrentScene = new Main();
        }
    }
}
