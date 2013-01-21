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
    //La dernière classe à préparer est celle du curseur. Il s’agit d’un simple sprite qui devra se
    //déplacer selon les entrées clavier de l’utilisateur.
    public class Cursor
    {
        KeyboardState keyboardState;
        KeyboardState lastKeyboardState;

        Texture2D Texture;
        Vector2 position;
        Vector2 deplacement;

        public Texture2D _texture
        {
            get { return Texture; }
            set { Texture = value; }
        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }


        public Cursor(Texture2D texture)
        {
            deplacement = new Vector2(0, 0);
            position = new Vector2(0, 0);
            Texture = texture;
        }

        public void Update(GameTime gameTime, Vector2 mapSize)
        {
            lastKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();

            position = new Vector2((int)deplacement.X * 16, (int)deplacement.Y * 16);

            //choisis la texture
            if (keyboardState.IsKeyDown(Keys.F5) && lastKeyboardState.IsKeyUp(Keys.F5))
                Texture = ressource.ARBRE;
            

            else if (keyboardState.IsKeyDown(Keys.F6) && lastKeyboardState.IsKeyUp(Keys.F6))
                Texture = ressource.SOL;
            

            else if (keyboardState.IsKeyDown(Keys.F7) && lastKeyboardState.IsKeyUp(Keys.F7))
                Texture = ressource.STATUT;
            
            //deplace le curseur
            if (keyboardState.IsKeyDown(Keys.J) && lastKeyboardState.IsKeyUp(Keys.J) && position.X > 0)
                deplacement.X--;
            
            if (keyboardState.IsKeyDown(Keys.L) && lastKeyboardState.IsKeyUp(Keys.L) && position.X < mapSize.X - 1)
                deplacement.X++;
            
            if (keyboardState.IsKeyDown(Keys.I) && lastKeyboardState.IsKeyUp(Keys.I) && position.Y > 0)
                deplacement.Y--;
            
            if (keyboardState.IsKeyDown(Keys.K) && lastKeyboardState.IsKeyUp(Keys.K) && position.Y < mapSize.Y - 1)
                deplacement.Y++;
            
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, position, Color.White);
        }
    }
}
