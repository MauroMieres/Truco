using EntidadesDelTruco;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VistaTruco
{
    public partial class Frm_MenuPpal : Form
    {
        List<Partida> partidasCreadas;
        static CancellationTokenSource cts;
        private CancellationTokenSource ct;

        public static CancellationTokenSource Cts
        {

            get
            {
                if (cts is null || cts.IsCancellationRequested)
                {
                    cts = new CancellationTokenSource();
                }

                return cts;
            }

        }
        public Frm_MenuPpal()
        {
            InitializeComponent();
            partidasCreadas = new List<Partida>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

  

        private void CrearPartida()
        {
            Partida nuevaPartida = new Partida(ActualizarRich);
            ActualizarDataGrid(nuevaPartida);
            while (!nuevaPartida.GetAlguienGano())//se cancela dentro de la partida por token
            {
                nuevaPartida.JugarPartida();
            }
        }

        public void ActualizarDataGrid(Partida partida)
        {
            if (this.dtg_partidasCreadas.InvokeRequired)
            {
                this.rich_ppal.BeginInvoke((MethodInvoker)delegate ()
                {
                    dtg_partidasCreadas.DataSource = null;
                    partidasCreadas.Add(partida);
                    dtg_partidasCreadas.DataSource = partidasCreadas;
                });
            }
            else
            {
                dtg_partidasCreadas.DataSource = partidasCreadas;
            }
        }

        public void ActualizarRich(string texto)
        {
            if (this.rich_ppal.InvokeRequired)
            {
                this.rich_ppal.BeginInvoke((MethodInvoker)delegate ()
                {
                    rich_ppal.AppendText("\r\n" + texto);
                });
            }
            else
            {
                rich_ppal.AppendText("\r\n" + texto);
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Se perderan todos los datos de la misma", "Seguro quiere cancelar esta partida?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                ((Partida)dtg_partidasCreadas.CurrentRow.DataBoundItem).CancelarPartida();
                partidasCreadas.Remove((Partida)dtg_partidasCreadas.CurrentRow.DataBoundItem);
                dtg_partidasCreadas.DataSource = null;
                dtg_partidasCreadas.DataSource = partidasCreadas;
                rich_ppal.Text = "Partida Cancelada, eliga otra para ver su historial.";
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }      
        }

        private void btn_crearPartida_Click(object sender, EventArgs e)
        {
            Task.Run(() => CrearPartida());
        }

        //private void btn_ver_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        MostrarPartidaElegida();
        //    }
        //    catch (NullReferenceException ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void MostrarPartidaElegida()
        {
            Partida partidaSeleccionada = (Partida)dtg_partidasCreadas.CurrentRow.DataBoundItem;
            this.rich_ppal.Text = string.Empty;
            partidasCreadas.ForEach((x) => x.NullearDelegados());
            if (!partidaSeleccionada.GetAlguienGano())
            {
                partidaSeleccionada.SuscribirDelegados(ActualizarRich);
            }
            else
            {
                // si alguien ya gano o si se cancelo la partida

                this.rich_ppal.Text = partidaSeleccionada.GetHistorial();
            }
        }

        private void btn_verPartida_Click(object sender, EventArgs e)
        {

        }
    }
}
