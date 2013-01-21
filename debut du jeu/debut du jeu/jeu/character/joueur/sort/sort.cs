using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Templar
{
    //cette classe initialise tout les sorts 
    class sort
    {
        Texture2D texture;
        Vector2 position;
        GamePlayer Player;
        Direction object_direction;
        Rectangle Hitbox_object;

        public Rectangle hitbox_object
        {
            get { return Hitbox_object; }
            set { Hitbox_object = value; }
        }

        public sort(Texture2D image, GamePlayer player)
        {
            texture = image;
            Player = player;
            position = player.Position;
            Hitbox_object = new Rectangle((int)position.X, (int)position.Y, image.Width, image.Height);

            switch (Player.frameline)
            {
                case 3:
                    object_direction = Direction.Up;
                    break;

                case 1:
                    object_direction = Direction.Down;
                    break;

                case 2:
                    object_direction = Direction.Left;
                    break;

                case 4:
                    object_direction = Direction.Right;
                    break;
            }
        }

        public void update()
        {
            this.Hitbox_object = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

            switch (object_direction)
            {
                case Direction.Up:
                    position.Y -= 10;
                    break;
                case Direction.Down:
                    position.Y += 10;
                    break;
                case Direction.Left:
                    position.X -= 10;
                    break;
                case Direction.Right:
                    position.X += 10;
                    break;
            }
        }

        public void draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(texture, position, Color.White);
        }

    }
}
