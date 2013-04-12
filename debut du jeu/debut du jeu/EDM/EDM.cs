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
        int nb;
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
        }
        #region update & draw
        public override void Update(GameTime gameTime)
        {
            lastKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();
            cursor.Update(gameTime, tileset, fenetre);
            text.update();

            //initialise la textbox
            /*if (map == null)
                text.Is_shown = true;
           */
            if (Donjon == null)
                text.Is_shown = true;


            //charge une map
            if (text.Is_shown && keyboardState.IsKeyDown(Keys.F2))
            {
                map = new Map();
                map.load(text.Saisie + ".txt");
                text.Is_shown = false;
            }

            //refait apparaitre la texte boxe
            if (text.Is_shown == false && keyboardState.IsKeyDown(Keys.A))
                text.Is_shown = true;

            //creer une nouvelle map
            if (text.Is_shown && keyboardState.IsKeyDown(Keys.Enter))
                creation_donjon(text.Saisie);


            if (map != null)
                map.Update(gameTime, @text.Saisie + @"\Map" + @nb + @"\Map" + @nb + @".txt", text);
        }
        public void creation_donjon(string path)
        {
            System.IO.Directory.CreateDirectory(@text.Saisie + @"\Map" + @nb);
            Donjon = new Donjon(path);
            Donjon.Ajout_map(0, 0, 0, creation_map(0, 0, 0));
            text.Is_shown = false;
        }
        public Map creation_map(int nb, int i, int j)
        {
            Stream sr = new FileStream(@text.Saisie + @"\Map" + @nb + @"\Map" + @nb+ @".txt", FileMode.Create, FileAccess.ReadWrite);
            sr.Close();
            map = new Map();
            listes_map[i, j] = map;
            map.init(@text.Saisie + @"\Map" + @nb + @"\Map" + @nb + @".txt");
            //text.Is_shown = false;
            return map;
        }
        public override void Draw(GameTime gameTime)
        {
            if (map != null)
                map.Draw(spriteBatch, 16);

            spriteBatch.Draw(ressource.tile, new Rectangle(fenetre.Width - ressource.tile.Width, 0, ressource.tile.Width, ressource.tile.Height), Color.White);

            //dessine les ligne de l'editeur de map
            for (int i = 0; i <= 32 * 16; i += 16)
            {
                spriteBatch.Draw(ressource.pixel, new Rectangle(i, 0, 1, 16 * 32), Color.FromNonPremultiplied(0, 0, 0, 250));
                spriteBatch.Draw(ressource.pixel, new Rectangle(0, i, 16 * 32, 1), Color.FromNonPremultiplied(0, 0, 0, 250));
            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (new Rectangle(Data.mouseState.X, Data.mouseState.Y, 1, 1).Intersects(new Rectangle(600 + 32 * i, 300 + 32 * j, 16, 8)))
                        spriteBatch.Draw(ressource.pixel, new Rectangle(600 + 32 * i, 300 + 32 * j, 16, 8), Color.FromNonPremultiplied(204, 0, 0, 50));
                    else
                        spriteBatch.Draw(ressource.pixel, new Rectangle(600 + 32 * i, 300 + 32 * j, 16, 8), Color.FromNonPremultiplied(250, 250, 250, 50));
                }
            }
         
            cursor.Draw(spriteBatch, fenetre);
            text.Draw(spriteBatch);
        }
        #endregion
    }
}
