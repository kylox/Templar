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
using System.IO;


namespace Templar
{
    class creat_perso : GameScreen
    {
        Texture2D texture;
        Rectangle rectangle;
        bool Change;
        int Frameligne;
        int selec;
        List<string> donjons;
        public string donjon;
        public int frameligne
        {
            get { return Frameligne; }
            set { value = Frameligne; }
        }
        public bool change
        {
            get { return Change; }
            set { Change = value; }
        }
        public creat_perso(Game game, SpriteBatch spriteBatch, Texture2D image)
            : base(game, spriteBatch)
        {
            this.texture = image;
            rectangle = new Rectangle(0, 0, game.Window.ClientBounds.Width, game.Window.ClientBounds.Height); //taille de l'ecran 
            Change = false;
            Frameligne = 0;
            donjons = new List<string>();
            selec = 0;
            foreach (string dr in System.IO.Directory.GetDirectories(@"Donjons"))
            {
                donjons.Add(dr.Substring(8));
            }
            if (donjons.Count != 0)
                if (donjons[0] != null)
                    donjon = donjons[0];
        }
        public override void Update(GameTime gameTime)
        {
            if (new Rectangle(Data.mouseState.X, Data.mouseState.Y, 1, 1).Intersects(new Rectangle(500, 200, 50, 50)) && Data.mouseState.LeftButton == ButtonState.Pressed)
                Change = true;
            int y = 0;

            foreach (string s in donjons)
            {
                if (new Rectangle(Data.mouseState.X, Data.mouseState.Y, 1, 1).Intersects(new Rectangle(100, 100 + y, s.Length * (int)s.LongCount() + 20, 20)) && Data.mouseState.LeftButton == ButtonState.Pressed && Data.prevMouseState.LeftButton == ButtonState.Released)
                {
                    donjon = donjons[y / 30];
                    selec = y;
                }
                y += 30;
            }
            //if (keyboard.IsKeyDown(Keys.Right))
            //{
            //    Frameligne++;

            //    if (Frameligne > 18)
            //        Frameligne = 0;
            //}

            //if (keyboard.IsKeyDown(Keys.Left))
            //{
            //    Frameligne--;

            //    if (Frameligne < 0)
            //        Frameligne = 18;
            //}
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Draw(texture, rectangle, Color.Black);
            int y = 0;

            Color higlight = Color.White;

            if (new Rectangle(Data.mouseState.X, Data.mouseState.Y, 1, 1).Intersects(new Rectangle(500, 200, 50, 50)))
                higlight = Color.Red;

            foreach (string s in donjons)
            {
                if (new Rectangle(Data.mouseState.X, Data.mouseState.Y, 1, 1).Intersects(new Rectangle(100, 100 + y, s.Length * (int)s.LongCount() + 20, 20)))
                    spriteBatch.DrawString(ressource.ecriture, s, new Vector2(100, 100 + y), Color.Red);
                else
                    spriteBatch.DrawString(ressource.ecriture, s, new Vector2(100, 100 + y), Color.Wheat);

                if (selec == y)
                    spriteBatch.DrawString(ressource.ecriture, s, new Vector2(100, 100 + y), Color.Red);

                y += 30;
            }
            spriteBatch.DrawString(ressource.ecriture, "SUIVANT", new Vector2(500, 200), higlight);
            spriteBatch.Draw(ressource.sprite_player, new Rectangle(100, 300, 100, 200), new Rectangle(0, 0, 32, 48), Color.White);
            //spriteBatch.Draw(ressource.tete_player, new Rectangle(125, 260, 78, 100), new Rectangle(0, 50 * frameligne, 39, 50), Color.White);
            base.Draw(gameTime);
        }
    }
}
