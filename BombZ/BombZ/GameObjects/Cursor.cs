

namespace TopDownShooter.GameObjects
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;


    public class Cursor
    {
        private Texture2D cursorTexture;
        private Vector2 position;
        private Vector2 scale;

        public Vector2 Position
        {
            get
            {
                return this.position;
            }
        }

        public Cursor(ContentManager Content)
        {
            this.cursorTexture = Content.Load<Texture2D>("cursor");
            this.scale = new Vector2(0.05f, 0.05f);
        }
        public void Update()
        {
            // Follow mouse
            MouseState mouse = Mouse.GetState();
            this.position.X = mouse.X - this.cursorTexture.Width / 2 * this.scale.X ;
            this.position.Y = mouse.Y - this.cursorTexture.Height/2 * this.scale.Y; 
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(this.cursorTexture, this.position, scale: this.scale);
        }
    }
}
