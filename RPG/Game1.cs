using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RPG.Objects;
using RPG.Scenes;

namespace RPG
{
    public class Game1 : Game
    {
        // MonoGame objects
        public GraphicsDeviceManager Graphics { get; private set; }
        public SpriteBatch SpriteBatch { get; private set; }
        public KeyboardState KeyboardState { get; private set; }
        public MouseState MouseState { get; private set; }
        public MouseState LastMouseState { get; private set; }
        public bool LeftMouseButtonClick { get; private set; }

        // RPG objects
        public SceneManager SceneManager { get; } = new SceneManager();

        // Getters
        public ObjectManager ObjectManager
        {
            get { return SceneManager.CurrentScene.ObjectManager; }
        }

        public Game1()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // Initialize graphics
            Drawing.InitializeGraphics(this);

            // Initialize scene manager with menu
            SceneManager.CurrentScene = new Menu();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Initialize sprite batch
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            // Load textures
            Textures.LoadTextures(this);
        }

        protected override void Update(GameTime gameTime)
        {
            // Process keyboard state
            KeyboardState = Keyboard.GetState();
            ProcessKeyboardState();

            // Process mouse state
            LastMouseState = MouseState;
            MouseState = Mouse.GetState();
            ProcessMouseState();

            // Update scene
            SceneManager.Update(gameTime, this);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // Clear graphics
            GraphicsDevice.Clear(Color.Black);

            // Start sprite batch
            SpriteBatch.Begin(
                SpriteSortMode.BackToFront,
                null,
                SamplerState.PointClamp,
                transformMatrix: SceneManager.CurrentScene.Camera?.Transform
            );

            // Draw scene
            SceneManager.Draw(this);

            // End sprite batch
            SpriteBatch.End();

            base.Draw(gameTime);
        }

        private void ProcessKeyboardState()
        {
            // Exit game
            if (KeyboardState.IsKeyDown(Keys.Escape)) Exit();
        }

        private void ProcessMouseState()
        {
            // Left mouse button clicked if released this frame and pressed last frame
            LeftMouseButtonClick = MouseState.LeftButton == ButtonState.Released && LastMouseState.LeftButton == ButtonState.Pressed;
        }
    }
}
