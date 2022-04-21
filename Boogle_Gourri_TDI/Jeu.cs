using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Timers;

namespace Boogle_Gourri_TDI
{
    public class Jeu
    {
        public static Plateau CreationDuPlateau() //Créer et affiche un plateau.
        {
            StreamReader lireFichier = new StreamReader("Des.txt");
            Plateau NouvPlateau = new Plateau();
            string ligne;
            string[,] terrain = new string[4, 4];
            int i = 0;
            int j = 0;
            int k = -1;
            int l = -1;

            while ((ligne = lireFichier.ReadLine()) != null) //Lecture du fichier dé (non vide) et ajout de chaque ligne dans un tableau.
            {
                string[] lignes = ligne.Split(';');
                Random r = new Random();
                k++; //On incrémente pour parcourir le plateau
                
                if (k == terrain.GetLength(0)) 
                {
                    i = 0;
                    k = 0;
                    l++; //On incrémente pour parcourir le fichier.
                    for (i = 0; i < terrain.GetLength(1); i++)
                    {
                        for (j = l; j < terrain.GetLength(0); j++)
                        {
                            De leDe = new De(lignes); //On tire aléatoirement une lettre parmis les différents dé et on remplit notre matrice avec la lettre tirée.
                            terrain[i, j] = leDe.Lance(r);
                        }
                    }
                }
                else
                {
                    l++; //On incrémente pour parcourir le fichier.
                    for (i = k; i < terrain.GetLength(1); i++)
                    {
                        for (j = 0; j < terrain.GetLength(0); j++)
                        {
                            De unDe = new De(lignes);
                            terrain[i, j] = unDe.Lance(r);
                        }
                    }
                }
            }
            NouvPlateau = new Plateau(terrain); //Création du plateau de jeu grâce à la matrice.
            Console.WriteLine(NouvPlateau.toString()); //Affichage du plateau de jeu.
            lireFichier.Close(); //Arretez la lecture du fichier.
            return NouvPlateau;
        }
        public static SortedList<int, string[]> CreationDuDico() //Permet de créer le dictionnaire en fonction de la taille d'un mot.
        {
            StreamReader lectureFichier = new StreamReader("MotsPossibles.txt");
            string line;
            int taille = 0;
            SortedList<int, string[]> nouvDico = new SortedList<int, string[]>();

            while ((line = lectureFichier.ReadLine()) != null)
            {
                try
                {
                    taille = Convert.ToInt32(line); //Lecture des lignes du fichier qui indique la longueur des mots.
                }
                catch (FormatException) //Lecture des lignes du fichier qui indique les mots.
                {
                    string[] lesMots = line.Split(' '); 
                    nouvDico.Add(taille, lesMots); 
                }
            }
            return nouvDico;
        }

        public static void Main(string[] args) //Création final du jeu.
        {
            Console.WriteLine("----------   PROJET BOOGLE - Ilies GOURRI TDI   ----------\n\nUne partie dure 6 minutes, vous avez 1 minute chacun pour jouer tour à tour.\n");

            Console.WriteLine("Veuillez saisir le pseudo du premier joueur");
            string nomJ1 = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Veuillez saisir le pseudo du deuxième joueur");
            string nomJ2 = Convert.ToString(Console.ReadLine());

            List<string> listMotJ1 = new List<string>();
            List<string> listMotJ2 = new List<string>();
            Joueur Joueur1 = new Joueur(nomJ1, listMotJ1);
            Joueur Joueur2 = new Joueur(nomJ2, listMotJ2);

            SortedList<int, string[]> leDictionnaire = CreationDuDico();
            Dictionnaire NouveauDictionnaire = new Dictionnaire(leDictionnaire, "français");

            DateTime limiteDeTemps = DateTime.Now.AddMinutes(6); //On initialise une limite de temps.

            while (DateTime.Now < limiteDeTemps)
            {
                Console.WriteLine("C'est à " + Joueur1.Nom + " de jouer.\n");
                // Générer nouveau plateau
                Plateau monNouveauPlateau = CreationDuPlateau();

                List<string> listeDuTour = new List<string>();

                DateTime finDuRound = DateTime.Now.AddMinutes(1); //On initialise une limite de temps.

                while (DateTime.Now < finDuRound)
                {
                    string mot = Convert.ToString(Console.ReadLine()) ;
                    mot = mot.ToUpper();

                    if (!Joueur1.Contain(mot) && NouveauDictionnaire.ContainDico(mot) && mot.Length >= 3)
                    {
                        
                        if ((monNouveauPlateau.Test_Plateau(mot) == true))
                        {
                            
                            Joueur1.Add_Mot(mot);
                            listeDuTour.Add(mot);
                            switch (mot.Length)
                            {
                                case 0:
                                    Console.WriteLine("Aucun mot n'a été saisi.Veuillez recommencer.");
                                    break;
                                case 1:
                                    Console.WriteLine("La condition de longueur n'est pas respectée. Veuillez recommencer. ");
                                    break;
                                case 2:
                                    Console.WriteLine("La condition de longueur n'est pas respectée. Veuillez recommencer.");
                                    break;
                                case 3:
                                    Joueur1.Score += 2;
                                    Console.WriteLine("\nBravo ! Vous avez trouvé : " + mot + ". Vous gagnez : 2 points");

                                    break;
                                case 4:
                                    Joueur1.Score += 3;
                                    Console.WriteLine("\nBravo ! Vous avez trouvé : " + mot + ". Vous gagnez : 3 points");
                                    break;
                                case 5:
                                    Joueur1.Score += 4;
                                    Console.WriteLine("\nBravo ! Vous avez trouvé : " + mot + ". Vous gagnez : 4 points");
                                    break;
                                case 6:
                                    Joueur1.Score += 5;
                                    Console.WriteLine("\nBravo ! Vous avez trouvé : " + mot + ". Vous gagnez : 5 points");
                                    break;
                                default:
                                    Joueur1.Score += 11;
                                    Console.WriteLine("\nBravo ! Vous avez trouvé : " + mot + ". Vous gagnez : 11 points");
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Veuillez saisir un mot qui se situe dans le plateau.");
                        }

                    }
                    else
                    {
                        Console.WriteLine("Veuillez saisir un NOUVEAU mot VALIDE, qui respecte la condition de longueur.");
                    }

                    Console.WriteLine(Joueur1.toString());

                }

                listeDuTour = null;


                Console.WriteLine("C'est au tour de " + Joueur2.Nom + " de jouer.\n");


                //Creation d'un nouveau plateau
                Plateau monNouveauPlateau2 = CreationDuPlateau();

                List<string> listeDuTour2 = new List<string>();
                DateTime finDuRound2 = DateTime.Now.AddMinutes(1); //On initialise une limite de temps.

                while (DateTime.Now < finDuRound2)
                {
                    string mot = Console.ReadLine();
                    mot = mot.ToUpper();

                    if (!Joueur2.Contain(mot) && NouveauDictionnaire.ContainDico(mot) && mot.Length >= 3)
                    {
                        if ((monNouveauPlateau2.Test_Plateau(mot) == true))
                        {
                            Joueur2.Add_Mot(mot);
                            listeDuTour2.Add(mot);

                            switch (mot.Length)
                            {
                                case 0:
                                    Console.WriteLine("Aucun mot n'a été saisi.Veuillez recommencer.");
                                    break;
                                case 1:
                                    Console.WriteLine("La condition de longueur n'est pas respectée. veuillez recommencer. ");
                                    break;
                                case 2:
                                    Console.WriteLine("La condition de longueur n'est pas respectée. Veuillez recommencer.");
                                    break;
                                case 3:
                                    Joueur2.Score += 2;
                                    Console.WriteLine("\nBravo ! Vous avez trouvé : " + mot + ". Vous gagnez : 2 points");
                                    break;
                                case 4:
                                    Joueur2.Score += 3;
                                    Console.WriteLine("\nBravo ! Vous avez trouvé : " + mot + ". Vous gagnez : 3 points");
                                    break;
                                case 5:
                                    Joueur2.Score += 4;
                                    Console.WriteLine("\nBravo ! Vous avez trouvé : " + mot + ". Vous gagnez : 4 points");
                                    break;
                                case 6:
                                    Joueur2.Score += 5;
                                    Console.WriteLine("\nBravo ! Vous avez trouvé : " + mot + ". Vous gagnez : 5 points");
                                    break;
                                default:
                                    Joueur2.Score += 11;
                                    Console.WriteLine("\nBravo ! Vous avez trouvé : " + mot + ". Vous gagnez : 11 points");
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Veuillez saisir un mot qui se situe dans le plateau.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Veuillez saisir un NOUVEAU mot VALIDE, qui respecte la condition de longueur.");
                    }

                    Console.WriteLine(Joueur2.toString());
                }
                listeDuTour2 = null;

            }

            Console.WriteLine("\n\n----------------------------\n\n");
            Console.WriteLine("Le score final de " + Joueur1.Nom + " est de : " + Joueur1.Score);
            Console.WriteLine("Le score final de " + Joueur2.Nom + " est de : " + Joueur2.Score);

            if (Joueur1.Score > Joueur2.Score)
            {
                Console.WriteLine("\n" + "Bravo " + Joueur1.Nom + ", tu as gagné la partie !");
                Console.WriteLine("\n\n----------------------------");

            }
            else if (Joueur2.Score > Joueur1.Score)
            {
                Console.WriteLine("\n" + "Bravo " + Joueur2.Nom + ", tu as gagné la partie !");
                Console.WriteLine("\n\n----------------------------");
            }
            else
            {
                Console.WriteLine("\n" + "Il n'y a pas de vainqueur. Vous êtes à égalité...");
                Console.WriteLine("\n\n----------------------------");
            }

            Console.ReadKey();
        }
    }
}