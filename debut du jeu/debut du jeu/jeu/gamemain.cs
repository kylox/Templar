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
    public class gamemain : GameScreen
    {

        //field ecran 
        #region variable
        public Donjon donj;
        public string IP;
        public Server Serveur;
        public Client Client;
        Rectangle fenetre;
        public switch_map map;
        HUD HUD;
        BasicEffect effect;
        GamePlayer localPlayer;
        public GamePlayer Player2;
        Color noir;
        Color white;
        List<wall> Walls;
        List<Personnage> personnage;
        List<NPC> list_zombi;
        List<sort> liste_sort;
        List<potion> liste_objet_map;
        KeyboardState keyboard;
        MouseState mouse;
        public Vector2 position_joueur, position_npc;
        Random x;
        textbox text;
        public bool same_map, Is_Server, Is_Client;
        bool ClickDown, pressdown;
        int pop_time, score, count_dead_zombi, timer_level_up;
        Princess princess;
        string nom_donjon;
        bool langue;
        #endregion
        #region get set
        public GamePlayer player2 { get { return Player2; } set { Player2 = value; } }
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
        public gamemain(Game game, SpriteBatch spriteBatch, GameScreen activescreen, Donjon donjon, bool is2p, string ip, string name_donjon, bool language)
            : base(game, spriteBatch)
        {
            langue = language;
            nom_donjon = name_donjon;
            fenetre = new Rectangle(0, 0, game.Window.ClientBounds.Width, game.Window.ClientBounds.Height); //taille de la fenetre
            text = new textbox(new Rectangle(0, 18 * 32 + 7, 200, 100));
            text.Is_shown = false;
            #region init du jeu
            x = new Random();
            keyboard = new KeyboardState();
            liste_sort = new List<sort>();
            //ICI POUR LOADMOB
            //FIN ICI
            Walls = new List<wall>();
            personnage = new List<Personnage>();
            liste_objet_map = new List<potion>();
            position_joueur = donjon.position_J;
            localPlayer = new GamePlayer(32, 48, 4, 8, 2, 15, 2, position_joueur, ressource.sprite_player, this, text, language);
            localPlayer.Niveau = 1;
            if (!is2p)
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (donjon.Map[i, j] != null)
                            donjon.Map[i, j].load_mob(@"Donjons\" + @name_donjon + @"\Map" + donjon.Map[i, j].Nb + @"\creature" + @".txt", this);
                    }
                }
            }
            donj = donjon;
            map = new switch_map(localPlayer/*, this*/, donjon, name_donjon);
            map.x = (int)donjon.map.X;
            map.y = (int)donjon.map.Y;
            list_zombi = map.Active_Map.monstre;
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
        public void StartReseauConnexion()
        {
            if (Is_Server)
            {
                Serveur = new Server();
                same_map = true;
                Player2 = new GamePlayer(32, 48, 4, 8, 2, 8, 8, position_joueur, ressource.sprite_player, this, text, langue);
                while (Serveur.isrunnin)
                {
                }
            }
            if (Is_Client)
            {
                Client = new Client(IP);
                same_map = true;
                Player2 = new GamePlayer(32, 48, 4, 8, 2, 8, 8, position_joueur, ressource.sprite_player, this, text, langue);
            }
        }
        public void AddP2()
        {
            Player2 = new GamePlayer(32, 48, 4, 8, 2, 10, 8, position_joueur, ressource.sprite_player, this, text, langue);
        }
        public void ramassage_objet()
        {
            bool est_present = false;
            bool libre = false;
            int j = 0;
            int x = 0, y = 0;
            for (int i = 0; i < liste_objet_map.Count; i++)
                if (localPlayer.Hitbox_image.Intersects(liste_objet_map[i].Collide))
                {
                    for (int k = 0; k < 5; k++)
                    {
                        for (int l = 0; l < 5; l++)
                        {
                            if (localPlayer.inventaire[l, k] == liste_objet_map[i])
                            {
                                est_present = true;
                                localPlayer.nb_objet[j]++;
                                liste_objet_map.RemoveAt(i);
                            }
                            if (localPlayer.inventaire[l, k] == null && libre == false)
                            {
                                libre = true;
                                x = l;
                                y = k;
                            }
                        }
                    }
                    if (!est_present && libre == true)
                    {
                        localPlayer.inventaire[x, y] = liste_objet_map[i];
                        liste_objet_map.RemoveAt(i);
                    }
                }
        }
        public override void Update(GameTime gameTime)
        {
            text.Fenetre.Width = (int)ressource.ecriture.MeasureString(map.Active_Map.Message).X + 7;
            text.Fenetre.Height = (int)ressource.ecriture.MeasureString(map.Active_Map.Message).Y + 7;
            //ICI
            if (text.Is_shown == false)
            {
                /*if (Is_Server&& Serveur.Client != null)
                    Serveur.Ping();
                if (Is_Client && Client.client != null)
                    Client.ping();*/
                map.update(localPlayer,this);
                HUD.update();
                int pop_item = x.Next(0, 5);
                #region JEU
                keyboard = Keyboard.GetState();
                mouse = Mouse.GetState();
                #region ZOMBIE
                int a = x.Next(0, 1200);
                int b = x.Next(0, 800);
                position_npc = new Vector2(32, 32);
                //pop_time++;

                if (text.Is_shown == true || localPlayer.in_action == true)
                {
                    if (Data.keyboardState.IsKeyDown(Keys.E) && Data.prevKeyboardState.IsKeyUp(Keys.E))
                    {
                        text.Is_shown = false;
                        localPlayer.in_action = false;
                        localPlayer.Coffre_ouvert.is_open = false;
                        localPlayer.Coffre_ouvert = null;
                    }
                    if (localPlayer.Coffre_ouvert != null)
                        localPlayer.Coffre_ouvert.Update(localPlayer);
                }
                else
                {
                    if (pop_time == 120)
                    {
                        list_zombi.Add(new NPC(32, 48, 4, 3, 16, 15, 4, position_npc, ressource.mob, localPlayer, map.Active_Map));
                        /* if (Is_Server)
                             Serveur.Send(42, 1, 0);
                         if (Is_Client)
                             Client.Send(42, 1, 0);*/
                        pop_time = 0;
                    }
                    if (Data.keyboardState.IsKeyDown(Keys.P) && Data.prevKeyboardState.IsKeyUp(Keys.P))
                    {
                        princess = new Princess(32, 48, 4, 3, 40, 15, 2, new Vector2(64, 32), ressource.mob, localPlayer);
                        /* if (Is_Server)
                             Serveur.Send(42, 1, 0);
                         if (Is_Client)
                             Client.Send(42, 1, 0);*/
                    }
                    if (Data.keyboardState.IsKeyDown(Keys.U) && Data.prevKeyboardState.IsKeyUp(Keys.U))
                    {
                        list_zombi.Add(new NPC(32, 48, 4, 3, 10, 15, 2, position_npc, ressource.mob, localPlayer, map.Active_Map));
                        /* if (Is_Server)
                             Serveur.Send(42, 1, 0);
                         if (Is_Client)
                             Client.Send(42, 1, 0);*/
                    }
                    if (Data.keyboardState.IsKeyDown(Keys.I) && Data.prevKeyboardState.IsKeyUp(Keys.I))
                    {
                        list_zombi.Add(new NPC(32, 48, 4, 3, 1, 15, 2, position_npc, ressource.mob, localPlayer, map.Active_Map));
                        /* if (Is_Server)
                             Serveur.Send(42, 1, 0);
                         if (Is_Client)
                             Client.Send(42, 1, 0);*/
                    }
                    if (Data.keyboardState.IsKeyDown(Keys.O) && Data.prevKeyboardState.IsKeyUp(Keys.O))
                    {
                        list_zombi.Add(new NPC(32, 48, 4, 3, 4, 15, 4, position_npc, ressource.mob, localPlayer, map.Active_Map));
                        /*if (Is_Server)
                            Serveur.Send(42, 1, 0);
                        if (Is_Client)
                            Client.Send(42, 1, 0);*/
                    }
                    foreach (NPC zombie in list_zombi)
                        zombie.update(mouse, keyboard, Walls, personnage, map);
                    foreach (NPC zombie in list_zombi)
                        if (localPlayer.Hitbox_image.Intersects(zombie.Hitbox_image))
                        {
                            zombie.combat = true;
                            zombie.Attaque(localPlayer);
                        }
                    for (int i = 0; i < list_zombi.Count; i++)
                    {
                        if (localPlayer.combat == true)
                            switch (localPlayer.frameline)
                            {
                                case 5:
                                    if (new Rectangle((int)localPlayer.position_player.X, (int)localPlayer.position_player.Y + 32, 32, 32).Intersects(list_zombi[i].Hitbox_image) ||
                                        new Rectangle((int)localPlayer.position_player.X, (int)localPlayer.position_player.Y, 32, 32).Intersects(list_zombi[i].Hitbox_image))
                                        list_zombi[i].touché(Direction.Down,localPlayer);
                                    break;
                                case 6:
                                    if (new Rectangle((int)localPlayer.position_player.X + 32, (int)localPlayer.position_player.Y, 32, 32).Intersects(list_zombi[i].Hitbox_image) ||
                                        new Rectangle((int)localPlayer.position_player.X, (int)localPlayer.position_player.Y, 32, 32).Intersects(list_zombi[i].Hitbox_image))
                                        list_zombi[i].touché(Direction.Left,localPlayer);
                                    break;
                                case 7:
                                    if (new Rectangle((int)localPlayer.position_player.X, (int)localPlayer.position_player.Y - 32, 32, 32).Intersects(list_zombi[i].Hitbox_image) ||
                                        new Rectangle((int)localPlayer.position_player.X, (int)localPlayer.position_player.Y, 32, 32).Intersects(list_zombi[i].Hitbox_image))
                                        list_zombi[i].touché(Direction.Up,localPlayer);
                                    break;
                                case 8:
                                    if (new Rectangle((int)localPlayer.position_player.X - 32, (int)localPlayer.position_player.Y, 32, 32).Intersects(list_zombi[i].Hitbox_image) ||
                                        new Rectangle((int)localPlayer.position_player.X, (int)localPlayer.position_player.Y, 32, 32).Intersects(list_zombi[i].Hitbox_image))
                                        list_zombi[i].touché(Direction.Right,localPlayer);
                                    break;
                            }
                        if (list_zombi[i].PV <= 0)
                        {
                            if (pop_item == 0)
                                liste_objet_map.Add(new potion(ressource.potion_vie, list_zombi[i], "VIE"));

                            if (pop_item == 1)
                                liste_objet_map.Add(new potion(ressource.potion_mana, list_zombi[i], "MANA"));

                            list_zombi.RemoveAt(i);
                            /*if (Is_Server)
                                Serveur.Send(41, i, 0);
                            if (Is_Client)
                                Client.Send(41, i, 0);*/
                            score += 5;

                            localPlayer.XP += 20 / localPlayer.Niveau;
                        }
                    }
                #endregion ZOMBIE
                    #region PLAYER
                    localPlayer.update(mouse, keyboard, Walls, personnage, map); //fait l'update du player


                    if (Is_Server)
                    {
                        Serveur.Send(2, (int)player.Position.X, (int)player.position_player.Y);
                        switch (player.direction)
                        {
                            case Direction.Up:
                                Serveur.Send(11, 3, 0);
                                break;
                            case Direction.Down:
                                Serveur.Send(11, 1, 0);
                                break;
                            case Direction.Left:
                                Serveur.Send(11, 2, 0);
                                break;
                            case Direction.Right:
                                Serveur.Send(11, 4, 0);
                                break;
                            case Direction.None:
                                Serveur.Send(11, 0, 0);
                                break;
                            default:
                                break;
                        }
                        Serveur.Parser(this);
                        player2.animate();
                    }
                    if (Is_Client)
                    {
                        Client.Send(2, (int)player.Position.X, (int)player.position_player.Y);
                        switch (player.direction)
                        {
                            case Direction.Up:
                                Client.Send(11, 0, 0);
                                break;
                            case Direction.Down:
                                Client.Send(11, 1, 0);
                                break;
                            case Direction.Left:
                                Client.Send(11, 2, 0);
                                break;
                            case Direction.Right:
                                Client.Send(11, 3, 0);
                                break;
                            case Direction.None:
                                Client.Send(11, 4, 0);
                                break;
                            default:
                                break;
                        }
                        Client.Parser(this);
                        player2.animate();
                    }

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
                    foreach (wall wall in Walls)
                        wall.Update(mouse, keyboard);

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
                        /* if (Is_Server)
                         {
                             Serveur.Send(32, player.Sort_selec, 0);
                         }
                         if (Is_Client)
                         {
                             Client.Send(32, player.Sort_selec, 0);
                         }*/
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
                                if (Is_Client)
                                {
                                    Client.Send(31, i, 0);
                                }
                                if (Is_Server)
                                {
                                    Serveur.Send(31, i, 0);
                                }
                                break;
                            }

                    #endregion SORT
                    // collision oO riena  foutre la ce truc xD
                    if (position_joueur.X + ressource.sprite_player.Width == game.Window.ClientBounds.Width)
                        position_joueur.X = 0;
                    if (princess != null)
                        princess.update(mouse, keyboard, Walls, personnage, map);
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
                if (map.Active_Map.Visited == false)
                {
                    text.Is_shown = true;
                    text.Saisie = map.Active_Map.Message;
                }
            }
            if (Data.keyboardState.IsKeyDown(Keys.Enter) && Data.prevKeyboardState.IsKeyUp(Keys.Enter))
            {
                text.Is_shown = false;
                map.Active_Map.Visited = true;
            }
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            map.Active_Map.Draw(spriteBatch, 32);
            timer_level_up++;
            if (text.Is_shown)
                text.Draw(spriteBatch);
            text.Draw(spriteBatch);
            #region draw du jeu
            foreach (item item in liste_objet_map)
                item.draw(spriteBatch, (int)item.Position.X, (int)item.Position.Y, 32, 32);

            foreach (wall wall in Walls)
                wall.Draw(spriteBatch);

            foreach (NPC zombie in list_zombi)
                zombie.Draw(spriteBatch);

            foreach (sort boule in liste_sort)
                boule.draw(spriteBatch);

            localPlayer.Draw(spriteBatch);
            if (Is_Client || Is_Server)
                Player2.Draw(spriteBatch);

            spriteBatch.DrawString(ressource.ecriture, Convert.ToString(score), new Vector2(500, 0), Color.Yellow);

            if (timer_level_up < 60 && localPlayer.Niveau != 1)
                spriteBatch.DrawString(ressource.ecriture, "LEVEL UP !", new Vector2(localPlayer.position_player.X, localPlayer.position_player.Y - 10), Color.Yellow);
            #endregion draw du jeu
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    if (map.Listes_map[i, j] != null)
                        spriteBatch.Draw(ressource.pixel, new Rectangle(Fenetre.Width - 160 + 32 * i, 300 + 32 * j, 16, 8), Color.FromNonPremultiplied(51, 204, 0, 50));
                    else
                        spriteBatch.Draw(ressource.pixel, new Rectangle(Fenetre.Width - 160 + 32 * i, 300 + 32 * j, 16, 8), Color.FromNonPremultiplied(250, 250, 250, 50));

            spriteBatch.Draw(ressource.pixel, new Rectangle(Fenetre.Width - 160 + 32 * map.x, 300 + 32 * map.y, 16, 1), Color.Red);
            spriteBatch.Draw(ressource.pixel, new Rectangle(Fenetre.Width - 160 + 32 * map.x, 300 + 32 * map.y, 1, 8), Color.Red);
            spriteBatch.Draw(ressource.pixel, new Rectangle(Fenetre.Width - 160 + 32 * map.x, 300 + 32 * map.y + 8, 16, 1), Color.Red);
            spriteBatch.Draw(ressource.pixel, new Rectangle(Fenetre.Width - 160 + 32 * map.x + 16, 300 + 32 * map.y, 1, 8), Color.Red);

            if (princess != null)
                princess.Draw(spriteBatch);
            HUD.draw(spriteBatch);
            spriteBatch.DrawString(ressource.ecriture, "coordonnees map" + map.x + "  " + map.y, new Vector2(0, 100), Color.Yellow);
            //dessine le rouge des collisions pour voir que ca marche A SUPPRIMER
            for (int i = 0; i < 25; i++)
                for (int j = 0; j < 18; j++)
                    if (map.Active_Map.colision[i, j] == 1)
                        spriteBatch.Draw(ressource.pixel, new Rectangle(i * 32, j * 32, 32, 32), Color.FromNonPremultiplied(204, 0, 0, 50));
            base.Draw(gameTime);
        }
    }
}
