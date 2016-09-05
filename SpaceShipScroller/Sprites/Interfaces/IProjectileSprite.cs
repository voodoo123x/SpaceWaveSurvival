using System;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceShipScroller
{
    public interface IProjectileSprite
    {
        void Update();

        void Draw(SpriteBatch spriteBatch);
    }

    public enum Direction { UP, DOWN };
}

