using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstMonoGameApplication.BoardMap
{
    public class BoardTileMap
    {
        Texture2D pixel;
        GraphicsDevice graphicsDevice;

        //array for each rectangle
        //Rectangle[] Tiles = new Rectangle[9];
        List<Rectangle> Rectangles = new List<Rectangle>();

        int BorderWidth = 3;

        public BoardTileMap(GraphicsDevice device)
        {
            graphicsDevice = device;
        }

        public void LoadContent()
        {
            pixel = new Texture2D(graphicsDevice, width: 1, height: 1);
            pixel.SetData(new[] { Color.White });
        }

        public void Draw(SpriteBatch sb)
        {
            //  perfect match of board   -    96%           
            //  Rectangle rectangle = new Rectangle((int)(60 + (x * 64)), 0, 3, 765);
            //  Rectangle rectangle = new Rectangle(0, (int)(80 + (y * 76)), 640, 3);

            for (float x = 0; x < 10; x++)
            {
                Rectangle rectangle = new Rectangle((int)(60 + (x * 64)), 0, BorderWidth, 765);
                sb.Draw(pixel, rectangle, Color.Black);
                Rectangles.Add(rectangle);
            }
            for (float y = 0; y < 9; y++)
            {
                Rectangle rectangle = new Rectangle(0, (int)(80 + (y * 76)), 640, BorderWidth);
                sb.Draw(pixel, rectangle, Color.Black);
                Rectangles.Add(rectangle);
            }


            //check if object makes a intersection with tiles[i]*/
        }


        public Rectangle CheckCollision(Rectangle playerPos)
        {

            for (int i = 0; i < Rectangles.Count; i++)
            {
                if (Rectangles[i].Intersects(playerPos))
                {
                    return playerPos;
                }
            }

            return playerPos;
        }


    }
}
