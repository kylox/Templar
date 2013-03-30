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
        MouseState mouse;
        Vector2 mapSize = new Vector2(800, 1200);
        Map map;
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
        }
       
        #region update & draw
        public override void Update(GameTime gameTime)
        {
            lastKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();

            if (text.Is_shown == false)
                cursor.Update(gameTime, mapSize);
            
            text.update();
          
                if (map == null)
                    text.Is_shown = true;
                      
            if (text.Is_shown && keyboardState.IsKeyDown(Keys.F2))
            {
                map = new Map(text.Saisie + ".txt");
                map.load(text.Saisie + ".txt");
                text.Is_shown = false;
            }

            if (text.Is_shown == false && keyboardState.IsKeyDown(Keys.A))
            {
                text.Is_shown = true;
            }

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
           
            
            mouse = Mouse.GetState();
        }

        public override void Draw(GameTime gameTime)
        {
            if (map != null)
                map.Draw(spriteBatch);

            

            if (mouse.X <= 10)
            {
                spriteBatch.Draw(ressource.pixel, new Rectangle(0, 0, 10, fenetre.Height), Color.Red);
            }
            cursor.Draw(spriteBatch);
            text.Draw(spriteBatch);
        }
        #endregion
    }
}
