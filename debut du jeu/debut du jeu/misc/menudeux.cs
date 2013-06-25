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
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace Templar
{
    class menudeux : GameScreen
    {
        public textbox box;
        public bool selec;

        public menudeux(Game game, SpriteBatch spritebatch,ref textbox Box)
            : base(game, spritebatch)
        {
            box = Box;
            selec = false;
        }
        public override void Update(GameTime gameTime)
        {
            if (new Rectangle(Data.mouseState.X, Data.mouseState.Y, 1, 1).Intersects(new Rectangle(200, 300, 100, 50)) && Data.mouseState.LeftButton == ButtonState.Pressed && Data.prevMouseState.LeftButton == ButtonState.Released)
                selec = true;
            if (!(new Rectangle(Data.mouseState.X, Data.mouseState.Y, 1, 1).Intersects(new Rectangle(200, 300, 100, 50))) && Data.mouseState.LeftButton == ButtonState.Pressed && Data.prevMouseState.LeftButton == ButtonState.Released)
                selec = false;
            if (selec)
                box.Is_shown = true;

            box.update();
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Draw(ressource.menu_2, new Rectangle(0, 0,game.Window.ClientBounds.Width,game.Window.ClientBounds.Height), Color.White);
            if (selec)
                box.Draw(spriteBatch);
            spriteBatch.Draw(ressource.pixel, new Rectangle(200, 300, 100, 50), Color.DarkGreen);
            spriteBatch.Draw(ressource.pixel, new Rectangle(520, 300, 100, 50), Color.DarkRed);
            spriteBatch.DrawString(ressource.ecriture, "CLIENT", new Vector2(220, 300), Color.White);
            spriteBatch.DrawString(ressource.ecriture, "SERVEUR", new Vector2(530, 300), Color.White);
            base.Draw(gameTime);
        }
    }
}
