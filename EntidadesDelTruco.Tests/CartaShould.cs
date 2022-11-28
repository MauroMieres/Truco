using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesDelTruco.Tests
{
    [TestClass]
    public class CartaShould
    {
        [TestMethod]
        public void ConstructorCarta()
        {
            Carta carta = new Carta(EPalo.Espada, 10, 2);

            Assert.IsNotNull(carta);
            Assert.IsNotNull(carta.Palo);
            Assert.IsNotNull(carta.Numero);
            Assert.IsNotNull(carta.ValorTruco);
            Assert.IsNotNull(carta.ValorEnvido==0);
        }

        [TestMethod]
        public void MostratInfoCarta()
        {
            Carta carta = new Carta(EPalo.Espada, 1, 2);

            string info = carta.ToString();

            Assert.IsTrue(info!=string.Empty);
        }
    }
}
