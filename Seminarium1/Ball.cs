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
        private int _width, _height;
        private Color color1;
        public float Time { set; get; }
        public Vector2 Position { get => position; }
        public float DirectionX { get => direction.X; set=> direction.X=value; }
        public float DirectionY { get => direction.Y; set => direction.Y = value; }
        public Vector2 Direction { get => direction; set=> direction=value; }
        public int Size { get; set; }
        public float Speed { private get; set; }
        public Ball(Texture2D tex, Vector2 pos, Vector2 direction, int height, int width, int size, Color color)
        {
            texture = tex;
            position = pos;
            this.direction = direction;
            _height = height;
            _width = width;
            Speed = 5;
            Size = size;
            Time = 0;
            color1 = color;
        }
        public void Update(GameTime gameTime)
        {
            position += direction * Speed;
            Time += (float)gameTime.ElapsedGameTime.TotalSeconds;
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
            spriteBatch.Draw(texture, new Rectangle((int)position.X, (int)position.Y, Size, Size), color1);
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
