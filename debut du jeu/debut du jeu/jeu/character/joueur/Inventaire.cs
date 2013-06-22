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
    public class Inventaire : GameScreen
    {
        gamemain Main;
        bool ispressed;
        Vector2 objet;
        public Inventaire(Game game, SpriteBatch spriteBatch, gamemain main)
            : base(game, spriteBatch)
        {
            ispressed = false;
            Main = main;
        }
        public void swap(ref item item1, ref item item2)
        {
            item aux;
            aux = item1;
            item1 = item2;
            item2 = aux;
        }
        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    if (Data.mouseState.LeftButton == ButtonState.Pressed && ispressed == false && new Rectangle(Data.mouseState.X, Data.mouseState.Y, 1, 1).Intersects(new Rectangle(i * 64 + 5 + game.Window.ClientBounds.Width / 2, j * 64 + 5 + 50, 64, 64)))
                    {
                        ispressed = true;
                        objet.X = i;
                        objet.Y = j;
                    }
                    if (Data.mouseState.LeftButton == ButtonState.Released && ispressed && new Rectangle(Data.mouseState.X, Data.mouseState.Y, 1, 1).Intersects(new Rectangle(i * 64 + 5 + game.Window.ClientBounds.Width / 2, j * 64 + 5 + 50, 64, 64)))
                    {
                        swap(ref Main.player.inventaire[(int)objet.X, (int)objet.Y], ref Main.player.inventaire[i, j]);
                        ispressed = false;
                    }
                }
            base.Update(gameTime);
        }
        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            spriteBatch.Draw(ressource.pixel, new Rectangle(0, 0, Game.Window.ClientBounds.Width, Game.Window.ClientBounds.Height), Color.SaddleBrown);
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    spriteBatch.Draw(ressource.selection_sort, new Rectangle(i * 64 + 5 + game.Window.ClientBounds.Width / 2, j * 64 + 5 + 50, 64, 64), Color.White);
                    if (Main.player.inventaire[i, j] != null)
                        Main.player.inventaire[i, j].draw(spriteBatch, i * 64 + 5 + game.Window.ClientBounds.Width / 2, j * 64 + 5 + 50, 64, 64);
                }
            for (int i = 0; i < 4; i++)
                spriteBatch.Draw(ressource.selection_sort, new Rectangle(25, i * 64 + 5 + 50, 64, 64), Color.White);
            if (ispressed)
                Main.player.inventaire[(int)objet.X, (int)objet.Y].draw(spriteBatch, Data.mouseState.X, Data.mouseState.Y, 64, 64);
            for (int j = 0; j < 5; j++)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (new Rectangle(Data.mouseState.X, Data.mouseState.Y, 1, 1).Intersects(new Rectangle(i * 64 + 5 + game.Window.ClientBounds.Width / 2, j * 64 + 5 + 50, 64, 64)))
                    {
                        if (Main.player.inventaire[i, j] != null)
                            if (Data.mouseState.X + (int)ressource.ecriture.MeasureString(Main.player.inventaire[i, j].utilité).X > game.Window.ClientBounds.Width)
                            {
                                spriteBatch.Draw(ressource.pixel, new Rectangle(
                                    Data.mouseState.X -
                                    (Data.mouseState.X +
                                    (int)ressource.ecriture.MeasureString(Main.player.inventaire[i, j].utilité).X - game.Window.ClientBounds.Width), Data.mouseState.Y,
                                    (int)ressource.ecriture.MeasureString(Main.player.inventaire[i, j].utilité).X,
                                    (int)ressource.ecriture.MeasureString(Main.player.inventaire[i, j].utilité).Y),
                                    Color.Wheat);
                                spriteBatch.DrawString(ressource.ecriture, Main.player.inventaire[i, j].utilité, new Vector2(Data.mouseState.X -
                                    (Data.mouseState.X +
                                    (int)ressource.ecriture.MeasureString(Main.player.inventaire[i, j].utilité).X - game.Window.ClientBounds.Width), Data.mouseState.Y), Color.Black);
                            }
                            else
                            {
                                spriteBatch.Draw(ressource.pixel, new Rectangle(Data.mouseState.X, Data.mouseState.Y, (int)ressource.ecriture.MeasureString(
                                Main.player.inventaire[i, j].utilité).X, (int)ressource.ecriture.MeasureString(
                                Main.player.inventaire[i, j].utilité).Y), Color.Wheat);
                                spriteBatch.DrawString(ressource.ecriture, Main.player.inventaire[i, j].utilité, new Vector2(Data.mouseState.X, Data.mouseState.Y), Color.Black);
                            }
                    }
                }
            }
            for (int j = 0; j < 5; j++)
                for (int i = 0; i < 5; i++)
                    if (new Rectangle(Data.mouseState.X, Data.mouseState.Y, 1, 1).Intersects(new Rectangle(i * 64 + 5 + game.Window.ClientBounds.Width / 2, j * 64 + 5 + 50, 64, 64)))
                    {
                        spriteBatch.Draw(ressource.pixel, new Rectangle(i * 64 + 5 + game.Window.ClientBounds.Width / 2, j * 64 + 5 + 50, 64, 4), Color.Red);
                        spriteBatch.Draw(ressource.pixel, new Rectangle(i * 64 + 5 + game.Window.ClientBounds.Width / 2, j * 64 + 5 + 50, 4, 64), Color.Red);
                        spriteBatch.Draw(ressource.pixel, new Rectangle(i * 64 + 5 + game.Window.ClientBounds.Width / 2, j * 64 + 5 + 50 + 62, 64, 4), Color.Red);
                        spriteBatch.Draw(ressource.pixel, new Rectangle(i * 64 + 5 + game.Window.ClientBounds.Width / 2 + 62, j * 64 + 5 + 50, 4, 64), Color.Red);
                    }
            spriteBatch.DrawString(ressource.ecriture, "Attaque : " + Main.player.attaque + "      Defense : " + Main.player.defense + "      Magie : " + Main.player.magie, new Vector2(50, 400), Color.DarkRed);
            base.Draw(gameTime);
        }
    }
}
