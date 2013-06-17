using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.IO;

namespace Templar
{
    public class EDM : GameScreen
    {
        #region variable
        textbox text;
        textbox message;
        Rectangle fenetre;
        KeyboardState keyboardState;
        KeyboardState lastKeyboardState;
        Tile current_tile;
        Rectangle tileset;
        Map[,] listes_map;
        Map map;
        Map prevfirst;
        Donjon Donjon;
        Point actuel;
        bool selec;
        int nb;
        Vector2 position;
        #endregion
        public Rectangle Fenetre
        {
            get { return fenetre; }
            set { fenetre = value; }
        }
        public EDM(Game game, SpriteBatch spriteBatch)
            : base(game, spriteBatch)
        {
            fenetre = new Rectangle(0, 0, game.Window.ClientBounds.Width, game.Window.ClientBounds.Height); //taille de la fenetre
            MediaPlayer.IsMuted = true;
            text = new textbox(new Rectangle(game.Window.ClientBounds.Width / 3, game.Window.ClientBounds.Height / 3, 200, 100));
            message = new textbox(new Rectangle(game.Window.ClientBounds.Width / 8, 2 * game.Window.ClientBounds.Height / 3, 600, 200));
            message.Is_shown = false;
            current_tile = new Tile(0, 0, 0);
            tileset = new Rectangle(fenetre.Width - ressource.objet_map.Width, 0, ressource.objet_map.Width, ressource.objet_map.Height);
            listes_map = new Map[5, 5];
            nb = 0;
            actuel = new Point();
            selec = false;
        }
        public void deposer_porte(string path)
        {
            if ((cursor.iD == new Vector2(0, 4) || cursor.iD == new Vector2(0, 7)) && Data.mouseState.X / 32 == 0)
                map.ecrire_objet(path);
            else
                if ((cursor.iD == new Vector2(0, 5) || cursor.iD == new Vector2(1, 4)) && Data.mouseState.X / 32 == 24)
                    map.ecrire_coll(path);
                else
                    if ((cursor.iD == new Vector2(0, 6) || cursor.iD == new Vector2(1, 7)) && Data.mouseState.Y / 32 == 0)
                        map.ecrire_objet(path);
                    else
                        if ((cursor.iD == new Vector2(1, 6) || cursor.iD == new Vector2(1, 5)) && Data.mouseState.Y / 32 == 24)
                            map.ecrire_objet(path);
        }
        public void ecrire_position(string path)
        {
            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine(position.X + " " + position.Y);
            sw.WriteLine(actuel.X + " " + actuel.Y);
            sw.Close();
        }
        public override void Update(GameTime gameTime)
        {
            lastKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();
            cursor.Update(gameTime, tileset, fenetre);
            text.update();
            //permet de creer le donjon
            if (Donjon == null)
                text.Is_shown = true;
            //donjon creer
            if (text.Is_shown && keyboardState.IsKeyDown(Keys.F1))
            {
                creation_donjon(text.Saisie);
                message.Is_shown = true;
                text.Is_shown = false;
            }
            //si donfon creer alors on update
            if (Donjon != null)
            {
                creation_map();
                selectionmap();
                selectiomessage();
                //met a jour le message de la map
                Donjon.Map[actuel.X, actuel.Y].Message = message.Saisie;
                //check le cursor position joueur
                if (Data.mouseState.LeftButton == ButtonState.Pressed &&
                        Data.prevMouseState.LeftButton == ButtonState.Released &&
                            new Rectangle(Data.mouseState.X, Data.mouseState.Y, 1, 1).Intersects(
                                new Rectangle((int)tileset.X - (int)ressource.ecriture.MeasureString("position joueur").X, 0, (int)ressource.ecriture.MeasureString("position joueur").X, (int)ressource.ecriture.MeasureString("position joueur").Y)))
                    cursor.position = true;


                //sinon on a selectionner la textbox
                if (selec == true)
                    message.update();

                //fait l'update de la map 
                if (nb < 10)
                    Donjon.Map[actuel.X, actuel.Y].Update(gameTime,
                        @"Donjons\" + @text.Saisie + @"\Map" + @"0" + @nb + @"\Map" + @"0" + @nb + @".txt",
                            @"Donjons\" + @text.Saisie + @"\Map" + @"0" + @nb + @"\collision" + @"0" + @nb + @".txt",
                                @"Donjons\" + @text.Saisie + @"\Map" + @"0" + @nb + @"\message" + @"0" + @nb + @".txt", text);
                else
                    Donjon.Map[actuel.X, actuel.Y].Update(gameTime,
                        @"Donjons\" + @text.Saisie + @"\Map" + @nb + @"\Map" + @nb + @".txt",
                            @"Donjons\" + @text.Saisie + @"\Map" + @nb + @"\collision" + @nb + @".txt",
                                @"Donjons\" + @text.Saisie + @"\Map" + @nb + @"\message" + @nb + @".txt", text);

                //change l'endroit de pop du joueur
                if (Data.mouseState.LeftButton == ButtonState.Pressed &&
                        Data.prevMouseState.LeftButton == ButtonState.Released &&
                            new Rectangle(Data.mouseState.X, Data.mouseState.Y, 1, 1).Intersects(new Rectangle(0, 0, 16 * 25, 16 * 18)) &&
                                 text.Is_shown == false && cursor.position == true)
                {
                    if (prevfirst != null)
                    {
                        prevfirst.isfirst = false;
                        position = new Vector2(Data.mouseState.X - Data.mouseState.X % 16, Data.mouseState.Y - Data.mouseState.Y % 16);
                        Donjon.Map[actuel.X, actuel.Y].isfirst = true;
                        prevfirst = Donjon.Map[actuel.X, actuel.Y];
                        ecrire_position(@"Donjons\" + @text.Saisie + @"\autre" + @".txt");
                        cursor.position = false;
                    }
                    else
                    {
                        position = new Vector2(Data.mouseState.X - Data.mouseState.X % 16, Data.mouseState.Y - Data.mouseState.Y % 16);
                        Donjon.Map[actuel.X, actuel.Y].isfirst = true;
                        prevfirst = Donjon.Map[actuel.X, actuel.Y];

                        ecrire_position(@"Donjons\" + @text.Saisie + @"\autre" + @".txt");
                        cursor.position = false;

                    }
                }
            }
        }
        public void selectiomessage()
        {
            if (new Rectangle(Data.mouseState.X, Data.mouseState.Y, 1, 1).Intersects(message.Fenetre)
                && Data.mouseState.LeftButton == ButtonState.Pressed
                && Data.prevMouseState.LeftButton == ButtonState.Released)
                selec = true;
            if ((!new Rectangle(Data.mouseState.X, Data.mouseState.Y, 1, 1).Intersects(message.Fenetre))
                && Data.mouseState.LeftButton == ButtonState.Pressed
                && Data.prevMouseState.LeftButton == ButtonState.Released)
                selec = false;
        }
        //selectionne la map dans l'edm
        public void selectionmap()
        {
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    if (new Rectangle(Data.mouseState.X, Data.mouseState.Y, 1, 1).Intersects(new Rectangle(Fenetre.Width - 160 + 32 * i, 300 + 32 * j, 16, 8))
                        && Data.mouseState.LeftButton == ButtonState.Pressed
                        && Data.prevMouseState.LeftButton != ButtonState.Pressed && Donjon.Map[i, j] != null)
                    {
                        actuel.X = i;
                        actuel.Y = j;
                        message.Saisie = Donjon.Map[actuel.X, actuel.Y].Message;
                    }
        }
        //cree une map
        public void creation_map()
        {
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    if (new Rectangle(Data.mouseState.X, Data.mouseState.Y, 1, 1).Intersects(new Rectangle(Fenetre.Width - 160 + 32 * i, 300 + 32 * j, 16, 8))
                        && Data.mouseState.LeftButton == ButtonState.Pressed
                        && Data.prevMouseState.LeftButton != ButtonState.Pressed && Donjon.Map[i, j] == null)
                    {
                        switch (j)
                        {
                            case 0:
                                nb = i;
                                break;
                            case 1:
                                nb = 5 + i;
                                break;
                            case 2:
                                nb = 10 + i;
                                break;
                            case 3:
                                nb = 15 + i;
                                break;
                            case 4:
                                nb = 20 + i;
                                break;
                        }
                        actuel.X = i;
                        actuel.Y = j;
                        Donjon.Ajout_map(i, j, nb, text.Saisie);
                        Donjon.Map[i, j].isCreate = true;
                        message.Saisie = "";
                    }
                }
        }
        //creer le donjon (le dossier + la premiere map)
        public void creation_donjon(string path)
        {
            try
            {
                string nombre;
                if (nb < 10)
                    nombre = "0" + Convert.ToString(nb);
                else
                    nombre = Convert.ToString(nb);
                System.IO.Directory.CreateDirectory(@"Donjons\" + @text.Saisie + @"\Map" + @nombre);
                Stream sr = new FileStream(@"Donjons\" + @text.Saisie + @"\autres.txt", FileMode.Create);
                sr.Close();
                Donjon = new Donjon(path, true);
                Donjon.Ajout_map(0, 0, 0, text.Saisie);
                text.Is_shown = false;
            }
            catch (Exception)
            {
                //l'affiche sur la deuxieme sortie car sinon ca valide
                message.Saisie = "nom incorrect ";
            }
        }
        public override void Draw(GameTime gameTime)
        {
            if (text.Is_shown == true)
            {
                spriteBatch.Draw(ressource.pixel, new Rectangle(0, 0, fenetre.Width, fenetre.Height), Color.FromNonPremultiplied(0, 0, 0, 255));
                spriteBatch.DrawString(ressource.ecriture, "Veuillez entrez le nom de donjon, une fois fait, appuyez sur F1 pour demarer", new Vector2(fenetre.Width / 9, (int)fenetre.Height / 2), Color.Red);
                text.Draw(spriteBatch);
            }
            else
            {
                //dessine la string de positionnement du joueur
                if (cursor.position == false)
                    spriteBatch.DrawString(ressource.ecriture, "position joueur", new Vector2(tileset.X - ressource.ecriture.MeasureString("position joueur").X, 0), Color.White);
                else
                    spriteBatch.DrawString(ressource.ecriture, "position joueur", new Vector2(tileset.X - ressource.ecriture.MeasureString("position joueur").X, 0), Color.Red);
                //dessine la map + ou on est sur la map !
                if (Donjon != null && Donjon.Map[actuel.X, actuel.Y] != null)
                {
                    Donjon.Map[actuel.X, actuel.Y].Draw(spriteBatch, 16);
                    spriteBatch.Draw(ressource.pixel, new Rectangle(Fenetre.Width - 160 + 32 * actuel.X, 300 + 32 * actuel.Y, 16, 1), Color.Red);
                    spriteBatch.Draw(ressource.pixel, new Rectangle(Fenetre.Width - 160 + 32 * actuel.X, 300 + 32 * actuel.Y, 1, 8), Color.Red);
                    spriteBatch.Draw(ressource.pixel, new Rectangle(Fenetre.Width - 160 + 32 * actuel.X, 300 + 32 * actuel.Y + 8, 16, 1), Color.Red);
                    spriteBatch.Draw(ressource.pixel, new Rectangle(Fenetre.Width - 160 + 32 * actuel.X + 16, 300 + 32 * actuel.Y, 1, 8), Color.Red);
                }
                spriteBatch.Draw(ressource.objet_map, new Rectangle(fenetre.Width - ressource.objet_map.Width, 0, ressource.objet_map.Width, ressource.objet_map.Height), Color.White);
                //dessine les ligne de l'editeur de map
                for (int i = 0; i <= 16 * 25; i += 16)
                    spriteBatch.Draw(ressource.pixel, new Rectangle(i, 0, 1, 16 * 18), Color.FromNonPremultiplied(0, 0, 0, 250));
                for (int j = 0; j < 16 * 18; j += 16)
                    spriteBatch.Draw(ressource.pixel, new Rectangle(0, j, 16 * 25, 1), Color.FromNonPremultiplied(0, 0, 0, 250));
                //dessine les 25 maps du donjon 
                for (int i = 0; i < 5; i++)
                    for (int j = 0; j < 5; j++)
                    {
                        if (new Rectangle(Data.mouseState.X, Data.mouseState.Y, 1, 1).Intersects(new Rectangle(Fenetre.Width - 160 + 32 * i, 300 + 32 * j, 16, 8)))
                            spriteBatch.Draw(ressource.pixel, new Rectangle(Fenetre.Width - 160 + 32 * i, 300 + 32 * j, 16, 8), Color.FromNonPremultiplied(204, 0, 0, 50));
                        else
                            if (Donjon != null && Donjon.Map[i, j] != null && Donjon.Map[i, j].isfirst == true)
                                spriteBatch.Draw(ressource.pixel, new Rectangle(Fenetre.Width - 160 + 32 * i, 300 + 32 * j, 16, 8), Color.Blue);
                            else
                                if (Donjon != null && Donjon.Map[i, j] != null && Donjon.Map[i, j].isCreate == true)
                                    spriteBatch.Draw(ressource.pixel, new Rectangle(Fenetre.Width - 160 + 32 * i, 300 + 32 * j, 16, 8), Color.FromNonPremultiplied(51, 204, 0, 50));
                                else
                                    spriteBatch.Draw(ressource.pixel, new Rectangle(Fenetre.Width - 160 + 32 * i, 300 + 32 * j, 16, 8), Color.FromNonPremultiplied(250, 250, 250, 50));
                    }
                cursor.Draw(spriteBatch, fenetre);
                spriteBatch.Draw(ressource.pixel, tileset, Color.FromNonPremultiplied(0, 0, 0, 50));
                message.Draw(spriteBatch);
                if (Donjon.Map[actuel.X, actuel.Y].isfirst == true)
                    spriteBatch.Draw(ressource.cross, new Rectangle((int)position.X, (int)position.Y, 16, 16), Color.White);
                if (selec == true)
                {
                    spriteBatch.Draw(ressource.pixel, new Rectangle(message.Fenetre.X - 3, message.Fenetre.Y - 3, 3, message.Fenetre.Height + 3), Color.Red);
                    spriteBatch.Draw(ressource.pixel, new Rectangle(message.Fenetre.X - 3, message.Fenetre.Y - 3, message.Fenetre.Width + 6, 3), Color.Red);
                    spriteBatch.Draw(ressource.pixel, new Rectangle(message.Fenetre.X - 3, message.Fenetre.Height + message.Fenetre.Y, message.Fenetre.Width + 3, 3), Color.Red);
                    spriteBatch.Draw(ressource.pixel, new Rectangle(message.Fenetre.Width + message.Fenetre.X, message.Fenetre.Y, 3, message.Fenetre.Height + 3), Color.Red);
                }
            }
        }
    }
}
