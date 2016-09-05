using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceShipScroller
{
    public interface IPlayerSprite
    {
        void Update(Keys[] keysPressed, GameTime gameTime);

        void Draw(SpriteBatch spriteBatch);
    }
}

