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
    public class potion : item
    {
        Rectangle Hitbox_potion;
        string Name;
        public Rectangle Collide
        {
            get { return Hitbox_potion; }
            set { Hitbox_potion = value; }
        }
        public string _Name
        {
            get { return Name; }
            set { Name = value; }
        }
        public potion(Texture2D texture, NPC npc, string name)
            : base(texture, npc.Position)
        {
            Hitbox_potion = new Rectangle((int)Position.X, (int)Position.Y, 32, 32);
            Name = name;
            usable = true;
            switch (name)
            {
                case "VIE":
                    utilité = "restore 10 pv au personnage";
                    break;
                case "MANA":
                    utilité = "restore 10 point de mana au personnage";
                    break;
            }
        }
        public override void action(GamePlayer player)
        {
            switch (this._Name)
            {
                case "VIE":
                    player.pv_player += 25;
                    break;
                case "MANA":
                    if (player.mana_player < 100)
                        player.mana_player += 25;
                    break;
            }
            base.action(player);
        }
        public override void draw(SpriteBatch spritebatch, int x, int y,int z,int w)
        {
            spritebatch.Draw(Texture, new Rectangle(x,y,z,w), Color.White);
            base.draw(spritebatch, (int)Position.X, (int)Position.Y,z,w);
        }
    }
}
