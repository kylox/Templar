﻿using System;

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
    class NPC : Personnage
    {
        Vector2 deplacement;
        int chrono;
        Map Map;
        GamePlayer player;

        public NPC(int taille_image_x, int taille_image_y, int nb_frameLine, int nb__framecolumn, int frame_start, int animation_speed,int speed, Vector2 position,
            Texture2D image, GamePlayer player, gamemain main)
            : base(taille_image_x, taille_image_y, nb_frameLine, nb__framecolumn, frame_start, animation_speed,speed, position, image, main)
        {
            this.player = player;
            Pv = 100;
            this.Map = main.map.Active_Map;
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
            if (chrono % 16 == 0)
            {
                Thread Deleg = new Thread(new ThreadStart(cheminement));
                Deleg.Start();
                chrono = 0;
            }

            switch (direction)
            {
                case Templar.Direction.Down:
                    break;
                case Templar.Direction.Up:
                    break;
                case Templar.Direction.Left:
                    break;
                case Templar.Direction.Right:
                    break;
            }

            base.update(mouse, keyboard, walls, personnages, map);
        }
        public void touché(Direction direction)
        {
            switch (direction)
            {
                case Templar.Direction.Left:
                    if (position.X - 32 >= 0)
                        position.X -= 32;
                    break;
                case Templar.Direction.Right:
                    if (position.X + 32 <= 25 * 32)
                        position.X += 32;
                    break;
                case Templar.Direction.Up:
                    if (position.Y - 32 >= 0)
                        position.Y -= 32;
                    break;
                case Templar.Direction.Down:
                    if (position.Y + 32 <= 18 * 32)
                        position.Y += 32;
                    break;
            }
            Pv -= player.attaque / 3;
        }

        public void cheminement()
        {
            int NPCx = (int)(position.X / (800 / 25));

            int NPCy = (int)position.Y / (608 / 19);

            int playerx = (int)player.Position.X / (800 / 25);

            int playery = (int)player.Position.Y / (608 / 19);


            Tile start = new Tile(NPCx, NPCy, 1);

            Tile End = new Tile(playerx, playery, 1);

            List<Tile> sol = new List<Tile>();

            sol = Pathfinding.Astar(Map, start, End);
            Tile end = sol[0];

            deplacement = new Vector2(player.Position.X - position.X, player.Position.Y - position.Y);
            if (start.X < end.X && start.Y == end.Y)
            {
                direction = Direction.Right;
                return;
            }

            if (start.Y < end.Y && start.X == end.X)
            {
                direction = Direction.Down;
                return;
            }
            if (start.Y > end.Y && start.X == end.X)
            {
                direction = Direction.Up;
                return;
            }
            if (start.X > end.X && start.Y == end.Y)
            {
                direction = Direction.Left;
                return;
            }
            else
            {
                direction = Direction.None;
            }
        }

        public override void Draw(SpriteBatch spritbatch)
        {
            spritbatch.Draw(ressource.pixel, new Rectangle((int)position.X, (int)position.Y - 5, 100 / 4, 2), Color.Red);
            spritbatch.Draw(ressource.pixel, new Rectangle((int)position.X, (int)position.Y - 5, Pv / 4, 2), Color.Green);

            base.Draw(spritbatch);
        }
    }
}
