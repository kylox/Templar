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
    //defini l'ecran qui va etre afficher

    public abstract class GameScreen : Microsoft.Xna.Framework.DrawableGameComponent
    {
        List<GameComponent> components = new List<GameComponent>(); // la liste des composition de l'ecran (ce qui est cliquable)
        protected Game game; //jeux actuel 
        protected SpriteBatch spriteBatch; //ecran 

        public List<GameComponent> compenents // retourne la liste des composant de l'ecran 
        {
            get { return components; }
        }

        public GameScreen(Game game, SpriteBatch spriteBatch)
            : base(game)
        {
            this.game = game;
            this.spriteBatch = spriteBatch;
            
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            foreach (GameComponent component in components)
                if (component.Enabled == true)
                    component.Update(gameTime);
        }

        // affcihe l'ecran
        public virtual void Show()
        {
            this.Visible = true;
            this.Enabled = true;

            foreach (GameComponent componenet in components)
            {
                componenet.Enabled = true; // marche comme un bouton 

                if (componenet is DrawableGameComponent)
                    ((DrawableGameComponent)componenet).Visible = true; // affiche les composant 
            }
        }

        // cache l'ecran
        public virtual void hide()
        {
            this.Visible = false;
            this.Enabled = false;

            foreach (GameComponent componenet in components)
            {
                componenet.Enabled = false; //n'est plus selectionable

                if (componenet is DrawableGameComponent)
                    ((DrawableGameComponent)componenet).Visible = false;
            }


        }

        public override void Draw(GameTime gameTime) // dessine les composant de l'ecran (la liste Item)
        {
            base.Draw(gameTime);
            foreach (GameComponent component in components)
                if (component is DrawableGameComponent && ((DrawableGameComponent)component).Visible)
                    ((DrawableGameComponent)component).Draw(gameTime);
        }
    }
}
