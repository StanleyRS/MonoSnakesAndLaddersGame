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
        private Rectangle Rectangle;
        private Vector2 startPosition;
        private int Pick;
    
        int playerSteps = 30;

        public Player(Texture2D sprite, Rectangle rect, Vector2 position, int pick)
        {
            Sprite = sprite;
            Rectangle = rect;
            startPosition = position;
            Pick = pick;

        }

        public void Update()
        {
            PlayerMove(Pick, startPosition);
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(Sprite, Rectangle, Color.White);
        }

        public Vector2 PlayerMove(int pick, Vector2 updatedPosition)
        {
            //Rectangle = new Rectangle((int)startPosition.X, (int)startPosition.Y, Sprite.Width, Sprite.Height);
            Rectangle = new Rectangle((int)updatedPosition.X, (int)updatedPosition.Y, Sprite.Width, Sprite.Height);

            Rectangle.X += playerSteps * pick;

            return updatedPosition;

        }
    }
}
