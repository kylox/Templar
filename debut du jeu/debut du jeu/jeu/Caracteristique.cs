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
    class Caracteristique : GameScreen
    {
        GamePlayer Player;
        public Caracteristique(Game game, SpriteBatch spritebatch, GamePlayer player)
            : base(game, spritebatch)
        {
            Player = player;
        }
        public override void Update(GameTime gameTime)
        {
            if (new Rectangle(Data.mouseState.X, Data.mouseState.Y, 1, 1).Intersects(new Rectangle(game.Window.ClientBounds.Width / 10, game.Window.ClientBounds.Height / 10, 200, 100)) &&
                Data.mouseState.LeftButton == ButtonState.Pressed &&
                Data.prevMouseState.LeftButton == ButtonState.Released && Player.nb_amelioration > 0)
            {
                Player.attaque += 5;
                Player.nb_amelioration--;
            }
            if (new Rectangle(Data.mouseState.X, Data.mouseState.Y, 1, 1).Intersects(new Rectangle(game.Window.ClientBounds.Width / 10 + 150, game.Window.ClientBounds.Height / 10, 200, 100)) &&
                Data.mouseState.LeftButton == ButtonState.Pressed &&
                Data.prevMouseState.LeftButton == ButtonState.Released && Player.nb_amelioration > 0)
            {
                Player.defense += 5;
                Player.nb_amelioration--;
            }
            if (new Rectangle(Data.mouseState.X, Data.mouseState.Y, 1, 1).Intersects(new Rectangle(game.Window.ClientBounds.Width / 10 + 300, game.Window.ClientBounds.Height / 10, 200, 100)) &&
                Data.mouseState.LeftButton == ButtonState.Pressed &&
                Data.prevMouseState.LeftButton == ButtonState.Released && Player.nb_amelioration > 0)
            {
                Player.magie += 5;
                Player.nb_amelioration--;
            }
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Draw(ressource.pixel, new Rectangle(0, 0, game.Window.ClientBounds.Width, game.Window.ClientBounds.Height), Color.DarkMagenta);
            spriteBatch.DrawString(ressource.ecriture, "Nombre d'amelioration " + Player.nb_amelioration, new Vector2(10, game.Window.ClientBounds.Height / 10), Color.White);
            spriteBatch.Draw(ressource.pixel, new Rectangle(game.Window.ClientBounds.Width / 10, game.Window.ClientBounds.Height / 10, 200, 100), Color.Brown);
            spriteBatch.DrawString(ressource.ecriture, "Attaque", new Vector2(game.Window.ClientBounds.Width / 10, game.Window.ClientBounds.Height / 10), Color.White);
            spriteBatch.Draw(ressource.pixel, new Rectangle(game.Window.ClientBounds.Width / 10 + 150, game.Window.ClientBounds.Height / 10, 200, 100), Color.Brown);
            spriteBatch.DrawString(ressource.ecriture, "Defense", new Vector2(game.Window.ClientBounds.Width / 10 + 150, game.Window.ClientBounds.Height / 10), Color.White);
            spriteBatch.Draw(ressource.pixel, new Rectangle(game.Window.ClientBounds.Width / 10 + 300, game.Window.ClientBounds.Height / 10, 200, 100), Color.Brown);
            spriteBatch.DrawString(ressource.ecriture, "Magie", new Vector2(game.Window.ClientBounds.Width / 10 + 300, game.Window.ClientBounds.Height / 10), Color.White);

            base.Draw(gameTime);
        }
    }
}
