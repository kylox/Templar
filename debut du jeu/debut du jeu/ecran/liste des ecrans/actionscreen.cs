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
    //la classe USELESS !!! ca sert a rien de regarder ce qu'il y a dedans
    class actionscreen : GameScreen
    {
        MouseState mouse;
        Texture2D image;
        Rectangle fenetre;


        public Rectangle Fenetre
        {
            get { return fenetre; }
            set { fenetre = value; }

        }

        public actionscreen(Game game, SpriteBatch spriteBatch, Texture2D image)
            : base(game, spriteBatch)
        {
            this.image = image;
            fenetre = new Rectangle(0, 0, game.Window.ClientBounds.Width, game.Window.ClientBounds.Height);
        }

        public override void Update(GameTime gameTime)
        {
            mouse = Mouse.GetState();
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Draw(image, fenetre, Color.White);
            base.Draw(gameTime);
        }

    }
}
