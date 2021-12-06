using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Seminarium1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D ballTex;
        private Ball ball1;
        private Ball ball2;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            ballTex = Content.Load<Texture2D>("ball");
            
            ball1 = new Ball(ballTex,new Vector2(800,100),new Vector2(1,2), Window.ClientBounds.Height,Window.ClientBounds.Width,50);
            ball2 = new Ball(ballTex, new Vector2(000,100),new Vector2(-1,-1),Window.ClientBounds.Height, Window.ClientBounds.Width,50);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            ball1.Update(gameTime);
            ball2.Update(gameTime);

            if (ball1.HitBox().Intersects(ball2.HitBox()))
            {
                ball1.Direction = -ball1.Direction;
                ball2.Direction = -ball2.Direction;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            ball1.Draw(_spriteBatch);
            ball2.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
