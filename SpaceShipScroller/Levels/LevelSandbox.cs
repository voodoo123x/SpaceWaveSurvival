using System;
using Microsoft.Xna.Framework;

namespace SpaceShipScroller
{
    public class LevelSandbox : IGameLevel
    {
        private int m_WindowWidth;

        public LevelSandbox() 
        { 
            m_WindowWidth = Game1.WindowWidth;
        }

        public void Update(GameTime gameTime)
        {
            Random rand = new Random();

            if (rand.Next(1000) <= 50)
            {
                if (rand.Next(2) == 1)
                {
                    Game1.Instance.EnemySprites.Add(new EnemyDroneSprite(rand.Next(m_WindowWidth), 0));
                }

                Game1.Instance.EnemySprites.Add(new EnemyDroneSprite(rand.Next(m_WindowWidth), 0));
            }
        }
    }
}

