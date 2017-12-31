using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Design;
using Microsoft.Xna.Framework.Media;

namespace FirstMonoGameApplication.Objects
{
    public class Player
    {
        private Texture2D Sprite;
        public Rectangle Rectangle;
        private Vector2 Position;
        private int Pick;
    
        int playerSteps = 64;

        public Player(Texture2D sprite, Rectangle rect, Vector2 position, int pick)
        {
            Sprite = sprite;
            Rectangle = rect;
            Position = position;
            Pick = pick;
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(Sprite, Rectangle, Color.White);
        }

        public Vector2 PlayerMove(int pick)
        {

            if (Rectangle.X <= 560)
            {
                Rectangle.X += (playerSteps * pick);
            }
            else
            {
                Rectangle.Y -= 50;
            }

            Position.X = Rectangle.X;
            Position.Y = Rectangle.Y;
            
            // check collision with tiles



            return Position;

        }
    }
}
