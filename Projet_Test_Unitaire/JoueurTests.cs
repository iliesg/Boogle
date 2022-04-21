using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Test_Unitaire
{
    [TestClass()]
    public class JoueurTests
    {
        [TestMethod()]
        public void ContainTest()
        {
            Joueur j = new Joueur("Ilies");
            List<string> listMot = new List<string>();
            listMot.Add("cheval");
            listMot.Add("zombie");
            listMot.Add("amour");
            Assert.Equals(true, j.Contain("cheval"));
        }
    }
}
