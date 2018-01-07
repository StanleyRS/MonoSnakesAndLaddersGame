using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Design;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstMonoGameApplication.Objects;

namespace FirstMonoGameApplication.BoardMap
{
    public class BoardTileMap
    {
        Texture2D pixel;
        GraphicsDevice graphicsDevice;
        //array for each rectangle
        //Rectangle[] Tiles = new Rectangle[9];
        List<Rectangle> Rectangles = new List<Rectangle>();

        int BorderWidth = 2;

        public BoardTileMap(GraphicsDevice device)
        {
            graphicsDevice = device;
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
                // pass tile rectangle to player class
                // check in player class if player rectangle intersects with tile rectangle
            }
            for (float y = 0; y < 9; y++)
            {
                Rectangle rectangle = new Rectangle(0, (int)(80 + (y * 76)), 640, BorderWidth);
                sb.Draw(pixel, rectangle, Color.Black);
                Rectangles.Add(rectangle);
            }     
        }  

        public Vector2 CheckTilePlayerCollision(Player player)
        {

            foreach (var r in Rectangles)
            {
                if (player.Rectangle.Intersects(r))
                {
                    return new Vector2(r.X, r.Y);
                }
            }
            //return new Vector2(700, 700);
            return Vector2.Zero;


        }
    }
}
