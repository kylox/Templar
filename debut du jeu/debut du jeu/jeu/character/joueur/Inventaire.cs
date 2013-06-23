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
        bool ispressed_i;
        bool ispressed_e;
        Vector2 objet;
        string[] strings;
        public Inventaire(Game game, SpriteBatch spriteBatch, gamemain main)
            : base(game, spriteBatch)
        {
            ispressed_i = false;
            ispressed_e = false;
            Main = main;
            strings = new string[]
            {
                "Augmenter Attaque de 1",
                "Augmenter Defense de 1",
                "Augmenter Magie de 1",
                "Augmenter Endurance de 25",
                "Augmenter point de vie de 25",
                "Augmenter point de mana de 25"
            };
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
            Main.player.maj_equipement();
            Main.player.maj_total();
            if (ispressed_i)
                ispressed_e = false;
            else
                if (ispressed_e)
                    ispressed_i = false;
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    for (int k = 0; k < 4; k++)
                    {
                        if (Data.mouseState.LeftButton == ButtonState.Released && Data.prevMouseState.LeftButton == ButtonState.Released)
                        {
                            ispressed_i = false;
                            ispressed_e = false;
                        }
                        if (Data.mouseState.LeftButton == ButtonState.Pressed && ispressed_e == false && ispressed_i == false
                            && new Rectangle(Data.mouseState.X, Data.mouseState.Y, 1, 1).Intersects(
                               new Rectangle(i * 64 + 5 + game.Window.ClientBounds.Width / 2, j * 64 + 5 + 50, 64, 64)))
                        {
                            ispressed_i = true;
                            objet.X = i;
                            objet.Y = j;
                        }
                        else
                            if (Data.mouseState.LeftButton == ButtonState.Pressed && ispressed_i == false && ispressed_e == false
                                                       && new Rectangle(Data.mouseState.X, Data.mouseState.Y, 1, 1).Intersects(
                                                          new Rectangle(25, k * 64 + 5 + 50, 64, 64)))
                            {
                                ispressed_e = true;
                                objet.X = k;
                            }

                        if (Data.mouseState.LeftButton == ButtonState.Released && ispressed_i &&
                            new Rectangle(Data.mouseState.X, Data.mouseState.Y, 1, 1).Intersects(
                            new Rectangle(i * 64 + 5 + game.Window.ClientBounds.Width / 2, j * 64 + 5 + 50, 64, 64)))
                        {
                            swap(ref Main.player.inventaire[(int)objet.X, (int)objet.Y], ref Main.player.inventaire[i, j]);
                            ispressed_i = false;
                        }
                        else
                            if (Data.mouseState.LeftButton == ButtonState.Released && ispressed_i &&
                            new Rectangle(Data.mouseState.X, Data.mouseState.Y, 1, 1).Intersects(
                            new Rectangle(25, k * 64 + 5 + 50, 64, 64)) && Main.player.inventaire[(int)objet.X, (int)objet.Y] != null && Main.player.inventaire[(int)objet.X, (int)objet.Y].is_equipable)
                            {
                                swap(ref Main.player.inventaire[(int)objet.X, (int)objet.Y], ref Main.player.equipement[k]);
                                ispressed_i = false;
                            }
                            else
                                if (Data.mouseState.LeftButton == ButtonState.Released && ispressed_e &&
                          new Rectangle(Data.mouseState.X, Data.mouseState.Y, 1, 1).Intersects(
                          new Rectangle(25, k * 64 + 5 + 50, 64, 64)))
                                {
                                    swap(ref Main.player.equipement[(int)objet.X], ref Main.player.equipement[k]);
                                    ispressed_i = false;
                                }
                                else
                                    if (Data.mouseState.LeftButton == ButtonState.Released && ispressed_e &&
                              new Rectangle(Data.mouseState.X, Data.mouseState.Y, 1, 1).Intersects(
                              new Rectangle(i * 64 + 5 + game.Window.ClientBounds.Width / 2, j * 64 + 5 + 50, 64, 64)) && Main.player.inventaire[i, j] != null)
                                    {
                                        swap(ref Main.player.equipement[(int)objet.X], ref Main.player.inventaire[i, j]);
                                        ispressed_i = false;
                                    }
                    }
            if (Main.player.nb_amelioration > 0)
                if (Main.player.nb_amelioration > 0)
                    for (int i = 0; i < 6; i++)
                        if (new Rectangle(Data.mouseState.X, Data.mouseState.Y, 1, 1).Intersects(
                            new Rectangle(450, 500 + 20 * i, (int)ressource.ecriture.MeasureString(strings[i]).X, (int)ressource.ecriture.MeasureString(strings[i]).Y))
                            && Data.mouseState.LeftButton == ButtonState.Pressed && Data.prevMouseState.LeftButton == ButtonState.Released)
                        {
                            switch (i)
                            {
                                case 0:
                                    Main.player.attaque_max++;
                                    break;
                                case 1:
                                    Main.player.defense_max++;
                                    break;
                                case 2:
                                    Main.player.magie_max++;
                                    break;
                                case 3:
                                    Main.player.endurance_max += 25;
                                    break;
                                case 4:
                                    Main.player.pv_max += 25;
                                    break;
                                case 5:
                                    Main.player.mana_max += 25;
                                    break;
                            }
                            Main.player.nb_amelioration--;
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
            {
                spriteBatch.Draw(ressource.selection_sort, new Rectangle(25, i * 64 + 5 + 50, 64, 64), Color.White);
                if (Main.player.equipement[i] != null)
                    Main.player.equipement[i].draw(spriteBatch, 25, i * 64 + 5 + 50, 64, 64);
                if (new Rectangle(Data.mouseState.X, Data.mouseState.Y, 1, 1).Intersects(new Rectangle(25, i * 64 + 5 + 50, 64, 64)))
                {
                    spriteBatch.Draw(ressource.pixel, new Rectangle(25, i * 64 + 5 + 50, 64, 4), Color.Red);
                    spriteBatch.Draw(ressource.pixel, new Rectangle(25, i * 64 + 5 + 50, 4, 64), Color.Red);
                    spriteBatch.Draw(ressource.pixel, new Rectangle(25, i * 64 + 5 + 50 + 62, 64, 4), Color.Red);
                    spriteBatch.Draw(ressource.pixel, new Rectangle(25 + 62, i * 64 + 5 + 50, 4, 64), Color.Red);
                    if (Main.player.equipement[i] != null)
                    {
                        spriteBatch.Draw(ressource.pixel, new Rectangle(Data.mouseState.X, Data.mouseState.Y, (int)ressource.ecriture.MeasureString(
                                    Main.player.equipement[i].utilité).X, (int)ressource.ecriture.MeasureString(
                                    Main.player.equipement[i].utilité).Y), Color.Wheat);
                        spriteBatch.DrawString(ressource.ecriture, Main.player.equipement[i].utilité, new Vector2(Data.mouseState.X, Data.mouseState.Y), Color.Black);
                    }
                }
            }
            if (ispressed_i && !ispressed_e && Main.player.inventaire[(int)objet.X, (int)objet.Y] != null)
                Main.player.inventaire[(int)objet.X, (int)objet.Y].draw(spriteBatch, Data.mouseState.X, Data.mouseState.Y, 64, 64);
            if (ispressed_e && !ispressed_i && Main.player.equipement[(int)objet.X] != null)
                Main.player.equipement[(int)objet.X].draw(spriteBatch, Data.mouseState.X, Data.mouseState.Y, 64, 64);
            for (int j = 0; j < 5; j++)
                for (int i = 0; i < 5; i++)
                    if (new Rectangle(Data.mouseState.X, Data.mouseState.Y, 1, 1).Intersects(new Rectangle(i * 64 + 5 + game.Window.ClientBounds.Width / 2, j * 64 + 5 + 50, 64, 64)))
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

            for (int j = 0; j < 5; j++)
                for (int i = 0; i < 5; i++)
                    if (new Rectangle(Data.mouseState.X, Data.mouseState.Y, 1, 1).Intersects(new Rectangle(i * 64 + 5 + game.Window.ClientBounds.Width / 2, j * 64 + 5 + 50, 64, 64)))
                    {
                        spriteBatch.Draw(ressource.pixel, new Rectangle(i * 64 + 5 + game.Window.ClientBounds.Width / 2, j * 64 + 5 + 50, 64, 4), Color.Red);
                        spriteBatch.Draw(ressource.pixel, new Rectangle(i * 64 + 5 + game.Window.ClientBounds.Width / 2, j * 64 + 5 + 50, 4, 64), Color.Red);
                        spriteBatch.Draw(ressource.pixel, new Rectangle(i * 64 + 5 + game.Window.ClientBounds.Width / 2, j * 64 + 5 + 50 + 62, 64, 4), Color.Red);
                        spriteBatch.Draw(ressource.pixel, new Rectangle(i * 64 + 5 + game.Window.ClientBounds.Width / 2 + 62, j * 64 + 5 + 50, 4, 64), Color.Red);
                    }

            spriteBatch.DrawString(ressource.ecriture, "Nombre d'amelioration " + Main.player.nb_amelioration, new Vector2(500, 480), Color.White);
            spriteBatch.DrawString(ressource.ecriture, "Total   =  items  +  amelioration  +  base", new Vector2(50, 480), Color.Black);
            spriteBatch.DrawString(ressource.ecriture, "Attaque :    " + Main.player.attaque + " = " + Main.player.attaque_item + " + " + Main.player.attaque_max + " + " + "10", new Vector2(50, 500), Color.Black);
            spriteBatch.DrawString(ressource.ecriture, "Defense :    " + Main.player.defense + " = " + Main.player.defense_item + " + " + Main.player.defense_max + " + " + "10", new Vector2(50, 520), Color.Black);
            spriteBatch.DrawString(ressource.ecriture, "Magie :    " + Main.player.magie + " = " + Main.player.magie_item + " + " + Main.player.magie_max + " + " + "10", new Vector2(50, 540), Color.Black);
            spriteBatch.DrawString(ressource.ecriture, "Endurance :    " + Main.player.end_player + " = " + Main.player.endurance_item + " + " + Main.player.endurance_max * 25 + " + " + " 100", new Vector2(50, 560), Color.Black);
            spriteBatch.DrawString(ressource.ecriture, "Pv max :    " + Main.player.PV + " = " + Main.player.pv_item + " + " + Main.player.pv_max * 25 + " + " + "100", new Vector2(50, 580), Color.Black);
            spriteBatch.DrawString(ressource.ecriture, "Mana max :    " + Main.player.mana_player + " = " + Main.player.mana_item + " + " + Main.player.mana_amelioration * 25 + " + " + "100", new Vector2(50, 600), Color.Black);
            spriteBatch.DrawString(ressource.ecriture, "Nb dash :    " + Main.player.timer_dash + " = " + Main.player.dash_item + " + " + "0" + " + " + "2 ", new Vector2(50, 620), Color.Black);

            if (Main.player.nb_amelioration > 0)
                for (int i = 0; i < 6; i++)
                    if (new Rectangle(Data.mouseState.X, Data.mouseState.Y, 1, 1).Intersects(new Rectangle(450, 500 + 20 * i, (int)ressource.ecriture.MeasureString(strings[i]).X, (int)ressource.ecriture.MeasureString(strings[i]).Y)))
                        spriteBatch.DrawString(ressource.ecriture, strings[i], new Vector2(450, 500 + i * 20), Color.Red);
                    else
                        spriteBatch.DrawString(ressource.ecriture, strings[i], new Vector2(450, 500 + i * 20), Color.Black);
            base.Draw(gameTime);
        }
    }

}
