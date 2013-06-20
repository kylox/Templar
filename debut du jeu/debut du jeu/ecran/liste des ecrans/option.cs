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
    class option : GameScreen // pour plus d'info voir la classe menudujeu c'est la meme chose ! 
    {
        Texture2D texture;
        Rectangle rectangle;
        menugenerale menugenrale;
        BUTTON plus;
        BUTTON moin;
        MouseEvent mouse;

        public int SelectedIndex
        {
            get { return menugenrale.SelectedIndex; }
            set { menugenrale.SelectedIndex = value; }
        }

        public option(Game game, SpriteBatch spriteBatch, SpriteFont spriteFont, Texture2D _texture, bool language)
            : base(game, spriteBatch)
        {
            XmlReader reader;

            reader = XmlReader.Create("Francais.xml");
            if (!language)
            {
                reader = XmlReader.Create("English.xml");
            }

            string op1 = "", op2 = "", op3 = "", op4 = "", op5 = "", op6 = "";

            while (reader.Read())
            {
                {
                    while (reader.NodeType != XmlNodeType.EndElement)
                    {
                        reader.Read();
                        if (reader.Name == "pleinecran")
                        {
                            while (reader.NodeType != XmlNodeType.EndElement)
                            {
                                reader.Read();
                                if (reader.NodeType == XmlNodeType.Text)
                                {
                                    op1 = reader.Value.ToString();
                                }
                            }
                            reader.Read();
                        } 
                        if (reader.Name == "fenetre")
                        {
                            while (reader.NodeType != XmlNodeType.EndElement)
                            {
                                reader.Read();
                                if (reader.NodeType == XmlNodeType.Text)
                                {
                                    op2 = reader.Value.ToString();
                                }
                            }

                            reader.Read();
                        } 
                        if (reader.Name == "activer")
                        {
                            while (reader.NodeType != XmlNodeType.EndElement)
                            {
                                reader.Read();
                                if (reader.NodeType == XmlNodeType.Text)
                                {
                                    op3 = reader.Value.ToString();
                                }
                            }

                            reader.Read();
                        }
                        if (reader.Name == "desactiver")
                        {
                            while (reader.NodeType != XmlNodeType.EndElement)
                            {
                                reader.Read();
                                if (reader.NodeType == XmlNodeType.Text)
                                {
                                    op4 = reader.Value.ToString();
                                }
                            }

                            reader.Read();
                        }
                        if (reader.Name == "langue")
                        {
                            while (reader.NodeType != XmlNodeType.EndElement)
                            {
                                reader.Read();
                                if (reader.NodeType == XmlNodeType.Text)
                                {
                                    op5 = reader.Value.ToString();
                                }
                            }

                            reader.Read();
                        }
                        if (reader.Name == "retour")
                        {
                            while (reader.NodeType != XmlNodeType.EndElement)
                            {
                                reader.Read();
                                if (reader.NodeType == XmlNodeType.Text)
                                {
                                    op6 = reader.Value.ToString();
                                }
                            }

                            reader.Read();
                        }
                    } 
                } 
            }

            string[] menuItems = { op1, op2, op3, op4, op5, op6 };
            plus = new BUTTON(ressource.plus, new Rectangle(game.Window.ClientBounds.Height / 2, game.Window.ClientBounds.Width / 2, 10, 10));
            moin = new BUTTON(ressource.moin, new Rectangle(game.Window.ClientBounds.Height / 2, game.Window.ClientBounds.Width / 2 + 15, 10, 10));
            mouse = new MouseEvent();
            this.texture = _texture;
            menugenrale = new menugenerale(game, spriteBatch, spriteFont, menuItems);
            compenents.Add(menugenrale);
            rectangle = new Rectangle(0, 0, game.Window.ClientBounds.Width, game.Window.ClientBounds.Height);
        }
        private void click_down(MouseEvent mouse)
        {


        }

        public override void Update(GameTime gameTime)
        {
            if (mouse.getMousecontainer().Intersects(plus.Hitbox_button))
                MediaPlayer.Volume += 0.1f;

            if (mouse.getMousecontainer().Intersects(moin.Hitbox_button))
                MediaPlayer.Volume -= 0.1f;

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
            plus.draw(spriteBatch);
            moin.draw(spriteBatch);
            spriteBatch.DrawString(ressource.ecriture, "niveau musique " + (int)(MediaPlayer.Volume * 100), new Vector2(500, 500), Color.Yellow);
            spriteBatch.DrawString(ressource.ecriture, "niveau sonore des effet du jeu " + (int)(SoundEffect.MasterVolume * 100), new Vector2(500, 515), Color.Yellow);
            base.Draw(gameTime);
        }
    }
}
