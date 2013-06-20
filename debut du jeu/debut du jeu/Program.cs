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
            //1 joueur
            writer.WriteElementString("nouv", "Nouvelle partie");
            writer.WriteElementString("continuer", "Continuer");
            // retour d�j� fait : "retour"
            //choix du donjon
            writer.WriteElementString("suivant", "Suivant");
            //en jeu
            /*
             * RAJOUTER BARILLES 
             * ET BIBLIO
             *
             */
            //menu pause
            writer.WriteElementString("inventaire", "Inventaire");
            writer.WriteElementString("caract", "Caracteristiques");
            writer.WriteElementString("sauv", "Sauvegarder");
            writer.WriteElementString("charger", "Charger");
            // retour d�j� fait : "retour"
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

