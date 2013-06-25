using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Templar
{
    [Serializable()]
    public class GamePlayer : Personnage
    {
        SpriteFont spriteFont;
        Vector2 position_pv;
        gamemain main;
        sort active_sort;
        textbox text;
        public Coffre Coffre_ouvert;
        int sort_selec;
        int Endurance;
        int timer_endurance;
        int Mana;
        int timer_invulnarable;
        int timer_inv2;
        public int timer_dash;
        int speed_max;
        int CanMove;
        public int pv_item;
        public int mana_item;
        public int magie_item;
        public int attaque_item;
        public int defense_item;
        public int dash_item;
        public int endurance_item;
        public int pv_amelioration;
        public int mana_amelioration;
        public int pv_max;
        public int mana_max;
        public int timer_dash_max;
        public int endurance_max;
        public int attaque_max;
        public int magie_max;
        public int defense_max;
        public int obj_selec;
        public int[] nb_objet;
        public int magie;
        public int nb_amelioration;
        string active;
        public bool levelup;
        bool dash;
        bool langue;
        bool click_down;
        bool affichage_invul;
        bool precInvulnarable;
        public bool in_action;
        public item[,] inventaire;
        public item[] equipement;
        public Rectangle HitBox;

        public string Active
        {
            get { return active; }
            set { active = value; }
        }
        public sort Active_Sort
        {
            get { return active_sort; }
            set { active_sort = value; }
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
            for (int j = 0; j < 5; j++)
                for (int i = 0; i < 5; i++)
                    if (inventaire[i, j] != null)
                        nb++;
            return nb;
        }
        public GamePlayer(int taille_image_x, int taille_image_y, int nb_frameLine, int nb__framecolumn, int frame_start, int animation_speed, int speed, Vector2 position, Texture2D image, gamemain main, textbox text, bool language)
            : base(taille_image_x, taille_image_y, nb_frameLine, nb__framecolumn, frame_start, animation_speed, speed, position, image)
        {
            equipement = new item[4];
            dash = false;
            invulnerable = false;
            precInvulnarable = false;
            timer_invulnarable = 600;
            timer_inv2 = 10;
            timer_dash = 2;
            langue = language;
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
            speed_max = Speed;
        }
        public void utilise_objet(item item)
        {
            if (item != null)
                item.action(main);
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
            XmlReader reader;

            reader = XmlReader.Create("Francais.xml");
            if (!langue)
            {
                reader = XmlReader.Create("English.xml");
            }
            string op1 = "", op2 = "";
            while (reader.Read())
                while (reader.NodeType != XmlNodeType.EndElement)
                {
                    reader.Read();
                    if (reader.Name == "bouquins")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op1 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                    if (reader.Name == "tonneaux")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                op2 = reader.Value.ToString();
                        }
                        reader.Read();
                    }
                }
            if (Data.keyboardState.IsKeyDown(Keys.E) && Data.prevKeyboardState.IsKeyUp(Keys.E))
            {
                if (main.princess != null && position == main.princess.position)
                    main.victoire = true;
                switch (frameline)
                {
                    // en haut
                    case 3:
                        
                        if (map.Active_Map.objet[(int)position.X / 32, (int)position.Y / 32 - 1] == new Vector2(2, 2))
                        {
                            text.Is_shown = true;
                            text.Saisie = op1;
                            text.Fenetre.Width = (int)ressource.ecriture.MeasureString(text.Saisie).X + 10;
                        }
                        if (map.Active_Map.objet[(int)position.X / 32, (int)position.Y / 32 - 1] == new Vector2(0, 3))
                        {
                            text.Is_shown = true;
                            text.Saisie = op2;
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
                            text.Saisie = op2;
                            text.Fenetre.Width = (int)ressource.ecriture.MeasureString(text.Saisie).X + 10;
                        }
                        break;
                    // a gauche
                    case 2:
                        if (map.Active_Map.objet[(int)position.X / 32 - 1, (int)position.Y / 32] == new Vector2(0, 3))
                        {
                            text.Is_shown = true;
                            text.Saisie = op2;
                            text.Fenetre.Width = (int)ressource.ecriture.MeasureString(text.Saisie).X + 10;
                        }
                        break;
                    // a droite
                    case 4:
                        if (map.Active_Map.objet[(int)position.X / 32 - 1, (int)position.Y / 32] == new Vector2(0, 3))
                        {
                            text.Is_shown = true;
                            text.Saisie = op2;
                            text.Fenetre.Width = (int)ressource.ecriture.MeasureString(text.Saisie).X + 10;
                        }
                        break;
                }
            }
        }
        public void maj_equipement()
        {
            magie_item = 0;
            attaque_item = 0;
            endurance_item = 0;
            dash_item = 0;
            pv_item = 0;
            mana_item = 0;
            defense_item = 0;
            foreach (item i in equipement)
            {
                if (i != null)
                {
                    magie_item += i.Bonus[1];
                    attaque_item += i.Bonus[0];
                    endurance_item += i.Bonus[2];
                    dash_item += i.Bonus[3];
                    pv_item += i.Bonus[4];
                    mana_item += i.Bonus[5];
                    defense_item += i.Bonus[6];
                }
            }

        }
        public void maj_total()
        {
            timer_dash = 2 + dash_item;
            Pv = 100 + pv_item + pv_max;
            Mana = 100 + mana_item + mana_max;
            main.player.magie = main.player.magie_item + main.player.magie_max + 10;
            main.player.attaque = main.player.attaque_item + main.player.attaque_max + 10;
            main.player.defense = main.player.defense_item + main.player.defense_max + 10;
            Endurance = endurance_item + endurance_max + 100;
        }
        public void Dash(switch_map map)
        {
            switch (Direction)
            {
                case Templar.Direction.Up:
                    if ((int)position.Y / 32 - 1 >= 0 && map.Active_Map.colision[(int)position.X / 32, (int)position.Y / 32 - 1] != 1)
                        position.Y -= 32;
                    else
                        dash = false;
                    break;
                case Templar.Direction.Down:
                    if (map.Active_Map.colision[(int)position.X / 32 + 1, (int)position.Y / 32] != 1)
                        position.Y += 32;
                    else
                        dash = false;
                    break;
                case Templar.Direction.Left:
                    if (position.X / 32 - 1 >= 0 && map.Active_Map.colision[(int)position.X / 32 - 1, (int)position.Y / 32] != 1)
                        position.X -= 32;
                    else
                        dash = false;
                    break;
                case Templar.Direction.Right:
                    if (map.Active_Map.colision[(int)position.X / 32 + 1, (int)position.Y / 32] != 1)
                        position.X += 32;
                    else
                        dash = false;
                    break;
            }
        }
        public override void update(MouseState mouse, KeyboardState keyboard, List<wall> walls, List<Personnage> personnages, switch_map map)
        {

            animaitonspeed = 5;
            if (invulnerable == true)
                timer_invulnarable--;
            if (invulnerable && timer_invulnarable % 60 == 0)
                affichage_invul = true;
            if (timer_invulnarable == 0)
            {
                timer_invulnarable = 600;
                invulnerable = false;
                timer_inv2 = 10;
            }
            if (timer_inv2 == 0 & invulnerable)
            {
                affichage_invul = false;
                timer_inv2 = 10;
            }
            if (dash == true)
            {
                timer_dash--;
                canwalk = false;
                Dash(map);
            }
            if (timer_dash == 0)
            {
                dash = false;
                timer_dash = 2;
                canwalk = true;
            }
            if (dash == false)
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
                    Pv -= 15;
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
                if (Data.keyboardState.IsKeyDown(Keys.LeftShift) && Data.prevKeyboardState.IsKeyDown(Keys.LeftShift) && Endurance > 50)
                {
                    dash = true;
                    Endurance -= 50;
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
                    mana_player = pv_player;
                    Niveau++;
                    levelup = false;
                }
                if (keyboard.IsKeyUp(Keys.Space))
                    click_down = false;
            }
            precInvulnarable = invulnerable;
        }
        public override void Draw(SpriteBatch spritebatch)
        {
            timer_attaque++;
            if (combat == true && timer_attaque > 4)
            {
                timer_attaque = 0;
                framecolumn++;
                spritebatch.Draw(Image, new Rectangle((int)position.X, (int)position.Y, 32, 48), new Rectangle((this.Framecolumn - 1) * this.Taille_image_x - 1, (this.FrameLine - 1) * this.Taille_image_y - 1, this.Taille_image_x, this.Taille_image_y), Color.White);
                if (framecolumn - Frame_start == 7)
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
            //spritebatch.DrawString(ressource.ecriture, position_player.X + " " + position_player.Y, new Vector2(100, 0), Color.Red);
            if (affichage_invul)
                spritebatch.DrawString(ressource.ecriture, Convert.ToString(timer_invulnarable / 60), new Vector2(position_player.X + 32, position_player.Y), Color.Red);
            base.Draw(spritebatch);
        }
    }
}
