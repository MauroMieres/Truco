namespace EntidadesDelTrucoVista
{
    partial class Frm_MenuPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_MenuPrincipal));
            this.dtg_salas = new System.Windows.Forms.DataGridView();
            this.btn_CrearPartida = new System.Windows.Forms.Button();
            this.btn_VerPartida = new System.Windows.Forms.Button();
            this.rich_jugadas = new System.Windows.Forms.RichTextBox();
            this.btn_CancelarPartida = new System.Windows.Forms.Button();
            this.btn_on = new System.Windows.Forms.Button();
            this.btn_off = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_salas)).BeginInit();
            this.SuspendLayout();
            // 
            // dtg_salas
            // 
            this.dtg_salas.BackgroundColor = System.Drawing.Color.ForestGreen;
            this.dtg_salas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dtg_salas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_salas.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dtg_salas.Location = new System.Drawing.Point(12, 12);
            this.dtg_salas.Name = "dtg_salas";
            this.dtg_salas.RowTemplate.Height = 25;
            this.dtg_salas.Size = new System.Drawing.Size(243, 426);
            this.dtg_salas.TabIndex = 0;
            // 
            // btn_CrearPartida
            // 
            this.btn_CrearPartida.Location = new System.Drawing.Point(257, 412);
            this.btn_CrearPartida.Name = "btn_CrearPartida";
            this.btn_CrearPartida.Size = new System.Drawing.Size(85, 23);
            this.btn_CrearPartida.TabIndex = 1;
            this.btn_CrearPartida.Text = "Crear partida";
            this.btn_CrearPartida.UseVisualStyleBackColor = true;
            this.btn_CrearPartida.Click += new System.EventHandler(this.btn_CrearPartida_Click);
            // 
            // btn_VerPartida
            // 
            this.btn_VerPartida.Location = new System.Drawing.Point(257, 383);
            this.btn_VerPartida.Name = "btn_VerPartida";
            this.btn_VerPartida.Size = new System.Drawing.Size(85, 23);
            this.btn_VerPartida.TabIndex = 2;
            this.btn_VerPartida.Text = "Ver Partida";
            this.btn_VerPartida.UseVisualStyleBackColor = true;
            this.btn_VerPartida.Click += new System.EventHandler(this.btn_VerPartida_Click);
            // 
            // rich_jugadas
            // 
            this.rich_jugadas.Font = new System.Drawing.Font("Reem Kufi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rich_jugadas.Location = new System.Drawing.Point(348, 10);
            this.rich_jugadas.Name = "rich_jugadas";
            this.rich_jugadas.Size = new System.Drawing.Size(337, 426);
            this.rich_jugadas.TabIndex = 3;
            this.rich_jugadas.Text = "";
            // 
            // btn_CancelarPartida
            // 
            this.btn_CancelarPartida.Location = new System.Drawing.Point(691, 412);
            this.btn_CancelarPartida.Name = "btn_CancelarPartida";
            this.btn_CancelarPartida.Size = new System.Drawing.Size(111, 23);
            this.btn_CancelarPartida.TabIndex = 4;
            this.btn_CancelarPartida.Text = "Cancelar partida";
            this.btn_CancelarPartida.UseVisualStyleBackColor = true;
            this.btn_CancelarPartida.Click += new System.EventHandler(this.btn_CancelarPartida_Click);
            // 
            // btn_on
            // 
            this.btn_on.Location = new System.Drawing.Point(691, 10);
            this.btn_on.Name = "btn_on";
            this.btn_on.Size = new System.Drawing.Size(111, 23);
            this.btn_on.TabIndex = 5;
            this.btn_on.Text = "Activar Musica";
            this.btn_on.UseVisualStyleBackColor = true;
            this.btn_on.Click += new System.EventHandler(this.btn_on_Click);
            // 
            // btn_off
            // 
            this.btn_off.Location = new System.Drawing.Point(691, 10);
            this.btn_off.Name = "btn_off";
            this.btn_off.Size = new System.Drawing.Size(115, 23);
            this.btn_off.TabIndex = 6;
            this.btn_off.Text = "Desactivar Musica";
            this.btn_off.UseVisualStyleBackColor = true;
            this.btn_off.Click += new System.EventHandler(this.btn_off_Click);
            // 
            // Frm_MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(810, 447);
            this.Controls.Add(this.btn_off);
            this.Controls.Add(this.btn_on);
            this.Controls.Add(this.btn_CancelarPartida);
            this.Controls.Add(this.rich_jugadas);
            this.Controls.Add(this.btn_VerPartida);
            this.Controls.Add(this.btn_CrearPartida);
            this.Controls.Add(this.dtg_salas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_MenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Truco Argentino";
            this.TransparencyKey = System.Drawing.SystemColors.ActiveCaption;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_MenuPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_salas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtg_salas;
        private System.Windows.Forms.Button btn_CrearPartida;
        private System.Windows.Forms.Button btn_VerPartida;
        private System.Windows.Forms.RichTextBox rich_jugadas;
        private System.Windows.Forms.Button btn_CancelarPartida;
        private System.Windows.Forms.Button btn_on;
        private System.Windows.Forms.Button btn_off;
    }
}
