using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesDelTruco
{
    public interface IGuardar<T>
    {
        public static void GuardarDatos(T dato, string info) {}
    }
}
