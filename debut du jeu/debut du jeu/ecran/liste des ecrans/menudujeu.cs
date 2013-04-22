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
    class menudujeu : GameScreen
    {
        Texture2D texture;
        Rectangle rectangle;
        menugenerale menugeneral;

        public int SelectedIndex //determine la selection du men
        {
            get { return menugeneral.SelectedIndex; }
            set { menugeneral.SelectedIndex = value; }
        }
        public menudujeu(Game game, SpriteBatch spriteBatch, SpriteFont spriteFont, Texture2D image)
            : base(game, spriteBatch)
        {
            string[] menuItems = { "nouveau jeu", "continue", "retour au menu principal" }; //les selcetions possible
            this.texture = image; //le fond d'ecrand
            menugeneral = new menugenerale(game, spriteBatch, spriteFont, menuItems); //rappel de la classe principale 
            compenents.Add(menugeneral); //ajoute les selection possible pour l'affichage
            rectangle = new Rectangle(0, 0, game.Window.ClientBounds.Width, game.Window.ClientBounds.Height); //taille de l'ecran 
            //note : pensez a faire des variable pour modifier taille d'ecran
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Draw(texture, rectangle, Color.White); // dessine la fenetre suivant son fond d'ecran sa taille et sa couleur
            base.Draw(gameTime);
        }


    }
}
