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
        Rectangle fenetre;
        KeyboardState keyboardState;
        KeyboardState lastKeyboardState;
        Map map;
        Tile current_tile;
        Rectangle tileset;
        Map[,] listes_map;
        Donjon Donjon;
        Point actuel;
        int nb;
        string nombre;
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
            current_tile = new Tile(0, 0, 0);
            tileset = new Rectangle(fenetre.Width - ressource.tile.Width, 0, ressource.tile.Width, ressource.tile.Height);
            listes_map = new Map[5, 5];
            nb = 0;
            actuel = new Point();
            nombre = "";
        }
        public override void Update(GameTime gameTime)
        {
            lastKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();
            cursor.Update(gameTime, tileset, fenetre);
            text.update();
            if (Donjon == null)
                text.Is_shown = true;
            if (text.Is_shown && keyboardState.IsKeyDown(Keys.Enter))
                creation_donjon(text.Saisie);
            if (Donjon != null)
            {
                creation_map();
                selectionmap();
                if(nb < 10)
                    Donjon.Map[actuel.X, actuel.Y].Update(gameTime, @text.Saisie + @"\Map" + @"0" + @nb + @"\Map" + @"0" + @nb + @".txt", @text.Saisie + @"\Map" + @"0" + @nb + @"\collision" + @"0" + @nb + @".txt", text);
                else
                    Donjon.Map[actuel.X, actuel.Y].Update(gameTime, @text.Saisie + @"\Map" + @nb + @"\Map" + @nb + @".txt", @text.Saisie + @"\Map" + @nb + @"\collision" + @nb + @".txt", text);

            }
            if (text.Is_shown && keyboardState.IsKeyDown(Keys.F2))
            {
                map = new Map();
                map.load(text.Saisie + ".txt");
                text.Is_shown = false;
            }
            if (text.Is_shown == false && keyboardState.IsKeyDown(Keys.A))
                text.Is_shown = true;
        }
        public void selectionmap()
        {
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    if (new Rectangle(Data.mouseState.X, Data.mouseState.Y, 1, 1).Intersects(new Rectangle(600 + 32 * i, 300 + 32 * j, 16, 8))
                        && Data.mouseState.LeftButton == ButtonState.Pressed
                        && Data.prevMouseState.LeftButton != ButtonState.Pressed && Donjon.Map[i, j] != null)
                    {
                        actuel.X = i;
                        actuel.Y = j;
                    }
        }
        public void creation_map()
        {
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    if (new Rectangle(Data.mouseState.X, Data.mouseState.Y, 1, 1).Intersects(new Rectangle(600 + 32 * i, 300 + 32 * j, 16, 8))
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
                    }
                }
        }
        public void creation_donjon(string path)
        {
            string nombre;
            if (nb < 10)
                nombre = "0" + Convert.ToString(nb);
            else
                nombre = Convert.ToString(nb);

            System.IO.Directory.CreateDirectory(@text.Saisie + @"\Map" + @nombre);
            Donjon = new Donjon(path,null);
            Donjon.Ajout_map(0, 0, 0, text.Saisie);
            text.Is_shown = false;
        }
        public override void Draw(GameTime gameTime)
        {
            if (Donjon != null && Donjon.Map[actuel.X, actuel.Y] != null)
            {
                Donjon.Map[actuel.X, actuel.Y].Draw(spriteBatch, 16);
                spriteBatch.Draw(ressource.pixel, new Rectangle(600 + 32 * actuel.X, 300 + 32 * actuel.Y, 16, 1), Color.Red);
                spriteBatch.Draw(ressource.pixel, new Rectangle(600 + 32 * actuel.X, 300 + 32 * actuel.Y, 1, 8), Color.Red);
                spriteBatch.Draw(ressource.pixel, new Rectangle(600 + 32 * actuel.X, 300 + 32 * actuel.Y + 8, 16, 1), Color.Red);
                spriteBatch.Draw(ressource.pixel, new Rectangle(600 + 32 * actuel.X + 16, 300 + 32 * actuel.Y, 1, 8), Color.Red);
            }
            spriteBatch.Draw(ressource.tile, new Rectangle(fenetre.Width - ressource.tile.Width, 0, ressource.tile.Width, ressource.tile.Height), Color.White);
            //dessine les ligne de l'editeur de map
            for (int i = 0; i <= 32 * 16; i += 16)
            {
                spriteBatch.Draw(ressource.pixel, new Rectangle(i, 0, 1, 16 * 32), Color.FromNonPremultiplied(0, 0, 0, 250));
                spriteBatch.Draw(ressource.pixel, new Rectangle(0, i, 16 * 32, 1), Color.FromNonPremultiplied(0, 0, 0, 250));
            }
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    if (new Rectangle(Data.mouseState.X, Data.mouseState.Y, 1, 1).Intersects(new Rectangle(600 + 32 * i, 300 + 32 * j, 16, 8)))
                        spriteBatch.Draw(ressource.pixel, new Rectangle(600 + 32 * i, 300 + 32 * j, 16, 8), Color.FromNonPremultiplied(204, 0, 0, 50));
                    else
                        if (Donjon != null && Donjon.Map[i, j] != null && Donjon.Map[i, j].isCreate == true)
                            spriteBatch.Draw(ressource.pixel, new Rectangle(600 + 32 * i, 300 + 32 * j, 16, 8), Color.FromNonPremultiplied(51, 204, 0, 50));
                        else
                            spriteBatch.Draw(ressource.pixel, new Rectangle(600 + 32 * i, 300 + 32 * j, 16, 8), Color.FromNonPremultiplied(250, 250, 250, 50));

                }
            cursor.Draw(spriteBatch, fenetre);
            text.Draw(spriteBatch);
        }
    }
}
