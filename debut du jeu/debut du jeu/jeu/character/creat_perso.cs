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
    class creat_perso : GameScreen
    {
        Texture2D texture;
        MouseState mouse;
        KeyboardState keyboard;
        Rectangle rectangle;
        bool Change;
        int Frameligne;

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

        public creat_perso(Game game, SpriteBatch spriteBatch, Texture2D image)
            : base(game, spriteBatch)
        {

            this.texture = image;
            rectangle = new Rectangle(0, 0, game.Window.ClientBounds.Width, game.Window.ClientBounds.Height); //taille de l'ecran 
            Change = false;
            Frameligne = 0;
        }

        public override void Update(GameTime gameTime)
        {
            mouse = Mouse.GetState();
            keyboard = Keyboard.GetState();

            if (new Rectangle(mouse.X, mouse.Y, 1, 1).Intersects(new Rectangle(500, 200, 50, 50)) && mouse.LeftButton == ButtonState.Pressed)
                Change = true;

            if (keyboard.IsKeyDown(Keys.Right))
            {
                Frameligne++;

                if (Frameligne > 18)
                    Frameligne = 0;
            }

            if (keyboard.IsKeyDown(Keys.Left))
            {
                Frameligne--;

                if (Frameligne < 0)
                    Frameligne = 18;
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Draw(texture, rectangle, Color.Black);

            Color higlight = Color.White;

            if (new Rectangle(mouse.X, mouse.Y, 1, 1).Intersects(new Rectangle(500, 200, 50, 50)))
                higlight = Color.Red;

            spriteBatch.DrawString(ressource.ecriture, "SUIVANT", new Vector2(500, 200), higlight);
            spriteBatch.Draw(ressource.sprite_player, new Rectangle(100, 300, 100, 200), new Rectangle(0, 0, 50, 100), Color.White);
            spriteBatch.Draw(ressource.tete_player, new Rectangle(125, 260, 78, 100), new Rectangle(0, 50 * frameligne, 39, 50), Color.White);

            base.Draw(gameTime);
        }
    }
}
