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
        textbox box;
        bool selec;

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
            if (selec)
                box.Draw(spriteBatch);

            spriteBatch.Draw(ressource.pixel, new Rectangle(200, 300, 100, 50), Color.Green);
            spriteBatch.Draw(ressource.pixel, new Rectangle(400, 300, 100, 50), Color.Yellow);
            spriteBatch.DrawString(ressource.ecriture, "CLIENT", new Vector2(200, 300), Color.Azure);
            spriteBatch.DrawString(ressource.ecriture, "SERVEUR", new Vector2(400, 300), Color.Azure);
            base.Draw(gameTime);
        }


    }
}
