namespace EP_CDB
{
    partial class FormGrafo
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
            this.lblTituloGrafo = new System.Windows.Forms.Label();
            this.cbAgenciaGrafo = new System.Windows.Forms.ComboBox();
            this.btnConsultaRutas = new System.Windows.Forms.Button();
            this.btnAlternarConexion = new System.Windows.Forms.Button();
            this.lstRutasGrafo = new System.Windows.Forms.ListBox();
            this.btnVerTodasRutas = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.crearRutaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTituloGrafo
            // 
            this.lblTituloGrafo.AutoSize = true;
            this.lblTituloGrafo.Location = new System.Drawing.Point(9, 33);
            this.lblTituloGrafo.Name = "lblTituloGrafo";
            this.lblTituloGrafo.Size = new System.Drawing.Size(120, 13);
            this.lblTituloGrafo.TabIndex = 0;
            this.lblTituloGrafo.Text = "Rutas de sincronizacion";
            // 
            // cmbAgenciaGrafo
            // 
            this.cbAgenciaGrafo.FormattingEnabled = true;
            this.cbAgenciaGrafo.Location = new System.Drawing.Point(12, 49);
            this.cbAgenciaGrafo.Name = "cmbAgenciaGrafo";
            this.cbAgenciaGrafo.Size = new System.Drawing.Size(121, 21);
            this.cbAgenciaGrafo.TabIndex = 1;
            // 
            // btnConsultaRutas
            // 
            this.btnConsultaRutas.Location = new System.Drawing.Point(12, 76);
            this.btnConsultaRutas.Name = "btnConsultaRutas";
            this.btnConsultaRutas.Size = new System.Drawing.Size(110, 23);
            this.btnConsultaRutas.TabIndex = 2;
            this.btnConsultaRutas.Text = "Consultar rutas";
            this.btnConsultaRutas.UseVisualStyleBackColor = true;
            this.btnConsultaRutas.Click += new System.EventHandler(this.btnConsultaRutas_Click);
            // 
            // btnAlternarConexion
            // 
            this.btnAlternarConexion.Location = new System.Drawing.Point(166, 33);
            this.btnAlternarConexion.Name = "btnAlternarConexion";
            this.btnAlternarConexion.Size = new System.Drawing.Size(77, 66);
            this.btnAlternarConexion.TabIndex = 3;
            this.btnAlternarConexion.Text = "Cambiar conectividad";
            this.btnAlternarConexion.UseVisualStyleBackColor = true;
            this.btnAlternarConexion.Click += new System.EventHandler(this.btnAlternarConexion_Click);
            // 
            // lstRutasGrafo
            // 
            this.lstRutasGrafo.FormattingEnabled = true;
            this.lstRutasGrafo.Location = new System.Drawing.Point(12, 114);
            this.lstRutasGrafo.Name = "lstRutasGrafo";
            this.lstRutasGrafo.Size = new System.Drawing.Size(231, 277);
            this.lstRutasGrafo.TabIndex = 4;
            // 
            // btnVerTodasRutas
            // 
            this.btnVerTodasRutas.Location = new System.Drawing.Point(12, 397);
            this.btnVerTodasRutas.Name = "btnVerTodasRutas";
            this.btnVerTodasRutas.Size = new System.Drawing.Size(231, 23);
            this.btnVerTodasRutas.TabIndex = 5;
            this.btnVerTodasRutas.Text = "Ver todas las rutas";
            this.btnVerTodasRutas.UseVisualStyleBackColor = true;
            this.btnVerTodasRutas.Click += new System.EventHandler(this.btnVerTodasRutas_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crearRutaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(255, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // crearRutaToolStripMenuItem
            // 
            this.crearRutaToolStripMenuItem.Name = "crearRutaToolStripMenuItem";
            this.crearRutaToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
            this.crearRutaToolStripMenuItem.Text = "Crear ruta nueva";
            this.crearRutaToolStripMenuItem.Click += new System.EventHandler(this.crearRutaToolStripMenuItem_Click);
            // 
            // FormGrafo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 427);
            this.Controls.Add(this.btnVerTodasRutas);
            this.Controls.Add(this.lstRutasGrafo);
            this.Controls.Add(this.btnAlternarConexion);
            this.Controls.Add(this.btnConsultaRutas);
            this.Controls.Add(this.cbAgenciaGrafo);
            this.Controls.Add(this.lblTituloGrafo);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormGrafo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultar rutas";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTituloGrafo;
        private System.Windows.Forms.ComboBox cbAgenciaGrafo;
        private System.Windows.Forms.Button btnConsultaRutas;
        private System.Windows.Forms.Button btnAlternarConexion;
        private System.Windows.Forms.ListBox lstRutasGrafo;
        private System.Windows.Forms.Button btnVerTodasRutas;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem crearRutaToolStripMenuItem;
    }
}