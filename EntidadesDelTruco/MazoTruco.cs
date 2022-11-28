using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesDelTruco
{
    public class MazoTruco
    {
        List<Carta> cartas;
        public List<Carta> Cartas { get => cartas; set => cartas = value; }

        //public MazoTruco(int num)
        //{
        //    this.cartas = crearCartas();
        //}

        public MazoTruco()
        {

        }

        public void Mezclar()
        {
            Random r = new Random();
            List<Carta> cartasDelMazo = cartas;
            for (int n = cartasDelMazo.Count - 1; n > 0; --n)
            {
                int k = r.Next(n + 1);
                Carta aux = cartasDelMazo[n];
                cartasDelMazo[n] = cartasDelMazo[k];
                cartasDelMazo[k] = aux;
            }
        }
        
        //private List<Carta> crearCartas()
        //{
        //    List<Carta> auxCartas = new List<Carta>();

        //    //creo de mas a menos importante
        //    auxCartas.Add(new Carta(EPalo.Espada, 1, 14));
        //    auxCartas.Add(new Carta(EPalo.Basto, 1, 13));
        //    auxCartas.Add(new Carta(EPalo.Espada, 7, 12));
        //    auxCartas.Add(new Carta(EPalo.Oro, 7, 11));

        //    //creo el resto de las cartas excluyendo las anteriores
        //    foreach (EPalo palo in Enum.GetValues(typeof(EPalo)))
        //    {
        //        for (int i = 12; i >= 1; i--)
        //        {
        //            switch (i)
        //            {
        //                case 12:
        //                    auxCartas.Add(new Carta(palo, i, 7));
        //                    break;

        //                case 11:
        //                    auxCartas.Add(new Carta(palo, i, 6));
        //                    break;

        //                case 10:
        //                    auxCartas.Add(new Carta(palo, i, 5));
        //                    break;

        //                case 8:
        //                case 9:
        //                    break;

        //                case 7:
        //                    if (palo == EPalo.Espada || palo == EPalo.Oro)
        //                        break;
        //                    auxCartas.Add(new Carta(palo, i, 4));
        //                    break;

        //                case 6:
        //                    auxCartas.Add(new Carta(palo, i, 3));
        //                    break;

        //                case 5:
        //                    auxCartas.Add(new Carta(palo, i, 2));
        //                    break;

        //                case 4:
        //                    auxCartas.Add(new Carta(palo, i, 1));
        //                    break;

        //                case 3:
        //                    auxCartas.Add(new Carta(palo, i, 9));
        //                    break;
        //                case 2:
        //                    auxCartas.Add(new Carta(palo, i, 8));
        //                    break;

        //                case 1:
        //                    if (palo == EPalo.Espada || palo == EPalo.Basto)
        //                        break;
        //                    auxCartas.Add(new Carta(palo, i, 8));
        //                    break;
        //            }
        //        }
        //    }
        //    return auxCartas;
        //}

        public void Dar3Cartas(Jugador jugador)
        {
            do
            {
                jugador.CartasEnMano.Add(this.Cartas[0]);
                this.cartas.RemoveAt(0);
            } while (jugador.CartasEnMano.Count < 3);//hasta q el pie tenga 3 cartas
        }
    }
}
