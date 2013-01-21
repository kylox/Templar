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
    class potion : item
    {
        GamePlayer Player;
        Texture2D Texture;
        Rectangle Hitbox_potion;
        gamemain Main;
        string Name;

        public Rectangle Collide
        {
            get { return Hitbox_potion; }
            set { Hitbox_potion = value; }
        }

        public string _Name
        {
            get { return Name;}
            set { Name = value;}
        }

        public potion(Texture2D texture, GamePlayer player, gamemain main, NPC npc, string name)
            : base(texture, player, npc.Position, main)
        {
            Main = main;
            Player = player;
            Texture = texture;
            Hitbox_potion = new Rectangle((int)Position.X, (int)Position.Y, Texture.Bounds.Width, Texture.Bounds.Y);
            Name = name;
        }


        public override void draw(SpriteBatch spritebatch)
        {
            base.draw(spritebatch);
        }


    }
}
