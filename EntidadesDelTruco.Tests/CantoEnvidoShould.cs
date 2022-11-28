using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesDelTruco.Tests
{
    [TestClass]
    public class CantoEnvidoShould
    {
        [TestMethod]
        public void ConstructorCanto()
        {
            CantoEnvido canto = new CantoEnvido("Envido",1,1);

            Assert.IsNotNull(canto);
            Assert.IsNotNull(canto.CantoJugador);
            Assert.IsNotNull(canto.ValorNoQuiero);
            Assert.IsNotNull(canto.ValorQuiero);
        }
    }
}
