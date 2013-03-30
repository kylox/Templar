using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Templar
{
    enum Direction
    {
        Up, Down, Left, Right, None
    };

    abstract class Personnage
    {

        //fields

        Rectangle Hitbox;
        Rectangle true_hitbox_motherfucker;
        protected Vector2 position;
        protected Direction Direction;
        Rectangle newHitbox;
        Texture2D Image;

        gamemain main;


        //variable d'animation
        protected int timer;
        protected int Speed;
        protected int FrameLine;
        protected int Framecolumn;
        protected int nb_Frameline;
        protected int nb_Framecolumn;
        protected int animaitonspeed;
        protected int Taille_image_x;
        protected int Taille_image_y;
        protected int Frame_start;
        protected bool collision;

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

        // main 

        public Personnage(int taille_image_x, int taille_image_y, int nb_frameLine,
            int nb__framecolumn, int frame_start, int animation_speed, Vector2 position
            , Texture2D image, gamemain game)
        {

            main = game;
            this.position = position;
            
            this.animaitonspeed = animation_speed;
            true_hitbox_motherfucker = new Rectangle(Hitbox.Width, Hitbox.Height, 20, 10);
            timer = 0;

            Framecolumn = 2;
            FrameLine = 1;
            
            Speed = 2;

            this.nb_Framecolumn = nb__framecolumn;
            this.nb_Frameline = nb_frameLine;

            this.Image = image;

            this.Taille_image_x = taille_image_x;
            this.Taille_image_y = taille_image_y;

            this.Frame_start = frame_start;
        }

        // method

        bool collide(List<wall> walls, List<Personnage> personnages)
        {
            collision = false;
            foreach (wall Wall in walls)
            {
                if (this.newHitbox.Intersects(Wall.Hitbox))
                {
                    collision = true;
                    break;
                }
            }

            return collision;
        }

        public void animate()
        {
            this.timer++;

            if (this.timer == this.animaitonspeed)
            {
                this.timer = 0;
                this.Framecolumn++;

                if (this.Framecolumn > this.nb_Framecolumn)
                {
                    this.Framecolumn = this.Frame_start;
                }
            }
        }


        //update & draw

        public virtual void update(MouseState mouse, KeyboardState keyboard,
            List<wall> walls, List<Personnage> personnages)
        {

            Hitbox = new Rectangle((int)position.X, (int)position.Y, Taille_image_x, Taille_image_y);
            
            if (Direction == Direction.Up)
            {
                this.newHitbox = new Rectangle((int)this.position.X, ((int)this.position.Y + (Taille_image_y - 10)) - this.Speed, 20, 10);

                if (collide(walls, personnages) == true)
                    Pv--;

                if (!collision)
                    this.position.Y -= this.Speed;

                this.animate();
            }

            else if (Direction == Direction.Down)
            {
                this.newHitbox = new Rectangle((int)this.position.X, ((int)this.position.Y + (Taille_image_y - 10)) + this.Speed, 20, 10);

                if (collide(walls, personnages) == true)
                    Pv--;

                if (!collision)
                    this.position.Y += this.Speed;

                this.animate();
            }

            else if (Direction == Direction.Right) // same 
            {
                this.newHitbox = new Rectangle((int)this.position.X + this.Speed, ((int)this.position.Y + (Taille_image_y - 10)), Taille_image_x, 10);

                if (collide(walls, personnages) == true)
                    Pv--;

                if (!collision)
                    this.position.X += this.Speed;

                this.animate();

            }

            else if (Direction == Direction.Left) // same 
            {
                this.newHitbox = new Rectangle((int)this.position.X - this.Speed, ((int)this.position.Y + (Taille_image_y - 10)), 20, 10);

                if (collide(walls, personnages) == true)
                    Pv--;

                if (!collision)
                    this.position.X -= this.Speed;

                this.animate();
            }

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

        public virtual void Draw(SpriteBatch spritbatch)
        {
            spritbatch.Draw(Image, position, new Rectangle((this.Framecolumn - 1) * this.Taille_image_x-1, (this.FrameLine - 1) * this.Taille_image_y-1, this.Taille_image_x, this.Taille_image_y), Color.White);
        }

        public void chgt_position(int X, int Y)
        {
            this.position.X = X;
            this.position.Y = Y;
        }
    }
}
