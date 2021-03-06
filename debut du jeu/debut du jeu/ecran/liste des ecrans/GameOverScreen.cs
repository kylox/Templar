﻿using System;
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
    //futur ecran de game over mais fonctionne pas va falloir attendre !
    class GameOverScreen : GameScreen
    {
        Texture2D image;
        menugenerale menugenerale;
        Rectangle rec;

        public int SelectedIndex
        {
            get { return menugenerale.SelectedIndex; }
            set { menugenerale.SelectedIndex = value; }
        }
        //main
        public GameOverScreen(Game game, gamemain main, SpriteBatch spritebatch, SpriteFont spritefont, Texture2D image, bool language)
            : base(game, spritebatch)
        {
            XmlReader reader;

            reader = XmlReader.Create("Francais.xml");
            if (!language)
            {
                reader = XmlReader.Create("English.xml");
            }
            string op1 = "", op2 = "", op3 = "";
            while (reader.Read())
                while (reader.NodeType != XmlNodeType.EndElement)
                {
                    reader.Read();
                    if (reader.Name == "recommencer")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op1 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                    if (reader.Name == "retour")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op2 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                    if (reader.Name == "fin")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op3 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                }

            string[] menuItems = { op1, op2, op3 };
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
