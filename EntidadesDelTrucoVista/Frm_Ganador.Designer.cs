namespace EntidadesDelTrucoVista
{
    partial class Frm_Ganador
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Ganador));
            this.rich_partida = new System.Windows.Forms.RichTextBox();
            this.lbl_ganador = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rich_partida
            // 
            this.rich_partida.Location = new System.Drawing.Point(12, 12);
            this.rich_partida.Name = "rich_partida";
            this.rich_partida.Size = new System.Drawing.Size(365, 426);
            this.rich_partida.TabIndex = 0;
            this.rich_partida.Text = "";
            // 
            // lbl_ganador
            // 
            this.lbl_ganador.AutoSize = true;
            this.lbl_ganador.Location = new System.Drawing.Point(12, 458);
            this.lbl_ganador.Name = "lbl_ganador";
            this.lbl_ganador.Size = new System.Drawing.Size(0, 15);
            this.lbl_ganador.TabIndex = 1;
            // 
            // Frm_Ganador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(481, 489);
            this.Controls.Add(this.lbl_ganador);
            this.Controls.Add(this.rich_partida);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Ganador";
            this.Text = "Frm_Ganador";
            this.Load += new System.EventHandler(this.Frm_Ganador_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rich_partida;
        private System.Windows.Forms.Label lbl_ganador;
    }
}