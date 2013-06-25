using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Templar
{
    class victory:GameScreen
    {
        public victory(Game game, SpriteBatch spritebatch)
            : base(game, spritebatch)
        {
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Draw(ressource.pixel, new Rectangle(0, 0, game.Window.ClientBounds.Width, game.Window.ClientBounds.Height), Color.Black);
            spriteBatch.DrawString(ressource.ecriture, "vous avez gagnez !!!! maintenant vous pouvez avoir un cookie !", new Vector2(game.Window.ClientBounds.Width / 3, game.Window.ClientBounds.Height / 2), Color.White);
            base.Draw(gameTime);
        }

    }
    
}
