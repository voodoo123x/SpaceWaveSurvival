using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceShipScroller
{
    public class EnemyDroneSprite : IEnemySprite
    {
        public static Texture2D Texture { get; set; }

        private int spriteWidth;
        private int spriteHeight;
        private int xLocation;
        private int yLocation;
        private int killValue = 100;
        private Rectangle currentRect;

        public EnemyDroneSprite(int startX, int startY)
        {
            spriteWidth = 36;
            spriteHeight = 36;
            xLocation = startX;
            yLocation = startY;
            currentRect = new Rectangle(xLocation, yLocation, spriteWidth, spriteHeight);
        }

        public void Update()
        {
            yLocation += 2;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = new Rectangle(68, 14, spriteWidth, spriteHeight);
            currentRect = new Rectangle(xLocation, yLocation, spriteWidth, spriteHeight);

            spriteBatch.Draw(Texture, currentRect, sourceRectangle, Color.White, 0, new Vector2(0,0), SpriteEffects.FlipVertically, 0);
        }

        public Rectangle GetCurrentRect()
        {
            return currentRect;
        }

        public void Kill()
        {
            Game1.Instance.EnemySprites.Remove(this);
            Game1.Instance.ExplosionSprites.Add(new ExplosionSprite(currentRect.Center));
            Game1.Instance.Score += killValue;
        }
    }
}

