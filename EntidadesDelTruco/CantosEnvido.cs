using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesDelTruco
{
    public class CantoEnvido
    {
        string cantoJugador;
        short valorQuiero;
        short valorNoQuiero;

        public string CantoJugador { get => cantoJugador; set => cantoJugador = value; }
        public short ValorQuiero { get => valorQuiero; set => valorQuiero = value; }
        public short ValorNoQuiero { get => valorNoQuiero; set => valorNoQuiero = value; }

        public CantoEnvido(string cantoJugador, short valorNoQuiero, short valorQuiero)
        {
            this.cantoJugador = cantoJugador;
            this.valorNoQuiero = valorNoQuiero;
            this.valorQuiero = valorQuiero;
        }

        public CantoEnvido()
        {

        }
    }
}
