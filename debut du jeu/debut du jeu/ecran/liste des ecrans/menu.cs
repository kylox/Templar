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

        public menu(Game game, SpriteBatch spriteBatch, SpriteFont spriteFont, Texture2D image)
            : base(game, spriteBatch)
        {
            //les sous menu disponible 
            string[] menuItems = { "1 joueur", "2 joueur", "editeur de map", "option", "quitter" };
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
