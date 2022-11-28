using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesDelTruco.Tests
{
    [TestClass]
    public class PartidaShould
    {
        public Action<Partida> delegado = null;
        public Action<string> delegadorich = null;

        public void Escribir(string txt){}

        [TestMethod]
        public void CrearPartida()
        {
            Partida partida = new Partida(delegado);

            Assert.IsNotNull(partida);  
        }

        [TestMethod]
        public void DesuscribirseDelDelegadoRich()
        {
            Partida partida = new Partida(delegado);

            partida.DesuscribirDelegadoRich(delegadorich);

            Assert.IsNull(partida.DelegadoEscribirRich);
        }

        [TestMethod]
        public void SuscribirseAlDelegadoRich()
        {
            Partida partida = new Partida(delegado);

            partida.SuscribirDelegadoRich(Escribir);

            Assert.IsNotNull(partida.DelegadoEscribirRich);
        }

        [TestMethod]
        public void GetCartaJugada()
        {
            Partida partida = new Partida(delegado);
            Carta carta1 = new Carta(EPalo.Espada, 7, 1);
            Carta carta2 = new Carta(EPalo.Espada, 3, 1);
            Carta carta3 = new Carta(EPalo.Espada, 1, 1);

            Jugador jugador = new Jugador(30, "jesus", 2);

            jugador.CartasEnMano.Add(carta1);
            jugador.CartasEnMano.Add(carta2);
            jugador.CartasEnMano.Add(carta3);

            Carta aux = partida.JugarCarta(jugador);

            Assert.IsNotNull(aux);
        }
    }
}
