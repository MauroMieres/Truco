using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EntidadesDelTruco
{
    public class Partida
    {
        int turnosJugados;
        Action<string> delegadoEscribirRich;
        Jugador j1 = null;
        Jugador j2 = null;
        short puntosJ1;
        short puntosJ2;
        StringBuilder historialPartida = null;
        MazoTruco mazo = null;
        List<Carta> cartasRepartidas = null;
        static Random rnd = new Random();
        Jugador ganador = null;
        public Action<Partida> huboGanador;
        CantosDelEnvido listaCantosEnvido;
        CantosDelTruco listaCantosTruco;
        int indiceCantoEnvido = 0;
        int indiceCantoTruco = 0;
        int puntosTruco = 1;

        public Partida(Action<Partida> partida)
        {
            ElegirJugadores();
            if (j1 is null || j2 is null)
                throw new Exception("No hay jugadores libres para jugar en esta sala");

            this.turnosJugados = 0;
            this.historialPartida = new StringBuilder();
            this.mazo = Serializadora<MazoTruco>.LeerXML("Cartas_Truco");
            this.puntosJ1 = 0;
            this.puntosJ2 = 0;
            this.huboGanador = partida;
            this.listaCantosEnvido = Serializadora<CantosDelEnvido>.LeerXML("Cantos_Envido");
            this.listaCantosTruco = Serializadora<CantosDelTruco>.LeerXML("Cantos_Truco");
        }

        private void ElegirJugadores()
        {
            Random random = new Random();
            List<Jugador> jugadoresDisp = new List<Jugador>();

            foreach (Jugador jugador in Sistema.Jugadores)
            {
                if (jugador.EstaJugando == false)
                    jugadoresDisp.Add(jugador);
            }

            if (jugadoresDisp.Count < 2)
            {
                throw new Exception("No hay jugadores disponibles para crear una sala/partida");
            }
            else
            {
                j1 = jugadoresDisp[random.Next(0, jugadoresDisp.Count)];
                j1.ComenzarPartida();

                jugadoresDisp.Remove(j1);

                j2 = jugadoresDisp[random.Next(0, jugadoresDisp.Count)];
                j2.ComenzarPartida();
            }
        }



        public void SuscribirDelegadoRich(Action<string> delegado)
        {
            delegadoEscribirRich += delegado;
        }

        public void DesuscribirDelegadoRich(Action<string> delegado)
        {
            delegadoEscribirRich -= delegado;
        }


        public Jugador J1 { get => j1; }
        public Jugador J2 { get => j2; }
        public StringBuilder HistorialPartida { get => historialPartida; }
        public Jugador Ganador { get => ganador; }
        public Action<string> DelegadoEscribirRich { get => delegadoEscribirRich; }

        public void JugarPartida3(CancellationToken ct)
        {
            j1.Puntos = 0;
            j2.Puntos = 0;
            while (!ct.IsCancellationRequested)
            {
                bool manoJugador1 = true;
                this.cartasRepartidas = new List<Carta>();

                this.mazo.Dar3Cartas(this.j1);
                this.mazo.Dar3Cartas(this.j2);

                j1.CartasEnMano.ForEach((x) => cartasRepartidas.Add(x));
                j2.CartasEnMano.ForEach((x) => cartasRepartidas.Add(x));

                if (delegadoEscribirRich is not null)
                    delegadoEscribirRich.Invoke("Repartiendo Cartas ...\n");
                historialPartida.AppendLine("Repartiendo Cartas ...");

                Thread.Sleep(1000);

                if (manoJugador1)
                {
                    this.JugarMano(this.j1, this.j2);
                }
                else
                {
                    this.JugarMano(this.j2, this.j1);
                }

                manoJugador1 = !manoJugador1;

                j1.CartasEnMano.Clear();
                j2.CartasEnMano.Clear();
                  
                puntosJ1 = j1.Puntos;
                puntosJ2 = j2.Puntos;

                puntosTruco = 1;
                //
                string puntajeActual = $"{j1.Nombre}: {puntosJ1} | {j2.Nombre}: {puntosJ2}";
                historialPartida.AppendLine(puntajeActual);
                if (delegadoEscribirRich is not null)
                    delegadoEscribirRich.Invoke(puntajeActual);

                //agrego las cartas q se repartieron al mazo
                this.cartasRepartidas.ForEach((x) => this.mazo.Cartas.Add(x));
                turnosJugados++;

                if (turnosJugados == 5 || puntosJ1 >= 15 || puntosJ2 >= 15)
                {
                    ganador = GetGanador();
                    historialPartida.AppendLine($"{ganador.Nombre} gano la partida!");
                    if (delegadoEscribirRich is not null)
                        delegadoEscribirRich.Invoke($"{ganador.Nombre} gano la partida!");

                    j1.LiberarJugador();
                    j2.LiberarJugador();

                    JugadoresDAO.ActualizarVictorias(ganador);
                    //si la partida no se cancela se guarda el historial
                    ManejadorArchivos<string>.GuardarDatos(this.historialPartida.ToString(), $"_{j1.Nombre}_{j2.Nombre}");

                    this.huboGanador.Invoke(this);

                    return;
                }

                if (ct.IsCancellationRequested)
                    if (delegadoEscribirRich is not null)
                        delegadoEscribirRich.Invoke("Esta partida fue cancelada, no se guardara el historial");

            }
        }

        private void JugarMano(Jugador mano, Jugador pie)
        {
            string resultado = string.Empty;
            mano.Envido = mano.CalcularEnvido();
            pie.Envido = pie.CalcularEnvido();

            Carta carta1mano = null;
            Carta carta1pie = null;

            //envido
            switch (rnd.Next(1, 5))//1 no canta el mano //2no canta el pie //3canta el mano //4canta el pie
            {
                case 1:
                case 2:
                    carta1mano = JugarCarta(mano);
                    carta1pie = JugarCarta(pie);
                    break;

                case 3://canta el mano
                    CantarEnvido(mano, pie);
                    carta1mano = JugarCarta(mano);
                    carta1pie = JugarCarta(pie);
                    break;

                case 4://canta el pie
                    carta1mano = JugarCarta(mano);
                    CantarEnvido(pie, mano);
                    carta1pie = JugarCarta(pie);
                    break;
            }

            Carta carta2mano = null;
            Carta carta2pie = null;

            if (carta1mano.ValorTruco >= carta1pie.ValorTruco)//el mano tiene primera
            {
                carta2mano = JugarCarta(mano);
                carta2pie = JugarCarta(pie);

                if (carta2mano.ValorTruco >= carta2pie.ValorTruco)//mano tiene primera y segunda
                {
                    resultado = $"{mano.Nombre} se lleva los puntos del truco";
                    mano.Puntos += (short)puntosTruco;
                }
                else //mano tiene primera, pie tiene segunda, van a tercera ...
                {
                    switch (rnd.Next(2, 4))
                    {
                        case 1://nadie canta truco            
                            break;
                        case 2://el pie canta truco
                            this.CantarTruco(pie, mano);
                            break;
                        case 3://el mano canta truco
                            this.CantarTruco(mano, pie);
                            break;
                    }

                    Carta carta3pie = JugarCarta(pie);
                    Carta carta3mano = JugarCarta(mano);

                    if (carta3pie.ValorTruco >= carta3mano.ValorTruco)//pie tiene segunda y tercera, gana
                    {
                        resultado = $"{pie.Nombre} se lleva los puntos del truco";
                        pie.Puntos += (short)puntosTruco;
                    }
                    else//mano tiene primera y tercera
                    {
                        resultado = $"{mano.Nombre} se lleva los puntos del truco";
                        mano.Puntos += (short)puntosTruco;
                    }
                }
                historialPartida.AppendLine(resultado);
                if (delegadoEscribirRich is not null)
                    delegadoEscribirRich.Invoke(resultado);
            }
            else //pie tiene primera
            {
                carta2pie = JugarCarta(pie);
                carta2mano = JugarCarta(mano);

                if (carta2pie.ValorTruco >= carta2mano.ValorTruco)//pie tiene primera y segunda
                {
                    resultado = $"{pie.Nombre} se lleva los puntos del truco";
                    pie.Puntos += (short)puntosTruco;
                }
                else //pie tiene primera, mano tiene segunda, van a tercera ....
                {

                    Carta carta3mano = null;
                    Carta carta3pie = null;

                    switch (rnd.Next(2, 4))
                    {
                        case 1://nadie canta truco
                            carta3mano = JugarCarta(mano);
                            carta3pie = JugarCarta(pie);
                            break;
                        case 2://el mano canta truco
                            this.CantarTruco(mano, pie);
                            carta3mano = JugarCarta(mano);
                            carta3pie = JugarCarta(pie);
                            break;
                        case 3://el pie canta truco                        
                            carta3mano = JugarCarta(mano);
                            this.CantarTruco(pie, mano);
                            carta3pie = JugarCarta(pie);
                            break;
                    }

                    if (carta3pie.ValorTruco >= carta3mano.ValorTruco)//pie tiene primera y tercera
                    {
                        resultado = $"{pie.Nombre} se lleva los puntos del truco";
                        pie.Puntos += (short)puntosTruco;
                    }
                    else //mano tiene segunda y tercera
                    {
                        resultado = $"{mano.Nombre} se lleva los puntos del truco";
                        mano.Puntos += (short)puntosTruco;
                    }
                }
                historialPartida.AppendLine(resultado);
                if (delegadoEscribirRich is not null)
                    delegadoEscribirRich.Invoke(resultado);
            }
        }


        private Jugador GetGanador()
        {
            if (puntosJ1 >= puntosJ2)
                return j1;
            else
                return j2;
        }

        private void CantarEnvido(Jugador canta, Jugador leCantan)
        {
            string cantoRealizado = $"{canta.Nombre}: {this.listaCantosEnvido.Cantos[indiceCantoEnvido].CantoJugador}";
            this.historialPartida.AppendLine(cantoRealizado);
            if (delegadoEscribirRich is not null)
                delegadoEscribirRich.Invoke(cantoRealizado);

            //ahora hay que responder
            //espera la respuesta
            string respuesta = string.Empty;

            Thread.Sleep(1000);
            switch (rnd.Next(0, 3))
            {
                case 0://no quiero
                    respuesta = $"{leCantan.Nombre}: no quiero.";
                    this.historialPartida.AppendLine(respuesta);
                    if (delegadoEscribirRich is not null)
                        delegadoEscribirRich.Invoke(respuesta);
                    canta.Puntos += this.listaCantosEnvido.Cantos[indiceCantoEnvido].ValorNoQuiero;
                    break;
                case 1://quiero
                    respuesta = $"{leCantan.Nombre}: quiero, {leCantan.Envido}";
                    this.historialPartida.AppendLine(respuesta);
                    if (delegadoEscribirRich is not null)
                        delegadoEscribirRich.Invoke(respuesta);
                    CompararEnvido(leCantan, canta);
                    break;
                case 2://envido envido
                    indiceCantoEnvido++;
                    respuesta = $"{leCantan.Nombre}: {listaCantosEnvido.Cantos[indiceCantoEnvido].CantoJugador}";
                    this.historialPartida.AppendLine(respuesta);
                    if (delegadoEscribirRich is not null)
                        delegadoEscribirRich.Invoke(respuesta);
                    Thread.Sleep(1000);
                    switch (rnd.Next(0, 3))
                    {
                        case 0://no quiero
                            respuesta = $"{canta.Nombre}: no quiero.";
                            this.historialPartida.AppendLine(respuesta);
                            if (delegadoEscribirRich is not null)
                                delegadoEscribirRich.Invoke(respuesta);
                            leCantan.Puntos += this.listaCantosEnvido.Cantos[indiceCantoEnvido].ValorNoQuiero;
                            break;
                        case 1://quiero
                            respuesta = $"{canta.Nombre}: quiero, {canta.Envido}";
                            this.historialPartida.AppendLine(respuesta);
                            if (delegadoEscribirRich is not null)
                                delegadoEscribirRich.Invoke(respuesta);
                            CompararEnvido(canta, leCantan);
                            break;
                        case 2://envido envido real envido
                            indiceCantoEnvido++;
                            respuesta = $"{canta.Nombre}: {listaCantosEnvido.Cantos[indiceCantoEnvido].CantoJugador}";
                            this.historialPartida.AppendLine(respuesta);
                            if (delegadoEscribirRich is not null)
                                delegadoEscribirRich.Invoke(respuesta);
                            Thread.Sleep(1000);
                            switch (rnd.Next(0, 3))
                            {
                                case 0://no quiero
                                    respuesta = $"{leCantan.Nombre}: no quiero.";
                                    this.historialPartida.AppendLine(respuesta);
                                    if (delegadoEscribirRich is not null)
                                        delegadoEscribirRich.Invoke(respuesta);
                                    canta.Puntos += this.listaCantosEnvido.Cantos[indiceCantoEnvido].ValorNoQuiero;
                                    break;
                                case 1://quiero
                                    respuesta = $"{leCantan.Nombre}: quiero, {canta.Envido}";
                                    this.historialPartida.AppendLine(respuesta);
                                    if (delegadoEscribirRich is not null)
                                        delegadoEscribirRich.Invoke(respuesta);
                                    CompararEnvido(leCantan, canta);
                                    break;
                                case 2://envido envido real envido falta envido
                                    indiceCantoEnvido++;
                                    respuesta = $"{leCantan.Nombre}: {listaCantosEnvido.Cantos[indiceCantoEnvido].CantoJugador}";
                                    this.historialPartida.AppendLine(respuesta);
                                    if (delegadoEscribirRich is not null)
                                        delegadoEscribirRich.Invoke(respuesta);
                                    Thread.Sleep(1000);
                                    switch (rnd.Next(0, 2))
                                    {
                                        case 0://no quiero
                                            respuesta = $"{canta.Nombre}: no quiero.";
                                            this.historialPartida.AppendLine(respuesta);
                                            if (delegadoEscribirRich is not null)
                                                delegadoEscribirRich.Invoke(respuesta);
                                            leCantan.Puntos += this.listaCantosEnvido.Cantos[indiceCantoEnvido].ValorNoQuiero;
                                            break;
                                        case 1://quiero
                                            respuesta = $"{canta.Nombre}: quiero, {canta.Envido}";
                                            this.historialPartida.AppendLine(respuesta);
                                            if (delegadoEscribirRich is not null)
                                                delegadoEscribirRich.Invoke(respuesta);
                                            CompararEnvido(canta, leCantan);
                                            break;
                                    }
                                    break;
                            }
                            break;
                    }
                    break;
            }
            indiceCantoEnvido = 0;
        }

        private void CantarTruco(Jugador canta, Jugador leCantan)
        {
            //trucoooo
            string cantoRealizado = $"{canta.Nombre}: {this.listaCantosTruco.Cantos[indiceCantoTruco].CantoJugador}";
            this.historialPartida.AppendLine(cantoRealizado);
            if (delegadoEscribirRich is not null)
                delegadoEscribirRich.Invoke(cantoRealizado);

            //ahora hay que responder
            //espera la respuesta
            string respuesta = string.Empty;

            Thread.Sleep(1000);
            switch (rnd.Next(0, 3))
            {
                case 0://no quiero
                    respuesta = $"{leCantan.Nombre}: no quiero.";
                    this.historialPartida.AppendLine(respuesta);
                    if (delegadoEscribirRich is not null)
                        delegadoEscribirRich.Invoke(respuesta);
                    canta.Puntos += this.listaCantosTruco.Cantos[indiceCantoTruco].ValorNoQuiero;
                    break;
                case 1://quiero
                    respuesta = $"{leCantan.Nombre}: quiero";
                    this.historialPartida.AppendLine(respuesta);
                    if (delegadoEscribirRich is not null)
                        delegadoEscribirRich.Invoke(respuesta);
                    puntosTruco = this.listaCantosTruco.Cantos[indiceCantoTruco].ValorQuiero;
                    break;
                case 2://retrucooooooo
                    indiceCantoTruco++;
                    respuesta = $"{leCantan.Nombre}: {listaCantosTruco.Cantos[indiceCantoTruco].CantoJugador}";
                    this.historialPartida.AppendLine(respuesta);
                    if (delegadoEscribirRich is not null)
                        delegadoEscribirRich.Invoke(respuesta);
                    Thread.Sleep(1000);
                    switch (rnd.Next(0, 3))
                    {
                        case 0://no quiero
                            respuesta = $"{canta.Nombre}: no quiero.";
                            this.historialPartida.AppendLine(respuesta);
                            if (delegadoEscribirRich is not null)
                                delegadoEscribirRich.Invoke(respuesta);
                            leCantan.Puntos += this.listaCantosTruco.Cantos[indiceCantoTruco].ValorNoQuiero;
                            break;
                        case 1://quiero
                            respuesta = $"{canta.Nombre}: quiero";
                            this.historialPartida.AppendLine(respuesta);
                            if (delegadoEscribirRich is not null)
                                delegadoEscribirRich.Invoke(respuesta);
                            puntosTruco = this.listaCantosTruco.Cantos[indiceCantoTruco].ValorQuiero;
                            break;
                        case 2://vale 4!
                            indiceCantoTruco++;
                            respuesta = $"{canta.Nombre}: {listaCantosTruco.Cantos[indiceCantoTruco].CantoJugador}";
                            this.historialPartida.AppendLine(respuesta);
                            if (delegadoEscribirRich is not null)
                                delegadoEscribirRich.Invoke(respuesta);
                            Thread.Sleep(1000);
                            switch (rnd.Next(0, 2))
                            {
                                case 0://no quiero
                                    respuesta = $"{leCantan.Nombre}: no quiero.";
                                    this.historialPartida.AppendLine(respuesta);
                                    if (delegadoEscribirRich is not null)
                                        delegadoEscribirRich.Invoke(respuesta);
                                    canta.Puntos += this.listaCantosTruco.Cantos[indiceCantoTruco].ValorNoQuiero;
                                    break;
                                case 1://quiero
                                    respuesta = $"{leCantan.Nombre}: quiero";
                                    this.historialPartida.AppendLine(respuesta);
                                    if (delegadoEscribirRich is not null)
                                        delegadoEscribirRich.Invoke(respuesta);
                                    canta.Puntos += this.listaCantosTruco.Cantos[indiceCantoTruco].ValorNoQuiero;
                                    break;
                            }
                            break;
                    }
                    break;
            }
            indiceCantoTruco = 0;
        }


        private void CompararEnvido(Jugador canta, Jugador leCantan)
        {
            string resultado = string.Empty;
            if (canta.Envido >= leCantan.Envido)
            {
                resultado = $"{leCantan.Nombre}: son buenas ...";
                if (indiceCantoEnvido != 3)
                    canta.Puntos += listaCantosEnvido.Cantos[indiceCantoEnvido].ValorQuiero;
                else
                    canta.Puntos = 15;
            }
            else
            {
                resultado = $"{leCantan.Nombre}: {leCantan.Envido} son mejores!";
                if (indiceCantoEnvido != 3)
                    leCantan.Puntos += listaCantosEnvido.Cantos[indiceCantoEnvido].ValorQuiero;
                else
                    leCantan.Puntos = 15;
            }
            historialPartida.AppendLine(resultado);
            if (delegadoEscribirRich is not null)
                delegadoEscribirRich.Invoke(resultado);
        }

        public Carta JugarCarta(Jugador jugador)
        {
            Thread.Sleep(1000);
            string jugadaRealizada = string.Empty;
            int indiceCartaElegida = rnd.Next(0, jugador.CartasEnMano.Count);
            Carta cartaElegida = jugador.CartasEnMano[indiceCartaElegida];
            jugador.CartasEnMano.RemoveAt(indiceCartaElegida);

            jugadaRealizada = $"{jugador.Nombre} juega el  {cartaElegida.ToString()}";
            this.historialPartida.AppendLine(jugadaRealizada);

            if (delegadoEscribirRich is not null)
                delegadoEscribirRich.Invoke(jugadaRealizada);

            return cartaElegida;
        }  
    }
}