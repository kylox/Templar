using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
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
        string op1 = "", op2 = "";
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
        public creat_perso(Game game, SpriteBatch spriteBatch, Texture2D image, bool language)
            : base(game, spriteBatch)
        {
            XmlReader reader;

            reader = XmlReader.Create("Francais.xml");
            if (!language)
            {
                reader = XmlReader.Create("English.xml");
            }
            while (reader.Read())
                while (reader.NodeType != XmlNodeType.EndElement)
                {
                    reader.Read();
                    if (reader.Name == "suivant")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op1 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                    if (reader.Name == "liste")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op2 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                }
            this.texture = image;
            rectangle = new Rectangle(0, 0, game.Window.ClientBounds.Width, game.Window.ClientBounds.Height); //taille de l'ecran 
            Change = false;
            Frameligne = 0;
            donjons = new List<string>();
            selec = 0;
            foreach (string dr in System.IO.Directory.GetDirectories(@"Donjons"))
                donjons.Add(dr.Substring(8));
            if (donjons.Count != 0)
                if (donjons[0] != null)
                    donjon = donjons[0];
        }
        public override void Update(GameTime gameTime)
        {
            if (new Rectangle(Data.mouseState.X, Data.mouseState.Y, 1, 1).Intersects(new Rectangle(500, 200, 50, 50)) && Data.mouseState.LeftButton == ButtonState.Pressed)
                Change = true;
            int y = 0;          
            foreach (string dr in System.IO.Directory.GetDirectories(@"Donjons"))
                if (!donjons.Contains(dr.Substring(8)))
                    donjons.Add(dr.Substring(8));
            foreach (string s in donjons)
            {
                if (new Rectangle(Data.mouseState.X, Data.mouseState.Y, 1, 1).Intersects(new Rectangle(100, 100 + y, s.Length * (int)s.LongCount() + 20, 20)) && Data.mouseState.LeftButton == ButtonState.Pressed && Data.prevMouseState.LeftButton == ButtonState.Released)
                {
                    donjon = donjons[y / 30];
                    selec = y;
                }
                y += 30;
            }
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Draw(texture, rectangle, Color.Black);
            spriteBatch.DrawString(ressource.ecriture, op2, new Vector2(100, 50), Color.Wheat);
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
            spriteBatch.DrawString(ressource.ecriture, op1, new Vector2(500, 200), higlight);
            spriteBatch.Draw(ressource.sprite_player, new Rectangle(100, 300, 100, 153), new Rectangle(0, 0, 32, 48), Color.White);
            base.Draw(gameTime);
        }
    }
}
