using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesDelTruco.Tests
{
    [TestClass]
    public class SalaShould
    {
        public Action<Partida> delegado = null;
        [TestMethod]
        public void CrearSala()
        {
            Sala sala = null;

            sala = new Sala(delegado);

            Assert.IsNotNull(sala);
        }

        [TestMethod]
        public void CrearPartida()
        {
            Sala sala = new Sala(delegado);

            sala.CrearPartida();

            Assert.IsNotNull(sala.Partida);
        }

        [TestMethod]
        public void CancelarPartida()
        {
            Sala sala = new Sala(delegado);

            sala.CrearPartida();
            sala.CancelarPartida();

            Assert.IsTrue(sala.SeCanceloLaPartida);
        }

        [TestMethod]
        public void GetPartida()
        {
            Sala sala = new Sala(delegado);
            sala.CrearPartida();

            Partida auxPartida = sala.GetPartidaSala();

            Assert.IsNotNull(auxPartida);
        }
    }
}
