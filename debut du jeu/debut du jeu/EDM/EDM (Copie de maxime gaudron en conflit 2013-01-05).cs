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


namespace debut_du_jeu
{
    public class EDM : GameScreen
    {
        Rectangle fenetre;

        KeyboardState keyboardState;

        KeyboardState lastKeyboardState;

        Cursor cursor;

        Vector2 mapSize;

        List<Tile> tile_list;

        public Rectangle Fenetre
        {
            get { return fenetre; }
            set { fenetre = value; }
        }

        public EDM(Game game, SpriteBatch spriteBatch)
            : base(game, spriteBatch)
        {
            tile_list = new List<Tile>();

            cursor = new Cursor(ressource.ARBRE);

            mapSize = new Vector2(game.Window.ClientBounds.Width, game.Window.ClientBounds.Height);

            fenetre = new Rectangle(0, 0, game.Window.ClientBounds.Width, game.Window.ClientBounds.Height); //taille de la fenetre
        }

        public override void Update(GameTime gameTime)
        {
            lastKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();

            cursor.Update(gameTime, mapSize);

            if (keyboardState.IsKeyDown(Keys.Enter))
            {
                tile_list.Add(new Tile(cursor._texture, cursor.Position));
            }
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Draw(ressource.pixel, fenetre, Color.Black);

            cursor.Draw(spriteBatch);

            foreach (Tile tile in tile_list)
                tile.Draw(spriteBatch);
        }
    }
}
