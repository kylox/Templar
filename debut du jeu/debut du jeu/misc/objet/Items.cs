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
    class Items:item
    {
        public string utilité;
        public int[] Bonus;
        public bool is_equipable;
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
                        return "revele la position de la princesse au joueur";
                    else if (position_tileset == new Vector2(1, 2))
                        return "revele la position de la princesse au joueur";
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
                            return "ramène a la map d'origine";
                        else if (position_tileset == new Vector2(1, 3))
                            return "rend le personnage invulnerable pendant 10 secondes";
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
                                return "revele la position de la princesse au joueur";
                            else if (position_tileset == new Vector2(1, 4))
                                return "revele la position de la princesse au joueur";
                            else if (position_tileset == new Vector2(2, 4))
                                return "restore 100 pv au joueur";
                            else if (position_tileset == new Vector2(3, 4))
                                return "augmente les points de vie du joueur de 25";
                            else if (position_tileset == new Vector2(4, 4))
                                return "augmente la points de vie du joueur de 50";
                            else if (position_tileset == new Vector2(5, 4))
                                return "augmente les points de vie du joueur de 5";
                            else if (position_tileset == new Vector2(6, 4))
                                return "augmente les points de vie du joueur de 100";
                            else
                                if (position_tileset == new Vector2(0, 5))
                                    return "detruit tout les mobs de la carte";
                                else if (position_tileset == new Vector2(1, 5))
                                    return "detruit un mob de la carte";
                                else if (position_tileset == new Vector2(2, 5))
                                    return "restore 150 pv au joueur";
                                else if (position_tileset == new Vector2(3, 5))
                                    return "augmente l'attaque du joueur de 5";
                                else if (position_tileset == new Vector2(4, 5))
                                    return "augmente l'attaque du joueur de 5";
                                else if (position_tileset == new Vector2(5, 5))
                                    return "augmente l'attaque du joueur de 10";
                                else if (position_tileset == new Vector2(6, 5))
                                    return "augmente l'attaque du joueur de 2";
                                else
                                    if (position_tileset == new Vector2(0, 6))
                                        return "titre de propriété du donjon";
                                    else if (position_tileset == new Vector2(1, 6))
                                        return "un rouleau de PQ restore toute la vie du personnage";
                                    else if (position_tileset == new Vector2(2, 6))
                                        return "restore 200 pv au joueur";
                                    else if (position_tileset == new Vector2(3, 6))
                                        return "augmente la magie du joueur de 5";
                                    else if (position_tileset == new Vector2(4, 6))
                                        return "augmente la magie du joueur de 10";
                                    else if (position_tileset == new Vector2(5, 6))
                                        return "augmente la magie du joueur de 2";
                                    else if (position_tileset == new Vector2(6, 6))
                                        return "augmente la magie du joueur de 7";
            return "";
        }
        public Items(Vector2 position_tileset):base(ressource.item,position_tileset)
        {
            is_equipable = false;
            if (position_tileset == new Vector2(0, 0))
                utilité = "revele la position de la princesse au joueur";
            else if (position_tileset == new Vector2(1, 0))
                utilité = "revele la position de la princesse au joueur";
            else if (position_tileset == new Vector2(2, 0))
                utilité = "restore 10 pv au joueur";
            else if (position_tileset == new Vector2(3, 0))
            {
                utilité = "augmente la magie du joueur de 5";
                Bonus = new int[] { 0, 5, 0, 0, 0 };
                is_equipable = true;
            }
            else if (position_tileset == new Vector2(4, 0))
            {
                utilité = "augmente la magie du joueur de 10";
                Bonus = new int[] { 0, 10, 0, 0, 0 };
                is_equipable = true;
            }
            else if (position_tileset == new Vector2(5, 0))
            {
                utilité = "augmente la magie du joueur de 2";
                Bonus = new int[] { 0, 2, 0, 0, 0 };
                is_equipable = true;
            }
            else if (position_tileset == new Vector2(6, 0))
            {
                utilité = "augmente la magie du joueur de 7";
                Bonus = new int[] { 0, 7, 0, 0, 0 };
                is_equipable = true;
            }
            else if (position_tileset == new Vector2(7, 0))
                utilité = "revele la position de la princesse au joueur";
            else
                if (position_tileset == new Vector2(0, 1))
                    utilité = "detruit tout les mobs de la carte";
                else if (position_tileset == new Vector2(1, 1))
                    utilité = "detruit un mob de la carte";
                else if (position_tileset == new Vector2(2, 1))
                    utilité = "restore 20 pv au joueur";
                else if (position_tileset == new Vector2(3, 1))
                {
                    utilité = "augmente l'attaque du joueur de 5";
                    Bonus = new int[] { 5, 0, 0, 0, 0 };
                    is_equipable = true;
                }
                else if (position_tileset == new Vector2(4, 1))
                {
                    utilité = "augmente l'attaque du joueur de 10";
                    Bonus = new int[] { 10, 0, 0, 0, 0 };
                    is_equipable = true;
                }
                else if (position_tileset == new Vector2(5, 1))
                {
                    utilité = "augmente l'attaque du joueur de 2";
                    Bonus = new int[] { 2, 0, 0, 0, 0 };
                    is_equipable = true;
                }
                else if (position_tileset == new Vector2(6, 1))
                {
                    utilité = "augmente l'attaque du joueur de 7";
                    Bonus = new int[] { 7, 0, 0, 0, 0 };
                    is_equipable = true;
                }
                else if (position_tileset == new Vector2(7, 1))
                    utilité = "augmente l'attaque du joueur de 7";
                else
                    if (position_tileset == new Vector2(0, 2))
                        utilité = "revele la position de la princesse au joueur";
                    else if (position_tileset == new Vector2(1, 2))
                        utilité = "revele la position de la princesse au joueur";
                    else if (position_tileset == new Vector2(2, 2))
                        utilité = "restore 10 pv au joueur";
                    else if (position_tileset == new Vector2(3, 2))
                    {
                        utilité = "augmente l'endurance du joueur de 5";
                        Bonus = new int[] { 0, 0, 5, 0, 0 };
                        is_equipable = true;
                    }
                    else if (position_tileset == new Vector2(4, 2))
                    {
                        utilité = "augmente l'endurance du joueur de 10";
                        Bonus = new int[] { 0, 0, 10, 0, 0 };
                        is_equipable = true;
                    }
                    else if (position_tileset == new Vector2(5, 2))
                    {
                        utilité = "augmente l'endurance du joueur de 2";
                        Bonus = new int[] { 0, 0, 2, 0, 0 };
                        is_equipable = true;
                    }
                    else if (position_tileset == new Vector2(6, 2))
                    {
                        utilité = "augmente l'endurance du joueur de 7";
                        Bonus = new int[] { 0, 0, 7, 0, 0 };
                        is_equipable = true;
                    }
                    else if (position_tileset == new Vector2(7, 2))
                        utilité = "revele l'enduran  de la princesse au joueur";
                    else
                        if (position_tileset == new Vector2(0, 3))
                            utilité = "detruit tout les mobs de la carte";
                        else if (position_tileset == new Vector2(1, 3))
                            utilité = "detruit un mob de la carte";
                        else if (position_tileset == new Vector2(2, 3))
                            utilité = "restore 20 pv au joueur";
                        else if (position_tileset == new Vector2(3, 3))
                        {
                            utilité = "augmente la vitesse du joueur de 1";
                            Bonus = new int[] { 0, 0, 0, 1, 0 };
                            is_equipable = true;
                        }
                        else if (position_tileset == new Vector2(4, 3))
                        {
                            utilité = "augmente la vitesse du joueur de 2";
                            Bonus = new int[] { 0, 0, 0, 2, 0 };
                            is_equipable = true;
                        }
                        else if (position_tileset == new Vector2(5, 3))
                        {
                            utilité = "augmente la vitesse du joueur de 3";
                            Bonus = new int[] { 0, 0, 0, 3, 0 };
                            is_equipable = true;
                        }
                        else if (position_tileset == new Vector2(6, 3))
                        {
                            utilité = "augmente la vitesse du joueur de 4";
                            Bonus = new int[] { 0, 0, 0, 4, 0 };
                            is_equipable = true;
                        }
                        else if (position_tileset == new Vector2(7, 3))
                        {
                            utilité = "augmente la vitesse du joueur de 5";
                            Bonus = new int[] { 0, 0, 0, 5, 0 };
                            is_equipable = true;
                        }
                        else
                            if (position_tileset == new Vector2(0, 4))
                                utilité = "revele la position de la princesse au joueur";
                            else if (position_tileset == new Vector2(1, 4))
                                utilité = "revele la position de la princesse au joueur";
                            else if (position_tileset == new Vector2(2, 4))
                                utilité = "restore 10 pv au joueur";
                            else if (position_tileset == new Vector2(3, 4))
                            {
                                utilité = "augmente les points de vie du joueur de 50";
                                Bonus = new int[] { 0, 0, 0, 0, 50 };
                                is_equipable = true;
                            }
                            else if (position_tileset == new Vector2(4, 4))
                            {
                                utilité = "augmente les points de vie du joueur de 100";
                                Bonus = new int[] { 0, 0, 0, 0, 50 };
                                is_equipable = true;
                            }
                            else if (position_tileset == new Vector2(5, 4))
                            {
                                utilité = "augmente les points de vie du joueur de 25";
                                Bonus = new int[] { 0, 0, 0, 0, 25 };
                                is_equipable = true;
                            }
                            else if (position_tileset == new Vector2(6, 4))
                            {
                                utilité = "augmente les points de vie du joueur de 75";
                                Bonus = new int[] { 0, 0, 0, 0, 75 };
                                is_equipable = true;
                            }
                            else if (position_tileset == new Vector2(7, 4))
                                utilité = "revele la position de la princesse au joueur";
                            else
                                if (position_tileset == new Vector2(0, 5))
                                    utilité = "detruit tout les mobs de la carte";
                                else if (position_tileset == new Vector2(1, 5))
                                    utilité = "detruit un mob de la carte";
                                else if (position_tileset == new Vector2(2, 5))
                                    utilité = "restore 20 pv au joueur";
                                else if (position_tileset == new Vector2(3, 5))
                                    utilité = "augmente l'attaque du joueur de 5";
                                else if (position_tileset == new Vector2(4, 5))
                                    utilité = "augmente l'attaque du joueur de 5";
                                else if (position_tileset == new Vector2(5, 5))
                                    utilité = "augmente l'attaque du joueur de 10";
                                else if (position_tileset == new Vector2(6, 5))
                                    utilité = "augmente l'attaque du joueur de 2";
                                else if (position_tileset == new Vector2(7, 5))
                                    utilité = "augmente l'attaque du joueur de 7";
                                else
                                    if (position_tileset == new Vector2(0, 6))
                                        utilité = "titre de propriété du donjon";
                                    else if (position_tileset == new Vector2(1, 6))
                                        utilité = "un rouleau de PQ restore toute la vie du personnage";
                                    else if (position_tileset == new Vector2(2, 6))
                                        utilité = "restore 10 pv au joueur";
                                    else if (position_tileset == new Vector2(3, 6))
                                        utilité = "augmente la magie du joueur de 5";
                                    else if (position_tileset == new Vector2(4, 6))
                                        utilité = "augmente la magie du joueur de 10";
                                    else if (position_tileset == new Vector2(5, 6))
                                        utilité = "augmente la magie du joueur de 2";
                                    else if (position_tileset == new Vector2(6, 6))
                                        utilité = "augmente la magie du joueur de 7";
                                    else if (position_tileset == new Vector2(7, 6))
                                        utilité = "revele la position de la princesse au joueur";
        }
    }
}
