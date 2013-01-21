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
    class menudepause:GameScreen
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
        public menudepause(Game game, SpriteBatch spritebatch, SpriteFont spritefont, Texture2D image):base(game,spritebatch)
        {
            string[] menuItems = { "inventaire", "caracteristique", "sauvegarde/charger", "retour au menu principale"};
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
