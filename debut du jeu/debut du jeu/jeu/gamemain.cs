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
    /*ceci est la fusion de la classe actionscreen(useless maintenant) et gamemain */
    class gamemain : GameScreen
    {

        //field ecran 
        Rectangle fenetre;
        public switch_map map;
        HUD HUD;
        BasicEffect effect;
        GamePlayer localPlayer;
        Color noir;
        Color white;
        List<wall> Walls;
        List<Personnage> personnage;
        List<NPC> list_zombi;
        List<sort> liste_sort;
        List<potion> liste_objet_map;
        KeyboardState keyboard;
        MouseState mouse;
        Vector2 position_joueur, position_npc;
        Random x;
        textbox text;
        bool ClickDown, pressdown;
        int pop_time, score, count_dead_zombi, timer_level_up;

        #region get set
        public GamePlayer player
        {
            get { return localPlayer; }
            set { localPlayer = value; }
        }

        public Rectangle Fenetre
        {
            get { return fenetre; }
            set { fenetre = value; }
        }

        public List<potion> List_Objet_Map
        {
            get { return liste_objet_map; }
            set { liste_objet_map = value; }
        }

        public List<sort> List_Sort
        {
            get { return liste_sort; }
            set { liste_sort = value; }
        }

        public List<wall> List_wall
        {
            get { return Walls; }
            set { Walls = value; }
        }

        public List<NPC> List_Zombie
        {
            get { return list_zombi; }
            set { list_zombi = value; }
        }
        #endregion
        #region field du jeu

        #endregion
        public gamemain(Game game, SpriteBatch spriteBatch, GameScreen activescreen, Donjon donjon)
            : base(game, spriteBatch)
        {
            //ICI
            /*
            prout = new Server(this);
            prout.StartConnexion();
             * */
            fenetre = new Rectangle(0, 0, game.Window.ClientBounds.Width, game.Window.ClientBounds.Height); //taille de la fenetre
            text = new textbox(new Rectangle(fenetre.Width / 3, fenetre.Height / 3, 96, 32));
            text.Is_shown = false;
            #region init du jeu
            map = new switch_map(localPlayer, this, donjon);
            map.Active_Map = map.Listes_map[0, 0];
            x = new Random();
            keyboard = new KeyboardState();
            liste_sort = new List<sort>();
            list_zombi = new List<NPC>();
            Walls = new List<wall>();
            personnage = new List<Personnage>();
            liste_objet_map = new List<potion>();
            position_joueur = new Vector2(32, 32);
            localPlayer = new GamePlayer(32,48 /*62, 121*/,4 , 10, 3, 10, position_joueur, 100, ressource.sprite_player, this, text);

            localPlayer.Niveau = 1;
            pop_time = 0;
            score = 0;
            count_dead_zombi = 0;
            #endregion init du jeu
            # region media_player;
            MediaPlayer.Play(ressource.main_theme);
            MediaPlayer.Volume = 0.56f;
            MediaPlayer.IsRepeating = true;
            # endregion
            noir.A = 200;
            noir.B = noir.G = noir.R = 0;
            white = Color.White;
            white.A = 120;
            effect = new BasicEffect(game.GraphicsDevice);

           
            HUD = new HUD(localPlayer, this);

        }
        public void ramassage_objet()
        {
            bool est_present = false;
            int j = 0;

            for (int i = 0; i < liste_objet_map.Count; i++)
                if (localPlayer.Hitbox_image.Intersects(liste_objet_map[i].Collide))
                {
                    while (!est_present && j < 25 && j < localPlayer.inventaire.Count())
                    {
                        if (localPlayer.inventaire.ElementAt(j) == liste_objet_map[i])
                        {
                            est_present = true;
                            localPlayer.nb_objet[j]++;
                            liste_objet_map.RemoveAt(i);
                            break;
                        }
                        j++;
                    }
                    if (localPlayer.inventaire.Count < 25)
                    {
                        localPlayer.inventaire.Add(liste_objet_map[i]);
                        liste_objet_map.RemoveAt(i);
                    }
                }
        }

        public override void Update(GameTime gameTime)
        {
            //ICI
            
            map.update();
            HUD.update();
            int pop_item = x.Next(0, 5);

            #region JEU
            keyboard = Keyboard.GetState();
            mouse = Mouse.GetState();
          
            int a = x.Next(0, 1200);
            int b = x.Next(0, 800);
            position_npc = new Vector2(32, 32);
            pop_time++;

            if (text.Is_shown == true)
            {
                if (Data.keyboardState.IsKeyDown(Keys.E) && Data.prevKeyboardState.IsKeyUp(Keys.E))
                    text.Is_shown = false;
            }
            else
            {

                #region ZOMBIE
                /*

                if (pop_time == 120)
                {
                    list_zombi.Add(new NPC(24, 32, 4, 2, 1, 15, position_npc, ressource.zombie, localPlayer, this));
                    pop_time = 0;
                }

                foreach (NPC zombie in list_zombi)
                    zombie.update(mouse, keyboard, Walls, personnage, map);

                foreach (NPC zombie in list_zombi)
                    if (localPlayer.Hitbox_image.Intersects(zombie.Hitbox_image))
                        localPlayer.pv_player--;

                for (int i = 0; i < list_zombi.Count; i++)
                    if (list_zombi[i].PV <= 0)
                    {
                        if (pop_item == 0)
                            liste_objet_map.Add(new potion(ressource.potion_vie, this, list_zombi[i], "VIE"));

                        if (pop_item == 1)
                            liste_objet_map.Add(new potion(ressource.potion_mana, this, list_zombi[i], "MANA"));

                        list_zombi.RemoveAt(i);
                        score += 5;

                        localPlayer.XP += 20 / localPlayer.Niveau;
                    }

           
                */
                #endregion 
                #region PLAYER
                localPlayer.update(mouse, keyboard, Walls, personnage, map); //fait l'update du player
                //cheat code
                if (keyboard.IsKeyDown(Keys.M))
                    localPlayer.mana_player = 100;
                if (keyboard.IsKeyDown(Keys.V))
                    localPlayer.pv_player = 100;

                //leveling
                if (localPlayer.XP >= 100)
                {
                    timer_level_up = 0;
                    localPlayer.levelup = true;
                }
                #endregion
                #region WALL
                //fait l'update des murs

                foreach (wall wall in Walls)
                    wall.Update(mouse, keyboard);

                //dessine des nouveau mur

                if (mouse.LeftButton == ButtonState.Pressed && !ClickDown)
                {
                    Walls.Add(new wall(mouse.X, mouse.Y, ressource.pixel, 32, Color.Black));
                    ClickDown = true;
                }
                #endregion WALL
                #region ITEM

                ramassage_objet();

                if (keyboard.IsKeyDown(Keys.Space) && !pressdown && localPlayer.mana_player > 0)
                {
                    if (localPlayer.Active == "feu")
                        ressource.feu.Play();

                    liste_sort.Add(localPlayer.Active_Sort);
                    pressdown = true;
                }

                foreach (sort sort in liste_sort)
                    sort.update();



                for (int i = 0; i < liste_sort.Count; i++)
                    for (int j = 0; j < Walls.Count; j++)
                        if (liste_sort[i].hitbox_object.Intersects(Walls[j].Hitbox))
                        {
                            Walls.RemoveAt(j);
                            liste_sort.RemoveAt(i);
                            break;
                        }

                for (int i = 0; i < liste_sort.Count; i++)
                    for (int j = 0; j < list_zombi.Count; j++)
                        if (liste_sort[i].hitbox_object.Intersects(list_zombi[j].Hitbox_image))
                        {
                            list_zombi[j].PV -= 100;
                            liste_sort.RemoveAt(i);
                            break;
                        }

                #endregion SORT
                // collision oO riena  foutre la ce truc xD
                if (position_joueur.X + ressource.sprite_player.Width == game.Window.ClientBounds.Width)
                    position_joueur.X = 0;

                // LEVEL UP! 
                if (count_dead_zombi == 5)
                {
                    localPlayer.Niveau++;
                    count_dead_zombi = 0;
                }

            #endregion update jeu
                if (mouse.LeftButton == ButtonState.Released)
                    ClickDown = false;
                if (keyboard.IsKeyUp(Keys.Space))
                    pressdown = false;
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            map.Active_Map.Draw(spriteBatch, 32);
            timer_level_up++;

            if (text.Is_shown)
                text.Draw(spriteBatch);

            #region draw du jeu
            foreach (item item in liste_objet_map)
                item.draw(spriteBatch);

            foreach (wall wall in Walls)
                wall.Draw(spriteBatch);

            foreach (NPC zombie in list_zombi)
                zombie.Draw(spriteBatch);

            foreach (sort boule in liste_sort)
                boule.draw(spriteBatch);

            localPlayer.Draw(spriteBatch);

            spriteBatch.DrawString(ressource.ecriture, Convert.ToString(score), new Vector2(500, 0), Color.Yellow);

            if (timer_level_up < 60 && localPlayer.Niveau != 1)
                spriteBatch.DrawString(ressource.ecriture, "LEVEL UP !", new Vector2(localPlayer.position_player.X, localPlayer.position_player.Y - 10), Color.Yellow);
            #endregion draw du jeu

            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    if (map.Listes_map[i, j] != null)
                        spriteBatch.Draw(ressource.pixel, new Rectangle(600 + 32 * i, 300 + 32 * j, 16, 8), Color.FromNonPremultiplied(51, 204, 0, 50));
                    else
                        spriteBatch.Draw(ressource.pixel, new Rectangle(600 + 32 * i, 300 + 32 * j, 16, 8), Color.FromNonPremultiplied(250, 250, 250, 50));

            HUD.draw(spriteBatch);
            spriteBatch.DrawString(ressource.ecriture, "coordonner map" + map.x + "  " + map.y, new Vector2(0, 100), Color.Yellow);

            base.Draw(gameTime);
        }
    }
}
