using System;

namespace EntidadesDelTruco
{
    public enum EPalo
    {
        Basto, Copa, Espada, Oro
    }

    public class Carta
    {
        private EPalo palo;
        private int numero;
        private int valorTruco;
        private int valorEnvido;

        public Carta()
        {

        }

        public Carta(EPalo palo, int numero, int valorTruco)
        {
            this.palo = palo;
            this.numero = numero;
            this.valorTruco = valorTruco;

            switch (numero)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                    valorEnvido = numero;
                    break;
                case 10:
                case 11:
                case 12:
                    valorEnvido = 0;
                    break;
            }
        }

        public EPalo Palo { get => palo; set => palo = value; }
        public int Numero { get => numero; set => numero = value; }
        public int ValorTruco { get => valorTruco; set => valorTruco = value; }
        public int ValorEnvido { get => valorEnvido; set => valorEnvido = value; }

        public override string ToString()
        {
            return $"{numero} de {palo}";
        }
    }
}
