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

namespace FirstMonoGameApplication
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // Fonts
        SpriteFont ScoresFont;
        SpriteFont GameStartFont;
        //Keyboardstate and Mouse
        KeyboardState currentKeyboardState;
        MouseState currentMouseState;
        MouseState previousMouseState;
        // Textures
        Texture2D playerSprite;
        Texture2D diceSprite;
        Texture2D backgroundPicture;
        Texture2D startImage;
        Texture2D DiceRollButton;
        //Rectangles
        Rectangle backgroundRectangle;
        Rectangle buttonRectangle;
        Rectangle diceRectangle;
        //Mouse location storage
        Point mousePosition;
        //Randomness
        Random random;
        // will be set to true when any button is pressed on startup screen
        bool gameStarted = false;
        bool playerOnBoard = false;
        bool buttonPressed = false;
        //Store the dice pick after button press
        int dicePick = 0;
        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // Set screen Size
            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 768;
            IsMouseVisible = true;

            

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here


            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            startImage = Content.Load<Texture2D>("Background/startlogo");
            backgroundPicture = Content.Load<Texture2D>("Background/background");
            GameStartFont = Content.Load<SpriteFont>("StartGameFont");
            ScoresFont = Content.Load<SpriteFont>("ScoresFont");
            DiceRollButton = Content.Load<Texture2D>("buttonroll");
            diceSprite = Content.Load<Texture2D>("diceone");

            backgroundRectangle = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            buttonRectangle = new Rectangle(750, 700, DiceRollButton.Width, DiceRollButton.Height);
            diceRectangle = new Rectangle(795, 600, diceSprite.Width, diceSprite.Height);
            


        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
       
        
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            if (!gameStarted)
            {
                InputHandle();
            }
            else
            {
                GameStart();
            }

                 



            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            spriteBatch.Begin();

            if (gameStarted)
            {
                spriteBatch.Draw(backgroundPicture, backgroundRectangle, Color.White);
                spriteBatch.Draw(DiceRollButton, buttonRectangle, Color.White);

                if (!buttonPressed)
                {
                    spriteBatch.DrawString(GameStartFont, "Press Roll Dice to Start.", new Vector2(690, 630), Color.Blue);
                }
                else
                { 
                   
                    spriteBatch.Draw(diceSprite, diceRectangle, Color.White);                     

                }

                

            }
            else
            {
                spriteBatch.Draw(startImage, backgroundRectangle, Color.White);

                spriteBatch.DrawString(GameStartFont, "Press any key to start the game...", new Vector2(320, 700), Color.LightSeaGreen);      
          

            }

            spriteBatch.End();






            base.Draw(gameTime);
        }

        public void GameStart()
        {
            if (!playerOnBoard)
            {
                currentMouseState = Mouse.GetState();
                mousePosition = new Point(currentMouseState.X, currentMouseState.Y);


                if (currentMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released)
                {
                   if( buttonRectangle.Contains(mousePosition))
                        buttonPressed = true;

                    DiceSwitch();
                }

                previousMouseState = currentMouseState;

            }



        }


        public void InputHandle()
        {
            if (Keyboard.GetState().GetPressedKeys().Length > 0)
            {
                gameStarted = true;
            }

        }


        public void DiceSwitch()
        {
            random = new Random();
            dicePick = random.Next(1, 7);

            switch (dicePick)
            {
                case 1: diceSprite = Content.Load<Texture2D>("diceone"); break;
                case 2: diceSprite = Content.Load<Texture2D>("dicetwo"); break;
                case 3: diceSprite = Content.Load<Texture2D>("dicethree"); break;
                case 4: diceSprite = Content.Load<Texture2D>("dicefour"); break;
                case 5: diceSprite = Content.Load<Texture2D>("dicefive"); break;
                case 6: diceSprite = Content.Load<Texture2D>("dicesix"); break;

                default:
                    break;

            }



            // check if player is not on board and has picked 6
            // if true draw player on board
            // make a random dice roll for computer
            // continue 

        }


    }
}
