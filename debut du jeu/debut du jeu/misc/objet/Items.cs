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

    public class Items : item
    {
        Random rd = new Random();
        bool langue;
        public Vector2 positin_tile;

        public string display_name(Vector2 position_tileset)
        {

            if (position_tileset == new Vector2(0, 0))
                return "revele la position de la princesse au joueur";
            else if (position_tileset == new Vector2(1, 0))
                return "revele la position de la princesse au joueur";
            else if (position_tileset == new Vector2(2, 0))
                return "restore 10 pv au joueur";
            else if (position_tileset == new Vector2(3, 0))
                return "augmente la magie du joueur de 5";
            else if (position_tileset == new Vector2(4, 0))
                return "augmente la magie du joueur de 10";
            else if (position_tileset == new Vector2(5, 0))
                return "augmente la magie du joueur de 2";
            else if (position_tileset == new Vector2(6, 0))
                return "augmente la magie du joueur de 7";
            else
                if (position_tileset == new Vector2(0, 1))
                    return "detruit tout les mobs de la carte";
                else if (position_tileset == new Vector2(1, 1))
                    return "detruit un mob de la carte";
                else if (position_tileset == new Vector2(2, 1))
                    return "restore 20 pv au joueur";
                else if (position_tileset == new Vector2(3, 1))
                    return "augmente l'attaque du joueur de 5";
                else if (position_tileset == new Vector2(4, 1))
                    return "augmente l'attaque du joueur de 10";
                else if (position_tileset == new Vector2(5, 1))
                    return "augmente l'attaque du joueur de 2";
                else if (position_tileset == new Vector2(6, 1))
                    return "augmente l'attaque du joueur de 7";
                else
                    if (position_tileset == new Vector2(0, 2))
                        return "ramene a la map d'origine";
                    else if (position_tileset == new Vector2(1, 2))
                        return "rend le personnage invulnerable pendant 10 secondes";
                    else if (position_tileset == new Vector2(2, 2))
                        return "restore 40 pv au joueur";
                    else if (position_tileset == new Vector2(3, 2))
                        return "augmente l'endurance du joueur de 5";
                    else if (position_tileset == new Vector2(4, 2))
                        return "augmente l'endurance du joueur de 10";
                    else if (position_tileset == new Vector2(5, 2))
                        return "augmente l'endurance du joueur de 2";
                    else if (position_tileset == new Vector2(6, 2))
                        return "augmente l'endurance du joueur de 7";
                    else
                        if (position_tileset == new Vector2(0, 3))
                            return "restore 5 point de mana";
                        else if (position_tileset == new Vector2(1, 3))
                            return "restore 10 point de mana";
                        else if (position_tileset == new Vector2(2, 3))
                            return "restore 60 pv au joueur";
                        else if (position_tileset == new Vector2(3, 3))
                            return "augmente la vitesse du joueur de 1";
                        else if (position_tileset == new Vector2(4, 3))
                            return "augmente la vitesse du joueur de 2";
                        else if (position_tileset == new Vector2(5, 3))
                            return "augmente la vitesse du joueur de 3";
                        else if (position_tileset == new Vector2(6, 3))
                            return "augmente la vitesse du joueur de 4";
                        else
                            if (position_tileset == new Vector2(0, 4))
                                return "restore 20 point de mana au joueur";
                            else if (position_tileset == new Vector2(1, 4))
                                return "restore 40 point de mana au joueur";
                            else if (position_tileset == new Vector2(2, 4))
                                return "restore 100 pv au joueur";
                            else if (position_tileset == new Vector2(3, 4))
                                return "augmente les points de vie max du joueur de 50";
                            else if (position_tileset == new Vector2(4, 4))
                                return "augmente la points de vie max du joueur de 100";
                            else if (position_tileset == new Vector2(5, 4))
                                return "augmente les points de vie max du joueur de 25";
                            else if (position_tileset == new Vector2(6, 4))
                                return "augmente les points de vie max du joueur de 75";
                            else
                                if (position_tileset == new Vector2(0, 5))
                                    return "restore 80 points de mana au joueur";
                                else if (position_tileset == new Vector2(1, 5))
                                    return "restore 160 points de mana au joueur";
                                else if (position_tileset == new Vector2(2, 5))
                                    return "restore 150 pv au joueur";
                                else if (position_tileset == new Vector2(3, 5))
                                    return "augmente les point de mana max du joueur de 50";
                                else if (position_tileset == new Vector2(4, 5))
                                    return "augmente les points de mana max du joueur de 100";
                                else if (position_tileset == new Vector2(5, 5))
                                    return "augmente les points de mana max du joueur de 25";
                                else if (position_tileset == new Vector2(6, 5))
                                    return "augmente les points de mana max du joueur de 75";
                                else
                                    if (position_tileset == new Vector2(0, 6))
                                        return "titre de propriete du donjon";
                                    else if (position_tileset == new Vector2(1, 6))
                                        return "un rouleau de PQ restore toute la vie du personnage";
                                    else if (position_tileset == new Vector2(2, 6))
                                        return "restore 200 pv au joueur";
                                    else if (position_tileset == new Vector2(3, 6))
                                        return "augmente la defense du joueur de 5";
                                    else if (position_tileset == new Vector2(4, 6))
                                        return "augmente la defense du joueur de 10";
                                    else if (position_tileset == new Vector2(5, 6))
                                        return "augmente la defense du joueur de 2";
                                    else if (position_tileset == new Vector2(6, 6))
                                        return "augmente la defense du joueur de 7";
            return "";
        }
        public Items(Vector2 position_tileset, bool language)
            : base(ressource.item, position_tileset)
        {

            usable = false;
            is_equipable = false;
            positin_tile = position_tileset;
            if (position_tileset == new Vector2(0, 0))
            {
                utilité = "revele la position de la princesse au joueur";
                usable = true;
            }
            else if (position_tileset == new Vector2(1, 0))
            {
                utilité = "revele la position de la princesse au joueur";
                usable = true;
            }
            else if (position_tileset == new Vector2(2, 0))
            {
                utilité = "restore 10 pv au joueur";
                usable = true;
            }
            else if (position_tileset == new Vector2(3, 0))
            {
                utilité = "augmente la magie du joueur de 5";
                Bonus = new int[] { 0, 5, 0, 0, 0, 0, 0 };
                is_equipable = true;
            }
            else if (position_tileset == new Vector2(4, 0))
            {
                utilité = "augmente la magie du joueur de 10";
                Bonus = new int[] { 0, 10, 0, 0, 0, 0, 0 };
                is_equipable = true;
            }
            else if (position_tileset == new Vector2(5, 0))
            {
                utilité = "augmente la magie du joueur de 2";
                Bonus = new int[] { 0, 2, 0, 0, 0, 0, 0 };
                is_equipable = true;
            }
            else if (position_tileset == new Vector2(6, 0))
            {
                utilité = "augmente la magie du joueur de 7";
                Bonus = new int[] { 0, 7, 0, 0, 0, 0, 0 };
                is_equipable = true;
            }
            else
                if (position_tileset == new Vector2(0, 1))
                {
                    utilité = "detruit tout les mobs de la carte";
                    usable = true;
                }
                else if (position_tileset == new Vector2(1, 1))
                {
                    utilité = "detruit un mob de la carte";
                    usable = true;
                }
                else if (position_tileset == new Vector2(2, 1))
                {
                    utilité = "restore 20 pv au joueur";
                    usable = true;
                }
                else if (position_tileset == new Vector2(3, 1))
                {
                    utilité = "augmente l'attaque du joueur de 5";
                    Bonus = new int[] { 5, 0, 0, 0, 0, 0, 0 };
                    is_equipable = true;
                }
                else if (position_tileset == new Vector2(4, 1))
                {
                    utilité = "augmente l'attaque du joueur de 10";
                    Bonus = new int[] { 10, 0, 0, 0, 0, 0, 0 };
                    is_equipable = true;
                }
                else if (position_tileset == new Vector2(5, 1))
                {
                    utilité = "augmente l'attaque du joueur de 2";
                    Bonus = new int[] { 2, 0, 0, 0, 0, 0, 0 };
                    is_equipable = true;
                }
                else if (position_tileset == new Vector2(6, 1))
                {
                    utilité = "augmente l'attaque du joueur de 7";
                    Bonus = new int[] { 7, 0, 0, 0, 0, 0, 0 };
                    is_equipable = true;
                }
                else
                    if (position_tileset == new Vector2(0, 2))
                    {
                        utilité = "ramene a la map d'origine";
                        usable = true;
                    }
                    else if (position_tileset == new Vector2(1, 2))
                    {
                        utilité = "rend le personnage invulnerable pendant 10 secondes";
                        usable = true;
                    }
                    else if (position_tileset == new Vector2(2, 2))
                    {
                        utilité = "restore 30 pv au joueur";
                        usable = true;
                    }
                    else if (position_tileset == new Vector2(3, 2))
                    {
                        utilité = "augmente l'endurance du joueur de 5";
                        Bonus = new int[] { 0, 0, 5, 0, 0, 0, 0 };
                        is_equipable = true;
                    }
                    else if (position_tileset == new Vector2(4, 2))
                    {
                        utilité = "augmente l'endurance du joueur de 10";
                        Bonus = new int[] { 0, 0, 10, 0, 0, 0, 0 };
                        is_equipable = true;
                    }
                    else if (position_tileset == new Vector2(5, 2))
                    {
                        utilité = "augmente l'endurance du joueur de 2";
                        Bonus = new int[] { 0, 0, 2, 0, 0, 0, 0 };
                        is_equipable = true;
                    }
                    else if (position_tileset == new Vector2(6, 2))
                    {
                        utilité = "augmente l'endurance du joueur de 7";
                        Bonus = new int[] { 0, 0, 7, 0, 0, 0, 0 };
                        is_equipable = true;
                    }
                    else
                        if (position_tileset == new Vector2(0, 3))
                        {
                            utilité = "restore 5 point de mana";
                            usable = true;
                        }
                        else if (position_tileset == new Vector2(1, 3))
                        {
                            utilité = "restore 10 point de mana";
                            usable = true;
                        }
                        else if (position_tileset == new Vector2(2, 3))
                        {
                            utilité = "restore 40 pv au joueur";
                            usable = true;
                        }
                        else if (position_tileset == new Vector2(3, 3))
                        {
                            utilité = "augmente le nombre de dash du joueur de 1";
                            Bonus = new int[] { 0, 0, 0, 1, 0, 0, 0 };
                            is_equipable = true;
                        }
                        else if (position_tileset == new Vector2(4, 3))
                        {
                            utilité = "augmente le nombre de dash du joueur de 2";
                            Bonus = new int[] { 0, 0, 0, 2, 0, 0, 0 };
                            is_equipable = true;
                        }
                        else if (position_tileset == new Vector2(5, 3))
                        {
                            utilité = "augmente le nombre de dash du joueur de 3";
                            Bonus = new int[] { 0, 0, 0, 3, 0, 0, 0 };
                            is_equipable = true;
                        }
                        else if (position_tileset == new Vector2(6, 3))
                        {
                            utilité = "augmente le nombre de dash du joueur de 4";
                            Bonus = new int[] { 0, 0, 0, 4, 0, 0, 0 };
                            is_equipable = true;
                        }
                        else if (position_tileset == new Vector2(7, 3))
                        {
                            utilité = "augmente le nombre de dash du joueur de 5";
                            Bonus = new int[] { 0, 0, 0, 5, 0, 0, 0 };
                            is_equipable = true;
                        }
                        else
                            if (position_tileset == new Vector2(0, 4))
                            {
                                utilité = "restore 20 point de mana";
                                usable = true;
                            }
                            else if (position_tileset == new Vector2(1, 4))
                            {
                                utilité = "restore 40 point de mana";
                                usable = true;
                            }
                            else if (position_tileset == new Vector2(2, 4))
                            {
                                utilité = "restore 160 pv au joueur";
                                usable = true;
                            }
                            else if (position_tileset == new Vector2(3, 4))
                            {
                                utilité = "augmente les points de vie du joueur de 50";
                                Bonus = new int[] { 0, 0, 0, 0, 50, 0, 0 };
                                is_equipable = true;
                            }
                            else if (position_tileset == new Vector2(4, 4))
                            {
                                utilité = "augmente les points de vie du joueur de 100";
                                Bonus = new int[] { 0, 0, 0, 0, 50, 0, 0 };
                                is_equipable = true;
                            }
                            else if (position_tileset == new Vector2(5, 4))
                            {
                                utilité = "augmente les points de vie du joueur de 25";
                                Bonus = new int[] { 0, 0, 0, 0, 25, 0, 0 };
                                is_equipable = true;
                            }
                            else if (position_tileset == new Vector2(6, 4))
                            {
                                utilité = "augmente les points de vie du joueur de 75";
                                Bonus = new int[] { 0, 0, 0, 0, 75, 0, 0 };
                                is_equipable = true;
                            }

                            else
                                if (position_tileset == new Vector2(0, 5))
                                {
                                    utilité = "restore 80 point de mana";
                                    usable = true;
                                }
                                else if (position_tileset == new Vector2(1, 5))
                                {
                                    utilité = "restore 160 point de mana";
                                    usable = true;
                                }
                                else if (position_tileset == new Vector2(2, 5))
                                {
                                    utilité = "restore 20 pv au joueur";
                                    usable = true;
                                }
                                else if (position_tileset == new Vector2(3, 5))
                                {
                                    utilité = "augmente les points de mana max du joueur de 50";
                                    Bonus = new int[] { 0, 0, 0, 0, 0, 50, 0 };
                                }
                                else if (position_tileset == new Vector2(4, 5))
                                {
                                    utilité = "augmente les points de mana max du joueur de 100";
                                    Bonus = new int[] { 0, 0, 0, 0, 0, 100, 0 };
                                }
                                else if (position_tileset == new Vector2(5, 5))
                                {
                                    utilité = "augmente les points de mana max du joueur de 25";
                                    Bonus = new int[] { 0, 0, 0, 0, 0, 25, 0 };
                                }
                                else if (position_tileset == new Vector2(6, 5))
                                {
                                    utilité = "augmente les points de mana max du joueur de 75";
                                    Bonus = new int[] { 0, 0, 0, 0, 0, 75, 0 };
                                }
                                else
                                    if (position_tileset == new Vector2(0, 6))
                                    {
                                        utilité = "titre de propriété du donjon";
                                        usable = true;
                                    }
                                    else if (position_tileset == new Vector2(1, 6))
                                    {
                                        utilité = "un rouleau de PQ restore toute la vie du personnage";
                                        usable = true;
                                    }
                                    else if (position_tileset == new Vector2(2, 6))
                                    {
                                        utilité = "restore 200 pv au joueur";
                                        usable = true;
                                    }
                                    else if (position_tileset == new Vector2(3, 6))
                                    {
                                        utilité = "augmente la defense du joueur de 5";
                                        Bonus = new int[] { 0, 0, 0, 0, 0, 0, 5 };
                                    }
                                    else if (position_tileset == new Vector2(4, 6))
                                    {
                                        utilité = "augmente la defense du joueur de 10";
                                        Bonus = new int[] { 0, 0, 0, 0, 0, 0, 10 };
                                    }
                                    else if (position_tileset == new Vector2(5, 6))
                                    {
                                        utilité = "augmente la defense du joueur de 2";
                                        Bonus = new int[] { 0, 0, 0, 0, 0, 0, 2 };
                                    }
                                    else if (position_tileset == new Vector2(6, 6))
                                    {
                                        utilité = "augmente la defense du joueur de 7";
                                        Bonus = new int[] { 0, 0, 0, 0, 0, 0, 7 };
                                    }
        }
        public override void action(gamemain main)
        {
            if (positin_tile == new Vector2(0, 0))
            {
                utilité = "revele la position de la princesse au joueur";
                usable = true;
            }
            else if (positin_tile == new Vector2(1, 0))
            {
                utilité = "revele la position de la princesse au joueur";
                usable = true;
            }
            else if (positin_tile == new Vector2(2, 0))
            {
                main.player.pv_player += 10;
            }
            else
                if (positin_tile == new Vector2(0, 1))
                {
                    main.List_Zombie.Clear();
                    utilité = "detruit tout les mobs de la carte";
                    usable = true;
                }
                else if (positin_tile == new Vector2(1, 1))
                {
                    main.List_Zombie.RemoveAt(rd.Next(main.List_Zombie.Count));
                    utilité = "detruit un mob de la carte";
                    usable = true;
                }
                else if (positin_tile == new Vector2(2, 1))
                {
                    utilité = "restore 20 pv au joueur";
                    main.player.pv_player += 20;
                    usable = true;
                }
                else
                    if (positin_tile == new Vector2(0, 2))
                    {
                        utilité = "ramene a la map d'origine";
                        usable = true;
                    }
                    else if (positin_tile == new Vector2(1, 2))
                    {
                        utilité = "rend le personnage invulnerable pendant 10 secondes";
                        main.player.invulnerable = true;
                        usable = true;
                    }
                    else if (positin_tile == new Vector2(2, 2))
                    {
                        utilité = "restore 40 pv au joueur";
                        main.player.pv_player += 0;
                        usable = true;
                    }
                    else
                        if (positin_tile == new Vector2(0, 3))
                        {
                            utilité = "restore 5 points de mana";
                            usable = true;
                        }
                        else if (positin_tile == new Vector2(1, 3))
                        {
                            utilité = "restore 10 points de mana";
                            usable = true;
                        }
                        else if (positin_tile == new Vector2(2, 3))
                        {
                            utilité = "restore 60 pv au joueur";
                            usable = true;
                        }

                        else
                            if (positin_tile == new Vector2(0, 4))
                            {
                                utilité = "restore 20 points de mana";
                                usable = true;
                            }
                            else if (positin_tile == new Vector2(1, 4))
                            {
                                utilité = "restore 40 points de mana";
                                usable = true;
                            }
                            else if (positin_tile == new Vector2(2, 4))
                            {
                                utilité = "restore 100 pv au joueur";
                                usable = true;
                            }
                            else
                                if (positin_tile == new Vector2(0, 5))
                                {
                                    utilité = "restore 80 points de mana";
                                    usable = true;
                                }
                                else if (positin_tile == new Vector2(1, 5))
                                {
                                    utilité = "restore 160 points de mana";
                                    usable = true;
                                }
                                else if (positin_tile == new Vector2(2, 5))
                                {
                                    utilité = "restore 150 pv au joueur";
                                    usable = true;
                                }
                                else
                                    if (positin_tile == new Vector2(0, 6))
                                    {
                                        utilité = "titre de propriété du donjon";
                                        usable = true;
                                    }
                                    else if (positin_tile == new Vector2(1, 6))
                                    {
                                        utilité = "un rouleau de PQ restore toute la vie du personnage";
                                        usable = true;
                                    }
                                    else if (positin_tile == new Vector2(2, 6))
                                    {
                                        utilité = "restore 200 pv au joueur";
                                        usable = true;
                                    }

            base.action(main);
        }
        public override void draw(SpriteBatch spritebatch, int x, int y, int z, int w)
        {
            spritebatch.Draw(ressource.item, new Rectangle(x, y, z, w), new Rectangle((int)positin_tile.X * 32, (int)positin_tile.Y * 32, 32, 32), Color.White);
            base.draw(spritebatch, x, y, z, w);
        }
    }
}
