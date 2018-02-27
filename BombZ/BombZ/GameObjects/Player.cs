

namespace TopDownShooter.GameObjects
{
    using Utilities;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using System;
    using Microsoft.Xna.Framework.Content;

    public delegate void ShootSignal();

    public class Player:Entity
    {
        private const int BORDER_OFFSET = 50;

        private const string IDLE_ANIMATION_KEY = "idleAnimation";
        private const string BOMB_ANIMATION_KEY = "bombAnimation";
        private const string MOVE_ANIMATION_KEY = "moveAnimation";

        //public event ShootSignal shootSignal;

        public Player(ContentManager Content, int gameWidth, int gameHeight, double health, double velocity, Vector2 scale)
            :base(Content, gameWidth, gameHeight, health, velocity, scale)
        {
            this.position = new Vector2(gameWidth / 2, gameHeight / 2);
        }

        public void Update(GameTime gameTime, int gameWidth, int gameHeight)
        {
            MouseState mouse = Mouse.GetState();
            KeyboardState keyboard = Keyboard.GetState();
            this.Move(gameWidth,gameHeight, keyboard);
            this.currentAnimationKey = MOVE_ANIMATION_KEY;
            foreach (var pair in this.animations)
            {
                pair.Value.Update(gameTime);
            }

            // Drop Bombs
            KeyboardState keyPressed = Keyboard.GetState();
            if (keyPressed.IsKeyDown(Keys.Space))
            {
                this.currentAnimationKey = BOMB_ANIMATION_KEY;
                    //this.shootSignal.Invoke();
            }
        }

        private void Move(int gameWidth, int gameHeight, KeyboardState keyboard)
        {
            if (keyboard.IsKeyDown(Keys.W))
            {
                this.position.Y -= (float)velocity;
            }
            if (keyboard.IsKeyDown(Keys.S))
            {
                this.position.Y += (float)velocity;
            }
            if (keyboard.IsKeyDown(Keys.A))
            {
                this.position.X -= (float)velocity;
            }
            if (keyboard.IsKeyDown(Keys.D))
            {
                this.position.X += (float)velocity;
            }

            if (this.position.X<=BORDER_OFFSET)
            {
                this.position.X = BORDER_OFFSET;
            }
            if (this.position.X >= gameWidth - BORDER_OFFSET)
            {
                this.position.X = gameWidth - BORDER_OFFSET;
            }
            if (this.position.Y <= BORDER_OFFSET)
            {
                this.position.Y = BORDER_OFFSET;
            }
            if (this.position.Y >= gameHeight - BORDER_OFFSET)
            {
                this.position.Y = gameHeight - BORDER_OFFSET;
            }
        }

        protected override void CreateAnimations(ContentManager Content)
        {
            var idleAnimation = Content.Load<Texture2D>(IDLE_ANIMATION_KEY);
            var moveAnimation = Content.Load<Texture2D>(MOVE_ANIMATION_KEY);
            var bombAnimation = Content.Load<Texture2D>(BOMB_ANIMATION_KEY);

            this.animations.Add(IDLE_ANIMATION_KEY, new Animation(idleAnimation,24,4,6,100,100));
            this.animations.Add(MOVE_ANIMATION_KEY, new Animation(moveAnimation,24,4,6,100,100));
            this.animations.Add(BOMB_ANIMATION_KEY, new Animation(bombAnimation, 3, 1, 3, 312, 206));


        }

        public override void TakeDamage(double damage)
        {
            this.Health -= damage;
            if (this.Health <= 0)
            {
                this.IsAlive = false;
            }
        }
    }
}
