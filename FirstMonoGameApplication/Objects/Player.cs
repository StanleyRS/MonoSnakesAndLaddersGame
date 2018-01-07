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
using FirstMonoGameApplication.BoardMap;
using FirstMonoGameApplication.Objects;

namespace FirstMonoGameApplication.Objects
{
    public class Player
    {
        private Texture2D Sprite;
        public Rectangle Rectangle;
        private Vector2 Position;
        private int Pick;
        //Levels level;
        int count = 1;

        SpriteFont font;

        private GraphicsDevice graphics;

       // List<Levels> levels = new List<Levels>();

        // List<Rectangle> Rectangles = new List<Rectangle>();

        int playerSteps = 64;

        public Player(Texture2D sprite, Rectangle rect, Vector2 position, int pick, GraphicsDevice g, ContentManager content)
        {
            Sprite = sprite;
            Rectangle = rect;
            Position = position;
            Pick = pick;
            graphics = g;
            font = content.Load<SpriteFont>("testFont");
            //level = new Levels(g);
            //spriteb = new SpriteBatch(graphics);
            //level.LoadContent(content);

        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(Sprite, Rectangle, Color.White);

            sb.DrawString(font, "LEVEL " + count, new Vector2(660, 720), Color.Blue);
            //level.Draw(sb);
        }

        public Vector2 PlayerMove(int pick, Player player)
        {
            // before moving the player, check if its rectangle.x is lower than border width (600px)
            // on each player roll draw six rectangles from players current position and for each next possible move of the player
            // eg. check players possible moves on every position

            //if rectangle.x < 600
            // rectangle
            //if (Rectangle.X <= 630)
            //{



            if (Rectangle.X + (playerSteps * pick) < 630)
            {
                Rectangle.X += playerSteps * pick;
            }
            else
            {
                //move up
                Rectangle.Y -= 78;

                // get the distance from the current player position
                // that is left till border width
                // 
                int distanceLeft = (int)Rectangle.X - 630;

                //Rectangle.X = 10;

                //Rectangle.X += playerSteps * pick;
                //Rectangle.X = 34 * pick;

                count++;
            }
           // }

            Position.X = Rectangle.X;
            Position.Y = Rectangle.Y;

            //level.LevelHandle(player, count);

            // check collision with tiles
            // update position
            // return to Game1.cs

            return Position;
        }
    }
}
