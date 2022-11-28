using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesDelTruco
{
    public class CantosDelEnvido
    {

        List<CantoEnvido> cantos = new List<CantoEnvido>();
        public CantosDelEnvido()
        {

        }

        //public CantosDelEnvido(int num)
        //{
        //    CargarCantosEnvido();
        //}

        //private void CargarCantosEnvido()
        //{
        //    cantos.Add(new CantoEnvido("Envido!", 1, 2));
        //    cantos.Add(new CantoEnvido("Envido!", 2, 4));
        //    cantos.Add(new CantoEnvido("Real Envido!", 4, 7));
        //    cantos.Add(new CantoEnvido("Falta Envido!", 7, 15));
        //}

        public List<CantoEnvido> Cantos { get => cantos; set => cantos = value; }
    }
}
