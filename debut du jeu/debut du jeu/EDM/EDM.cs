using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace Templar
{
    public class EDM : GameScreen
    {
        Rectangle fenetre;

        KeyboardState keyboardState;

        KeyboardState lastKeyboardState;

        Cursor cursor;

        Vector2 mapSize = new Vector2(800, 1200);

        List<Button> tile_list;
        Map map;
       
        public Rectangle Fenetre
        {
            get { return fenetre; }
            set { fenetre = value; }
        }

        public EDM(Game game, SpriteBatch spriteBatch)
            : base(game, spriteBatch)
        {
            tile_list = new List<Button>();
            map = new Map();
            cursor = new Cursor(ressource.ARBRE);
            fenetre = new Rectangle(0, 0, game.Window.ClientBounds.Width, game.Window.ClientBounds.Height); //taille de la fenetre
            MediaPlayer.IsMuted = true;
        }

        public override void Update(GameTime gameTime)
        {
            lastKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();

            cursor.Update(gameTime, mapSize);
            map.Update(gameTime);

             if (keyboardState.IsKeyDown(Keys.Enter))
            {
                tile_list.Add(new Button(cursor.Position,cursor._texture));
            }
        }

        public override void Draw(GameTime gameTime)
        {
            //spriteBatch.Draw(ressource.map, fenetre, Color.White);

            map.Draw(spriteBatch);
            foreach (Button tile in tile_list)
                tile.draw(spriteBatch);

            cursor.Draw(spriteBatch);
        }
    }
}
