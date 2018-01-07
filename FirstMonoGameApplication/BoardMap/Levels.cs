using FirstMonoGameApplication.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FirstMonoGameApplication.BoardMap
{

    public class Levels
    {
        #region Levels
        /// /// /// /// /// /// /// /// 
        /* each level's start rectangle, est. width of rect 60x60 /* levels set        Rectangle level0 = new Rectangle(600, 720, 62, 76);
                                                                                      Rectangle Level1 = new Rectangle(30, 650, 50, 50);
                                                                                     Rectangle Level2 = new Rectangle(600, 650, 50, 50);
          0 - 605, 725 *  1 - 30, 650 2 - 600, 650 3 - 30, 570                      Rectangle Level3 = new Rectangle(30, 570, 50, 50);
                           4 - 600, 570    5 - 30, 500                             Rectangle Level4 = new Rectangle(600, 570, 50, 50);
                        6 - 600, 500     7 - 30, 425                              Rectangle Level5 = new Rectangle(30, 500, 50, 50);
                         8 - 600, 425     9 - 30, 345                            Rectangle Level6 = new Rectangle(600, 600, 50, 50);
              10 - 600, 345   11 - 30, 270                                      Rectangle Level7 = new Rectangle(30, 425, 50, 50);
                                12 - 600, 270   13 - 30, 190                   Rectangle Level8 = new Rectangle(600, 425, 50, 50);
                           14 - 600, 190   15 - 30, 120                       Rectangle Level9 = new Rectangle(30, 345, 50, 50);
                    16 - 600, 120   17 - 30, 45                              Rectangle Level10 = new Rectangle(600, 345, 50, 50);         
                 18 - 600, 45                                               Rectangle Level12 = new Rectangle(600, 270, 50, 50);
                                                                           Rectangle Level13 = new Rectangle(30, 190, 50, 50);
                                                                          Rectangle Level14 = new Rectangle(600, 190, 50, 50);
                                                                         Rectangle Level15 = new Rectangle(30, 120, 50, 50);
                                                                        Rectangle Level16 = new Rectangle(600, 120, 50, 50);
                                                                       Rectangle Level17 = new Rectangle(600, 45, 50, 50);*/

        #endregion

        private Texture2D pxl;
        private GraphicsDevice graphics;

        private List<Rectangle> possibleMoves = new List<Rectangle>();
        private List<Rectangle> testMoves = new List<Rectangle>();
        private Rectangle oldPositionRectangle, newPositionRectangle, possibleRectangleMoves;

        SpriteBatch sb;
        Random rand;
        Vector2 textVector;
        SpriteFont font;
        Song song;
        int pick1, pick2;

        bool predictMove = false;
        bool hasCollision = false;

        int levelCount = 1;
        int leftX = 612;
        int rightX = 690;
        int count = 1;

        public Rectangle[] rectangle = new Rectangle[19];

        public Levels(GraphicsDevice g)
        {
            graphics = g;
            pxl = new Texture2D(graphics, width: 1, height: 1);
            pxl.SetData(new[] { Color.White });

        }

        public void LoadContent(ContentManager Content)
        {
            Content.RootDirectory = "Content";
            MediaPlayer.IsRepeating = true;

            //LoadLevels();

            song = Content.Load<Song>("beep-21");
            font = Content.Load<SpriteFont>("testFont");

            sb = new SpriteBatch(graphics);


        }
        public void LoadLevels()
        {
            
            for (int i = 0; i < rectangle.Length; i++)
            {
                if (i % 2 == 0)
                {
                    rectangle[i] = new Rectangle(577, rightX, 62, 76);
                }
                else if (i % 2 == 1)
                {
                    rectangle[i] = new Rectangle(3, leftX, 62, 76);
                }

                if (count == 2)
                {
                    count = 0;
                    rightX -= 77;
                    leftX -= 77;

                }
                count++;
            }
        }


        public void LevelHandle(Player player)
        {
            rand = new Random();

            //levelCount = p;
            predictMove = true;
            pick1 = rand.Next(250, 500);
            pick2 = rand.Next(250, 500);
            oldPositionRectangle = player.Rectangle;

            /* for (int i = 0; i < rectangle.Length; i++)

             {
                 if (rectangle[i].Intersects(player.Rectangle))
                 {
                     hasCollision = true;
                     //levelCount++;

                     textVector = new Vector2(690, 580);

                     //MediaPlayer.Play(song);
                 }
                 else
                 {

                     hasCollision = false;
                     //levelCount++;
                 }
                 */


            // draw rectangles for each possible move of the current player
            if (predictMove)
            {
                //if (possibleMoves.ToString() != null)
                if (testMoves.Count > 0)
                {
                    predictMove = false;
                    if (!predictMove)
                    {
                        foreach (var d in testMoves)
                        {
                            possibleMoves.Remove(d);
                        }
                    }
                    //oldPositionRectangle = player.Rectangle;
                }
                for (int j = 0; j < 6; j++)
                {
                    possibleRectangleMoves = new Rectangle((player.Rectangle.X + 70 * j), player.Rectangle.Y, 50, 50);
                    possibleMoves.Add(possibleRectangleMoves);
                    testMoves.Add(possibleMoves[j]);
                }
                if (oldPositionRectangle == Rectangle.Empty)
                {
                    oldPositionRectangle = player.Rectangle;
                }
                if (oldPositionRectangle != player.Rectangle)
                {
                    predictMove = false;

                    //oldPositionRectangle = player.Rectangle;
                }
                else if (oldPositionRectangle == player.Rectangle)
                {
                    predictMove = true;
                }
            }
        }

        public void Draw(SpriteBatch sb)
        {

            if (predictMove)
            {
                foreach (var move in possibleMoves)
                {
                    sb.Draw(pxl, move, Color.Black);
                }

            }


            for (int i = 0; i < rectangle.Length; i++)
            {
                sb.Draw(pxl, rectangle[i], Color.Black);
            }


        }
    }
}
