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
    class Princess : Personnage
    {
        int count_deplacement;
        int bob;
        int canmove;
        Random rd = new Random();
        public Princess(int taille_image_x, int taille_image_y, int nb_frameLine, int nb__framecolumn, int frame_start, int animation_speed, int speed, Vector2 position, Texture2D image, GamePlayer player, gamemain main)
            : base(taille_image_x, taille_image_y, nb_frameLine, nb__framecolumn, frame_start, animation_speed, speed, position, image, main)
        {
            bob = 0;
            count_deplacement = 60;
            canmove = 0;
            this.direction = Templar.Direction.None;
        }
        public override void update(MouseState mouse, KeyboardState keyboard, List<wall> walls, List<Personnage> personnages, switch_map map)
        {
            count_deplacement++;
            canmove++;
            if (canmove > 15)
            {
                bob = rd.Next(0, 5);
                switch (bob)
                {
                    case 0:
                        this.direction = Templar.Direction.None;
                        break;
                    case 1:
                        this.direction = Templar.Direction.Up;
                        break;
                    case 2:
                        this.direction = Templar.Direction.Down;
                        break;
                    case 3:
                        this.direction = Templar.Direction.Left;
                        break;
                    case 4:
                        this.direction = Templar.Direction.Right;
                        break;
                }
                canmove = 0;
            }
            base.update(mouse, keyboard, walls, personnages, map);
        }
        public override void Draw(SpriteBatch spritbatch)
        {
            spritbatch.DrawString(ressource.ecriture, position.X + " " + position.Y, new Vector2(200, 0), Color.Yellow);
            base.Draw(spritbatch);
        }
    }
}