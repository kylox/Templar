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

    class NPC : Personnage
    {
        Vector2 deplacement;

        GamePlayer player;

        public NPC(int taille_image_x, int taille_image_y, int nb_frameLine, int nb__framecolumn, int frame_start, int animation_speed, Vector2 position,
            Texture2D image, GamePlayer player, gamemain main)
            : base(taille_image_x, taille_image_y, nb_frameLine, nb__framecolumn, frame_start, animation_speed, position, image, main)
        {
            this.player = player;
            Pv = 100;
        }

        public override void update(MouseState mouse, KeyboardState keyboard, List<wall> walls, List<Personnage> personnages)
        {
            if ((player.Position.X <= position.X) && (player.Position.Y <= position.Y))
            {
                deplacement = new Vector2(player.Position.X - position.X, player.Position.Y - position.Y);

                if (-deplacement.X > -deplacement.Y)
                    Direction = Direction.Left;

                if (-deplacement.X <= -deplacement.Y)
                    Direction = Direction.Up;
            }

            if ((player.Position.X >= position.X) && (player.Position.Y <= position.Y))
            {
                deplacement = new Vector2(player.Position.X - position.X, player.Position.Y - position.Y);

                if (deplacement.X > -deplacement.Y)
                    Direction = Direction.Right;

                else
                    if (deplacement.X <= -deplacement.Y)
                        Direction = Direction.Up;

            }

            if ((player.Position.X <= position.X) && (player.Position.Y >= position.Y))
            {
                deplacement = new Vector2(player.Position.X - position.X, player.Position.Y - position.Y);
                
                if (-deplacement.X > deplacement.Y)
                    Direction = Direction.Left;
                else
                    if (-deplacement.X <= deplacement.Y)
                        Direction = Direction.Down;

            }

            if ((player.Position.X >= position.X) && (player.Position.Y >= position.Y))
            {
                deplacement = new Vector2(player.Position.X - position.X, player.Position.Y - position.Y);
               
                if (deplacement.X > deplacement.Y)
                    Direction = Direction.Right;
                else
                    if (deplacement.X <= deplacement.Y)
                        Direction = Direction.Down;
            }
            base.update(mouse, keyboard, walls, personnages);
        }

        public override void Draw(SpriteBatch spritbatch)
        {
            spritbatch.Draw(ressource.pixel, new Rectangle((int)position.X, (int)position.Y - 5, 100 / 4, 2), Color.Red);
            spritbatch.Draw(ressource.pixel, new Rectangle((int)position.X, (int)position.Y - 5, Pv/4, 2), Color.Green);

            base.Draw(spritbatch);
        }
    }
}
