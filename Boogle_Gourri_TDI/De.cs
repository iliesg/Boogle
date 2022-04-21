using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boogle_Gourri_TDI
{
    public class De
    {
        #region Attributs

        public string lettre;
        public string[] ensembleDeLettre;

        #endregion Attributs

        #region Propriétés
        public string[] EnsembleDeLettre
        {
            get { return ensembleDeLettre; }
            set { this.ensembleDeLettre = value; }
        }

        public string Lettre
        {
            get { return lettre; }
            set { this.lettre = value; }
        }
        #endregion

        #region Constructeur
        public De(string[] de)
        {
            if (de.Length == 6 && de != null) //Il faut que le dé contienne 6 lettres d'après la consigne.
            {
                this.ensembleDeLettre = de;
            }
        }
        #endregion 

        #region Méthodes
        public string Lance(Random r) //Permet de tirer une lettre aléatoire parmi les 6 faces d'un dé.
        {
            int rdm = r.Next(5);
            lettre = ensembleDeLettre[rdm];
            return lettre;
        }
        public string Affiche() //Permet d'afficher les lettres d'un dé.
        {
            string index = "";
            for (int i = 0; i < ensembleDeLettre.Length; i++)
            {
                index += ensembleDeLettre[i] + " | ";
            }
            return index;
        }
        public string toString() //Affiche les caractéristiques d'un dé.
        {
            return "Les 6 faces du dé sont : " + Affiche();
        }

        #endregion
    }
}
