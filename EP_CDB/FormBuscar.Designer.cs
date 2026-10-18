namespace EP_CDB
{
    partial class FormBuscar
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
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lbResultados = new System.Windows.Forms.ListBox();
            this.tbDatos = new System.Windows.Forms.TextBox();
            this.rbOrigen = new System.Windows.Forms.RadioButton();
            this.rbDestino = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbBusqueda = new System.Windows.Forms.GroupBox();
            this.lblResultadoBusqueda = new System.Windows.Forms.Label();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.btnBuscarCod = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbMonto = new System.Windows.Forms.TextBox();
            this.cbMMI = new System.Windows.Forms.ComboBox();
            this.btnBuscarMonto = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.btnBuscarTipo = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbEstados = new System.Windows.Forms.ComboBox();
            this.btnBuscarEstado = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.checkBoxHoy = new System.Windows.Forms.CheckBox();
            this.DTPFecha = new System.Windows.Forms.DateTimePicker();
            this.btnBuscarFecha = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.gbBusqueda.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(18, 101);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 23);
            this.btnBuscar.TabIndex = 0;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lbResultados
            // 
            this.lbResultados.FormattingEnabled = true;
            this.lbResultados.Location = new System.Drawing.Point(296, 28);
            this.lbResultados.Name = "lbResultados";
            this.lbResultados.Size = new System.Drawing.Size(468, 394);
            this.lbResultados.TabIndex = 1;
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
            this.groupBox1.Controls.Add(this.tbDatos);
            this.groupBox1.Controls.Add(this.rbDestino);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.rbOrigen);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(129, 133);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ciudad";
            // 
            // gbBusqueda
            // 
            this.gbBusqueda.Controls.Add(this.lblResultadoBusqueda);
            this.gbBusqueda.Controls.Add(this.txtBusqueda);
            this.gbBusqueda.Controls.Add(this.btnBuscarCod);
            this.gbBusqueda.Location = new System.Drawing.Point(147, 12);
            this.gbBusqueda.Name = "gbBusqueda";
            this.gbBusqueda.Size = new System.Drawing.Size(129, 133);
            this.gbBusqueda.TabIndex = 30;
            this.gbBusqueda.TabStop = false;
            this.gbBusqueda.Text = "Buscar operación";
            // 
            // lblResultadoBusqueda
            // 
            this.lblResultadoBusqueda.AutoSize = true;
            this.lblResultadoBusqueda.Location = new System.Drawing.Point(15, 39);
            this.lblResultadoBusqueda.Name = "lblResultadoBusqueda";
            this.lblResultadoBusqueda.Size = new System.Drawing.Size(91, 13);
            this.lblResultadoBusqueda.TabIndex = 19;
            this.lblResultadoBusqueda.Text = "Ingrese el código:";
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Location = new System.Drawing.Point(18, 55);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(100, 20);
            this.txtBusqueda.TabIndex = 20;
            this.txtBusqueda.Text = "(415)";
            // 
            // btnBuscarCod
            // 
            this.btnBuscarCod.Location = new System.Drawing.Point(18, 81);
            this.btnBuscarCod.Name = "btnBuscarCod";
            this.btnBuscarCod.Size = new System.Drawing.Size(100, 23);
            this.btnBuscarCod.TabIndex = 14;
            this.btnBuscarCod.Text = "Buscar";
            this.btnBuscarCod.UseVisualStyleBackColor = true;
            this.btnBuscarCod.Click += new System.EventHandler(this.btnBuscarCod_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnBuscarMonto);
            this.groupBox2.Controls.Add(this.cbMMI);
            this.groupBox2.Controls.Add(this.tbMonto);
            this.groupBox2.Location = new System.Drawing.Point(12, 151);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(129, 102);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Buscar por monto";
            // 
            // tbMonto
            // 
            this.tbMonto.Location = new System.Drawing.Point(6, 46);
            this.tbMonto.Name = "tbMonto";
            this.tbMonto.Size = new System.Drawing.Size(112, 20);
            this.tbMonto.TabIndex = 0;
            // 
            // cbMMI
            // 
            this.cbMMI.FormattingEnabled = true;
            this.cbMMI.Location = new System.Drawing.Point(6, 19);
            this.cbMMI.Name = "cbMMI";
            this.cbMMI.Size = new System.Drawing.Size(112, 21);
            this.cbMMI.TabIndex = 1;
            // 
            // btnBuscarMonto
            // 
            this.btnBuscarMonto.Location = new System.Drawing.Point(28, 70);
            this.btnBuscarMonto.Name = "btnBuscarMonto";
            this.btnBuscarMonto.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarMonto.TabIndex = 2;
            this.btnBuscarMonto.Text = "Buscar";
            this.btnBuscarMonto.UseVisualStyleBackColor = true;
            this.btnBuscarMonto.Click += new System.EventHandler(this.btnBuscarMonto_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnBuscarTipo);
            this.groupBox3.Controls.Add(this.cmbTipo);
            this.groupBox3.Location = new System.Drawing.Point(147, 151);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(129, 102);
            this.groupBox3.TabIndex = 32;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Buscar por tipo";
            // 
            // cmbTipo
            // 
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(18, 35);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(100, 21);
            this.cmbTipo.TabIndex = 10;
            // 
            // btnBuscarTipo
            // 
            this.btnBuscarTipo.Location = new System.Drawing.Point(18, 62);
            this.btnBuscarTipo.Name = "btnBuscarTipo";
            this.btnBuscarTipo.Size = new System.Drawing.Size(100, 23);
            this.btnBuscarTipo.TabIndex = 11;
            this.btnBuscarTipo.Text = "Buscar";
            this.btnBuscarTipo.UseVisualStyleBackColor = true;
            this.btnBuscarTipo.Click += new System.EventHandler(this.btnBuscarTipo_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnBuscarEstado);
            this.groupBox4.Controls.Add(this.cbEstados);
            this.groupBox4.Location = new System.Drawing.Point(12, 259);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(264, 79);
            this.groupBox4.TabIndex = 33;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Buscar por estado";
            // 
            // cbEstados
            // 
            this.cbEstados.FormattingEnabled = true;
            this.cbEstados.Location = new System.Drawing.Point(18, 36);
            this.cbEstados.Name = "cbEstados";
            this.cbEstados.Size = new System.Drawing.Size(121, 21);
            this.cbEstados.TabIndex = 0;
            // 
            // btnBuscarEstado
            // 
            this.btnBuscarEstado.Location = new System.Drawing.Point(166, 34);
            this.btnBuscarEstado.Name = "btnBuscarEstado";
            this.btnBuscarEstado.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarEstado.TabIndex = 1;
            this.btnBuscarEstado.Text = "Buscar";
            this.btnBuscarEstado.UseVisualStyleBackColor = true;
            this.btnBuscarEstado.Click += new System.EventHandler(this.btnBuscarEstado_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnBuscarFecha);
            this.groupBox5.Controls.Add(this.checkBoxHoy);
            this.groupBox5.Controls.Add(this.DTPFecha);
            this.groupBox5.Location = new System.Drawing.Point(12, 344);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(264, 79);
            this.groupBox5.TabIndex = 34;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Buscar por fecha";
            // 
            // checkBoxHoy
            // 
            this.checkBoxHoy.AutoSize = true;
            this.checkBoxHoy.Location = new System.Drawing.Point(28, 46);
            this.checkBoxHoy.Name = "checkBoxHoy";
            this.checkBoxHoy.Size = new System.Drawing.Size(45, 17);
            this.checkBoxHoy.TabIndex = 14;
            this.checkBoxHoy.Text = "Hoy";
            this.checkBoxHoy.UseVisualStyleBackColor = true;
            // 
            // DTPFecha
            // 
            this.DTPFecha.Location = new System.Drawing.Point(28, 20);
            this.DTPFecha.Name = "DTPFecha";
            this.DTPFecha.Size = new System.Drawing.Size(200, 20);
            this.DTPFecha.TabIndex = 13;
            this.DTPFecha.ValueChanged += new System.EventHandler(this.DTPFecha_ValueChanged);
            // 
            // btnBuscarFecha
            // 
            this.btnBuscarFecha.Location = new System.Drawing.Point(135, 50);
            this.btnBuscarFecha.Name = "btnBuscarFecha";
            this.btnBuscarFecha.Size = new System.Drawing.Size(93, 23);
            this.btnBuscarFecha.TabIndex = 15;
            this.btnBuscarFecha.Text = "Buscar";
            this.btnBuscarFecha.UseVisualStyleBackColor = true;
            this.btnBuscarFecha.Click += new System.EventHandler(this.btnBuscarFecha_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(293, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "Resultados de la búsqueda";
            // 
            // FormBuscar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 439);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbBusqueda);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbResultados);
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
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ListBox lbResultados;
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
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Button btnBuscarTipo;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnBuscarEstado;
        private System.Windows.Forms.ComboBox cbEstados;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnBuscarFecha;
        private System.Windows.Forms.CheckBox checkBoxHoy;
        private System.Windows.Forms.DateTimePicker DTPFecha;
        private System.Windows.Forms.Label label1;
    }
}