namespace EP_CDB
{
    partial class FormBusqueda
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
            this.tbDatos = new System.Windows.Forms.TextBox();
            this.rbOrigen = new System.Windows.Forms.RadioButton();
            this.rbDestino = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbBusqueda = new System.Windows.Forms.GroupBox();
            this.lblResultadoBusqueda = new System.Windows.Forms.Label();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.btnBuscarCod = new System.Windows.Forms.Button();
            this.checkBoxIgnorar = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBuscarMonto = new System.Windows.Forms.Button();
            this.cbMMI = new System.Windows.Forms.ComboBox();
            this.tbMonto = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbEstados = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.DTPFecha = new System.Windows.Forms.DateTimePicker();
            this.lbResultados = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.reiniciarFiltrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBuscarCiudad = new System.Windows.Forms.Button();
            this.dgvOperaciones = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.gbBusqueda.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // tbDatos
            // 
            this.tbDatos.Location = new System.Drawing.Point(18, 29);
            this.tbDatos.Name = "tbDatos";
            this.tbDatos.Size = new System.Drawing.Size(100, 20);
            this.tbDatos.TabIndex = 2;
            // 
            // rbOrigen
            // 
            this.rbOrigen.AutoSize = true;
            this.rbOrigen.Location = new System.Drawing.Point(18, 55);
            this.rbOrigen.Name = "rbOrigen";
            this.rbOrigen.Size = new System.Drawing.Size(56, 17);
            this.rbOrigen.TabIndex = 3;
            this.rbOrigen.TabStop = true;
            this.rbOrigen.Text = "Origen";
            this.rbOrigen.UseVisualStyleBackColor = true;
            // 
            // rbDestino
            // 
            this.rbDestino.AutoSize = true;
            this.rbDestino.Location = new System.Drawing.Point(18, 78);
            this.rbDestino.Name = "rbDestino";
            this.rbDestino.Size = new System.Drawing.Size(61, 17);
            this.rbDestino.TabIndex = 4;
            this.rbDestino.TabStop = true;
            this.rbDestino.Text = "Destino";
            this.rbDestino.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBuscarCiudad);
            this.groupBox1.Controls.Add(this.tbDatos);
            this.groupBox1.Controls.Add(this.rbDestino);
            this.groupBox1.Controls.Add(this.rbOrigen);
            this.groupBox1.Location = new System.Drawing.Point(14, 84);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(129, 134);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ingresar ciudad";
            // 
            // gbBusqueda
            // 
            this.gbBusqueda.Controls.Add(this.checkBoxIgnorar);
            this.gbBusqueda.Controls.Add(this.lblResultadoBusqueda);
            this.gbBusqueda.Controls.Add(this.txtBusqueda);
            this.gbBusqueda.Controls.Add(this.btnBuscarCod);
            this.gbBusqueda.Location = new System.Drawing.Point(14, 289);
            this.gbBusqueda.Name = "gbBusqueda";
            this.gbBusqueda.Size = new System.Drawing.Size(264, 108);
            this.gbBusqueda.TabIndex = 30;
            this.gbBusqueda.TabStop = false;
            this.gbBusqueda.Text = "Buscar operación";
            // 
            // lblResultadoBusqueda
            // 
            this.lblResultadoBusqueda.AutoSize = true;
            this.lblResultadoBusqueda.Location = new System.Drawing.Point(15, 28);
            this.lblResultadoBusqueda.Name = "lblResultadoBusqueda";
            this.lblResultadoBusqueda.Size = new System.Drawing.Size(91, 13);
            this.lblResultadoBusqueda.TabIndex = 19;
            this.lblResultadoBusqueda.Text = "Ingrese el código:";
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Location = new System.Drawing.Point(18, 44);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(100, 20);
            this.txtBusqueda.TabIndex = 20;
            this.txtBusqueda.Text = "(415)";
            // 
            // btnBuscarCod
            // 
            this.btnBuscarCod.Location = new System.Drawing.Point(77, 70);
            this.btnBuscarCod.Name = "btnBuscarCod";
            this.btnBuscarCod.Size = new System.Drawing.Size(100, 23);
            this.btnBuscarCod.TabIndex = 14;
            this.btnBuscarCod.Text = "Buscar";
            this.btnBuscarCod.UseVisualStyleBackColor = true;
            this.btnBuscarCod.Click += new System.EventHandler(this.btnBuscarCod_Click);
            // 
            // checkBoxIgnorar
            // 
            this.checkBoxIgnorar.AutoSize = true;
            this.checkBoxIgnorar.Location = new System.Drawing.Point(134, 44);
            this.checkBoxIgnorar.Name = "checkBoxIgnorar";
            this.checkBoxIgnorar.Size = new System.Drawing.Size(124, 17);
            this.checkBoxIgnorar.TabIndex = 21;
            this.checkBoxIgnorar.Text = "Buscar en todo lugar";
            this.checkBoxIgnorar.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnBuscarMonto);
            this.groupBox2.Controls.Add(this.cbMMI);
            this.groupBox2.Controls.Add(this.tbMonto);
            this.groupBox2.Location = new System.Drawing.Point(14, 224);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(264, 59);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ingresar monto";
            // 
            // btnBuscarMonto
            // 
            this.btnBuscarMonto.Location = new System.Drawing.Point(183, 16);
            this.btnBuscarMonto.Name = "btnBuscarMonto";
            this.btnBuscarMonto.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarMonto.TabIndex = 2;
            this.btnBuscarMonto.Text = "Buscar";
            this.btnBuscarMonto.UseVisualStyleBackColor = true;
            this.btnBuscarMonto.Click += new System.EventHandler(this.btnBuscarMonto_Click);
            // 
            // cbMMI
            // 
            this.cbMMI.FormattingEnabled = true;
            this.cbMMI.Location = new System.Drawing.Point(6, 19);
            this.cbMMI.Name = "cbMMI";
            this.cbMMI.Size = new System.Drawing.Size(73, 21);
            this.cbMMI.TabIndex = 1;
            // 
            // tbMonto
            // 
            this.tbMonto.Location = new System.Drawing.Point(85, 19);
            this.tbMonto.Name = "tbMonto";
            this.tbMonto.Size = new System.Drawing.Size(92, 20);
            this.tbMonto.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbTipo);
            this.groupBox3.Location = new System.Drawing.Point(149, 90);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(129, 56);
            this.groupBox3.TabIndex = 32;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ingresar tipo";
            // 
            // cbTipo
            // 
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Location = new System.Drawing.Point(6, 19);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(117, 21);
            this.cbTipo.TabIndex = 10;
            this.cbTipo.SelectedIndexChanged += new System.EventHandler(this.cbTipo_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbEstados);
            this.groupBox4.Location = new System.Drawing.Point(149, 152);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(129, 66);
            this.groupBox4.TabIndex = 33;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Ingresar estado";
            // 
            // cbEstados
            // 
            this.cbEstados.FormattingEnabled = true;
            this.cbEstados.Location = new System.Drawing.Point(6, 34);
            this.cbEstados.Name = "cbEstados";
            this.cbEstados.Size = new System.Drawing.Size(117, 21);
            this.cbEstados.TabIndex = 0;
            this.cbEstados.SelectedIndexChanged += new System.EventHandler(this.cbEstados_SelectedIndexChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.DTPFecha);
            this.groupBox5.Location = new System.Drawing.Point(14, 27);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(264, 51);
            this.groupBox5.TabIndex = 34;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Ingresar fecha";
            // 
            // DTPFecha
            // 
            this.DTPFecha.Location = new System.Drawing.Point(28, 20);
            this.DTPFecha.Name = "DTPFecha";
            this.DTPFecha.Size = new System.Drawing.Size(200, 20);
            this.DTPFecha.TabIndex = 13;
            this.DTPFecha.ValueChanged += new System.EventHandler(this.DTPFecha_ValueChanged);
            // 
            // lbResultados
            // 
            this.lbResultados.AutoSize = true;
            this.lbResultados.Location = new System.Drawing.Point(296, 14);
            this.lbResultados.Name = "lbResultados";
            this.lbResultados.Size = new System.Drawing.Size(136, 13);
            this.lbResultados.TabIndex = 35;
            this.lbResultados.Text = "Resultados de la búsqueda";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reiniciarFiltrosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1101, 24);
            this.menuStrip1.TabIndex = 36;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // reiniciarFiltrosToolStripMenuItem
            // 
            this.reiniciarFiltrosToolStripMenuItem.Name = "reiniciarFiltrosToolStripMenuItem";
            this.reiniciarFiltrosToolStripMenuItem.Size = new System.Drawing.Size(97, 20);
            this.reiniciarFiltrosToolStripMenuItem.Text = "Reiniciar filtros";
            this.reiniciarFiltrosToolStripMenuItem.Click += new System.EventHandler(this.reiniciarFiltrosToolStripMenuItem_Click);
            // 
            // btnBuscarCiudad
            // 
            this.btnBuscarCiudad.Location = new System.Drawing.Point(18, 101);
            this.btnBuscarCiudad.Name = "btnBuscarCiudad";
            this.btnBuscarCiudad.Size = new System.Drawing.Size(100, 23);
            this.btnBuscarCiudad.TabIndex = 37;
            this.btnBuscarCiudad.Text = "Buscar";
            this.btnBuscarCiudad.UseVisualStyleBackColor = true;
            this.btnBuscarCiudad.Click += new System.EventHandler(this.btnBuscarCiudad_Click);
            // 
            // dgvOperaciones
            // 
            this.dgvOperaciones.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvOperaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOperaciones.Location = new System.Drawing.Point(299, 37);
            this.dgvOperaciones.Name = "dgvOperaciones";
            this.dgvOperaciones.Size = new System.Drawing.Size(784, 369);
            this.dgvOperaciones.TabIndex = 37;
            // 
            // FormBuscar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 427);
            this.Controls.Add(this.dgvOperaciones);
            this.Controls.Add(this.lbResultados);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbBusqueda);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormBuscar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Búsqueda";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbBusqueda.ResumeLayout(false);
            this.gbBusqueda.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbDatos;
        private System.Windows.Forms.RadioButton rbOrigen;
        private System.Windows.Forms.RadioButton rbDestino;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gbBusqueda;
        private System.Windows.Forms.Label lblResultadoBusqueda;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.Button btnBuscarCod;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbMonto;
        private System.Windows.Forms.ComboBox cbMMI;
        private System.Windows.Forms.Button btnBuscarMonto;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbTipo;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cbEstados;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DateTimePicker DTPFecha;
        private System.Windows.Forms.Label lbResultados;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem reiniciarFiltrosToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBoxIgnorar;
        private System.Windows.Forms.Button btnBuscarCiudad;
        private System.Windows.Forms.DataGridView dgvOperaciones;
    }
}