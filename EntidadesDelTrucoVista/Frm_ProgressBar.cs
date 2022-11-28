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
    public partial class Frm_ProgressBar : Form
    {

        int progreso = 0;
        public Frm_ProgressBar()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progreso += 5;
            if (progreso >= 100)
            {
                timer1.Enabled = false;
                timer1.Stop();
                progressBar.Value = 100;
                this.Hide();
                Frm_MenuPrincipal form = new Frm_MenuPrincipal();
                try
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        this.Close();
                    }
                }catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }       
                //abro el otro form
            }
            else
            {
                progressBar.Value = progreso;
            }
        }

        private void Frm_ProgressBar_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
