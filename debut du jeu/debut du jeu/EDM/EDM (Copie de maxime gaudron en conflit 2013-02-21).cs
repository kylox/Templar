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
        textbox text;

        Rectangle fenetre;

        KeyboardState keyboardState;

        KeyboardState lastKeyboardState;

        Cursor cursor;

        MouseState mouse;

        Vector2 mapSize = new Vector2(800, 1200);


        Map map;
        //taille de la fenetre
        public Rectangle Fenetre
        {
            get { return fenetre; }
            set { fenetre = value; }
        }

        public EDM(Game game, SpriteBatch spriteBatch)
            : base(game, spriteBatch)
        {

            cursor = new Cursor();
            fenetre = new Rectangle(0, 0, game.Window.ClientBounds.Width, game.Window.ClientBounds.Height); //taille de la fenetre
            MediaPlayer.IsMuted = true;
            text = new textbox(new Rectangle(game.Window.ClientBounds.Width / 3, game.Window.ClientBounds.Height / 3, 200, 100));
        }


        public override void Update(GameTime gameTime)
        {
            lastKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();

            if (text.Is_shown == false)
                cursor.Update(gameTime, new Vector2(800, 1200));

            text.update();

            //initialise une nouvelle map en faisant aparaitre la textbox
            if (map == null)
                text.Is_shown = true;

            //initialise une nouvelle map
            if (text.Is_shown && keyboardState.IsKeyDown(Keys.Enter))
            {
                Stream sr = new FileStream(text.Saisie + ".txt", FileMode.Create, FileAccess.ReadWrite);
                sr.Close();
                map = new Map(text.Saisie + ".txt");

                text.Is_shown = false;
            }

            //fait l'update de la map si elle existe
            if (map != null)
                map.Update(gameTime, text.Saisie + ".txt",cursor);
            mouse = Mouse.GetState();
        }

        public override void Draw(GameTime gameTime)
        {
            //dessine la map
            if (map != null)
                map.Draw(spriteBatch);

            //dessine la textbox
            text.Draw(spriteBatch);

            //dessine le caré rouge a gauche quand n voudra faire plusieur map;
            if (mouse.X <= 10)
            {
                spriteBatch.Draw(ressource.pixel, new Rectangle(0, 0, 10, fenetre.Height), Color.Red);
            }

            //dessinela position de la souris
            spriteBatch.DrawString(ressource.ecriture, mouse.X + "  " + mouse.Y, new Vector2(500, 0), Color.Red);

            //dessine le curseur 
            cursor.Draw(spriteBatch);
        }
    }
}
