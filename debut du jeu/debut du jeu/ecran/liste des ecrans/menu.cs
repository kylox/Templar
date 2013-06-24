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
    //cette ecran est l'eran principale 
    class menu : GameScreen //voir menu du jeu 
    {
        menugenerale menugeneral;
        Texture2D image;
        Rectangle imageRectangle;
        //seletion du futur menu
        public int SelectedIndex
        {
            get { return menugeneral.SelectedIndex; }
            set { menugeneral.SelectedIndex = value; }
        }
        public menu(Game game, SpriteBatch spriteBatch, SpriteFont spriteFont, Texture2D image, bool language)
            : base(game, spriteBatch)
        {
            //les sous menu disponible 
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
                    if (reader.Name == "unj")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op1 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                    if (reader.Name == "deuxj")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op2 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                    if (reader.Name == "edm")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op3 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                    if (reader.Name == "options")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op4 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                    if (reader.Name == "fin")
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
            menugeneral = new menugenerale(game, spriteBatch, spriteFont, menuItems);
            compenents.Add(menugeneral);
            this.image = image;
            imageRectangle = new Rectangle(0, 0, Game.Window.ClientBounds.Width, Game.Window.ClientBounds.Height);
            MediaPlayer.IsMuted = false;
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Draw(image, imageRectangle, Color.White);
            base.Draw(gameTime);
        }
    }
}
