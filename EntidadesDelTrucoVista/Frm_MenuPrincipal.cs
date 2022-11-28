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
using System.Media;

namespace EntidadesDelTrucoVista
{
    public partial class Frm_MenuPrincipal : Form
    {
        static Sala ultimaSalaSeleccionada = null;
        static SoundPlayer reproductor = null;
        static string rutaSp = null;
        public Action<Partida> huboGanador;

        public void MostrarFormularioGanador(Partida partida)
        {
            Frm_Ganador ganador = new Frm_Ganador(partida);
            ganador.ShowDialog();
        }

        public Frm_MenuPrincipal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dtg_salas.DataSource = null;
            rutaSp = Serializadora<MazoTruco>.GetDireccionSolucion().FullName;
            reproductor = new SoundPlayer(rutaSp + "\\musica.wav");
            reproductor.PlayLooping();
            btn_on.Visible = false;
            btn_VerPartida.Visible = false;
            btn_CancelarPartida.Visible = false;
        }

        private void btn_CrearPartida_Click(object sender, EventArgs e)
        {
            Sistema.CrearSala(MostrarFormularioGanador);
            ActualizarDataGrid();
            btn_VerPartida.Visible = true;
            btn_CancelarPartida.Visible = true;
        }

        private void ActualizarDataGrid()
        {
            dtg_salas.DataSource = null;
            dtg_salas.DataSource = Sistema.SalasCreadas;
            this.dtg_salas.Columns["Partida"].Visible = false;
            this.dtg_salas.Columns["SeCanceloLaPartida"].Visible = false;
        }

        public void ActualizarRich(string texto)
        {
            if (this.rich_jugadas.InvokeRequired)
            {
                this.rich_jugadas.BeginInvoke((MethodInvoker)delegate ()
                {
                    rich_jugadas.AppendText("\r\n" + texto);
                });
            }
            else
            {
                rich_jugadas.AppendText("\r\n" + texto);
            }
        }

        private void btn_VerPartida_Click(object sender, EventArgs e)
        {
            rich_jugadas.Clear();
            Sala salaSeleccionada = GetSalaSeleccionada();
            if (salaSeleccionada is not null)
            {
                if (salaSeleccionada.Partida.Status == TaskStatus.Running)
                {
                    rich_jugadas.Text = salaSeleccionada.GetPartidaSala().HistorialPartida.ToString();
                    salaSeleccionada.GetPartidaSala().SuscribirDelegadoRich(ActualizarRich);
                }
                else
                {
                    if (salaSeleccionada.SeCanceloLaPartida)
                    {
                        rich_jugadas.Text = "Esta partida fue cancelada y no se guardo su historial";
                    }
                    else
                    {
                        rich_jugadas.Text = salaSeleccionada.GetPartidaSala().HistorialPartida.ToString();
                    }
                }
            }
            else
            {
                throw new Exception("Sala seleccionada fue null");
            }
        }

        private Sala GetSalaSeleccionada()
        {
            if (dtg_salas.CurrentRow.DataBoundItem is not null)
            {
                Sala salaSeleccionada;
                if (ultimaSalaSeleccionada is null)
                {
                    ultimaSalaSeleccionada = (Sala)dtg_salas.CurrentRow.DataBoundItem;
                    salaSeleccionada = ultimaSalaSeleccionada;
                }
                else
                {
                    if (ultimaSalaSeleccionada != (Sala)dtg_salas.CurrentRow.DataBoundItem)
                    {
                        ultimaSalaSeleccionada.GetPartidaSala().DesuscribirDelegadoRich(ActualizarRich);
                        ultimaSalaSeleccionada = (Sala)dtg_salas.CurrentRow.DataBoundItem;
                        salaSeleccionada = (Sala)dtg_salas.CurrentRow.DataBoundItem;
                    }
                    else
                    {
                        salaSeleccionada = ultimaSalaSeleccionada;
                    }
                }
                return salaSeleccionada;
            }
            return null;
        }

        private void btn_CancelarPartida_Click(object sender, EventArgs e)
        {
            if (dtg_salas.CurrentRow.DataBoundItem is not null)
            {
                Sala aux = (Sala)dtg_salas.CurrentRow.DataBoundItem;
                aux.CancelarPartida();
                MessageBox.Show("La partida se cancelara al terminar este turno");
            }
        }

        private void btn_on_Click(object sender, EventArgs e)
        {
            reproductor.PlayLooping();
            btn_on.Visible = false;
            btn_off.Visible = true;
        }

        private void btn_off_Click(object sender, EventArgs e)
        {
            reproductor.Stop();
            btn_on.Visible = true;
            btn_off.Visible = false;
        }

        private void Frm_MenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
