using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesDelTruco.Tests
{
    [TestClass]
    public class JugadoresDAO_Should
    {
        [TestMethod]
        public void ObtenerJugadoresDB()
        {
            List<Jugador> jugadores = null;

            jugadores = JugadoresDAO.ObtenerJugadoresDB();

            Assert.IsNotNull(jugadores);
            Assert.IsTrue(jugadores.Count > 0);
        }

        
        [TestMethod]
        public void ActualizarVictorias()
        {
            int victoriasAntes = JugadoresDAO.ObtenerJugadoresDB()[0].Victorias;

            JugadoresDAO.ActualizarVictorias(JugadoresDAO.ObtenerJugadoresDB()[0]);

            Assert.IsTrue(victoriasAntes< JugadoresDAO.ObtenerJugadoresDB()[0].Victorias);
        }
    }
}
