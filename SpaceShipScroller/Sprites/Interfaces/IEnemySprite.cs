using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceShipScroller
{
    public interface IEnemySprite
    {
        void Update();

        void Draw(SpriteBatch spriteBatch);

        Rectangle GetCurrentRect();

        void Kill();
    }
}

