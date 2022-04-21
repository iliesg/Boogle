using System;
using System.Collections.Generic;
using System.Text;

namespace Boogle_Gourri_TDI

{
    public class Plateau
    {
        #region Attributs

        private string[,] tab = new string[4, 4];

        #endregion

        #region Propriétés
        public string[,] Tab
        {
            get { return this.tab; }
            set { this.tab = value; }
        }
        #endregion

        #region Constructeurs
        public Plateau () { }
        public Plateau(string[,] tab)
        {
            this.tab = tab;
        }
        #endregion 

        #region Méthodes
        public string toString() //Affiche le plateau de jeu constitué des 16 lettres
        {
            string index = "";
            for (int i = 0; i < tab.GetLength(0); i++)
            {
                for (int j = 0; j < tab.GetLength(1); j++)
                {
                    index += tab[i, j] + " ";
                }
                index += '\n';
            }
            return index;
        }
        public bool Test_Plateau(string mot) //Teste si le mot appartient au plateau.
        {
            bool result = false;

            List<string> listIndex = new List<string>();

            if (mot.Length == 0) //Cas où le mot ne respecte pas la condition de longueur.
            {
                return result;
            }
            else
            {
                char premiereLettre = mot[0];

                for (int i = 0; i < 4; i++) //On recherche ici la première lettre du mot en parcourant le plateau.
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (tab[i, j] == Convert.ToString(premiereLettre)) //Si la première lettre est présente on réalise un teste récursif.
                        {
                            if (Test_Recursif(i, j, mot, 0, listIndex)) //Avec cette fonction, on cherche les autres lettres du mot selon les règles.
                            {
                                result = true;
                            }
                        }

                    }
                }
            }

            return result;
        }
        public bool Test_Recursif(int i, int j, string mot, int motIndex, List<string> listIndex) //Teste si les autres lettres du mot sont à proximité.
        {
            motIndex = motIndex + 1;
            bool test = false;

            if (motIndex == mot.Length)
            {
                test = true;
            }

            else
            {
                try
                {
                    if (Convert.ToString(mot[motIndex]) == tab[i - 1, j]) //Vérifie en haut de la cellule i,j.
                    {
                        test = true;
                        if (Test_Recursif(i - 1, j, mot, motIndex, listIndex) == false)
                        {
                            test = false;
                        }
                    }
                }
                catch { };
                try
                {
                    if (Convert.ToString(mot[motIndex]) == tab[i - 1, j - 1]) //Vérifie en haut à gauche de la cellule i,j.
                    {
                        test = true;
                        if (Test_Recursif(i - 1, j - 1, mot, motIndex, listIndex) == false) //On vérifie plusieurs fois à l'aide de la récursivité.
                        {
                            test = false; //Retourne false si on ne trouve pas le mot.
                        }
                    }
                }
                catch { };
                try
                {
                    if (Convert.ToString(mot[motIndex]) == tab[i + 1, j + 1]) //Vérifie en bas à droite de la cellule i,j.
                    {
                        test = true;
                        if (Test_Recursif(i + 1, j + 1, mot, motIndex, listIndex) == false)
                        {
                            test = false;
                        }
                    }
                }
                catch { };
                try
                {
                    if (Convert.ToString(mot[motIndex]) == tab[i - 1, j + 1]) //Vérifie en haut à droite de la cellule i,j.
                    {
                        test = true;
                        if (Test_Recursif(i - 1, j + 1, mot, motIndex, listIndex) == false)
                        {
                            test = false;
                        }
                    }
                }
                catch { };
                
                try
                {
                    if (Convert.ToString(mot[motIndex]) == tab[i, j + 1]) //Vérifie à droite de la cellule i,j.
                    {
                        test = true;
                        if (Test_Recursif(i, j + 1, mot, motIndex, listIndex) == false)
                        {
                            test = false;
                        }
                    }
                }
                catch { };
                try
                {
                    if (Convert.ToString(mot[motIndex]) == tab[i + 1, j - 1]) //Vérifie en bas à gauche de la cellule i,j.
                    {
                        test = true;
                        if (Test_Recursif(i + 1, j - 1, mot, motIndex, listIndex) == false)
                        {
                            test = false;
                        }
                    }
                }
                catch { };
                
                try
                {
                    if (Convert.ToString(mot[motIndex]) == tab[i, j - 1]) //Vérifie à gauche de la cellule i,j.
                    {
                        test = true;
                        if (Test_Recursif(i, j - 1, mot, motIndex, listIndex) == false)
                        {
                            test = false;
                        }
                    }
                }
                catch { };
                
                try
                {
                    if (Convert.ToString(mot[motIndex]) == tab[i + 1, j]) //Vérifie en bas de la cellule i,j.
                    {
                        test = true;
                        if (Test_Recursif(i + 1, j, mot, motIndex, listIndex) == false)
                        {
                            test = false;
                        }
                    }
                }
                catch { };
            }
            return test;
        }
        #endregion Méthodes

    }
}