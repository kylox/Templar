using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Templar
{
    class GamePlayer : Personnage
    {
        SpriteFont spriteFont;
        Vector2 position_pv;

        gamemain main;

        sort active_sort;

        bool click_down;

        int sort_selec;
        int Endurance;
        int timer_endurance;
        int Mana;
        string active;
        public string Active
        {
            get { return active; }
            set { active = value; }
        }
        public int XP
        {
            get;
            set;
        }

        public int Niveau
        {
            get;
            set;
        }

        public int Sort_selec
        {
            get { return sort_selec; }
            set { sort_selec = value; }
        }

        public sort Active_Sort
        {
            get { return active_sort; }
            set { active_sort = value; }
        }

        public int pv_player
        {
            get { return Pv; }
            set { Pv = value; }
        }

        public int end_player
        {
            get { return Endurance; }
            set { Endurance = value; }
        }

        public int mana_player
        {
            get { return Mana; }
            set { Mana = value; }
        }

        public Vector2 position_player
        {
            get { return position; }
            set {position = value;}

        }

        public GamePlayer(int taille_image_x, int taille_image_y, int nb_frameLine, int nb__framecolumn, int frame_start, int animation_speed, Vector2 position, int pv, Texture2D image, gamemain main)
            : base(taille_image_x, taille_image_y, nb_frameLine, nb__framecolumn, frame_start, animation_speed, position, image, main)
        {
            this.main = main;
            spriteFont = ressource.ecriture;
            position_pv.X = 300;
            position_pv.Y = 0;

            this.Direction = Direction.None;
            Endurance = 100;
            Mana = 100;
            Pv = 100;
            timer_endurance = 0;
            sort_selec = 1;
            active_sort = new sort(ressource.boule_de_feu, this);
            click_down = false;
        }

        public override void update(MouseState mouse, KeyboardState keyboard, List<wall> walls, List<Personnage> personnages)
        {


            if (keyboard.IsKeyDown(Keys.LeftShift) && Endurance > 0)
            {
                animate();
                Endurance--;
                Speed = 4;
                animaitonspeed = 5;
            }

            else
            {
                animate();
                Speed = 2;
                animaitonspeed = 8;
            }

            timer_endurance++;

            if (position.X + 34 >= main.Fenetre.Width)
                position.X = main.Fenetre.Width - 34;

            if (position.X <= 0)
                position.X = 0;

            if (position.Y + 61 >= main.Fenetre.Height)
                position.Y = main.Fenetre.Height - 61;

            if (position.Y <= 0)
                position.Y = 0;


            //modifie la selection des sorts
            if (keyboard.IsKeyDown(Keys.D1))
            {
                sort_selec = 1;
            }
            if (keyboard.IsKeyDown(Keys.D2))
            {
                sort_selec = 2;
            }

            //lance le nouveau sort suivant la selection
            switch (sort_selec)
            {
                case 1:
                    active_sort = new sort(ressource.boule_de_feu, this);
                    active = "feu";
                    break;
                case 2:
                    active_sort = new sort(ressource.glace, this);
                    active = "glace";
                    break;
            }

            //verifie si le joueur peut courir
           
            //recharge l'endurance 
            if (keyboard.IsKeyUp(Keys.LeftShift) && timer_endurance >= 5 && Endurance < 100)
            {
                Endurance++;
                timer = 0;
            }

            //ces deux test marche aps specialement bien A MODIFIER 
            if (Endurance <= 0)
                Endurance = 0;
 
            if (Pv <= 0)
                Pv = 0;

            if (pv_player >= 100)
                pv_player = 100;

            //change la direction du player
            if (keyboard.IsKeyDown(Keys.Z))
                direction = Direction.Up;

            if (keyboard.IsKeyDown(Keys.S))
                direction = Direction.Down;

            if (keyboard.IsKeyDown(Keys.D))
                direction = Direction.Right;

            if (keyboard.IsKeyDown(Keys.Q))
                direction = Direction.Left;

            if (keyboard.IsKeyUp(Keys.Z) && keyboard.IsKeyUp(Keys.S) &&
              keyboard.IsKeyUp(Keys.Q) && keyboard.IsKeyUp(Keys.D))
                direction = Direction.None;

            //evite de trop cliquer
            if (keyboard.IsKeyUp(Keys.Space))
                click_down = false;

            //diminue le mana a chaque sort lancer
            if (keyboard.IsKeyDown(Keys.Space) && Mana >= 0 && click_down == false)
            {
                Mana -= 10;
                click_down = true;
            }
            base.update(mouse, keyboard, walls, personnages);
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            base.Draw(spritebatch);
        }
    }
}
