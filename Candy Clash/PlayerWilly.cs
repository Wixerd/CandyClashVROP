using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Utilities;
using Microsoft.Xna.Framework.Windows;
namespace Candy_Clash
{
    class PlayerWilly
    {
        public Texture2D Texture { get; set; }
        public Rectangle RectangleW;
        public Rectangle RectaglePunchW;
        public Rectangle RectagleKickW;
        public Rectangle RectagleSpec1W;
        public Rectangle RectagleSpec2W;
        public int health;
        int teller;
        int teller1;
        #region movement
        public Vector2 position;       
        public Vector2 velocity;
        bool hasJumped;
        #endregion
        #region animation
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int currentFrame;
        private int totalframes;
        private int timeSinceLastFrame = 0;
        private int millisecondsPerFrame = 150;
        #endregion

        public PlayerWilly(Texture2D texture, int rows, int columns, Vector2 newPosition,int newHealth)
        {
            
            health = newHealth;
            position = newPosition;
            hasJumped = true;
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalframes = Rows * Columns;
        }
        
        public void Update(GameTime gametime,PlayerFrank frank)
        {
            #region rectangles

            if (Keyboard.GetState().IsKeyDown(Keys.U)&&Keyboard.GetState().IsKeyUp(Keys.K))
            {
                RectaglePunchW = new Rectangle((int)position.X +50 , (int)position.Y+150, 50, 50);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.O) && Keyboard.GetState().IsKeyUp(Keys.K))
            {
                RectagleKickW = new Rectangle((int)position.X+180, (int)position.Y + 150, 50, 50);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.O) && Keyboard.GetState().IsKeyDown(Keys.K))
            {
                RectagleSpec1W = new Rectangle((int)position.X + 180, (int)position.Y + 150, 50, 50);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.U) && Keyboard.GetState().IsKeyDown(Keys.K))
            {
                RectagleSpec2W = new Rectangle((int)position.X + 180, (int)position.Y + 150, 50, 50);
            }
            RectangleW = new Rectangle((int)position.X+290, (int)position.Y, (Texture.Width/Columns)/3, Texture.Height/Rows);

            #endregion

            if (health > 0)
            {
                #region movement
                position += velocity;
                if (Keyboard.GetState().IsKeyDown(Keys.L)) velocity.X = 6f;
                else if (Keyboard.GetState().IsKeyDown(Keys.J)) velocity.X = -6f;
                else velocity.X = 0f;

                if (Keyboard.GetState().IsKeyDown(Keys.I) && hasJumped == false)
                {
                    position.Y -= 10f;
                    velocity.Y = -9f;
                    hasJumped = true;
                }
                if (hasJumped == true)
                {
                    float i = 1;
                    velocity.Y += 0.40f * i;

                }
                if (hasJumped == false)
                {
                    velocity.Y = 0f;
                }
                if (position.Y + Texture.Height / 4 >= 700)
                    hasJumped = false;


                #endregion
                #region animation
                timeSinceLastFrame += gametime.ElapsedGameTime.Milliseconds;

                if (Keyboard.GetState().IsKeyDown(Keys.O) && Keyboard.GetState().IsKeyDown(Keys.K))
                {

                    currentFrame = 11;

                }

                if (Keyboard.GetState().IsKeyDown(Keys.U) && Keyboard.GetState().IsKeyDown(Keys.K))
                {

                    currentFrame = 12;

                }

                if (Keyboard.GetState().IsKeyDown(Keys.O) && Keyboard.GetState().IsKeyUp(Keys.K))
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

                if (Keyboard.GetState().IsKeyDown(Keys.U) && Keyboard.GetState().IsKeyUp(Keys.K))
                {
                    currentFrame = 10;

                }

                if (Keyboard.GetState().IsKeyDown(Keys.J))
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
                if (Keyboard.GetState().IsKeyDown(Keys.L))
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


                if (currentFrame > 18)
                { currentFrame = 2; }

                if (Keyboard.GetState().IsKeyDown(Keys.I))
                {
                    currentFrame = 6;

                }

                if (timeSinceLastFrame > millisecondsPerFrame && Keyboard.GetState().IsKeyUp(Keys.I) && Keyboard.GetState().IsKeyUp(Keys.U) && Keyboard.GetState().IsKeyUp(Keys.K))
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
            
            if (frank.health1 <= 0)
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
            if (health <= 0)
            {
                teller += gametime.ElapsedGameTime.Milliseconds;
                currentFrame = 0;
                if (teller > 350)
                    currentFrame = 1;
            }
        }

        public void Draw(SpriteBatch spritebatch, Vector2 location)
        {
            int width = Texture.Width / Columns;
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
