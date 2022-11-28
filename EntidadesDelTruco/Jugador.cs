using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesDelTruco
{
    public class Jugador
    {
        int id;
        string nombre;
        int victorias;
        List<Carta> cartasEnMano;
        Random random;
        bool estaJugando;
        short puntos;
        int envido;

        public Jugador(int id, string nombre, int victorias)
        {
            this.id = id;
            this.nombre = nombre;
            this.victorias = victorias;
            this.cartasEnMano = new List<Carta>();
            this.random = new Random();
            this.estaJugando = false;
            this.puntos = 0;
            this.envido = 0;
        }

        public void ComenzarPartida()
        {
            this.estaJugando = true;
        }

        public List<Carta> CartasEnMano { get => cartasEnMano;  }
        public string Nombre { get => nombre;  }
        public int Victorias { get => victorias; }
        public int Id { get => id; }
        public short Puntos { get => puntos; set => puntos = value; }
        public bool EstaJugando { get => estaJugando;  }
        public int Envido { get => envido; set => envido = value; }

        public void LiberarJugador()
        {
            this.estaJugando = false;
        }

        public int CalcularEnvido()
        {
            List<Carta> cartas = BuscarCartasMismoPaloEnMano();

            int envido = 20;
            switch (cartas.Count)
            {
                case 1://si tengo una sola carta ....
                    return cartas.First().ValorEnvido;
                case 2://si tengo 2
                    cartas.ForEach((c) => envido += c.ValorEnvido);
                    return envido;

                case 3://si tengo 3 
                    (tresCartasMismoPalo()).ForEach((c) => envido += c.ValorEnvido);
                    return envido;
                default: return 0;
            }
        }

        public List<Carta> tresCartasMismoPalo()
        {
            List<Carta> auxCartas = new List<Carta>();
            this.cartasEnMano.ForEach((x) => auxCartas.Add(x));

            List<Carta> mejoresCartas = new List<Carta>();

            int mayorValorEnvido = auxCartas.Max(t => t.ValorEnvido);         
            //busco cual es la mejor carta para el envido y la saco
            foreach (Carta carta in auxCartas)
            {
                if (carta.ValorEnvido == mayorValorEnvido)
                {
                    mejoresCartas.Add(carta);
                    auxCartas.Remove(carta);
                    break;
                }
            }
            //lo hago una vez mas 
            mayorValorEnvido = auxCartas.Max(t => t.ValorEnvido);

            foreach (Carta carta in auxCartas)
            {
                if (carta.ValorEnvido == mayorValorEnvido)
                {
                    mejoresCartas.Add(carta);
                    auxCartas.Remove(carta);
                    break;
                }
            }
            return mejoresCartas;
            //retorno las 2 mejores cartas en caso de tener 3 del mismo palo
        }

        public List<Carta> BuscarCartasMismoPaloEnMano()
        {
            List<Carta> cartasBasto = CartasEnMano.FindAll((c) => c.Palo == EPalo.Basto);
            List<Carta> cartasEspada = CartasEnMano.FindAll((c) => c.Palo == EPalo.Espada);
            List<Carta> cartasOro = CartasEnMano.FindAll((c) => c.Palo == EPalo.Oro);
            List<Carta> cartasCopa = CartasEnMano.FindAll((c) => c.Palo == EPalo.Copa);

            //tengo 2 o mas cartas de ese palo

            if (cartasBasto.Count >= 2)
                return cartasBasto;

            if (cartasEspada.Count >= 2)
                return cartasEspada;

            if (cartasOro.Count >= 2)
                return cartasOro;


            if (cartasCopa.Count >= 2)
                return cartasCopa;

            //si tengo una sola, devuelvo la mayor
            List<Carta> cartaMayorValorEnvido = new List<Carta>();
            int mayorValorEnvido = CartasEnMano.Max(t => t.ValorEnvido);
            foreach (Carta carta in CartasEnMano)
            {
                if (carta.ValorEnvido == mayorValorEnvido)
                    cartaMayorValorEnvido.Add(carta);
            }
            return cartaMayorValorEnvido;

            //en ambos casos devuelvo una lista de cartas
        }
    }
}
