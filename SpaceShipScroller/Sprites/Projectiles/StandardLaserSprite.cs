using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceShipScroller
{
    public class StandardLaserSprite : IProjectileSprite
    {
        public static Texture2D Texture { get; set; }
        public static readonly float Cooldown = 200f;

        private Direction direction;
        private int xLocation;
        private int yLocation;
        private int spriteWidth;
        private int spriteHeight;
        private Rectangle currentRect;

        //private readonly int damage = 10;

        public StandardLaserSprite(Direction shotDirection, int startX, int startY)
        {
            direction = shotDirection;
            xLocation = startX;
            yLocation = startY;
            spriteWidth = 53;
            spriteHeight = 85;
            currentRect = new Rectangle(xLocation, yLocation, spriteWidth, spriteHeight);
        }

        public void Update()
        {
            foreach (var enemy in Game1.Instance.EnemySprites.ToArray())
            {
                if (currentRect.Intersects(enemy.GetCurrentRect()))
                {
                    enemy.Kill();
                    Game1.Instance.ProjectileSprites.Remove(this);
                    break;
                }
            }

            if (direction == Direction.DOWN)
            {
                yLocation += 10;
            }
            else if (direction == Direction.UP)
            {
                yLocation -= 10;
            }

            if ((yLocation + Texture.Height) <= 0)
            {
                Game1.Instance.ProjectileSprites.Remove(this);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {  
            Rectangle sourceRectangle = new Rectangle(14, 301, spriteWidth, spriteHeight);
            currentRect = new Rectangle(xLocation, yLocation, spriteWidth, spriteHeight);

            spriteBatch.Draw(Texture, currentRect, sourceRectangle, Color.White);
        }
    }
}

