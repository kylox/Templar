using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Templar
{
    [Serializable()]
    public class GamePlayer : Personnage
    {
        int CanMove;
        SpriteFont spriteFont;
        Vector2 position_pv;
        gamemain main;
        sort active_sort;
        textbox text;
        public Coffre Coffre_ouvert;
        bool click_down;
        int sort_selec;
        int Endurance;
        int timer_endurance;
        int Mana;
        string active;

        public bool in_action;
        public item[,] inventaire;
        public int[] nb_objet;
        public int obj_selec;
        public bool levelup;
        public int magie;
        public int nb_amelioration;
        public Rectangle HitBox;
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
        public int nb_item(item[,] inventaire)
        {
            int nb = 0;
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    if (inventaire[j, i] != null)
                        nb++;
            return nb;
        }
        public GamePlayer(int taille_image_x, int taille_image_y, int nb_frameLine, int nb__framecolumn, int frame_start, int animation_speed, int speed, Vector2 position, Texture2D image, gamemain main, textbox text)
            : base(taille_image_x, taille_image_y, nb_frameLine, nb__framecolumn, frame_start, animation_speed, speed, position, image)
        {
            CanMove = 0;
            this.main = main;
            this.text = text;
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
            click_down = false;
            levelup = false;
            nb_amelioration = 0;
            inventaire = new item[5, 5];
            nb_objet = new int[25];
            HitBox = new Rectangle((int)position.X, (int)position.Y, 32, 32);
            in_action = false;
            text.Is_shown = false;
        }
        public void utilise_objet(item item)
        {
            if (item.usable)
                item.action(this);
        }
        public void deplacement()
        {
            if (CanMove > 15)
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
                CanMove = 0;
            }
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
        public void action(switch_map map)
        {
            if (Data.keyboardState.IsKeyDown(Keys.E) && Data.prevKeyboardState.IsKeyUp(Keys.E))
            {
                switch (frameline)
                {
                    // en haut
                    case 3:
                        if (map.Active_Map.objet[(int)position.X / 32, (int)position.Y / 32 - 1] == new Vector2(2, 2))
                        {
                            text.Is_shown = true;
                            text.Saisie = "quelques bouquins relatant de la vie, de l'univers et du reste";
                            text.Fenetre.Width = (int)ressource.ecriture.MeasureString(text.Saisie).X + 10;
                        }
                        if (map.Active_Map.objet[(int)position.X / 32, (int)position.Y / 32 - 1] == new Vector2(0, 3))
                        {
                            text.Is_shown = true;
                            text.Saisie = "hummm... des tonneaux, plein de tonneaux !! ";
                            text.Fenetre.Width = (int)ressource.ecriture.MeasureString(text.Saisie).X + 10;
                        }
                        if (map.Active_Map.objet[(int)position.X / 32, (int)position.Y / 32 - 1] == new Vector2(0, 0))
                        {
                            map.Active_Map.Coffres[(int)position.X / 32, (int)position.Y / 32 - 1].is_open = true;
                            Coffre_ouvert = map.Active_Map.Coffres[(int)position.X / 32, (int)position.Y / 32 - 1];
                            in_action = true;
                        }
                        break;
                    // en bas
                    case 1:
                        if (map.Active_Map.objet[(int)position.X / 32, (int)position.Y / 32 + 1] == new Vector2(0, 3))
                        {
                            text.Is_shown = true;
                            text.Saisie = "hummm... des tonneaux, plein de tonneaux !! ";
                            text.Fenetre.Width = (int)ressource.ecriture.MeasureString(text.Saisie).X + 10;
                        }
                        break;
                    // a gauche
                    case 2:
                        if (map.Active_Map.objet[(int)position.X / 32 - 1, (int)position.Y / 32] == new Vector2(0, 3))
                        {
                            text.Is_shown = true;
                            text.Saisie = "hummm... des tonneaux, plein de tonneaux !! ";
                            text.Fenetre.Width = (int)ressource.ecriture.MeasureString(text.Saisie).X + 10;
                        }
                        break;
                    // a droite
                    case 4:
                        if (map.Active_Map.objet[(int)position.X / 32 - 1, (int)position.Y / 32] == new Vector2(0, 3))
                        {
                            text.Is_shown = true;
                            text.Saisie = "hummm... des tonneaux, plein de tonneaux !! ";
                            text.Fenetre.Width = (int)ressource.ecriture.MeasureString(text.Saisie).X + 10;
                        }
                        break;
                }
            }
        }
        public override void update(MouseState mouse, KeyboardState keyboard, List<wall> walls, List<Personnage> personnages, switch_map map)
        {
            base.update(mouse, keyboard, walls, personnages, map);
            collision_bord();
            CanMove++;
            deplacement();
            action(map);

            HitBox = new Rectangle((int)position.X, (int)position.Y, 32, 32);

            #region sort & item

            if (keyboard.IsKeyDown(Keys.D1))
                sort_selec = 1;
            if (keyboard.IsKeyDown(Keys.D2))
                sort_selec = 2;
            if (keyboard.IsKeyDown(Keys.D3))
                sort_selec = 3;
            if (keyboard.IsKeyDown(Keys.D4))
                sort_selec = 4;

            if (Data.keyboardState.IsKeyDown(Keys.NumPad1))
                obj_selec = 1;
            if (Data.keyboardState.IsKeyDown(Keys.NumPad2))
                obj_selec = 2;
            if (Data.keyboardState.IsKeyDown(Keys.NumPad3))
                obj_selec = 3;
            if (Data.keyboardState.IsKeyDown(Keys.NumPad4))
                obj_selec = 4;
            if (Data.keyboardState.IsKeyDown(Keys.NumPad5))
                obj_selec = 5;
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

            if (Data.keyboardState.IsKeyDown(Keys.LeftControl) && Data.prevKeyboardState.IsKeyUp(Keys.LeftControl))
                if (this.nb_item(this.inventaire) != 0 && obj_selec - 1 < this.nb_item(this.inventaire))
                {
                    utilise_objet(inventaire[obj_selec - 1, 0]);
                    inventaire[obj_selec - 1, 0] = null;
                }
            #endregion
            //si le tile ou se trouve le joueur est des troude pique alors il devient de piques ! 
            if (map.Active_Map.objet[(int)position.X / 32, (int)position.Y / 32] == new Vector2(0, 2))
            {
                map.Active_Map.objet[(int)position.X / 32, (int)position.Y / 32] = new Vector2(1, 2);
                pv_player -= 15;
                ressource.pique.Play();
            }
            else
                if (map.Active_Map.objet[(int)position.X / 32, (int)position.Y / 32] != new Vector2(0, 2) && map.Active_Map.objet[(int)position.X / 32, (int)position.Y / 32] != new Vector2(1, 2))
                    for (int i = 0; i < 25; i++)
                        for (int j = 0; j < 18; j++)
                            if (main.map.Active_Map.objet[i, j] == new Vector2(1, 2))
                                main.map.Active_Map.objet[i, j] = new Vector2(0, 2);
            #region endurance
            timer_endurance++;
            if (keyboard.IsKeyDown(Keys.LeftShift) && Endurance > 0)
            {
                animate();
                Endurance--;
                animaitonspeed = 5;
            }
            else
            {
                animate();
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

            if (Data.keyboardState.IsKeyDown(Keys.A) && Data.prevKeyboardState.IsKeyUp(Keys.A) && direction == Templar.Direction.None && !combat)
                combat = true;

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
        }
        public override void Draw(SpriteBatch spritebatch)
        {
            spritebatch.DrawString(ressource.ecriture, position_player.X + " " + position_player.Y, new Vector2(100, 0), Color.Red);
            base.Draw(spritebatch);
        }
    }
}
