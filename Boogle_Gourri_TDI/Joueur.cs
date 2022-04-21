using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boogle_Gourri_TDI
{
    public class Joueur
    {
        #region Attributs

        private string nom;
        private int score;
        private string mot;
        public List<string> listMots;

        #endregion Attributs

        #region Propriétés
        public string Nom
        {
            get { return this.nom; }
            set { this.nom = value; }
        }
        public int Score
        {
            get { return this.score; }
            set { this.score = value; }
        }

        public string Mot
        {
            get { return this.mot; }
            set { this.mot = value; }
        }

        public List<string> ListMots
        {
            get { return this.listMots; }
            set { this.listMots = value; }
        }
        #endregion

        #region Constructeurs
        public Joueur(string nom, int score, List<string> listMots)
        {
            this.nom = nom;
            this.score = score;
            this.listMots = listMots;
        }
        public Joueur(string nom)
        {
            this.nom = nom;
        }
        public Joueur(string nom, List<string> listMots)
        {
            this.nom = nom;
            this.listMots = listMots;
        }
        #endregion Constructeurs

        #region Méthodes
        public void Add_Mot(string mot) //Ajout de mot.
        {
            listMots.Add(mot);
        }
        public bool Contain(string mot) //Test si le mot est déjà dans la liste de mots trouvé durant toute la partie.
        {
            bool index = false;

            if (listMots == null && listMots.Count == 0) //Il n'y a pas de mots au début de la partie.
            {
                index = true;
            }

            for (int i = 0; i < listMots.Count; i++) //Parcours de la liste de mots au cours de la partie.
            {
                if (mot == listMots[i])
                {
                    index = true;
                }
            }

            return index;
        }
        public string Affiche() //Affichage de la liste des mots.
        {
            string index = "";

            foreach (string mot in listMots)
            {
                index += mot + " | ";
            }
            return index;
        }
        public string toString() //Affichage de la chaîne de caractère.
        {
            return this.nom + " a un score de " + this.score + ". Les mots gagnant sont : " + Affiche() +"\n";
        }

        #endregion Méthodes
    }
}