using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceShipScroller
{
    public class PlayerSprite : IPlayerSprite
    {
        public Texture2D Texture { get; set; }
        public int Health { get; set; }

        private int windowWidth;
        private int windowHeight;
        private int xLocation;
        private int yLocation;
        private float weaponCooldown;
        private float timeLastShot;


        public PlayerSprite(Texture2D texture)
        {
            Texture = texture;
            Health = 100;

            windowWidth = Game1.WindowWidth;
            windowHeight = Game1.WindowHeight;

            xLocation = (windowWidth / 2) - (texture.Width / 2);
            yLocation = windowHeight - (texture.Height + 20); 

            weaponCooldown = StandardLaserSprite.Cooldown;
            timeLastShot = 0f;
        }

        public void Update(Keys[] keysPressed, GameTime gameTime)
        {
            // Player shooting
            if (keysPressed.Any(k => k == Keys.Space))
            {
                float totalGameTime = (float)gameTime.TotalGameTime.TotalMilliseconds;
                float nextShot = timeLastShot + weaponCooldown;

                if (timeLastShot == 0 || nextShot < totalGameTime)
                {
                    Game1.Instance.ProjectileSprites.Add(new StandardLaserSprite(Direction.UP, xLocation + (Texture.Width / 4) - 3, yLocation - Texture.Height + 10));
                    timeLastShot = totalGameTime;
                }
            }

            // Diagonal movements
            if (keysPressed.Any(k => k == Keys.Left) && keysPressed.Any(k => k == Keys.Up))
            {
                if (xLocation > 0)
                {
                    xLocation -= 5;
                }
                if (yLocation > 0)
                {
                    yLocation -= 5;
                }

                return;
            }

            if (keysPressed.Any(k => k == Keys.Left) && keysPressed.Any(k => k == Keys.Down))
            {
                if (xLocation > 0)
                {
                    xLocation -= 5;
                }
                if (yLocation < (windowHeight - Texture.Height))
                {
                    yLocation += 5;
                }

                return;
            }

            if (keysPressed.Any(k => k == Keys.Right) && keysPressed.Any(k => k == Keys.Up))
            {
                if (xLocation < (windowWidth - Texture.Width))
                {
                    xLocation += 5;
                }
                if (yLocation > 0)
                {
                    yLocation -= 5;
                }

                return;
            }

            if (keysPressed.Any(k => k == Keys.Right) && keysPressed.Any(k => k == Keys.Down))
            {
                if (xLocation < (windowWidth - Texture.Width))
                {
                    xLocation += 5;
                }
                if (yLocation < (windowHeight - Texture.Height))
                {
                    yLocation += 5;
                }

                return;
            }


            // Standard single direction movements
            if (keysPressed.Any(k => k == Keys.Left) && xLocation > 0)
            {
                xLocation -= 5;
            }
            else if (keysPressed.Any(k => k == Keys.Right) && xLocation < (windowWidth - Texture.Width))
            {
                xLocation += 5;
            }
            else if (keysPressed.Any(k => k == Keys.Up) && yLocation > 0)
            {
                yLocation -= 5;
            }
            else if (keysPressed.Any(k => k == Keys.Down) && yLocation < (windowHeight - Texture.Height))
            { 
                yLocation += 5;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, new Vector2(xLocation, yLocation));
        }
    }
}

