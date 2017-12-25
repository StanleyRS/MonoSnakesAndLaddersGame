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

namespace FirstMonoGameApplication
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //Players
        Player playerOne;
        Player playerTwo;
        // Fonts
        SpriteFont ScoresFont;
        SpriteFont GameStartFont;
        //Keyboardstate and Mouse
        KeyboardState currentKeyboardState;
        MouseState currentMouseState;
        MouseState previousMouseState;
        // Textures
        Texture2D playerTexture;
        Texture2D computerTexture;
        Texture2D diceSprite;
        Texture2D backgroundPicture;
        Texture2D startImage;
        Texture2D DiceRollButton;
        //Rectangles
        Rectangle playerStartRectangle;
        Rectangle backgroundRectangle;
        Rectangle buttonRectangle;
        Rectangle diceRectangle;
        //Mouse location storage
        Point mousePosition;
        // player position variable of type vector2
        Vector2 playerPositionUpdated;
        //  Create a list to store the players
        List<Player> players = new List<Player>();
        //Randomness
        Random random;
        // will be set to true when any button is pressed on startup screen
        bool gameStarted = false;
        bool playerOnBoard = false;
        bool computerOnBoard = false;
        bool buttonPressed = false;
        //Store the dice pick after button press
        int dicePick = 0;
        int playerTurn = 1;
        

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

            // Load start screen and background pictures
            startImage = Content.Load<Texture2D>("Background/startlogo");
            backgroundPicture = Content.Load<Texture2D>("Background/background");
            // Game font for loading screen
            GameStartFont = Content.Load<SpriteFont>("StartGameFont");
            // Font for displaying scores
            ScoresFont = Content.Load<SpriteFont>("ScoresFont");
            // Dice roll button texture and sprite
            DiceRollButton = Content.Load<Texture2D>("buttonroll");
            diceSprite = Content.Load<Texture2D>("diceone");
            // Background, button and dice rectangles
            backgroundRectangle = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            buttonRectangle = new Rectangle(750, 700, DiceRollButton.Width, DiceRollButton.Height);
            diceRectangle = new Rectangle(795, 600, diceSprite.Width, diceSprite.Height);
            // Player textures load
            playerTexture = Content.Load<Texture2D>("playerOne");
            computerTexture = Content.Load<Texture2D>("playerTwo");
            playerPositionUpdated = new Vector2(15, 710);
            playerStartRectangle = new Rectangle((int)playerPositionUpdated.X, (int)playerPositionUpdated.Y, playerTexture.Width, playerTexture.Height);
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
            // check if game is at loading screen
            if (!gameStarted)
            {
                // check if a key is pressed at loading screen so game could start
                InputHandle();
            }
            else
            {
                // if key is pressed start game
                GameStart();

                // add game logic here

                // player.update
                // computer.update
            }          
            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            spriteBatch.Begin();

            // game starts bool
            if (gameStarted)
            {
                // if game is on draw board and dice roll button
                spriteBatch.Draw(backgroundPicture, backgroundRectangle, Color.White);
                spriteBatch.Draw(DiceRollButton, buttonRectangle, Color.White);
                // if button isnt pressed yet
                if (!buttonPressed)
                {
                    // draw dice roll text
                    spriteBatch.DrawString(GameStartFont, "Press Roll Dice to Start.", new Vector2(690, 630), Color.Blue);
                }
                else
                {
                    // iff button pressed draw picked dice
                    spriteBatch.Draw(diceSprite, diceRectangle, Color.White);
                    // check if player is on board
                    if (playerOnBoard)
                    {
                        // draw player
                        playerOne.Draw(spriteBatch);
                    }
                    // check if computer is on board
                    if (computerOnBoard)
                    {
                        // draw computer
                        playerTwo.Draw(spriteBatch);
                    }
                }
            }
            else
            {
                // draw start screen picture and game start text
                spriteBatch.Draw(startImage, backgroundRectangle, Color.White);
                spriteBatch.DrawString(GameStartFont, "Press any key to start the game...", new Vector2(320, 700), Color.LightSeaGreen);      
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }

        public void GameStart()
        {
            // get the current mouse state
            currentMouseState = Mouse.GetState();
            // mouse position X,Y
            mousePosition = new Point(currentMouseState.X, currentMouseState.Y);
            // check if player makes a click
            if (currentMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released)
            {
                // check if the click is on the button
                if (buttonRectangle.Contains(mousePosition))
                    buttonPressed = true;
                // roll teh diceee
                DiceRoll();
            }
            // previous mouse state is equal to the current mouse state, so we can make a comparasion later
            previousMouseState = currentMouseState;
        }

        // player input handle
        public void InputHandle()
        {
            if (Keyboard.GetState().GetPressedKeys().Length > 0)
            {
                gameStarted = true;
            }
        }

        public void DiceRoll()
        {
            // create a random number generator
            random = new Random();
            // roll a random dice between 1 and 6
            dicePick = random.Next(1, 7);
            // determine which dice sprite to use based on the random pick
            switch (dicePick)
            {
                case 1: diceSprite = Content.Load<Texture2D>("diceone"); break;
                case 2: diceSprite = Content.Load<Texture2D>("dicetwo"); break;
                case 3: diceSprite = Content.Load<Texture2D>("dicethree"); break;
                case 4: diceSprite = Content.Load<Texture2D>("dicefour"); break;
                case 5: diceSprite = Content.Load<Texture2D>("dicefive"); break;
                case 6: diceSprite = Content.Load<Texture2D>("dicesix"); break;
                default: break;
            }
            // pass the pick to determine which player turn it is
            PlayersSwitch(dicePick);
        }

        public void PlayersSwitch(int pick)
        {
            // the current turn which presses button
            if (playerTurn == 1)
                // if player is not on board and picks 6
                if (!playerOnBoard && dicePick.Equals(6))
                {
                    // player is active e.g on board
                    playerOnBoard = true;
                    // create new player and pass it to Player class
                    playerOne = new Player(
                                Content.Load<Texture2D>("playerOne"),
                                playerStartRectangle,
                                new Vector2(15, 710),
                                dicePick);
                    // add the current player to the list
                    players.Add(playerOne);
                    //repeat turn
                    playerTurn = 1;
                }
                else if (!playerOnBoard && dicePick != 6)
                {
                    playerTurn = 2;
                }
                // on next roll player is already on board so its time to move it
                else
                {
                    // if dice is 6 again, give extra turn
                    if (dicePick == 6)
                    { // move player
                        playerOne.PlayerMove(dicePick, playerPositionUpdated);
                        playerTurn = 1;
                    }
                    else
                    { // different roll than 6, pass turn to computer
                        playerOne.PlayerMove(dicePick, playerPositionUpdated);
                        playerTurn = 2;
                    }
                }
            else if (playerTurn == 2)
                // if player is not yet on board and picks 6
                if (!computerOnBoard && dicePick.Equals(6))
                {
                    computerOnBoard = true;
                    // create computer and pass it to Player class
                    playerTwo = new Player(
                        Content.Load<Texture2D>("playerTwo"),
                        playerStartRectangle,
                        new Vector2(15, 710),
                        dicePick);
                    // add player to the player list
                    players.Add(playerTwo);
                }
                else if (!computerOnBoard && dicePick != 6)
                {
                    playerTurn = 1;
                }
                // computer is already on board so lets move it
                else
                {
                    // UPDATE: need to implement rectangle update on player move position
                    // update by Vector2 position, after every pass to playermove
                    if (dicePick == 6)
                    {
                        playerTwo.PlayerMove(dicePick, playerPositionUpdated);
                        playerTurn = 1;
                    }
                    else
                    {
                        playerTwo.PlayerMove(dicePick, playerPositionUpdated);
                        playerTurn = 2;
                    }
                }
        }
    }
}
