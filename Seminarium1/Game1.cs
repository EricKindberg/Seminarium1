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
        private SpriteFont font;
        private float tid;

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
            font = Content.Load<SpriteFont>("File");
            ball1 = new Ball(ballTex, new Vector2(800, 100), new Vector2(1, 2), Window.ClientBounds.Height, Window.ClientBounds.Width, 50, Color.White);
            ball2 = new Ball(ballTex, new Vector2(000, 100), new Vector2(-1, -1), Window.ClientBounds.Height, Window.ClientBounds.Width, 50, Color.Blue);
            tid = 0;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            tid += (float)gameTime.ElapsedGameTime.TotalSeconds;

            ball1.Update(gameTime);
            ball2.Update(gameTime);

            if (ball1.HitBox().Intersects(ball2.HitBox()))
            {
                if (ball1.Position.Y < ball2.Position.Y + ball1.Size/2 || ball2.Position.Y < ball1.Position.Y + ball1.Size/2)
                {
                    float f = ball1.DirectionX;
                    ball1.DirectionX = ball2.Direction.X;
                    ball2.DirectionX = f;

                }
                if (ball1.Position.X < ball2.Position.X + ball1.Size/2 || ball2.Position.X < ball1.Position.X + ball1.Size/2)
                {
                    float g = ball1.DirectionY;
                    ball1.DirectionY = ball2.DirectionY;
                    ball2.DirectionY = g;

                }

                /*ball1.Direction = -ball1.Direction;
                ball2.Direction = -ball2.Direction;*/
                System.Diagnostics.Debug.WriteLine((int)ball1.Time);
                ball1.Time = 0;
                ball2.Time = 0;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            ball1.Draw(_spriteBatch);
            ball2.Draw(_spriteBatch);
            _spriteBatch.DrawString(font, "Tid:" + (int)tid, new Vector2(50, 10), Color.Green);
            _spriteBatch.DrawString(font, "1:" + ball1.Direction, new Vector2(120, 10), Color.Red);
            _spriteBatch.DrawString(font, "2:" + ball2.Direction, new Vector2(120, 50), Color.Red);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
