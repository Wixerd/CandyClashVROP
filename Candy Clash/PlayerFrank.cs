using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Candy_Clash
{
    class PlayerFrank
    {
        public Texture2D Texture { get; set;}
        public Vector2 position1;
        public Rectangle RectangleF;
        public int health1;
        public Vector2 velocity;
        bool hasJumped;
        public Rectangle RectaglePunchF;
        public Rectangle RectagleKickF;
        public Rectangle RectagleSpec1F;
        public Rectangle RectagleSpec2F;
        #region animation
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int currentFrame;
        private int totalframes;
        private int timeSinceLastFrame = 0;
        private int millisecondsPerFrame = 200;
        int teller;
        int teller1;
        
        
        #endregion

        public PlayerFrank(Texture2D texture, int rows, int columns,Vector2 newPosition,int newHealth)
        {
            position1 = newPosition;
            health1 = newHealth;
            hasJumped = true;
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalframes = Rows * Columns;
        }

        public void Update(GameTime gametime,PlayerWilly willy)
        {
            #region rectangles
            
            RectangleF = new Rectangle((int)position1.X + 100, (int)position1.Y, (Texture.Width / Columns) / 2, Texture.Height / Rows);

            if (Keyboard.GetState().IsKeyDown(Keys.A) && Keyboard.GetState().IsKeyUp(Keys.S))
            {
                RectaglePunchF = new Rectangle((int)position1.X + 480, (int)position1.Y + 150, 50, 50);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.E) && Keyboard.GetState().IsKeyUp(Keys.S))
            {
                RectagleKickF = new Rectangle((int)position1.X + 410, (int)position1.Y + 150, 50, 50);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.E) && Keyboard.GetState().IsKeyDown(Keys.S))
            {
                RectagleSpec1F = new Rectangle((int)position1.X + 420, (int)position1.Y + 150, 50, 50);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A) && Keyboard.GetState().IsKeyDown(Keys.S))
            {
                RectagleSpec2F = new Rectangle((int)position1.X + 480, (int)position1.Y + 150, 50, 50);
            }
            #endregion
              
            if (health1 >0)
            {
                #region movement
                position1 += velocity;
                if (Keyboard.GetState().IsKeyDown(Keys.D)) velocity.X = 4f;
                else if (Keyboard.GetState().IsKeyDown(Keys.Q)) velocity.X = -4f;
                else velocity.X = 0f;

                if (Keyboard.GetState().IsKeyDown(Keys.Z) && hasJumped == false)
                {

                    position1.Y -= 10f;
                    velocity.Y = -10f;
                    hasJumped = true;
                }
                if (hasJumped == true)
                {
                    float i = 1;
                    velocity.Y += 0.60f * i;

                }
                if (hasJumped == false)
                {
                    velocity.Y = 0f;
                }
                if (position1.Y + Texture.Height / 4 >= 700)
                    hasJumped = false;
                #endregion
                #region animation
                timeSinceLastFrame += gametime.ElapsedGameTime.Milliseconds;


                if (Keyboard.GetState().IsKeyDown(Keys.E) && Keyboard.GetState().IsKeyDown(Keys.S))
                {

                    currentFrame = 11;

                }

                if (Keyboard.GetState().IsKeyDown(Keys.A) && Keyboard.GetState().IsKeyDown(Keys.S))
                {

                    currentFrame = 12;

                }

                if (Keyboard.GetState().IsKeyDown(Keys.E) && Keyboard.GetState().IsKeyUp(Keys.S))
                {
                    if (timeSinceLastFrame > millisecondsPerFrame)
                    {
                        if (currentFrame < 8)
                        { currentFrame = 8; }
                        timeSinceLastFrame -= millisecondsPerFrame;
                        currentFrame++;
                        timeSinceLastFrame = 0;
                        if (currentFrame > 9)
                        {
                            currentFrame = 8;
                        }

                    }
                }

                if (Keyboard.GetState().IsKeyDown(Keys.A) && Keyboard.GetState().IsKeyUp(Keys.S))
                {
                    currentFrame = 10;

                }



                if (Keyboard.GetState().IsKeyDown(Keys.Q))
                {
                    if (timeSinceLastFrame > millisecondsPerFrame)
                    {
                        if (currentFrame < 15)
                        { currentFrame = 15; }
                        timeSinceLastFrame -= millisecondsPerFrame;
                        currentFrame++;
                        timeSinceLastFrame = 0;
                        if (currentFrame >= 18)
                        {
                            currentFrame = 15;
                        }

                    }
                }
                if (Keyboard.GetState().IsKeyDown(Keys.D))
                {
                    if (timeSinceLastFrame > millisecondsPerFrame)
                    {
                        if (currentFrame < 15)
                        { currentFrame = 15; }
                        timeSinceLastFrame -= millisecondsPerFrame;
                        currentFrame++;
                        timeSinceLastFrame = 0;
                        if (currentFrame >= 18)
                        {
                            currentFrame = 15;
                        }

                    }
                }


                

                if (Keyboard.GetState().IsKeyDown(Keys.Z))
                {
                    currentFrame = 6;

                }

                if (timeSinceLastFrame > millisecondsPerFrame && Keyboard.GetState().IsKeyUp(Keys.Z) && Keyboard.GetState().IsKeyUp(Keys.S) && Keyboard.GetState().IsKeyUp(Keys.D))
                {
                    if (currentFrame > 6)
                    { currentFrame = 2; }
                    timeSinceLastFrame -= millisecondsPerFrame;
                    currentFrame++;
                    timeSinceLastFrame = 0;

                    if (currentFrame == 6)
                    {
                        currentFrame = 2;
                    }

                }
                #endregion
            }
           
            if (willy.health <= 0)
            {
                teller1 += gametime.ElapsedGameTime.Milliseconds;
                if (teller1 < 350)
                    currentFrame = 13;
                else
                {
                    currentFrame = 14;
                    if (teller1 > 700)
                        teller1 = 0;

                }
                
            }
            if (health1 <= 0)
            {
                teller += gametime.ElapsedGameTime.Milliseconds;
                currentFrame = 0;
                if (teller > 350)
                    currentFrame = 1;
            }
        }

        public void Draw(SpriteBatch spritebatch, Vector2 location)
       {
           int width = Texture.Width/Columns;
           int height = Texture.Height / Rows;
           int row = (int)((float)currentFrame / Columns);
           int column = currentFrame % Columns;

           Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
           Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

           spritebatch.Begin();
           spritebatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
           
           spritebatch.End();
       }
    }
}
