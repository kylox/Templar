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
        }
        #region update & draw
        public override void Update(GameTime gameTime)
        {
            lastKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();

            cursor.Update(gameTime, tileset, fenetre);
            text.update();

            //initialise la textbox
            if (map == null)
                text.Is_shown = true;

            //charge une map
            if (text.Is_shown && keyboardState.IsKeyDown(Keys.F2))
            {
                map = new Map(text.Saisie + ".txt");
                map.load(text.Saisie + ".txt");
                text.Is_shown = false;
            }

            //refait apparaitre la texte boxe
            if (text.Is_shown == false && keyboardState.IsKeyDown(Keys.A))
                text.Is_shown = true;

            //creer une nouvelle map
            if (text.Is_shown && keyboardState.IsKeyDown(Keys.Enter))
            {
                Stream sr = new FileStream(text.Saisie + ".txt", FileMode.Create, FileAccess.ReadWrite);
                sr.Close();
                map = new Map(text.Saisie + ".txt");
                map.init(text.Saisie + ".txt");
                text.Is_shown = false;
            }

            if (map != null)
                map.Update(gameTime, text.Saisie + ".txt", text);
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

            cursor.Draw(spriteBatch,fenetre);
            text.Draw(spriteBatch);
        }
        #endregion
    }
}
