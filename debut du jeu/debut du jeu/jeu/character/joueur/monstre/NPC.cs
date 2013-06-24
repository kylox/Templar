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
using System.Threading;

namespace Templar
{
    [Serializable()]
    public class NPC : Personnage
    {
        Vector2 deplacement, OldPosition;
        int chrono;
        Map Map;
        GamePlayer player;
        bool PlayerMoved, CanMove;
       // public int frameline;
        //public Vector2 position;
        Thread Deleg;

        public NPC(int taille_image_x, int taille_image_y, int nb_frameLine, int nb__framecolumn, int frame_start, int animation_speed, int speed, Vector2 position,
            Texture2D image, GamePlayer player, Map map)
            : base(taille_image_x, taille_image_y, nb_frameLine, nb__framecolumn, frame_start, animation_speed, speed, position, image)
        {
            this.frameline = nb_frameLine;
            this.position = position;
            this.player = player;
            //partie pour L'A*
            PlayerMoved = false;
            OldPosition = player.Position;
            CanMove = true;
            direction = Direction.None;
            //Fin Partie pour l'A*
            Pv = 100;
            this.Map = map;
            Deleg = new Thread(new ThreadStart(cheminement));
            switch (frame_start)
            {
                case 1:
                    Pv = 100;
                    attaque = 5;
                    defense = 5;
                    break;
                case 4:
                    Pv = 50;
                    attaque = 5;
                    defense = 5;
                    break;
                case 7:
                    attaque = 7;
                    defense = 5;
                    Pv = 50;
                    break;
                case 10:
                    attaque = 10;
                    defense = 5;
                    Pv = 200;
                    break;
                case 16:
                    attaque = 5;
                    defense = 5;
                    Pv = 100;
                    break;
                case 19:
                    attaque = 5;
                    defense = 5;
                    Pv = 100;
                    break;
                case 22:
                    attaque = 5;
                    defense = 5;
                    Pv = 100;
                    break;
                case 25:
                    attaque = 5;
                    defense = 5;
                    Pv = 100;
                    break;
                case 28:
                    attaque = 5;
                    defense = 5;
                    Pv = 100;
                    break;
                case 31:
                    attaque = 5;
                    defense = 5;
                    Pv = 100;
                    break;
                case 34:
                    attaque = 5;
                    defense = 5;
                    Pv = 100;
                    break;
            }
        }
        public override void update(MouseState mouse, KeyboardState keyboard, List<wall> walls, List<Personnage> personnages, switch_map map)
        {
            chrono++;
            if (chrono > 15)
            {
                //Deleg = new Thread(cheminement);
                CanMove = true;
                chrono = 0;
                //Partie new A*
                if (OldPosition != player.Position)
                {
                    PlayerMoved = true;
                    OldPosition = player.Position;
                }
                if (PlayerMoved)
                {
                    PlayerMoved = false;
                    if (Deleg != null)
                    {
                        Deleg.Abort();
                        Deleg = new Thread(cheminement);
                        Deleg.Start();
                    }
                    else
                        Deleg.Start();

                }
                //Fin Partie new A*

            }

            switch (direction)
            {
                case Direction.Down:
                    if (new Rectangle(Taille_image_x, (int)position.Y + 32, 32, 32).Intersects(new Rectangle((int)player.Position.X, (int)player.Position.Y, 32, 32)))
                        combat = true;
                    else
                        combat = false;
                    break;
                case Direction.Up:
                    if (new Rectangle(Taille_image_x, (int)position.Y - 32, 32, 32).Intersects(new Rectangle((int)player.Position.X, (int)player.Position.Y, 32, 32)))
                        combat = true;
                    else
                        combat = false;
                    break;
                case Direction.Left:
                    if (new Rectangle(Taille_image_x - 32, (int)position.Y, 32, 32).Intersects(new Rectangle((int)player.Position.X, (int)player.Position.Y, 32, 32)))
                        combat = true;
                    else
                        combat = false;
                    break;
                case Direction.Right:
                    if (new Rectangle(Taille_image_x + 32, (int)position.Y, 32, 32).Intersects(new Rectangle((int)player.Position.X, (int)player.Position.Y, 32, 32)))
                        combat = true;
                    else
                        combat = false;
                    break;
            }

            base.update(mouse, keyboard, walls, personnages, map);
        }
        public void touché(Direction direction, GamePlayer Player)
        {
            switch (direction)
            {
                case Direction.Left:
                    if (position.X - 32 >= 0)
                        position.X += 32;
                    break;
                case Direction.Right:
                    if (position.X + 32 <= 25 * 32)
                        position.X -= 32;
                    break;
                case Direction.Up:
                    if (position.Y - 32 >= 0)
                        position.Y -= 32;
                    break;
                case Direction.Down:
                    if (position.Y + 32 <= 18 * 32)
                        position.Y += 32;
                    break;
            }
            Pv -= Player.attaque / 3;
        }

        public void cheminement()
        {
            int NPCx = (int)(position.X / 32);

            int NPCy = (int)position.Y / 32;

            int playerx = (int)player.Position.X / 32;

            int playery = (int)player.Position.Y / 32;


            Tile start = new Tile(NPCx, NPCy, 1);

            Tile End = new Tile(playerx, playery, 1);

            List<Tile> sol = new List<Tile>();

            sol = Pathfinding.Astar(Map, start, End);
            int i = 0;
            while (i < sol.Count)
            {


                Tile end = sol[i];
                i++;
                //CanMove = false;
                deplacement = new Vector2(player.Position.X - position.X, player.Position.Y - position.Y);
                if (start.X == end.X && start.Y == end.Y)
                {
                    direction = Direction.None;
                    deplacement = new Vector2(0, 0);
                }
                if (start.X < end.X && start.Y == end.Y)
                {
                    direction = Direction.Right;
                    start.X++;
                    //position.X += 32;
                }

                if (start.Y < end.Y && start.X == end.X)
                {
                    direction = Direction.Down;
                    start.Y++;
                    //position.Y += 32;

                }
                if (start.Y > end.Y && start.X == end.X)
                {
                    direction = Direction.Up;
                    start.Y--;
                    //position.Y -= 32;

                }
                if (start.X > end.X && start.Y == end.Y)
                {
                    direction = Direction.Left;
                    start.X--;
                   // position.X -= 32;

                }
                Thread.Sleep(266);
            }
            Direction = Direction.None;
        }

        public override void Draw(SpriteBatch spritbatch)
        {
            spritbatch.Draw(ressource.pixel, new Rectangle((int)position.X, (int)position.Y - 5, 100 / 4, 2), Color.Red);
            spritbatch.Draw(ressource.pixel, new Rectangle((int)position.X, (int)position.Y - 5, Pv / 4, 2), Color.Green);
            base.Draw(spritbatch);
            /* timer_attaque++;
             if (combat == true && timer_attaque > 4)
             {
                 timer_attaque = 0;
                 if (Frame_start != 10)
                 {
                     framecolumn++;
                     spritbatch.Draw(Image, new Rectangle((int)position.X, (int)position.Y, 32, 48), new Rectangle((this.Framecolumn - 1) * this.Taille_image_x - 1, (this.FrameLine - 1) * this.Taille_image_y - 1, this.Taille_image_x, this.Taille_image_y), Color.White);
                     if (!player.Hitbox_image.Intersects(this.Hitbox_image))
                     {
                         combat = false;
                         switch (FrameLine)
                         {
                             case 6:
                                 frameline = 4;
                                 break;
                             case 5:
                                 frameline = 1;
                                 break;
                             case 7:
                                 frameline = 3;
                                 break;
                             case 8:
                                 frameline = 2;
                                 break;
                         }
                     }
                 }
                 else
                 {
                     framecolumn += 2;
                     spritbatch.Draw(Image,
                         new Rectangle((int)position.X, (int)position.Y, 32 * 2, 48),
                         new Rectangle((this.Framecolumn - 1) * this.Taille_image_x - 1, (this.FrameLine - 1) * this.Taille_image_y - 1,
                             this.Taille_image_x * 2, this.Taille_image_y),
                         Color.White);
                     if (!player.Hitbox_image.Intersects(this.Hitbox_image))
                     {
                         combat = false;
                         switch (FrameLine)
                         {
                             case 6:
                                 frameline = 4;
                                 break;
                             case 5:
                                 frameline = 1;
                                 break;
                             case 7:
                                 frameline = 3;
                                 break;
                             case 8:
                                 frameline = 2;
                                 break;
                         }
                     }
                 }*/
        }
    }
}
