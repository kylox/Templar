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
    class Inventaire:GameScreen
    {
        Game Game;
        gamemain Main;
        public Inventaire(Game game, SpriteBatch spriteBatch, gamemain main)
            : base(game, spriteBatch)
        {
            this.Game = game;
            Main = main;
        }


        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
           
            spriteBatch.Draw(ressource.pixel, new Rectangle(0, 0, Game.Window.ClientBounds.Width, Game.Window.ClientBounds.Height),Color.SaddleBrown);

            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    spriteBatch.Draw(ressource.selection_sort, new Rectangle(i * 64 + 5 + game.Window.ClientBounds.Width/2, j * 64 + 5 +50, 64, 64), Color.White);

            for (int i = 0; i < 4; i++)
                spriteBatch.Draw(ressource.selection_sort, new Rectangle(25, i * 64 + 5 + 50 , 64, 64), Color.White);

            spriteBatch.DrawString(ressource.ecriture, "Attaque : " + Main.player.attaque + "      Defense : " + Main.player.defense + "      Magie : " + Main.player.magie,new Vector2(50,400),Color.DarkRed);

            base.Draw(gameTime);
        }
    }
}
