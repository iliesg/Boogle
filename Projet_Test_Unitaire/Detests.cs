using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Test_Unitaire
{
    [TestClass()]
    public class DeTests
    {
        [TestMethod()]
        public void LanceTest()
        {
            string[] tab = new string[] { "A", "B", "E", "J", "K", "L" };
            De de = new De(tab);
            Random r = new Random();
            Assert.Equals("A", de.Lance(r));
        }
    }
}