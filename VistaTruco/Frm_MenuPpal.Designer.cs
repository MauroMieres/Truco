namespace VistaTruco
{
    partial class Frm_MenuPpal
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
            this.rich_ppal = new System.Windows.Forms.RichTextBox();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.btn_crearPartida = new System.Windows.Forms.Button();
            this.dtg_partidasCreadas = new System.Windows.Forms.DataGridView();
            this.btn_verPartida = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_partidasCreadas)).BeginInit();
            this.SuspendLayout();
            // 
            // rich_ppal
            // 
            this.rich_ppal.Location = new System.Drawing.Point(241, 11);
            this.rich_ppal.Name = "rich_ppal";
            this.rich_ppal.Size = new System.Drawing.Size(336, 426);
            this.rich_ppal.TabIndex = 0;
            this.rich_ppal.Text = "";
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.Location = new System.Drawing.Point(364, 444);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(213, 23);
            this.btn_cancelar.TabIndex = 1;
            this.btn_cancelar.Text = "Cancelar Partida";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // btn_crearPartida
            // 
            this.btn_crearPartida.Location = new System.Drawing.Point(12, 444);
            this.btn_crearPartida.Name = "btn_crearPartida";
            this.btn_crearPartida.Size = new System.Drawing.Size(114, 23);
            this.btn_crearPartida.TabIndex = 2;
            this.btn_crearPartida.Text = "Crear Partida";
            this.btn_crearPartida.UseVisualStyleBackColor = true;
            this.btn_crearPartida.Click += new System.EventHandler(this.btn_crearPartida_Click);
            // 
            // dtg_partidasCreadas
            // 
            this.dtg_partidasCreadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_partidasCreadas.Location = new System.Drawing.Point(12, 11);
            this.dtg_partidasCreadas.Name = "dtg_partidasCreadas";
            this.dtg_partidasCreadas.RowTemplate.Height = 25;
            this.dtg_partidasCreadas.Size = new System.Drawing.Size(223, 427);
            this.dtg_partidasCreadas.TabIndex = 3;
            
            // 
            // btn_verPartida
            // 
            this.btn_verPartida.Location = new System.Drawing.Point(160, 444);
            this.btn_verPartida.Name = "btn_verPartida";
            this.btn_verPartida.Size = new System.Drawing.Size(75, 23);
            this.btn_verPartida.TabIndex = 4;
            this.btn_verPartida.Text = "Ver Partida";
            this.btn_verPartida.UseVisualStyleBackColor = true;
            this.btn_verPartida.Click += new System.EventHandler(this.btn_verPartida_Click);
            // 
            // Frm_MenuPpal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 477);
            this.Controls.Add(this.btn_verPartida);
            this.Controls.Add(this.dtg_partidasCreadas);
            this.Controls.Add(this.btn_crearPartida);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.rich_ppal);
            this.Name = "Frm_MenuPpal";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dtg_partidasCreadas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rich_ppal;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.Button btn_crearPartida;
        private System.Windows.Forms.DataGridView dtg_partidasCreadas;
        private System.Windows.Forms.Button btn_verPartida;
    }
}
