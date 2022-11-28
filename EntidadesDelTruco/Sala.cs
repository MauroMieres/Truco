using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EntidadesDelTruco
{
    public class Sala
    {
        CancellationTokenSource cts = null;
        CancellationToken ct = default;
        Partida partidaTruco = null;
        Task partida = null;
        string jugador1;
        string jugador2;
        bool seCanceloLaPartida = false;
        Action<Partida> delegadoGanador;


        public string Jugador1 { get => jugador1; }
        public string Jugador2 { get => jugador2; }
        public Task Partida { get => partida; }
        public bool SeCanceloLaPartida { get => seCanceloLaPartida; }

        public Sala(Action<Partida> delegado)
        {
            this.cts = new CancellationTokenSource();
            this.ct = cts.Token;
            this.jugador1 = "";
            this.jugador2 = "";
            delegadoGanador = delegado;
        }

        public Partida GetPartidaSala()
        {
            return partidaTruco;
        }

        public void CrearPartida()
        {
            try
            {
                Partida partida = new Partida(delegadoGanador);
                this.partida = Task.Run(() => partida.JugarPartida3(this.ct));
                this.jugador1 = partida.J1.Nombre;
                this.jugador2 = partida.J2.Nombre;
                this.partidaTruco = partida;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }     
        }

        public void CancelarPartida()
        {
            this.partidaTruco.J1.LiberarJugador();
            this.partidaTruco.J2.LiberarJugador();
            this.cts.Cancel();
            this.seCanceloLaPartida = true;
        }
    }
}
