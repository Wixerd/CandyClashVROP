using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace Candy_Clash
{
   
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D Background;
        bool ishit;
        bool iskicked;
        bool isspec1;
        bool isspec2;
        bool ishit1;
        bool iskicked1;
        bool isspec11;
        bool isspec21;
        Texture2D healthTexture;
        Rectangle healtRectangle;
        Rectangle healtRectangle1;
        int teller;
        int teller1;
        private PlayerFrank PlayerFrank;
        private PlayerWilly PlayerWilly;

        MouseState pastMouse;
     
        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferHeight = 675;
            graphics.PreferredBackBufferWidth = 1200;
            
        }

       
        protected override void Initialize()
        {
            
            base.Initialize();
        }
  
        protected override void LoadContent()
        {
            
            spriteBatch = new SpriteBatch(GraphicsDevice);         
            Background = Content.Load<Texture2D>("Images/achtergrond");
            Texture2D texture = Content.Load<Texture2D>("Images/spritesheetfrank1");
            PlayerFrank = new PlayerFrank(texture, 4, 5, new Vector2(150,150),400);
            Texture2D texture2 = Content.Load<Texture2D>("Images/spritesheetwilly1");
            PlayerWilly = new PlayerWilly(texture2, 4, 5,new Vector2(450,150),400);
           healthTexture = Content.Load<Texture2D>("Images/healthleft");
           IsMouseVisible = true;
           PlayerFrank.currentFrame = 2;
           PlayerWilly.currentFrame = 2;


        }
        
        protected override void UnloadContent()
        {
            
        }
        
        protected override void Update(GameTime gameTime)
        {
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            #region healthbar 
            MouseState mouse = Mouse.GetState();
            Rectangle mouseRectangle = new Rectangle(mouse.X, mouse.Y, 1, 1);
            if (mouseRectangle.Intersects(PlayerWilly.RectangleW) && (mouse.LeftButton == ButtonState.Pressed && pastMouse.LeftButton == ButtonState.Released))
            PlayerWilly.health -= 40; 
            healtRectangle = new Rectangle(975, 6, PlayerWilly.health, 84);
            if (mouseRectangle.Intersects(PlayerFrank.RectangleF) && (mouse.LeftButton == ButtonState.Pressed && pastMouse.LeftButton == ButtonState.Released))
                PlayerFrank.health1 -= 40;
            healtRectangle1 = new Rectangle(40, 6, PlayerFrank.health1, 84);
            pastMouse = mouse;
            if (Keyboard.GetState().IsKeyDown(Keys.Y))
            {
                PlayerFrank.health1 = 400;
                PlayerWilly.health = 400;
            }
            #endregion
            #region attackswilly
            
           //punchatt
            if (PlayerWilly.RectaglePunchW.Intersects(PlayerFrank.RectangleF) && Keyboard.GetState().IsKeyDown(Keys.U) && ishit == false && Keyboard.GetState().IsKeyUp(Keys.K))
            {
                PlayerFrank.health1 -= 8;
                ishit = true;
            }

            if (Keyboard.GetState().IsKeyUp(Keys.U))
                ishit = false;
            //kickatt
            if (PlayerWilly.RectagleKickW.Intersects(PlayerFrank.RectangleF) && Keyboard.GetState().IsKeyDown(Keys.O) && iskicked == false && Keyboard.GetState().IsKeyUp(Keys.K)&& teller >350)
            {
               
                PlayerFrank.health1 -= 12;
                iskicked = true;
               teller=0;
            }
            teller += gameTime.ElapsedGameTime.Milliseconds;
            if (teller > 350)
                iskicked = false;
          
            //specatt1
            if (PlayerWilly.RectagleSpec1W.Intersects(PlayerFrank.RectangleF) && Keyboard.GetState().IsKeyDown(Keys.O) &&Keyboard.GetState().IsKeyDown(Keys.K)&& isspec1 == false)
            {
                PlayerFrank.health1 -= 22;
                isspec1 = true;
            }

            if (Keyboard.GetState().IsKeyUp(Keys.O)&&Keyboard.GetState().IsKeyUp(Keys.K))
                isspec1 = false;
           //specatt2
            if (PlayerWilly.RectagleSpec2W.Intersects(PlayerFrank.RectangleF) && Keyboard.GetState().IsKeyDown(Keys.U) && Keyboard.GetState().IsKeyDown(Keys.K) && isspec2 == false)
            {
                PlayerFrank.health1 -= 25;
                isspec2 = true;
            }

            if (Keyboard.GetState().IsKeyUp(Keys.U) && Keyboard.GetState().IsKeyUp(Keys.K))
                isspec2 = false;

            #endregion
            #region attacksfrank
             //punchatt
            if (PlayerFrank.RectaglePunchF.Intersects(PlayerWilly.RectangleW) && Keyboard.GetState().IsKeyDown(Keys.A) && ishit1 == false && Keyboard.GetState().IsKeyUp(Keys.S))
            {
                PlayerWilly.health -= 8;
                ishit1 = true;
            }

            if (Keyboard.GetState().IsKeyUp(Keys.A))
                ishit1 = false;
            //kickatt
            if (PlayerFrank.RectagleKickF.Intersects(PlayerWilly.RectangleW) && Keyboard.GetState().IsKeyDown(Keys.E) && iskicked1 == false && Keyboard.GetState().IsKeyUp(Keys.S)&& teller1 >350)
            {
               
                PlayerWilly.health -= 12;
                iskicked1 = true;
               teller1=0;
            }
            teller1 += gameTime.ElapsedGameTime.Milliseconds;
            if (teller1 > 350)
                iskicked1 = false;
          
            //specatt1
            if (PlayerFrank.RectagleSpec1F.Intersects(PlayerWilly.RectangleW) && Keyboard.GetState().IsKeyDown(Keys.E) && Keyboard.GetState().IsKeyDown(Keys.S) && isspec11 == false)
            {
                PlayerWilly.health -= 22;
                isspec11 = true;
            }

            if (Keyboard.GetState().IsKeyUp(Keys.E)&&Keyboard.GetState().IsKeyUp(Keys.S))
                isspec11 = false;
           //specatt2
            if (PlayerFrank.RectagleSpec2F.Intersects(PlayerWilly.RectangleW) && Keyboard.GetState().IsKeyDown(Keys.A) && Keyboard.GetState().IsKeyDown(Keys.S) && isspec21 == false)
            {
                PlayerWilly.health -= 25;
                isspec21 = true;
            }

            if (Keyboard.GetState().IsKeyUp(Keys.A) && Keyboard.GetState().IsKeyUp(Keys.E))
                isspec21 = false;
            #endregion 
            #region collision
            if (PlayerFrank.RectangleF.Intersects(PlayerWilly.RectangleW))
            {
                  PlayerWilly.velocity.X = 10f;
                PlayerFrank.velocity.X = -10f;
            }
            #endregion
            PlayerWilly.Update(gameTime, PlayerFrank);
            PlayerFrank.Update(gameTime, PlayerWilly);            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            

            spriteBatch.Begin();   
        
            spriteBatch.Draw(Background, new Vector2(0,0));
            spriteBatch.Draw(healthTexture, healtRectangle, Color.White);
            spriteBatch.Draw(healthTexture, healtRectangle1, Color.White);
            
            spriteBatch.End();
           
            PlayerFrank.Draw(spriteBatch, PlayerFrank.position1);
            PlayerWilly.Draw(spriteBatch, PlayerWilly.position);

            base.Draw(gameTime);
        }
    }
}
