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


namespace Templar
{
    class menudepause : GameScreen
    {
        //fields
        Texture2D image;
        menugenerale menugenerale;
        Rectangle rec;
        public int SelectedIndex
        {
            get { return menugenerale.SelectedIndex; }
            set { menugenerale.SelectedIndex = value; }
        }
        //main
        public menudepause(Game game, SpriteBatch spritebatch, SpriteFont spritefont, Texture2D image, bool language)
            : base(game, spritebatch)
        {
            XmlReader reader;

            reader = XmlReader.Create("Francais.xml");
            if (!language)
            {
                reader = XmlReader.Create("English.xml");
            }
            string op1 = "", op2 = "", op3 = "", op4 = "", op5 = "";
            while (reader.Read())
                while (reader.NodeType != XmlNodeType.EndElement)
                {
                    reader.Read();
                    if (reader.Name == "inventaire")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op1 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                    if (reader.Name == "caract")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op2 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                    if (reader.Name == "sauv")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op3 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                    if (reader.Name == "charger")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op4 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                    if (reader.Name == "retour")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op5 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                }

            string[] menuItems = { op1, op2, op3, op4, op5 };
            this.image = image;
            menugenerale = new menugenerale(game, spriteBatch, spritefont, menuItems);
            compenents.Add(menugenerale);
            rec = new Rectangle(0, 0, game.Window.ClientBounds.Width, game.Window.ClientBounds.Height);

        }

        //methode 

        //update && draw
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Draw(image, rec, Color.Maroon);
            base.Draw(gameTime);
        }

    }
}
