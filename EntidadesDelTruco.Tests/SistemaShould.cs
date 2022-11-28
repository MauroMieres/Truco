using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesDelTruco.Tests
{
    [TestClass]
    public class SistemaShould
    {
        public Action<Partida> delegado = null;

        [TestMethod]
        public void CrearSala()
        {
            Sala auxSala = null;

            auxSala = Sistema.CrearSala(delegado);

            Assert.IsNotNull(auxSala);
            Assert.IsTrue(Sistema.SalasCreadas.Count > 0);
        }
    }
}
