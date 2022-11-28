using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EntidadesDelTruco
{
    public class ManejadorArchivos<T> : IGuardar<T>
    {
        static string ruta;
        static ManejadorArchivos()
        {
            ruta = Serializadora<string>.GetDireccionSolucion().FullName;
            ruta += @"/Partidas_Jugadas";
        }

        public static void GuardarDatos(T datos, string archivo)
        {
            string completa = ruta + @"/Partida"+ archivo + DateTime.Now.ToString("HH_mm_ss") + ".txt";

            try
            {
                if (!Directory.Exists(ruta))//Esto significa que la carpeta NO EXISTE
                {
                    Directory.CreateDirectory(ruta); //Aca la creamos
                }
                File.AppendAllText(completa, datos.ToString());
            }
            catch (Exception e)
            {
                throw new Exception($"Error en el archivo {completa}");
            }
        }

        //public static DirectoryInfo GetDireccionSolucion(string currentPath = null)
        //{
        //    DirectoryInfo directory = new DirectoryInfo(
        //        currentPath ?? Directory.GetCurrentDirectory());
        //    while (directory != null && !directory.GetFiles("*.sln").Any())
        //    {
        //        directory = directory.Parent;
        //    }
        //    return directory;
        //}
    }
}
