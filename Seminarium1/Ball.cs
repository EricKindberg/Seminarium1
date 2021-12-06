using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seminarium1
{
    public class Ball
    {
        private Vector2 position, direction;
        private Texture2D texture;
        private double elapsed;
        private int _width, _height;
        public Vector2 Direction { get => direction; set=> direction=value; }
        public int Size { private get; set; }
        public float Speed { private get; set; }
        public Ball(Texture2D tex, Vector2 pos, Vector2 direction, int height, int width, int size)
        {
            elapsed = 0;
            texture = tex;
            position = pos;
            this.direction = direction;
            _height = height;
            _width = width;
            Speed = 10;
            Size = size;
        }
        public void Update(GameTime gameTime)
        {
            position += direction * Speed;
            if (position.X >= _width-texture.Width && direction.X>0)
            {
                direction.X = -direction.X;
            }
            else if(position.X<=0 && direction.X < 0)
            {
                direction.X = -direction.X;
            }
            else if(position.Y>=_height-texture.Height && direction.Y > 0)
            {
                direction.Y = -direction.Y;
            }
            else if(position.Y<=0 && direction.Y < 0)
            {
                direction.Y = -direction.Y;
            }

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle((int)position.X, (int)position.Y, Size, Size), Color.White);
        }
        public void SetPosition(Vector2 value)
        {
            position = value;
        }
        public Rectangle HitBox()
        {
            return new Rectangle((int)position.X,(int)position.Y,Size,Size);
        }
    }
}
