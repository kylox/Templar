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
        dessin_perso dessin_tete;
        sort active_sort;
        bool click_down;
        public bool levelup;
        int sort_selec;
        public int obj_selec;
        int Endurance;
        int timer_endurance;
        int Mana;
        string active;
        public List<item> inventaire;
        public int[] nb_objet;

        public int attaque;
        public int defense;
        public int magie;

        public int nb_amelioration;

        public Rectangle HitBox;

        public int tete
        {
            get;
            set;
        }
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
            set { position = value; }

        }
        public GamePlayer(int taille_image_x, int taille_image_y, int nb_frameLine, int nb__framecolumn, int frame_start, int animation_speed, Vector2 position, int pv, Texture2D image, gamemain main)
            : base(taille_image_x, taille_image_y, nb_frameLine, nb__framecolumn, frame_start, animation_speed, position, image, main)
        {
            this.main = main;
            spriteFont = ressource.ecriture;
            position_pv.X = 300;
            position_pv.Y = 0;
            this.Direction = Direction.None;
            attaque = 10;
            defense = 10;
            magie = 10;
            Endurance = 100;
            Mana = 100;
            Pv = 100;
            timer_endurance = 0;
            sort_selec = 1;
            obj_selec = 1;
            active_sort = new sort(ressource.boule_de_feu, this);
            dessin_tete = new dessin_perso(this);
            click_down = false;
            levelup = false;
            nb_amelioration = 0;
            inventaire = new List<item>();
            nb_objet = new int[25];
            HitBox = new Rectangle((int)position.X, (int)position.Y, 32, 32);
        }
        public void utilise_objet(item item)
        {
            item.action(this);
        }
        public void deplacement()
        {
            if (Data.keyboardState.IsKeyDown(Keys.Z))
                direction = Direction.Up;

            if (Data.keyboardState.IsKeyDown(Keys.S))
                direction = Direction.Down;

            if (Data.keyboardState.IsKeyDown(Keys.D))
                direction = Direction.Right;

            if (Data.keyboardState.IsKeyDown(Keys.Q))
                direction = Direction.Left;

            if (Data.keyboardState.IsKeyUp(Keys.Z) && Data.keyboardState.IsKeyUp(Keys.S) &&
             Data.keyboardState.IsKeyUp(Keys.Q) && Data.keyboardState.IsKeyUp(Keys.D))
                direction = Direction.None;
        }
        public void collision_bord()
        {
            if (position.X + 34 >= main.Fenetre.Width)
                position.X = main.Fenetre.Width - 34;

            if (position.X <= 0)
                position.X = 0;

            if (position.Y + 61 >= main.Fenetre.Height)
                position.Y = main.Fenetre.Height - 61;

            if (position.Y <= 0)
                position.Y = 0;
        }
        public bool vision(int x, int y)
        {
            return Math.Pow((x - position.X), 2) + Math.Pow((y - position.Y), 2) < Math.Pow(50, 2);
        }
        public void attaque_mana(KeyboardState keyboard)
        {
            if (keyboard.IsKeyDown(Keys.Space) && Mana >= 0 && click_down == false)
            {
                Mana -= 10;
                click_down = true;
            }
        }
        public override void update(MouseState mouse, KeyboardState keyboard, List<wall> walls, List<Personnage> personnages, switch_map map)
        {
            collision_bord();
            deplacement();
            HitBox = new Rectangle((int)position.X, (int)position.Y, 32, 32);
            #region sort
           
            if (keyboard.IsKeyDown(Keys.F1))
                sort_selec = 1;
            if (keyboard.IsKeyDown(Keys.F2))
                sort_selec = 2;
            if (keyboard.IsKeyDown(Keys.F3))
                sort_selec = 3;
            if (keyboard.IsKeyDown(Keys.F4))
                sort_selec = 4;

            if (Data.keyboardState.IsKeyDown(Keys.D1))
                obj_selec = 1;
            if (Data.keyboardState.IsKeyDown(Keys.D2))
                obj_selec = 2;
            if (Data.keyboardState.IsKeyDown(Keys.D3))
                obj_selec = 3;
            if (Data.keyboardState.IsKeyDown(Keys.D4))
                obj_selec = 4;
            if (Data.keyboardState.IsKeyDown(Keys.D5))
                obj_selec = 5;

            if (Data.keyboardState.IsKeyDown(Keys.A) && Data.prevKeyboardState.IsKeyUp(Keys.A))
            {
                utilise_objet(inventaire.ElementAt(obj_selec - 1));
                inventaire.RemoveAt(obj_selec - 1);
            }
            
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
            attaque_mana(keyboard);
            #endregion

            #region endurance
            timer_endurance++;
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

            if (keyboard.IsKeyUp(Keys.LeftShift) && timer_endurance >= 5 && Endurance < 100)
            {
                Endurance++;
                timer = 0;
            }
            if (Endurance <= 0)
                Endurance = 0;
            #endregion

            #region attaque
            if (keyboard.IsKeyDown(Keys.A))
                frameline = 5;
            #endregion

            if (levelup == true)
            {
                nb_amelioration++;
                XP -= 100;
                mana_player = pv_player = 100;
                Niveau++;
                levelup = false;

            }

            if (keyboard.IsKeyUp(Keys.Space))
                click_down = false;

            dessin_tete.update();

            base.update(mouse, keyboard, walls, personnages, map);
        }
        public override void Draw(SpriteBatch spritebatch)
        {
            base.Draw(spritebatch);
            dessin_tete.draw(spritebatch);
            for (int i = 0; i < 5; i++)
            {
                if (i < inventaire.Count())
                    spritebatch.Draw(inventaire.ElementAt(i).Texture, new Rectangle(100 + i * 32 + 5, 0, 32, 32), Color.White);
            }
            spritebatch.Draw(ressource.pixel, HitBox, Color.Red);
        }
    }
}
