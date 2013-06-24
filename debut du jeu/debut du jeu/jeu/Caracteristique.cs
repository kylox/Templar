using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
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
        bool langue;
        public Caracteristique(Game game, SpriteBatch spritebatch, GamePlayer player, bool language)
            : base(game, spritebatch)
        {
            langue = language;
            Player = player;
        }
        public override void Update(GameTime gameTime)
        {
         
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            if (langue)
            {
                spriteBatch.Draw(ressource.pixel, new Rectangle(0, 0, game.Window.ClientBounds.Width, game.Window.ClientBounds.Height), Color.DarkMagenta);
                spriteBatch.DrawString(ressource.ecriture, "Nombre d'amelioration " + Player.nb_amelioration, new Vector2(10, game.Window.ClientBounds.Height / 10), Color.White);
                spriteBatch.Draw(ressource.pixel, new Rectangle(game.Window.ClientBounds.Width / 10, game.Window.ClientBounds.Height / 10, 200, 100), Color.Brown);
                spriteBatch.DrawString(ressource.ecriture, "Attaque", new Vector2(game.Window.ClientBounds.Width / 10, game.Window.ClientBounds.Height / 10), Color.White);
                spriteBatch.Draw(ressource.pixel, new Rectangle(game.Window.ClientBounds.Width / 10 + 150, game.Window.ClientBounds.Height / 10, 200, 100), Color.Brown);
                spriteBatch.DrawString(ressource.ecriture, "Defense", new Vector2(game.Window.ClientBounds.Width / 10 + 150, game.Window.ClientBounds.Height / 10), Color.White);
                spriteBatch.Draw(ressource.pixel, new Rectangle(game.Window.ClientBounds.Width / 10 + 300, game.Window.ClientBounds.Height / 10, 200, 100), Color.Brown);
                spriteBatch.DrawString(ressource.ecriture, "Magie", new Vector2(game.Window.ClientBounds.Width / 10 + 300, game.Window.ClientBounds.Height / 10), Color.White);
            }
            else
            {
                spriteBatch.Draw(ressource.pixel, new Rectangle(0, 0, game.Window.ClientBounds.Width, game.Window.ClientBounds.Height), Color.DarkMagenta);
                spriteBatch.DrawString(ressource.ecriture, "Improvement available" + Player.nb_amelioration, new Vector2(10, game.Window.ClientBounds.Height / 10), Color.White);
                spriteBatch.Draw(ressource.pixel, new Rectangle(game.Window.ClientBounds.Width / 10, game.Window.ClientBounds.Height / 10, 200, 100), Color.Brown);
                spriteBatch.DrawString(ressource.ecriture, "Attack", new Vector2(game.Window.ClientBounds.Width / 10, game.Window.ClientBounds.Height / 10), Color.White);
                spriteBatch.Draw(ressource.pixel, new Rectangle(game.Window.ClientBounds.Width / 10 + 150, game.Window.ClientBounds.Height / 10, 200, 100), Color.Brown);
                spriteBatch.DrawString(ressource.ecriture, "Defense", new Vector2(game.Window.ClientBounds.Width / 10 + 150, game.Window.ClientBounds.Height / 10), Color.White);
                spriteBatch.Draw(ressource.pixel, new Rectangle(game.Window.ClientBounds.Width / 10 + 300, game.Window.ClientBounds.Height / 10, 200, 100), Color.Brown);
                spriteBatch.DrawString(ressource.ecriture, "Magic", new Vector2(game.Window.ClientBounds.Width / 10 + 300, game.Window.ClientBounds.Height / 10), Color.White);
            }
            base.Draw(gameTime);
        }
    }
}
