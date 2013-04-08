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

    class NPC : Personnage
    {
        Vector2 deplacement;
        int chrono;
        Map map;
        GamePlayer player;

        public NPC(int taille_image_x, int taille_image_y, int nb_frameLine, int nb__framecolumn, int frame_start, int animation_speed, Vector2 position,
            Texture2D image, GamePlayer player, gamemain main)
            : base(taille_image_x, taille_image_y, nb_frameLine, nb__framecolumn, frame_start, animation_speed, position, image, main)
        {
            this.player = player;
            Pv = 100;
            this.map = new Map("map.txt");
        }

        public override void update(MouseState mouse, KeyboardState keyboard, List<wall> walls, List<Personnage> personnages)
        {
            chrono++;
            if (chrono % 16 == 0)
            {
                Thread Deleg = new Thread(new ThreadStart(cheminement));
                Deleg.Start();
                chrono = 0;
            }
            base.update(mouse, keyboard, walls, personnages);
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

            sol = Pathfinding.Astar(map, start, End);
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
            spritbatch.Draw(ressource.pixel, new Rectangle((int)position.X, (int)position.Y - 5, Pv/4, 2), Color.Green);

            base.Draw(spritbatch);
        }
    }
}