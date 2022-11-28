using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesDelTruco.Tests
{
    [TestClass]
    public class JugadorShould
    {
        [TestMethod]
        public void ConstructorJugador()
        {
            Jugador jugador = new Jugador(30, "jesus", 2);

            Assert.IsNotNull(jugador);
        }

        [TestMethod]
        public void JugadorComienzaJugar()
        {
            Jugador jugador = new Jugador(30, "jesus", 2);

            jugador.ComenzarPartida();

            Assert.IsTrue(jugador.EstaJugando);
        }

        [TestMethod]
        public void JugadorTerminaPartida()
        {
            Jugador jugador = new Jugador(30, "jesus", 2);

            jugador.LiberarJugador();

            Assert.IsTrue(!jugador.EstaJugando);
        }

        [TestMethod]
        public void JugadorCalcularEnvido2Cartas()
        {
            Carta carta1 = new Carta(EPalo.Espada, 7, 1);
            Carta carta2 = new Carta(EPalo.Espada, 1, 1);

            Jugador jugador = new Jugador(30, "jesus", 2);

            jugador.CartasEnMano.Add(carta1);
            jugador.CartasEnMano.Add(carta2);

            int envido = jugador.CalcularEnvido();

            Assert.IsTrue(envido == 28);
        }

        [TestMethod]
        public void JugadorCalcularEnvido1Cartas()
        {
            Carta carta1 = new Carta(EPalo.Espada, 7, 1);
            Carta carta2 = new Carta(EPalo.Basto, 1, 1);
            Carta carta3 = new Carta(EPalo.Oro, 1, 1);

            Jugador jugador = new Jugador(30, "jesus", 2);

            jugador.CartasEnMano.Add(carta1);
            jugador.CartasEnMano.Add(carta2);
            jugador.CartasEnMano.Add(carta3);

            int envido = jugador.CalcularEnvido();

            Assert.IsTrue(envido == 7);
        }

        [TestMethod]
        public void JugadorCalcularEnvido3Cartas()
        {
            Carta carta1 = new Carta(EPalo.Espada, 7, 1);
            Carta carta2 = new Carta(EPalo.Espada, 3, 1);
            Carta carta3 = new Carta(EPalo.Espada, 1, 1);

            Jugador jugador = new Jugador(30, "jesus", 2);

            jugador.CartasEnMano.Add(carta1);
            jugador.CartasEnMano.Add(carta2);
            jugador.CartasEnMano.Add(carta3);

            int envido = jugador.CalcularEnvido();

            Assert.IsTrue(envido == 30);
        }

        [TestMethod]
        [DataRow(EPalo.Oro)]
        [DataRow(EPalo.Espada)]
        [DataRow(EPalo.Basto)]
        [DataRow(EPalo.Copa)]
        public void Tengo3CartasDelMismoPalo(EPalo palo)
        {
            Jugador jugador = new Jugador(30, "jesus", 2);
            jugador.CartasEnMano.Add(new Carta(palo,1,1));
            jugador.CartasEnMano.Add(new Carta(palo, 4, 1));
            jugador.CartasEnMano.Add(new Carta(palo, 3, 1));
            List<Carta> cartas = jugador.BuscarCartasMismoPaloEnMano();
            Assert.IsNotNull(cartas);
            Assert.IsTrue(cartas.Count==3);
        }

        [TestMethod]
        [DataRow(EPalo.Oro)]
        [DataRow(EPalo.Espada)]
        [DataRow(EPalo.Basto)]
        [DataRow(EPalo.Copa)]
        public void Tengo2CartasDelMismoPalo(EPalo palo)
        {
            Jugador jugador = new Jugador(30, "jesus", 2);
            jugador.CartasEnMano.Add(new Carta(palo, 1, 1));
            jugador.CartasEnMano.Add(new Carta(palo, 5, 1));

            List<Carta> cartas = jugador.BuscarCartasMismoPaloEnMano();

            Assert.IsNotNull(cartas);
            Assert.IsTrue(cartas.Count == 2);
        }

        [TestMethod]
        [DataRow(EPalo.Oro,EPalo.Espada,EPalo.Basto)]
        [DataRow(EPalo.Oro, EPalo.Espada, EPalo.Copa)]
        public void Tengo3CartarDeDistintosPalos(EPalo p1,EPalo p2,EPalo p3)
        {
            Jugador jugador = new Jugador(30, "jesus", 2);
            jugador.CartasEnMano.Add(new Carta(p1, 1, 1));
            jugador.CartasEnMano.Add(new Carta(p2, 7, 1));
            jugador.CartasEnMano.Add(new Carta(p3, 1, 1));

            List<Carta> cartas = jugador.BuscarCartasMismoPaloEnMano();

            Assert.IsNotNull(cartas);
            Assert.IsTrue(cartas.Count == 1);
            Assert.IsTrue(cartas[0].ValorEnvido == 7);
        }

        [TestMethod]
        public void Devolver2MayoresCartasEnvidoCuandoTengo3DelMismoPalo()
        {
            Jugador jugador = new Jugador(30, "jesus", 2);
            jugador.CartasEnMano.Add(new Carta(EPalo.Basto, 1, 1));
            jugador.CartasEnMano.Add(new Carta(EPalo.Basto, 3, 1));
            jugador.CartasEnMano.Add(new Carta(EPalo.Basto, 6, 1));
            List<Carta> cartasDelJugador = jugador.CartasEnMano;

            List<Carta> cartas = jugador.tresCartasMismoPalo();

            Assert.IsNotNull(cartas);
            Assert.IsTrue(cartas.Count==2);     
        }

    }
}
