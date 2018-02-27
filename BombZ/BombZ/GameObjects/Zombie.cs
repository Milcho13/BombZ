namespace TopDownShooter.GameObjects
{
    using global::TopDownShooter.Utilities;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public delegate void AttackSignal();

    public class Zombie : Entity
    {
        private const string MOVE_ANIMATION_KEY = "zombieMoveAnimation";
        private const string ATTACK_ANIMATION_KEY = "zombieAttackAnimation";
        private const float DEFAULT_ACCELERATION = 0.6f;
        private const int ATTACK_DISTANCE = 20;

        private float maxVelocity;
        private float acceleration;

        public event AttackSignal zombieAttack;

        public Zombie(ContentManager Content, int gameWidth, int gameHeight, double health, double velocity, Vector2 scale, Random rng)
            :base(Content, gameWidth, gameHeight, health, velocity, scale)
        {
            
            this.currentAnimationKey = MOVE_ANIMATION_KEY;
            this.maxVelocity = (float)(rng.NextDouble() * 3 + 5.8);
            this.velocity = maxVelocity;
            this.acceleration = DEFAULT_ACCELERATION;
            this.SpawnZombie(gameWidth, gameHeight, rng);
        }

        public void Update(GameTime gameTime, Vector2 playerPosition)
        {
            this.CheckCollision(gameTime, playerPosition);

            if (this.currentAnimationKey == MOVE_ANIMATION_KEY)
            {
                this.velocity += this.acceleration;
            }

            foreach (var pair in this.animations)
            {
                this.animations[pair.Key].Update(gameTime);
            }
            if (this.velocity>this.maxVelocity)
            {
                this.velocity = maxVelocity;
            }
        }

        private void CheckCollision(GameTime gameTime, Vector2 playerPosition)
        {
            
        }


        private void SpawnZombie(int gameWidth, int gameHeight, Random rng)
        {

        }

        public override void TakeDamage(double damage)
        {
            
        }

        protected override void CreateAnimations(ContentManager Content)
        {
            var moveAnimation = Content.Load<Texture2D>(MOVE_ANIMATION_KEY);
            var attackAnimation = Content.Load<Texture2D>(ATTACK_ANIMATION_KEY);

            this.animations.Add(MOVE_ANIMATION_KEY, new Animation(moveAnimation, 17,6,3,288,314));
            this.animations.Add(ATTACK_ANIMATION_KEY, new Animation(attackAnimation, 9, 3, 3, 294, 318));
        }
    }
}
