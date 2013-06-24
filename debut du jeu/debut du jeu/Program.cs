using System;
using System.Xml;

namespace Templar
{
#if WINDOWS || XBOX


    static class Program
    {
        static void Main(string[] args)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            XmlWriter writer = XmlWriter.Create("Francais.xml", settings); // FICHIER XML TRAD FR
            writer.WriteStartDocument();
            writer.WriteComment("This file is generated by the program.");
            writer.WriteComment("Traduction Fran�aise de Templar.");
            writer.WriteStartElement("FR");
            //Menu Principal
            writer.WriteElementString("unj", "1 Joueur");
            writer.WriteElementString("deuxj", "2 Joueurs");
            writer.WriteElementString("edm", "Editeur de Carte");
            writer.WriteElementString("options", "Options");
            writer.WriteElementString("fin", "Quitter");
            //Menu options
            writer.WriteElementString("pleinecran", "Plein Ecran");
            writer.WriteElementString("fenetre", "Fenetre");
            writer.WriteElementString("activer", "Activer le son");
            writer.WriteElementString("desactiver", "Desactiver le son");
            writer.WriteElementString("langue", "Langue : Francais");
            writer.WriteElementString("retour", "Retour au menu principal");
            //EDM
            writer.WriteElementString("debut", "Entrez le nom de votre donjon, puis appuyez sur F1 pour commencer !");
            writer.WriteElementString("pos", "Position joueur");
            writer.WriteElementString("err", "nom incorrect");
            writer.WriteElementString("tuto", "Tutoriel");
            writer.WriteElementString("tuile", "clic gauche ici\n pour selectionner\n une tuile");
            writer.WriteElementString("map", "clic gauche ici\n pour ajouter\n une salle");
            writer.WriteElementString("mob", "clic gauche ici pour selectionn un monstre");
            writer.WriteElementString("messa", "clic guche ici pour activer la saisie du message du donjon");
            // retour d�j� fait : "retour"
            //1 joueur
            writer.WriteElementString("nouv", "Nouvelle partie");
            writer.WriteElementString("continuer", "Continuer");
            // retour d�j� fait : "retour"
            //choix du donjon
            writer.WriteElementString("suivant", "Suivant");
            writer.WriteElementString("liste", "Liste des donjons disponibles");
            //en jeu
            writer.WriteElementString("tonneaux", "Hummm... Des tonneaux, plein de tonneaux !!");
            writer.WriteElementString("bouquins", "Quelques bouquins relatant de la Vie, de l'Univers et du Reste");
            // menu inventaire
            writer.WriteElementString("attaque", "Augmenter Attaque de 1");
            writer.WriteElementString("defense", "Augmenter Defense de 1");
            writer.WriteElementString("magie", "Augmenter Magie de 1");
            writer.WriteElementString("endurance", "Augmenter Endurance de 1");
            writer.WriteElementString("pdv", "Augmenter Points de vie de 1");
            writer.WriteElementString("pdm", "Augmenter Points de mana de 1");
            // items
            string[] listeuh = new string[] { "revele la position de la princesse au joueur",
                "revele la position de la princesse au joueur",
                "restaure 10 pv au joueur",
                "augmente la magie du joueur de 5",
                "augmente la magie du joueur de 10",
            "augmente la magie du joueur de 2",
            "augmente la magie du joueur de 7",
            "detruit tous les montres de la carte",
            "detruit un monstre de la carte",
            "restaure 20 pv au joueur",
            "augmente l'attaque du joueur de 5",
            "augmente l'attaque du joueur de 10",
            "augmente l'attaque du joueur de 2",
            "augmente l'attaque du joueur de 7",
            "ramene a la map d'origine",
            "rend le personnage invulnerable pendant 10 secondes",
            "restaure 40 pv au joueur",
            "augmente l'endurance du joueur de 5",
            "augmente l'endurance du joueur de 10",
            "augmente l'endurance du joueur de 2",
            "augmente l'endurance du joueur de 7",
            "restaure 5 points de mana",
            "restaure 10 points de mana",
            "restaure 60 pv au joueur",
            "augmente la vitesse du joueur de 1",
            "augmente la vitesse du joueur de 2",
            "augmente la vitesse du joueur de 3",
            "augmente la vitesse du joueur de 4",
            "restaure 20 points de mana au joueur",
            "restaure 40 points de mana au joueur",
            "restaure 100 pv au joueur",
            "augmente les points de vie max du joueur de 50",
            "augmente la points de vie max du joueur de 100",
            "augmente les points de vie max du joueur de 25",
            "augmente les points de vie max du joueur de 75",
            "restaure 80 points de mana au joueur",
            "restaure 160 points de mana au joueur",
            "restaure 150 pv au joueur",
            "augmente les points de mana max du joueur de 50",
            "augmente les points de mana max du joueur de 100",
            "augmente les points de mana max du joueur de 25",
            "augmente les points de mana max du joueur de 75",
            "titre de propriete du donjon",
            "un rouleau de PQ restaure toute la vie du personnage",
            "restaure 200 pv au joueur",
            "augmente la defense du joueur de 5",
            "augmente la defense du joueur de 10",
            "augmente la defense du joueur de 2",
            "augmente la defense du joueur de 7"};
            for (int i = 0; i < listeuh.Length; i++)
            {
                writer.WriteElementString("i" + i.ToString(), listeuh[i]);
            }
            //menu pause
            writer.WriteElementString("inventaire", "Inventaire");
            writer.WriteElementString("caract", "Caracteristiques");
            writer.WriteElementString("sauv", "Sauvegarder");
            writer.WriteElementString("charger", "Charger");
            // retour d�j� fait : "retour"
            //menu game over
            writer.WriteElementString("recommencer", "Recommencer");
            // retour d�j� fait : "retour"
            // quitter d�j� fait : "fin"
            //2 joueurs
            /*
             * QUAND CE SERA FINI 
             * 
             */
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();
            writer.Close(); // FIN FR

            writer = XmlWriter.Create("English.xml", settings); // FICHIER XML TRAD EN
            writer.WriteStartDocument();
            writer.WriteComment("This file is generated by the program.");
            writer.WriteComment("English translation of Templar.");
            writer.WriteStartElement("EN");
            //Menu Principal
            writer.WriteElementString("unj", "1 Player");
            writer.WriteElementString("deuxj", "2 Players");
            writer.WriteElementString("edm", "Map Editor");
            writer.WriteElementString("options", "Options");
            writer.WriteElementString("fin", "Exit");
            //Menu options
            writer.WriteElementString("pleinecran", "Full screen");
            writer.WriteElementString("fenetre", "Window");
            writer.WriteElementString("activer", "Activate sound");
            writer.WriteElementString("desactiver", "Desactivate sound");
            writer.WriteElementString("langue", "Language : English");
            writer.WriteElementString("retour", "Back to main menu");
            //EDM
            writer.WriteElementString("debut", "Input the name of your donjon, then press F1 to start !");
            writer.WriteElementString("pos", "Player position");
            writer.WriteElementString("err", "name incorrect");
            writer.WriteElementString("tuto", "Tutorial");
            writer.WriteElementString("tuile", "left clic here\n to select\n a tile");
            writer.WriteElementString("map", "left clic here\n to add\n a map");
            writer.WriteElementString("mob", "left clic here to select a monster");
            writer.WriteElementString("messa", "left clic here to activate the seizure of a message for the map");
            //1 joueur
            writer.WriteElementString("nouv", "New game");
            writer.WriteElementString("continuer", "Continue");
            // retour d�j� fait : "retour"
            //choix du donjon
            writer.WriteElementString("suivant", "Next");
            writer.WriteElementString("liste", "List of donjons available");
            //en jeu
            writer.WriteElementString("tonneaux", "Hummm... Barrels, barrels everywhere !!");
            writer.WriteElementString("bouquins", "Some books talking about Life, the Universe, and Everything ");
            // menu inventaire
            writer.WriteElementString("attaque", "Increase Attack by 1");
            writer.WriteElementString("defense", "Increase Defense by 1");
            writer.WriteElementString("magie", "Increase Magic by 1");
            writer.WriteElementString("endurance", "Increase Stamina by 1");
            writer.WriteElementString("pdv", "Increase Health by 1");
            writer.WriteElementString("pdm", "Increase Mana by 1");
            //menu pause
            writer.WriteElementString("inventaire", "Inventory");
            writer.WriteElementString("caract", "Characteristics");
            writer.WriteElementString("sauv", "Save");
            writer.WriteElementString("charger", "Load");
            // retour d�j� fait : "retour"
            // items
            string[] listeuuh = new string[] { "show the position of the princess to the player",
                "show the position of the princess to the player",
                "restore 10 pv to the player",
                "increase magic of the player by 5",
                "increase magic of the player by 10",
            "increase magic of the player by 2",
            "increase magic of the player by 7",
            "kill every monster on the map",
            "kill one monster on the map",
            "restore 20 hp to the player",
            "increase attack of the player by 5",
            "increase attack of the player by 10",
            "increase attack of the player by 2",
            "increase attack of the player by 7",
            "get back to the first map",
            "the player become invulnerable for 10 secondes",
            "restore 40 hp to the player",
            "increase stamina of the player by 5",
            "increase stamina of the player by 10",
            "increase stamina of the player by 2",
            "increase stamina of the player by 7",
            "restore 5 mana",
            "restore 10 mana",
            "restore 60 hp",
            "increase speed of the player by 1",
            "increase speed of the player by 2",
            "increase speed of the player by 3",
            "increase speed of the player by 4",
            "restore 20 mana",
            "restore 40  mana",
            "restore 100 hp",
            "increase hp max of the player by 50",
            "increase hp max of the player by 100",
            "increase hp max of the player by 25",
            "increase hp max of the player by 75",
            "restore 80 mana",
            "restore 160 mana",
            "restore 150 hp",
            "increase mana max by 50",
            "increase mana max by 100",
            "increase mana max by 25",
            "increase mana max by 75",
            "deed of property of the donjon",
            "a roll of toilet paper restore all hp",
            "restore 200 hp",
            "increase defense of the player by 5",
            "increase defense of the player by 10",
            "increase defense of the player by 2",
            "increase defense of the player by 7"};
            for (int i = 0; i < listeuuh.Length; i++)
            {
                writer.WriteElementString("i" + i.ToString(), listeuuh[i]);
            }
            //menu game over
            writer.WriteElementString("recommencer", "Try again");
            // retour d�j� fait : "retour"
            // quitter d�j� fait : "fin"
            //2 joueurs
            /*
             * QUAND CE SERA FINI 
             * 
             */

            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();
            writer.Close(); // FIN EN

            using (Game1 game = new Game1())
            {
                game.Run();
            }
        }
    }
#endif
}

