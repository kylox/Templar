using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Templar
{
    public enum Direction
    {
        Up, Down, Left, Right, None
    };
    [Serializable()]
    abstract class Personnage
    {

        //fields
        int timer_attaque;
        int gauche;
        Rectangle Hitbox;
        Rectangle true_hitbox_motherfucker;
        protected Vector2 position;
        protected Direction Direction;
        Rectangle newHitbox;
        gamemain main;
        //variable d'animation
        protected int timer, timer_speed;
        protected int Speed;
        protected int FrameLine;
        protected int Framecolumn;
        protected int nb_Frameline;
        protected int nb_Framecolumn;
        protected int animaitonspeed;
        protected int Taille_image_x;
        protected int Taille_image_y;
        protected int Frame_start;
        public int attaque;
        public int defense;
        protected bool collision;
        public bool combat;
        public bool CanMove;
        //autre
        protected int Pv;

        public int PV
        {
            get { return Pv; }
            set { Pv = value; }
        }
        public Rectangle Hitbox_personnage
        {
            get { return newHitbox; }
            set { newHitbox = value; }
        }
        public Rectangle Hitbox_image
        {
            get { return Hitbox; }
            set { Hitbox = value; }
        }
        public Direction direction
        {
            get { return Direction; }
            set { Direction = value; }
        }
        public Vector2 Position
        {
            get { return position; }

            set { position = value; }
        }
        public int frameline
        {
            get { return FrameLine; }
            set { FrameLine = value; }
        }
        public int framecolumn
        {
            get { return Framecolumn; }
            set { Framecolumn = value; }
        }
        [NonSerialized()]
        protected Texture2D Image;
        // main 
        public Personnage(int taille_image_x, int taille_image_y, int nb_frameLine,
            int nb__framecolumn, int frame_start, int animation_speed, int speed, Vector2 position
            , Texture2D image, gamemain game)
        {
            main = game;
            this.position = position;
            this.animaitonspeed = animation_speed;
            timer = 0;
            FrameLine = 1;
            this.nb_Framecolumn = nb__framecolumn;
            this.nb_Frameline = nb_frameLine;
            this.Image = image;
            this.Taille_image_x = taille_image_x;
            this.Taille_image_y = taille_image_y;
            this.Frame_start = frame_start;
            Framecolumn = Frame_start;
            timer_attaque = 0;
            Speed = speed;
            timer_speed = 0;
            CanMove = true;
        }
        // method
        bool collide(List<wall> walls, List<Personnage> personnages)
        {
            collision = false;
            foreach (wall Wall in walls)
                if (this.newHitbox.Intersects(Wall.Hitbox))
                {
                    collision = true;
                    break;
                }
            return collision;
        }
        public void Attaque(Personnage attaquant, Personnage attaque)
        {
            attaque.Pv -= attaquant.attaque * 3;
        }
        bool coll(Map map)
        {
            bool poissible = false;
            for (int i = 0; i < 32; i++)
                for (int j = 0; j < 32; j++)
                    poissible = this.newHitbox.Intersects(new Rectangle(map.Tilelist[i, j].X, map.Tilelist[i, j].Y, 32, 32)) && map.Tilelist[i, j].Type == Templar.Tile.TileType.wall;
            return poissible;
        }
        public void animate()
        {
            timer++;
            if (this.timer == this.animaitonspeed)
            {
                this.timer = 0;
                
                    this.Framecolumn++;
                if (this.Framecolumn > this.nb_Framecolumn + Frame_start)
                    this.Framecolumn = this.Frame_start;
            }
        }
        //update & draw
        public virtual void update(MouseState mouse, KeyboardState keyboard,
            List<wall> walls, List<Personnage> personnages, switch_map map)
        {
            timer_speed++;
            Hitbox = new Rectangle((int)position.X, (int)position.Y, Taille_image_x, Taille_image_y);
            if (Direction == Direction.Up)
            {
                this.newHitbox = new Rectangle((int)this.position.X, ((int)this.position.Y + (32 - 10)) - this.Speed, 20, 10);
                if (collide(walls, personnages) == true)
                    Pv--;
                if (!collision && /*timer_speed > Speed && */(int)position.Y / 32 - 1 >= 0 && map.Active_Map.colision[(int)position.X / 32, (int)position.Y / 32 - 1] != 1)
                {
                    timer_speed = 0;
                    this.position.Y -= Speed;
                   /* for (int i = 0; i < 32; i++)
                    {
                        this.position.Y--;
                    }*/
                }
                this.animate();
            }
            else if (Direction == Direction.Down)
            {
                this.newHitbox = new Rectangle((int)this.position.X, ((int)this.position.Y + (32 - 10)) + this.Speed, 20, 10);

                if (collide(walls, personnages) == true)
                    Pv--;
                if (!collision && /*timer_speed > Speed &&*/ (int)position.Y / 32 + 1 < 18 && map.Active_Map.colision[(int)position.X / 32, (int)position.Y / 32 + 1] != 1)
                {
                    timer_speed = 0;
                    this.position.Y += Speed;
                    /*for (int i = 0; i < 32; i++)
                    {
                        this.position.Y++;
                    }*/
                }
                this.animate();
            }
            else if (Direction == Direction.Right) // same 
            {
                this.newHitbox = new Rectangle((int)this.position.X + this.Speed, ((int)this.position.Y + (32 - 10)), 20, 10);
                if (collide(walls, personnages) == true)
                    Pv--;
                if (!collision && /*timer_speed > Speed && */map.Active_Map.colision[(int)position.X / 32 + 1, (int)position.Y / 32] != 1)
                {
                    timer_speed = 0;
                    this.position.X += Speed;
                    /*for (int i = 0; i < 32; i++)
                    {
                        this.position.X++;
                    }*/
                }
                this.animate();
            }
            else if (Direction == Direction.Left) // same 
            {
                this.newHitbox = new Rectangle((int)this.position.X - this.Speed, ((int)this.position.Y + (32 - 10)), 20, 10);
                if (collide(walls, personnages) == true)
                    Pv--;
                if (!collision && /*timer_speed > Speed &&*/ position.X / 32 - 1 >= 0 && map.Active_Map.colision[(int)position.X / 32 - 1, (int)position.Y / 32] != 1)
                {
                    timer_speed = 0;
                    this.position.X -= Speed;
                   /* for (int i = 0; i < 32; i++)
                    {
                        this.position.X--;
                    }*/
                }
                this.animate();
            }
            if (combat == true)
                switch (FrameLine)
                {
                    case 4:
                        frameline = 6;
                        break;
                    case 1:
                        frameline = 5;
                        break;
                    case 3:
                        frameline = 7;
                        break;
                    case 2:
                        frameline = 8;
                        break;
                }
            else
            {
                switch (this.Direction)
                {
                    case Direction.Up:
                        this.FrameLine = 3;
                        break;

                    case Direction.Down:
                        this.FrameLine = 1;
                        break;

                    case Direction.Left:
                        this.FrameLine = 2;
                        break;

                    case Direction.Right:
                        this.FrameLine = 4;
                        break;
                }
                if (Direction == Direction.None) // si toute les touches sont relacher alors tu affiche le personnage a l'arret
                {
                    this.Framecolumn = 2;
                    this.timer = 0;
                }
            }
        }
        public virtual void Draw(SpriteBatch spritbatch)
        {
            timer_attaque++;
            if (combat == true && timer_attaque > 4)
            {
                timer_attaque = 0;
                framecolumn++;
                spritbatch.Draw(Image, new Rectangle((int)position.X, (int)position.Y, 32, 48), new Rectangle((this.Framecolumn - 1) * this.Taille_image_x - 1, (this.FrameLine - 1) * this.Taille_image_y - 1, this.Taille_image_x, this.Taille_image_y), Color.White);
                if (framecolumn == 7)
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
            if (Frame_start == 10)
                spritbatch.Draw(Image, new Rectangle((int)position.X, (int)position.Y, 32 * 2, 48), new Rectangle((this.Framecolumn - 1) * this.Taille_image_x - 1, (this.FrameLine - 1) * this.Taille_image_y - 1, this.Taille_image_x * 2, this.Taille_image_y), Color.White);
            else
                spritbatch.Draw(Image, new Rectangle((int)position.X, (int)position.Y, 32, 48), new Rectangle((this.Framecolumn - 1) * this.Taille_image_x - 1, (this.FrameLine - 1) * this.Taille_image_y - 1, this.Taille_image_x, this.Taille_image_y), Color.White);
        }
        public void chgt_position(int X, int Y)
        {
            this.position.X = X;
            this.position.Y = Y;
        }
    }
}
