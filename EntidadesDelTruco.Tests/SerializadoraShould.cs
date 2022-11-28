using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesDelTruco.Tests
{
    [TestClass]
    public class SerializadoraShould
    {
        [TestMethod]
        public void GetDirectorioSolucion()
        {
            DirectoryInfo directorio;

            directorio = Serializadora<DirectoryInfo>.GetDireccionSolucion();

            Assert.IsNotNull(directorio);
        }

        [TestMethod]
        [DataRow("Cartas_Truco")]
        public void LeerArchivosXml(string nombreArchivo)
        {
            MazoTruco mazo = null;

            mazo = Serializadora<MazoTruco>.LeerXML(nombreArchivo);

            Assert.IsNotNull(mazo);
            Assert.IsTrue(mazo.Cartas.Count == 40);
        }

        [TestMethod]
        [DataRow("Mazo_Prueba")]
        public void GuardarArchivosXml(string nombreArchivo)
        {
            Serializadora<MazoTruco>.GuardarDatos(Serializadora<MazoTruco>.LeerXML("Cartas_Truco"), nombreArchivo);

            MazoTruco mazo = Serializadora<MazoTruco>.LeerXML(nombreArchivo);

            Assert.IsNotNull(mazo);
        }
    }
}
