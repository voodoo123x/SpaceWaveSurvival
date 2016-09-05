using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;

namespace SpaceShipScroller
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        public static int WindowWidth = 500;
        public static int WindowHeight = 698;
        private static Game1 gameController;

        private GraphicsDeviceManager m_Graphics;
        private SpriteBatch m_SpriteBatch;
        private Texture2D m_SpaceBackground;
        private SpriteFont m_ScreenFont;
        private int m_Score;
        private PlayerSprite m_PlayerSprite;
        private List<IEnemySprite> m_EnemySprites;
        private List<IProjectileSprite> m_ProjectileSprites;
        private List<IExplosionSprite> m_ExplosionSprites;
        private IGameLevel m_CurrentLevel;

        public static Game1 Instance
        {
            get
            {
                if (gameController == null)
                {
                    gameController = new Game1();
                }

                return gameController;
            }
        }

        public List<IEnemySprite> EnemySprites
        {
            get { return m_EnemySprites; }
        }

        public List<IProjectileSprite> ProjectileSprites
        {
            get { return m_ProjectileSprites; }
        }

        public List<IExplosionSprite> ExplosionSprites
        {
            get { return m_ExplosionSprites; }
        }

        public int Score
        {
            get { return m_Score; }

            set
            {
                if (value != m_Score)
                {
                    m_Score = value;
                }
            }
        }

        public Game1()
        {
            gameController = this;
            m_Graphics = new GraphicsDeviceManager(this);
            m_Graphics.PreferredBackBufferHeight = WindowHeight;
            m_Graphics.PreferredBackBufferWidth = WindowWidth;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            m_Score = 0;
            m_EnemySprites = new List<IEnemySprite>();
            m_ProjectileSprites = new List<IProjectileSprite>();
            m_ExplosionSprites = new List<IExplosionSprite>();

            m_CurrentLevel = new LevelSandbox();
            
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            m_SpriteBatch = new SpriteBatch(GraphicsDevice);

            //TODO: use this.Content to load your game content here 
            m_SpaceBackground = Content.Load<Texture2D>("space");
            m_ScreenFont = Content.Load<SpriteFont>("Score");
            StandardLaserSprite.Texture = Content.Load<Texture2D>("beams");
            EnemyDroneSprite.Texture = Content.Load<Texture2D>("EnemyShips");
            ExplosionSprite.Texture = Content.Load<Texture2D>("explosion");

            m_PlayerSprite = new PlayerSprite(Content.Load<Texture2D>("PlayerSpaceShip"));
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // For Mobile devices, this logic will close the Game when the Back button is pressed
            // Exit() is obsolete on iOS
            #if !__IOS__ &&  !__TVOS__
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            #endif
            
            // TODO: Add your update logic here
            m_CurrentLevel.Update(gameTime);
            m_PlayerSprite.Update(Keyboard.GetState().GetPressedKeys(), gameTime);

            foreach (var projectile in ProjectileSprites.ToArray())
            {
                projectile.Update();
            }

            foreach (var enemy in EnemySprites)
            {
                enemy.Update();
            }

            foreach (var explosion in ExplosionSprites.ToArray())
            {
                explosion.Update();
            }
            
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            m_Graphics.GraphicsDevice.Clear(Color.Black);
            
            //TODO: Add your drawing code here
            m_SpriteBatch.Begin();

            m_SpriteBatch.Draw(m_SpaceBackground, new Vector2(0, 0));
            m_SpriteBatch.DrawString(m_ScreenFont, string.Format("Score: {0}", m_Score), new Vector2(10,10), Color.White);

            m_PlayerSprite.Draw(m_SpriteBatch);

            foreach (var projectile in ProjectileSprites)
            {
                projectile.Draw(m_SpriteBatch);
            }

            foreach (var enemy in EnemySprites)
            {
                enemy.Draw(m_SpriteBatch);
            }

            foreach (var explosion in ExplosionSprites)
            {
                explosion.Draw(m_SpriteBatch);
            }

            m_SpriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}

