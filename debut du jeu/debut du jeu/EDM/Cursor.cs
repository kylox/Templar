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
    public static class cursor
    {
        static Rectangle mobs = new Rectangle(0, 18 * 16 + 7, 32 * 15, 48);
        static Rectangle obj = new Rectangle(27 * 16, 48, 32 * 7, 32 * 7);
        public static bool position = false;
        static Texture2D Texture = ressource.objet_map;
        static Vector2 ID = new Vector2(0, 0);
        static public Vector2 iD
        {
            get { return ID; }
            set { ID = value; }
        }
        public static Texture2D _texture
        {
            get { return Texture; }
            set { Texture = value; }
        }
        public static bool selected;
        public static bool selected_mob;
        public static bool selec_obj;
        static bool display_name = false;
        static Items item = new Items(new Vector2(0, 0));
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
            selected = false;
            vec.X = nb / 10;
            vec.Y = nb % 10;

            return vec;
        }
        public static void Update(GameTime gameTime, Rectangle tileset, Rectangle fenetre)
        {
            if (new Rectangle(Data.mouseState.X, Data.mouseState.Y, 1, 1).Intersects(tileset) &&
                Data.mouseState.LeftButton == ButtonState.Pressed &&
                Data.prevMouseState.LeftButton == ButtonState.Released)
            {
                selected = true;
                selected_mob = false;
                selec_obj = false;
                ID.X = Math.Abs(((fenetre.Width - Data.mouseState.X) / 32) - 5);
                ID.Y = Data.mouseState.Y / 32;

            }
            if (new Rectangle(Data.mouseState.X, Data.mouseState.Y, 1, 1).Intersects(mobs) &&
                Data.mouseState.LeftButton == ButtonState.Pressed &&
                Data.prevMouseState.LeftButton == ButtonState.Released)
            {
                selected = false;
                selec_obj = false;
                selected_mob = true;
                ID.X = (Data.mouseState.X) / 32;
                if (ID.X == 4)
                    ID.X = 3;
                ID.Y = 0;
            }

            if (new Rectangle(Data.mouseState.X, Data.mouseState.Y, 1, 1).Intersects(obj) &&
               Data.mouseState.LeftButton == ButtonState.Pressed &&
               Data.prevMouseState.LeftButton == ButtonState.Released)
            {
                display_name = true;
                selected = false;
                selec_obj = true;
                selected_mob = false;
                ID.X = (Data.mouseState.X - obj.X) / 32;
                ID.Y = (Data.mouseState.Y - obj.Y) / 32;
            }

            if (new Rectangle(Data.mouseState.X, Data.mouseState.Y, 1, 1).Intersects(obj))
                display_name = true;

        }
        public static void Draw(SpriteBatch spriteBatch, Rectangle fenetre)
        {
            if (selected)
            {
                spriteBatch.Draw(ressource.pixel, new Rectangle((int)fenetre.Width - (int)Math.Abs(ID.X - 6) * 32, (int)ID.Y * 32, 32, 2), Color.Red);
                spriteBatch.Draw(ressource.pixel, new Rectangle((int)fenetre.Width - (int)Math.Abs(ID.X - 6) * 32, (int)ID.Y * 32, 2, 32), Color.Red);
                spriteBatch.Draw(ressource.pixel, new Rectangle((int)fenetre.Width - (int)Math.Abs(ID.X - 6) * 32, (int)ID.Y * 32 + 32, 34, 2), Color.Red);
                spriteBatch.Draw(ressource.pixel, new Rectangle((int)fenetre.Width - (int)Math.Abs(ID.X - 6) * 32 + 32, (int)ID.Y * 32, 2, 34), Color.Red);
            }
            if (selected_mob)
            {
                if (ID.X == 3 || ID.X == 4)
                {
                    spriteBatch.Draw(ressource.pixel, new Rectangle((int)3 * 32, 18 * 16 + 7, 64, 2), Color.Red);
                    spriteBatch.Draw(ressource.pixel, new Rectangle((int)3 * 32, 18 * 16 + 7, 2, 48), Color.Red);
                    spriteBatch.Draw(ressource.pixel, new Rectangle((int)3 * 32, 18 * 16 + 48 + 7, 66, 2), Color.Red);
                    spriteBatch.Draw(ressource.pixel, new Rectangle((int)3 * 32 + 64, 18 * 16 + 7, 2, 50), Color.Red);
                }
                else
                {
                    spriteBatch.Draw(ressource.pixel, new Rectangle((int)ID.X * 32, 18 * 16 + 7, 32, 2), Color.Red);
                    spriteBatch.Draw(ressource.pixel, new Rectangle((int)ID.X * 32, 18 * 16 + 7, 2, 48), Color.Red);
                    spriteBatch.Draw(ressource.pixel, new Rectangle((int)ID.X * 32, 18 * 16 + 48 + 7, 34, 2), Color.Red);
                    spriteBatch.Draw(ressource.pixel, new Rectangle((int)ID.X * 32 + 32, 18 * 16 + 7, 2, 50), Color.Red);
                }
            }
            if (selec_obj)
            {
                spriteBatch.Draw(ressource.pixel, new Rectangle((int)ID.X * 32 + obj.X, (int)ID.Y * 32 + obj.Y, 32, 2), Color.Red);
                spriteBatch.Draw(ressource.pixel, new Rectangle((int)ID.X * 32 + obj.X, (int)ID.Y * 32 + obj.Y, 2, 32), Color.Red);
                spriteBatch.Draw(ressource.pixel, new Rectangle((int)ID.X * 32 + obj.X, (int)ID.Y * 32 + 32 + obj.Y, 34, 2), Color.Red);
                spriteBatch.Draw(ressource.pixel, new Rectangle((int)ID.X * 32 + 32 + obj.X, (int)ID.Y * 32 + obj.Y, 2, 34), Color.Red);
            }
            if (display_name)
            {
                if (Data.mouseState.X +(int)ressource.ecriture.MeasureString(item.display_name(new Vector2((Data.mouseState.X - obj.X) / 32,
                    (Data.mouseState.Y - obj.Y) / 32))).X > fenetre.Width)
                {
                    spriteBatch.Draw(ressource.pixel, new Rectangle(
                        Data.mouseState.X - 
                        (Data.mouseState.X +
                        (int)ressource.ecriture.MeasureString(
                            item.display_name(new Vector2((Data.mouseState.X - obj.X) / 32,(Data.mouseState.Y - obj.Y) / 32))).X 
                        - fenetre.Width),
                        Data.mouseState.Y, 
                        (int)ressource.ecriture.MeasureString(
                            item.display_name(new Vector2((Data.mouseState.X - obj.X) / 32, (Data.mouseState.Y - obj.Y) / 32))).X, 
                        (int)ressource.ecriture.MeasureString(
                            item.display_name(new Vector2((Data.mouseState.X - obj.X) / 32, (Data.mouseState.Y - obj.Y) / 32))).Y), 
                        Color.Wheat);
                    spriteBatch.DrawString(ressource.ecriture, item.display_name(new Vector2((Data.mouseState.X - obj.X) / 32, (Data.mouseState.Y - obj.Y) / 32)), new Vector2(Data.mouseState.X -
                        (Data.mouseState.X +
                        (int)ressource.ecriture.MeasureString(item.display_name(new Vector2((Data.mouseState.X - obj.X) / 32, (Data.mouseState.Y - obj.Y) / 32))).X
                            - fenetre.Width), Data.mouseState.Y), Color.Black);
                }
                else
                {
                    spriteBatch.Draw(ressource.pixel, new Rectangle(Data.mouseState.X, Data.mouseState.Y, (int)ressource.ecriture.MeasureString(
                    item.display_name(new Vector2((Data.mouseState.X - obj.X) / 32, (Data.mouseState.Y - obj.Y) / 32))).X, (int)ressource.ecriture.MeasureString(
                    item.display_name(new Vector2((Data.mouseState.X - obj.X) / 32, (Data.mouseState.Y - obj.Y) / 32))).Y), Color.Wheat);
                    spriteBatch.DrawString(ressource.ecriture, item.display_name(new Vector2((Data.mouseState.X - obj.X) / 32, (Data.mouseState.Y - obj.Y) / 32)), new Vector2(Data.mouseState.X, Data.mouseState.Y), Color.Black);
                }
                
            }
           
            for (int i = 0; i < 16 * 25; i += 16)
                for (int j = 0; j < 16 * 18; j += 16)
                    if (new Rectangle(Data.mouseState.X, Data.mouseState.Y, 1, 1).Intersects(new Rectangle(i, j, 16, 16)))
                    {
                        if (position == false)
                        {
                            spriteBatch.Draw(ressource.pixel, new Rectangle((int)i, (int)j, 16, 2), Color.Red);
                            spriteBatch.Draw(ressource.pixel, new Rectangle((int)i, (int)j, 2, 16), Color.Red);
                            spriteBatch.Draw(ressource.pixel, new Rectangle((int)i, (int)j + 16, 18, 2), Color.Red);
                            spriteBatch.Draw(ressource.pixel, new Rectangle((int)i + 16, (int)j, 2, 18), Color.Red);
                        }
                        else
                        {
                            spriteBatch.Draw(ressource.pixel, new Rectangle((int)i, (int)j, 16, 2), Color.Blue);
                            spriteBatch.Draw(ressource.pixel, new Rectangle((int)i, (int)j, 2, 16), Color.Blue);
                            spriteBatch.Draw(ressource.pixel, new Rectangle((int)i, (int)j + 16, 18, 2), Color.Blue);
                            spriteBatch.Draw(ressource.pixel, new Rectangle((int)i + 16, (int)j, 2, 18), Color.Blue);
                        }
                    }
        }
    }
}
