using System;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceShipScroller
{
    public interface IExplosionSprite
    {
        void Update();

        void Draw(SpriteBatch spriteBatch);
    }
}

