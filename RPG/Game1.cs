using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RPG.Objects;
using RPG.Scenes;
using RPG.Tiles;
using RPG.UI;

namespace RPG
{
    public class Game1 : Game
    {
        // MonoGame objects
        public GraphicsDeviceManager Graphics { get; private set; }
        public SpriteBatch SpriteBatch { get; private set; }
        public KeyboardState KeyboardState { get; private set; }
        public KeyboardState LastKeyboardState { get; private set; }
        public MouseState MouseState { get; private set; }
        public MouseState LastMouseState { get; private set; }
        public bool LeftMouseButtonClick { get; private set; }

        // RPG objects
        public SceneManager SceneManager { get; } = new SceneManager();

        // Getters
        public Scene CurrentScene => SceneManager.CurrentScene;
        public ObjectManager ObjectManager => CurrentScene.ObjectManager;
        public TileManager TileManager => CurrentScene.TileManager;
        public UIManager UIManager => CurrentScene.UIManager;
        public Camera Camera => CurrentScene.Camera;
        public Player Player => CurrentScene.Player;

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

            // Load content
            Drawing.LoadContent(this);
        }

        protected override void Update(GameTime gameTime)
        {
            // Process keyboard state
            LastKeyboardState = KeyboardState;
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

            // Object sprite batch
            Matrix? transform = Camera?.Transform;
            SpriteBatch.Begin(SpriteSortMode. BackToFront,null, SamplerState.PointClamp, transformMatrix: transform);
            SceneManager.Draw(this);
            SpriteBatch.End();

            // UI sprite batch
            SpriteBatch.Begin(SpriteSortMode.BackToFront, null, SamplerState.PointClamp);
            SceneManager.DrawUI(this);
            SpriteBatch.End();

            base.Draw(gameTime);
        }

        // Switches current scene to given scene
        public void LoadScene(Scene scene)
        {
            SceneManager.CurrentScene = scene;
        }

        // Returns whether given key is down
        public bool KeyDown(Keys key) => KeyboardState.IsKeyDown(key);

        // Returns whether given key was pressed
        public bool KeyPressed(Keys key) => LastKeyboardState.IsKeyDown(key) && !KeyboardState.IsKeyDown(key);

        private void ProcessKeyboardState()
        {
            // Exit game
            if (KeyDown(Keys.Escape)) Exit();

            // Toggle fullscreen
            if (KeyPressed(Keys.F)) Graphics.ToggleFullScreen();
        }

        private void ProcessMouseState()
        {
            // Left mouse button clicked if released this frame and pressed last frame
            LeftMouseButtonClick = MouseState.LeftButton == ButtonState.Released && LastMouseState.LeftButton == ButtonState.Pressed;
        }
    }
}
