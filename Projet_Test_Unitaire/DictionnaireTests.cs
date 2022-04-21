using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Test_Unitaire
{
    [TestClass()]
    public class DictionnaireTests
    {
        [TestMethod()]
        public void appartientTest()
        {
            SortedList<int, string[]> dico = new SortedList<int, string[]>();
            string[] tab1 = new string[] { "cheval", "zombi", "aimer" };
            dico.Add(5, tab1);
            string[] tab2 = new string[] { "joue", "hier", "soir" };
            dico.Add(4, tab2);
            Dictionnaire bigdico = new Dictionnaire(dico, "français");
            bool result = bigdico.appartient("joue");
            Assert.Equals(true, result);
        }
    }
}