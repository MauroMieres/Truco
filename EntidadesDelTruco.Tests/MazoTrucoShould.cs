using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EntidadesDelTruco.Tests
{
    [TestClass]
    public class MazoTrucoShould
    {     
        [TestMethod]
        public void RepartirCartas()
        {
            Jugador j1 = new Jugador(1, "Mauro", 0);
            MazoTruco mazo = Serializadora<MazoTruco>.LeerXML("Cartas_Truco");
            mazo.Dar3Cartas(j1);

            Assert.IsTrue(j1.CartasEnMano.Count == 3);
        }

        [TestMethod]
        public void MezclarCartas()
        {      
            MazoTruco mazo = Serializadora<MazoTruco>.LeerXML("Cartas_Truco");
            MazoTruco mazoMezclado = Serializadora<MazoTruco>.LeerXML("Cartas_Truco");

            mazoMezclado.Mezclar();

            Assert.AreNotEqual(mazoMezclado, mazo);
        }
    }
}
