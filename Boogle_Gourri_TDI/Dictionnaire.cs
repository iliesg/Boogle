using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Boogle_Gourri_TDI
{
    public class Dictionnaire
    {
        #region Attributs

        public SortedList<int, string[]> ensembleDeMots;
        public string langue;
        private string[] dico;
        private int longueur;

        #endregion Attributs

        #region Propriétés
        public SortedList<int, string[]> EnsembleDeMots
        {
            get { return this.ensembleDeMots; }
            set { this.ensembleDeMots = value; }

        }
        public string[] Dico
        {
            get { return this.dico; }
            set { this.dico = value; }
        }

        public int Longueur
        {
            get { return this.longueur; }
            set { this.longueur = value; }
        }

        public string Langue
        {
            get { return this.langue; }
            set { this.langue = value; }
        }
        #endregion 

        #region Constructeurs
        public Dictionnaire(string[] dico, int longueur, string langue)
        {
            this.dico = dico;
            this.longueur = longueur;
            this.langue = langue;
        }

        public Dictionnaire(SortedList<int, string[]> ensembleDeMots, string langue)
        {
            this.ensembleDeMots = ensembleDeMots;
            this.langue = langue;
        }
        public Dictionnaire(string[] dico)
        {
            this.dico = dico;
        }
        #endregion 

        #region Méthodes
        public string Affiche() //Affiche l'ensemble de mots et leur longueur correspondante.
        {
            string index = "";
            foreach (KeyValuePair<int, string[]> mot in ensembleDeMots)
            {
                for (int i = 0; i < ensembleDeMots.Count; i++)
                {
                    index = "Il y a " + ensembleDeMots[i].Length + " mots qui sont de longueur" + mot.Key;
                }
            }
            return index;
        }
        public string toString() //Retourne une description du dictionnaire.
        {
            return "La langue est : " + langue + "\n" + "\n" + Affiche();
        }
        public bool ContainDico(string mot) //Vérifie si le mot appartient au dictionnaire.
        {
            mot = mot.ToUpper();
            string[] tabMotTaille = ensembleDeMots[mot.Length];
            foreach (string element in tabMotTaille)
            {
                if (element.Equals(mot))
                {
                    return true;
                }
            }
            return false;
        }

        public bool RechDichoRecursif(int debut, int fin, string mot, List<string> ensembleDeMots)
        {

            if (string.Compare(mot, ensembleDeMots[debut]) == -1 || mot == null || mot.Length < 3 || debut > fin || string.Compare(mot, ensembleDeMots[fin]) == 1)
            {
                return false;  //Vérifie si les conditions sont bonnes.
            }

            int milieu = (debut + fin) / 2;

            if (string.Compare(ensembleDeMots[milieu], mot) == 1) ///Vérifie si le mot correspond à notre recherche grâce à la méthode string.Compare.
                                                                  ///Si ce n'est pas le cas on réalise une récursivité selon les différents cas.
            {
                return RechDichoRecursif(debut, milieu - 1, mot, ensembleDeMots);
            }
            else if (string.Compare(ensembleDeMots[milieu], mot) == 0)   
            {
                return true;
            }
            else
            {
                return RechDichoRecursif(milieu + 1, fin, mot, ensembleDeMots);
            }

        }
        #endregion 
    }
}
