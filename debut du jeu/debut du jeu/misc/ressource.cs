using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Templar
{
    class ressource
    {
        //static field
        public static Texture2D sprite_player, zombie, sprite_cochon, //sprite personnage
            particule, pixel, // autre
            map_0, map_1, map_2, // map
            th, templar, option, gameover, //ecran de jeu 
            barre, selection_sort, barre_xp,// HUD
            glace, boule_de_feu, // sort 
            ARBRE, MUR, STATUT, cursor, SOL, // EDM
            potion_vie, potion_mana, map, tile, plus, moin ; //POTION

        public static SoundEffect selection, lowHP, feu; //ressource des bruitage

        public static Song menu,main_theme;

        public static SpriteFont ecriture;


        public static void loadcontent(ContentManager Content) //installe les ressource du jeu 
        {


            //songe
            selection = Content.Load<SoundEffect>("selection");
            lowHP = Content.Load<SoundEffect>("lowHP");
            feu = Content.Load<SoundEffect>("Mémo");


            //sprite character
            zombie = Content.Load<Texture2D>("Zomtemplate");
            sprite_cochon = Content.Load<Texture2D>("sprite_cochon");
            sprite_player = Content.Load<Texture2D>("spritefinale1habit");

            //fond d'ecran menu
            templar = Content.Load<Texture2D>("templar-style-cross-logo");
            th = Content.Load<Texture2D>("th");
            option = Content.Load<Texture2D>("option");
            gameover = Content.Load<Texture2D>("game_o10");

            //song
            menu = Content.Load<Song>("01 - niNzo` - Epic feel");
            main_theme = Content.Load<Song>("PSICODREAMICS_-_Into_the_Darkness");

            //map
            map_0 = Content.Load<Texture2D>("map_test");
            map_1 = Content.Load<Texture2D>("map_1");
            map_2 = Content.Load<Texture2D>("game_o10");
            map = Content.Load<Texture2D>("tile_map");
            tile = Content.Load<Texture2D>("tileset");

            //autre
            pixel = Content.Load<Texture2D>("pixel");
            boule_de_feu = Content.Load<Texture2D>("Boule_de_feu");
            glace = Content.Load<Texture2D>("glaces");
            selection_sort = Content.Load<Texture2D>("boite_selection");
            particule = Content.Load<Texture2D>("particule");
            barre = Content.Load<Texture2D>("barre");
            potion_vie = Content.Load<Texture2D>("Potion_de_Vie");
            potion_mana = Content.Load<Texture2D>("Potion_de_Mana");
            barre_xp = Content.Load<Texture2D>("barre_xp");
            moin = Content.Load<Texture2D>("moin");
            plus = Content.Load<Texture2D>("plus");

            //spriteFont
            ecriture = Content.Load<SpriteFont>("SpriteFont");

            //EDM
            ARBRE = Content.Load<Texture2D>("ARBRE");
            MUR = Content.Load<Texture2D>("ARBRE");//AMODIFIE
            STATUT = Content.Load<Texture2D>("STATUT");
            cursor = Content.Load<Texture2D>("glaces");//AMODIFIE
            SOL = Content.Load<Texture2D>("SOL");
        }
    }
}
