using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopDownShooter.Utilities;

namespace TopDownShooter.GameObjects
{
    public class BombAnimation
    {
        private const int BOMB_SHOWN_TIMER = 100;
        private Animation animation;
        public bool IsAlive { get; set; }
        private double spawnTimer;
        private Vector2 position;


        public BombAnimation(ContentManager Content, Vector2 position)
        {
            var animationTexture = Content.Load<Texture2D>("bombAnimation");
            this.animation = new Animation(animationTexture, 16, 4, 4, 128, 128);
            this.IsAlive = true;
            this.spawnTimer = 0;
            this.position = position;
        }

        public void Update(GameTime gameTime)
        {
            this.spawnTimer += gameTime.ElapsedGameTime.Milliseconds;
            if (this.spawnTimer >= BOMB_SHOWN_TIMER)
            {
                this.IsAlive = false;
            }

            this.animation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.animation.Draw(spriteBatch, 0, this.position, new Vector2(0.8f, 0.8f));
        }

    }
}
