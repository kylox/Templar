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
        public static Texture2D 
            sprite_player, zombie, sprite_cochon,tete_player, //sprite personnage
            particule, pixel, // autre
            map_0, map_1, map_2, // map
            th, templar, option, gameover, //ecran de jeu 
            barre, selection_sort, barre_xp,// HUD
            glace, boule_de_feu, // sort 
            ARBRE, MUR, STATUT, SOL, // EDM
            potion_vie, potion_mana,//POTION
            tile, plus, moin,objet_map,mob; 

        public static SoundEffect selection, lowHP, feu; //ressource des bruitage

        public static Song menu,main_theme;

        public static SpriteFont ecriture;


        public static void loadcontent(ContentManager Content) //installe les ressource du jeu 
        {
            //effect
            selection = Content.Load<SoundEffect>(@"Music\effet\selection");
            lowHP = Content.Load<SoundEffect>(@"Music\effet\lowHP");
            feu = Content.Load<SoundEffect>(@"Music\effet\Mémo");

            //sprite character
            zombie = Content.Load<Texture2D>(@"Sprite\Personnage\Zomtemplate");
            sprite_cochon = Content.Load<Texture2D>(@"Sprite\Personnage\sprite_cochon");
            sprite_player = Content.Load<Texture2D>( "perso"/*"swordsman_m_2"*/);
            tete_player = Content.Load<Texture2D>("M_Black");
            mob = Content.Load<Texture2D>("mobs");

            //fond d'ecran menu
            templar = Content.Load<Texture2D>(@"ecran\templar-style-cross-logo");
            th = Content.Load<Texture2D>(@"ecran\th");
            option = Content.Load<Texture2D>(@"ecran\option\option");
            gameover = Content.Load<Texture2D>(@"ecran\jeux\game_o10");

            //song
            menu = Content.Load<Song>(@"Music\musiques\01 - niNzo` - Epic feel");
            main_theme = Content.Load<Song>(@"Music\musiques\PSICODREAMICS_-_Into_the_Darkness");

            //map
            map_0 = Content.Load<Texture2D>(@"ecran\jeux\map_test");
            map_1 = Content.Load<Texture2D>(@"ecran\jeux\map_1");
            map_2 = Content.Load<Texture2D>(@"ecran\jeux\game_o10");
            tile = Content.Load<Texture2D>(@"maintenantoui"/*"piece"*/);
            objet_map = Content.Load<Texture2D>(@"maintenantoui"/*"piece_objet_mod"*/);

            //autre
            pixel = Content.Load<Texture2D>(@"Misc\pixel");
            boule_de_feu = Content.Load<Texture2D>(@"Sprite\attaque\Boule_de_feu");
            glace = Content.Load<Texture2D>(@"Sprite\attaque\glaces");
            selection_sort = Content.Load<Texture2D>(@"HUD\boite_selection");
            particule = Content.Load<Texture2D>(@"Misc\particule");
            barre = Content.Load<Texture2D>(@"HUD\barre");
            potion_vie = Content.Load<Texture2D>(@"Sprite\item\Potion_de_Vie");
            potion_mana = Content.Load<Texture2D>(@"Sprite\item\Potion_de_Mana");
            barre_xp = Content.Load<Texture2D>(@"HUD\barre_xp");
            moin = Content.Load<Texture2D>(@"ecran\option\moin");
            plus = Content.Load<Texture2D>(@"ecran\option\plus");

            //spriteFont
            ecriture = Content.Load<SpriteFont>("SpriteFont");

            //EDM
            ARBRE = Content.Load<Texture2D>(@"Sprite\Tile\ARBRE");
            MUR = Content.Load<Texture2D>(@"Sprite\Tile\ARBRE");//AMODIFIE
            STATUT = Content.Load<Texture2D>(@"Sprite\Tile\STATUT");
            SOL = Content.Load<Texture2D>(@"Sprite\Tile\SOL");
        }
    }
}
