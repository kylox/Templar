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
    public static class cursor
    {
        #region variable
        static KeyboardState keyboardState;
        static KeyboardState lastKeyboardState;
        //texture du curseur
        static Texture2D Texture = ressource.tile;
        //sa position
        static Vector2 position = new Vector2(0, 0);
        //son deplacement ?
        static Vector2 deplacement = new Vector2(0, 0);
        //l'id qu'il represente sur le tileset 
        static Vector2 ID = new Vector2(0, 0);
        #endregion
        #region field
        //retourne l'id
        static public Vector2 iD
        {
            get { return ID; }
            set { ID = value; }
        }
        //retourne la texture 
        public static Texture2D _texture
        {
            get { return Texture; }
            set { Texture = value; }
        }

        public static Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        #endregion
        #region method
        //change l'id du tile en fonction des touches zqsd
        public static void change_ID(KeyboardState KeyboardState)
        {

            if (keyboardState.IsKeyDown(Keys.D) && lastKeyboardState.IsKeyUp(Keys.D))
            {
                ID.X++;
                if (ID.X > 2)
                    ID.X = 0;
            }

            if (keyboardState.IsKeyDown(Keys.Q) && lastKeyboardState.IsKeyUp(Keys.Q))
            {
                ID.X--;
                if (ID.X < 0)
                    ID.X = 2;
            }

            if (keyboardState.IsKeyDown(Keys.S) && lastKeyboardState.IsKeyUp(Keys.S))
            {
                ID.Y++;
                if (ID.Y > 4)
                    ID.Y = 0;
            }

            if (keyboardState.IsKeyDown(Keys.Z) && lastKeyboardState.IsKeyUp(Keys.Z))
            {
                ID.Y--;
                if (ID.Y < 0)
                    ID.Y = 4;
            }

        }

        public static char vec_to_id(Vector2 vec)
        {
            int symb = (int)vec.X * 10 + (int)vec.Y;
            char C = Convert.ToChar(symb + 33);

            return C;
        }

        public static Vector2 id_to_vec(char C)
        {
            Vector2 vec;
            int nb = Convert.ToInt32(C) - 33;

            vec.X = nb / 10;
            vec.Y = nb % 10;

            return vec;
        }

        public static void mouve(KeyboardState keyboardState, Vector2 mapSize)
        {
            if (keyboardState.IsKeyDown(Keys.J) && lastKeyboardState.IsKeyUp(Keys.J) && position.X > 0)
                deplacement.X--;

            if (keyboardState.IsKeyDown(Keys.L) && lastKeyboardState.IsKeyUp(Keys.L) && position.X < mapSize.X - 1)
                deplacement.X++;

            if (keyboardState.IsKeyDown(Keys.I) && lastKeyboardState.IsKeyUp(Keys.I) && position.Y > 0)
                deplacement.Y--;

            if (keyboardState.IsKeyDown(Keys.K) && lastKeyboardState.IsKeyUp(Keys.K) && position.Y < mapSize.Y - 1)
                deplacement.Y++;
        }
        #endregion

        #region upadte & draw
        public static void Update(GameTime gameTime, Vector2 mapSize )
        {
            lastKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();
            position = new Vector2((int)deplacement.X * 32, (int)deplacement.Y * 32);
            mouve(keyboardState, mapSize);
            change_ID(keyboardState);
      
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            //dessine le curseur avec sa bonne texture
            spriteBatch.Draw(Texture, new Rectangle((int)position.X, (int)position.Y, 32 * 2 / 3, 32 * 2 / 3), Tile.tile(ID), Color.White);

          
        }

        #endregion
    }
}
