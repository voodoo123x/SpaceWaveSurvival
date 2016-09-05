using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SpaceShipScroller
{
    public class ExplosionSprite : IExplosionSprite
    {
        public static Texture2D Texture { get; set; }

        private int xLocation;
        private int yLocation;
        private int currentFrame;
        private int totalFrames;
        private int spriteWidth;
        private int spriteHeight;

        public ExplosionSprite(Point center)
        {
            currentFrame = 1;
            totalFrames = 10;
            spriteWidth = 56;
            spriteHeight = 56;
            xLocation = center.X - (spriteWidth / 2);
            yLocation = center.Y - (spriteHeight / 2);
        }

        public void Update()
        {
            currentFrame++;

            if (!(currentFrame <= totalFrames))
            {
                Game1.Instance.ExplosionSprites.Remove(this);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Point sourcePoint = currentFrame <= 5 ? new Point((currentFrame * 60) + 1, 186) : new Point(((currentFrame - 5) * 60) + 1, 245);
            Point spritePoint = new Point(spriteHeight, spriteWidth);

            Rectangle sourceRectangle = new Rectangle(sourcePoint, spritePoint);
            Rectangle destinationRectangle = new Rectangle(xLocation, yLocation, spriteWidth, spriteHeight);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}