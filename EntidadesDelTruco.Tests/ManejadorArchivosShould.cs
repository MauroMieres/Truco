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
    public class ManejadorArchivosShould
    {
        [TestMethod]
        public void GuardarHistorialPartidaTxt()
        {
            string prueba = "UNIT TESTING ...";
            string archivo = "UnitTesting";
            string rutaArchivo = Serializadora<string>.GetDireccionSolucion().FullName;

            ManejadorArchivos<string>.GuardarDatos(prueba, archivo);

            //checkeamos que la carpeta no este vacia, para testear esto borre todas las demas partidas
            Assert.IsTrue(Directory.EnumerateFileSystemEntries(rutaArchivo).Any());
        }
    }
}
