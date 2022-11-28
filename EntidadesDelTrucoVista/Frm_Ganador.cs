using EntidadesDelTruco;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntidadesDelTrucoVista
{
    public partial class Frm_Ganador : Form
    {
        static Partida partida = null;
        public Frm_Ganador()
        {
            InitializeComponent();
        }

        public Frm_Ganador(Partida partidaRecibida)
        {
            InitializeComponent();
            partida = partidaRecibida;        
        }

        private void Frm_Ganador_Load(object sender, EventArgs e)
        {
            lbl_ganador.Text = $"Ganador: {partida.Ganador.Nombre}";
            rich_partida.Text = partida.HistorialPartida.ToString();
        }
    }
}
