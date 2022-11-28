using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EntidadesDelTruco
{
    public class Serializadora<T> : IGuardar<T>
    {
        static string ruta;
        static Serializadora()
        {
            ruta = GetDireccionSolucion().FullName;
            ruta += @"/Archivos-Serializacion";
        }

        public static void GuardarDatos(T datos, string archivo)
        {
            string rutaCompleta = ruta + @"/Serializadora_" + archivo + ".xml";

            if (!Directory.Exists(ruta))//Esto significa que la carpeta NO EXISTE
            {
                Directory.CreateDirectory(ruta); //Aca la creamos
            }

            using (StreamWriter sw = new StreamWriter(rutaCompleta))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                xmlSerializer.Serialize(sw, datos);
            }
        }
       
        public static T LeerXML(string nombreArchivo)
        {
            T datos = default;
            string completa = ruta + @"/Serializadora_" + nombreArchivo + ".xml";

            if (Directory.Exists(ruta))//Esto significa que la carpeta NO EXISTE
            {
                if (!Directory.Exists(ruta))//Esto significa que la carpeta NO EXISTE
                {
                    Directory.CreateDirectory(ruta); //Aca la creamos
                }

                using (StreamReader sr = new StreamReader(completa))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                    datos = (T)xmlSerializer.Deserialize(sr);
                }
            }
            return datos;
        }

        public static DirectoryInfo GetDireccionSolucion(string currentPath = null)
        {
            var directory = new DirectoryInfo(
                currentPath ?? Directory.GetCurrentDirectory());
            while (directory != null && !directory.GetFiles("*.sln").Any())
            {
                directory = directory.Parent;
            }
            return directory;
        }
    }
}
