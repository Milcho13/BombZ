

namespace BombZ
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using System;
    using System.Collections.Generic;
    using TopDownShooter.GameObjects;

    public class BombZ : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private const int GAME_WIDTH = 1600;
        private const int GAME_HEGHT = 1200;

        private Texture2D background;

        // Game objects we need
        private Player player;
        private List<Zombie> zombies;
        private List<BombAnimation> bombAnimation;

        private Random rng;
        private Cursor cursor;
        private int pointsScored;

        public BombZ()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = GAME_WIDTH;
            graphics.PreferredBackBufferHeight = GAME_HEGHT;
            graphics.ApplyChanges();

            this.cursor = new Cursor(Content);
            this.player = new Player(Content, GAME_WIDTH, GAME_HEGHT, 1, 1, new Vector2(0.45f, 0.45f));

            base.Initialize();
        }

        protected override void LoadContent()
        {
            this.background = Content.Load<Texture2D>("background");
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {
            
        }
        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            this.cursor.Update();
            this.player.Update(gameTime, GAME_WIDTH, GAME_HEGHT);
            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(this.background, Vector2.Zero);
            this.cursor.Draw(spriteBatch);
            this.player.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
