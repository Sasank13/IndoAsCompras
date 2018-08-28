using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Teste.Dominio
{    
    [TestClass]
    public class TestaMsTest
    {
        [TestMethod]
        public void PassingTest()
        {
            Assert.AreEqual(4, Add(2, 2));
            //Assert.Equal(4, Add(2, 2));
        }

        [TestMethod]
        public void FailingTest()
        {
            Assert.AreEqual(5, Add(2, 2));
        }

        int Add(int x, int y)
        {
            return x + y;
        }
    }
}
