using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesDelTruco
{
    public class CantosDelTruco
    {
        List<CantosTruco> cantos = new List<CantosTruco>();
        public CantosDelTruco()
        {

        }

        //public CantosDelTruco(int num)
        //{
        //    CargarCantosTruco();
        //}

        //private void CargarCantosTruco()
        //{
        //    cantos.Add(new CantosTruco("Truco!", 1, 2));
        //    cantos.Add(new CantosTruco("Retruco!", 2, 3));
        //    cantos.Add(new CantosTruco("Vale 4!", 3, 4));
        //}

        public List<CantosTruco> Cantos { get => cantos; set => cantos = value; }
    }
}
