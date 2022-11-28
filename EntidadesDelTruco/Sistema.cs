using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesDelTruco
{
    public static class Sistema
    {
        static List<Sala> salasCreadas = null;
        static List<Jugador> jugadores = null;

        static Sistema()
        {
            salasCreadas = new List<Sala>();
            jugadores = JugadoresDAO.ObtenerJugadoresDB();
        }

        public static List<Sala> SalasCreadas { get => salasCreadas; }
        public static List<Jugador> Jugadores { get => jugadores; }

        public static Sala CrearSala(Action<Partida> delegadoGanador)
        {
            Sala sala = new Sala(delegadoGanador);
            salasCreadas.Add(sala);
            sala.CrearPartida();
            return sala;
        }
    }
}
