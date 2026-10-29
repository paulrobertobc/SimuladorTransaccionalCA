namespace EP_CDB
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblMonto = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.lblOrigen = new System.Windows.Forms.Label();
            this.txtOrigen = new System.Windows.Forms.TextBox();
            this.lblDestino = new System.Windows.Forms.Label();
            this.txtDestino = new System.Windows.Forms.TextBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.btnEncolar = new System.Windows.Forms.Button();
            this.btnProcesar = new System.Windows.Forms.Button();
            this.btnProcesarTodo = new System.Windows.Forms.Button();
            this.btnRevertir = new System.Windows.Forms.Button();
            this.btnSimularPico = new System.Windows.Forms.Button();
            this.lstCola = new System.Windows.Forms.ListBox();
            this.lstPila = new System.Windows.Forms.ListBox();
            this.dgvOperaciones = new System.Windows.Forms.DataGridView();
            this.lblRecibidas = new System.Windows.Forms.Label();
            this.lblProcesadas = new System.Windows.Forms.Label();
            this.lblPendientes = new System.Windows.Forms.Label();
            this.lblRevertidas = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gpRegistro = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DTPFecha = new System.Windows.Forms.DateTimePicker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.grafoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gpNoti = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperaciones)).BeginInit();
            this.gpRegistro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.gpNoti.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Location = new System.Drawing.Point(26, 49);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(37, 13);
            this.lblMonto.TabIndex = 2;
            this.lblMonto.Text = "Monto";
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(72, 46);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(100, 20);
            this.txtMonto.TabIndex = 3;
            // 
            // lblOrigen
            // 
            this.lblOrigen.AutoSize = true;
            this.lblOrigen.Location = new System.Drawing.Point(21, 22);
            this.lblOrigen.Name = "lblOrigen";
            this.lblOrigen.Size = new System.Drawing.Size(38, 13);
            this.lblOrigen.TabIndex = 4;
            this.lblOrigen.Text = "Origen";
            // 
            // txtOrigen
            // 
            this.txtOrigen.Location = new System.Drawing.Point(72, 19);
            this.txtOrigen.Name = "txtOrigen";
            this.txtOrigen.Size = new System.Drawing.Size(100, 20);
            this.txtOrigen.TabIndex = 5;
            // 
            // lblDestino
            // 
            this.lblDestino.AutoSize = true;
            this.lblDestino.Location = new System.Drawing.Point(203, 22);
            this.lblDestino.Name = "lblDestino";
            this.lblDestino.Size = new System.Drawing.Size(43, 13);
            this.lblDestino.TabIndex = 6;
            this.lblDestino.Text = "Destino";
            // 
            // txtDestino
            // 
            this.txtDestino.Location = new System.Drawing.Point(254, 19);
            this.txtDestino.Name = "txtDestino";
            this.txtDestino.Size = new System.Drawing.Size(100, 20);
            this.txtDestino.TabIndex = 7;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(26, 75);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(28, 13);
            this.lblTipo.TabIndex = 8;
            this.lblTipo.Text = "Tipo";
            // 
            // cbTipo
            // 
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Location = new System.Drawing.Point(72, 72);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(100, 21);
            this.cbTipo.TabIndex = 9;
            // 
            // btnEncolar
            // 
            this.btnEncolar.Location = new System.Drawing.Point(325, 76);
            this.btnEncolar.Name = "btnEncolar";
            this.btnEncolar.Size = new System.Drawing.Size(129, 23);
            this.btnEncolar.TabIndex = 10;
            this.btnEncolar.Text = "Encolar operación";
            this.btnEncolar.UseVisualStyleBackColor = true;
            this.btnEncolar.Click += new System.EventHandler(this.btnEncolar_Click);
            // 
            // btnProcesar
            // 
            this.btnProcesar.Location = new System.Drawing.Point(12, 150);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(158, 23);
            this.btnProcesar.TabIndex = 11;
            this.btnProcesar.Text = "Procesar siguiente operación";
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // btnProcesarTodo
            // 
            this.btnProcesarTodo.Location = new System.Drawing.Point(184, 150);
            this.btnProcesarTodo.Name = "btnProcesarTodo";
            this.btnProcesarTodo.Size = new System.Drawing.Size(147, 23);
            this.btnProcesarTodo.TabIndex = 12;
            this.btnProcesarTodo.Text = "Procesar todas pendientes";
            this.btnProcesarTodo.UseVisualStyleBackColor = true;
            this.btnProcesarTodo.Click += new System.EventHandler(this.btnProcesarTodo_Click);
            // 
            // btnRevertir
            // 
            this.btnRevertir.Location = new System.Drawing.Point(354, 150);
            this.btnRevertir.Name = "btnRevertir";
            this.btnRevertir.Size = new System.Drawing.Size(137, 23);
            this.btnRevertir.TabIndex = 13;
            this.btnRevertir.Text = "Revertir la última";
            this.btnRevertir.UseVisualStyleBackColor = true;
            this.btnRevertir.Click += new System.EventHandler(this.btnRevertir_Click);
            // 
            // btnSimularPico
            // 
            this.btnSimularPico.Location = new System.Drawing.Point(1172, 80);
            this.btnSimularPico.Name = "btnSimularPico";
            this.btnSimularPico.Size = new System.Drawing.Size(90, 87);
            this.btnSimularPico.TabIndex = 15;
            this.btnSimularPico.Text = "Simular múltiples operaciones";
            this.btnSimularPico.UseVisualStyleBackColor = true;
            this.btnSimularPico.Click += new System.EventHandler(this.btnSimularPico_Click);
            // 
            // lstCola
            // 
            this.lstCola.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lstCola.FormattingEnabled = true;
            this.lstCola.Location = new System.Drawing.Point(12, 199);
            this.lstCola.Name = "lstCola";
            this.lstCola.Size = new System.Drawing.Size(479, 121);
            this.lstCola.TabIndex = 16;
            // 
            // lstPila
            // 
            this.lstPila.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lstPila.FormattingEnabled = true;
            this.lstPila.Location = new System.Drawing.Point(12, 351);
            this.lstPila.Name = "lstPila";
            this.lstPila.Size = new System.Drawing.Size(479, 121);
            this.lstPila.TabIndex = 17;
            // 
            // dgvOperaciones
            // 
            this.dgvOperaciones.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvOperaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOperaciones.Location = new System.Drawing.Point(497, 224);
            this.dgvOperaciones.Name = "dgvOperaciones";
            this.dgvOperaciones.Size = new System.Drawing.Size(765, 305);
            this.dgvOperaciones.TabIndex = 18;
            // 
            // lblRecibidas
            // 
            this.lblRecibidas.AutoSize = true;
            this.lblRecibidas.Location = new System.Drawing.Point(6, 26);
            this.lblRecibidas.Name = "lblRecibidas";
            this.lblRecibidas.Size = new System.Drawing.Size(54, 13);
            this.lblRecibidas.TabIndex = 21;
            this.lblRecibidas.Text = "Recibidas";
            // 
            // lblProcesadas
            // 
            this.lblProcesadas.AutoSize = true;
            this.lblProcesadas.Location = new System.Drawing.Point(241, 26);
            this.lblProcesadas.Name = "lblProcesadas";
            this.lblProcesadas.Size = new System.Drawing.Size(63, 13);
            this.lblProcesadas.TabIndex = 22;
            this.lblProcesadas.Text = "Procesadas";
            // 
            // lblPendientes
            // 
            this.lblPendientes.AutoSize = true;
            this.lblPendientes.Location = new System.Drawing.Point(112, 26);
            this.lblPendientes.Name = "lblPendientes";
            this.lblPendientes.Size = new System.Drawing.Size(60, 13);
            this.lblPendientes.TabIndex = 23;
            this.lblPendientes.Text = "Pendientes";
            // 
            // lblRevertidas
            // 
            this.lblRevertidas.AutoSize = true;
            this.lblRevertidas.Location = new System.Drawing.Point(370, 26);
            this.lblRevertidas.Name = "lblRevertidas";
            this.lblRevertidas.Size = new System.Drawing.Size(50, 13);
            this.lblRevertidas.TabIndex = 24;
            this.lblRevertidas.Text = "Control Z";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Pendientes:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 327);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Listas para control Z (revertir)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(494, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Procesados";
            // 
            // gpRegistro
            // 
            this.gpRegistro.Controls.Add(this.label4);
            this.gpRegistro.Controls.Add(this.DTPFecha);
            this.gpRegistro.Controls.Add(this.lblMonto);
            this.gpRegistro.Controls.Add(this.lblOrigen);
            this.gpRegistro.Controls.Add(this.txtOrigen);
            this.gpRegistro.Controls.Add(this.txtMonto);
            this.gpRegistro.Controls.Add(this.txtDestino);
            this.gpRegistro.Controls.Add(this.lblDestino);
            this.gpRegistro.Controls.Add(this.cbTipo);
            this.gpRegistro.Controls.Add(this.lblTipo);
            this.gpRegistro.Controls.Add(this.btnEncolar);
            this.gpRegistro.Location = new System.Drawing.Point(12, 36);
            this.gpRegistro.Name = "gpRegistro";
            this.gpRegistro.Size = new System.Drawing.Size(479, 108);
            this.gpRegistro.TabIndex = 28;
            this.gpRegistro.TabStop = false;
            this.gpRegistro.Text = "Nueva operacion";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(203, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Fecha";
            // 
            // DTPFecha
            // 
            this.DTPFecha.Location = new System.Drawing.Point(254, 49);
            this.DTPFecha.Name = "DTPFecha";
            this.DTPFecha.Size = new System.Drawing.Size(200, 20);
            this.DTPFecha.TabIndex = 11;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(497, 44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(669, 161);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.grafoToolStripMenuItem,
            this.buscarToolStripMenuItem,
            this.acercaDeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1279, 24);
            this.menuStrip1.TabIndex = 32;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // grafoToolStripMenuItem
            // 
            this.grafoToolStripMenuItem.Name = "grafoToolStripMenuItem";
            this.grafoToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
            this.grafoToolStripMenuItem.Text = "Consultar rutas";
            this.grafoToolStripMenuItem.Click += new System.EventHandler(this.grafoToolStripMenuItem_Click);
            // 
            // buscarToolStripMenuItem
            // 
            this.buscarToolStripMenuItem.Name = "buscarToolStripMenuItem";
            this.buscarToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.buscarToolStripMenuItem.Text = "Buscar";
            this.buscarToolStripMenuItem.Click += new System.EventHandler(this.buscarToolStripMenuItem_Click);
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.acercaDeToolStripMenuItem.Text = "Acerca de";
            this.acercaDeToolStripMenuItem.Click += new System.EventHandler(this.acercaDeToolStripMenuItem_Click);
            // 
            // gpNoti
            // 
            this.gpNoti.Controls.Add(this.lblRevertidas);
            this.gpNoti.Controls.Add(this.lblRecibidas);
            this.gpNoti.Controls.Add(this.lblPendientes);
            this.gpNoti.Controls.Add(this.lblProcesadas);
            this.gpNoti.Location = new System.Drawing.Point(12, 478);
            this.gpNoti.Name = "gpNoti";
            this.gpNoti.Size = new System.Drawing.Size(479, 51);
            this.gpNoti.TabIndex = 31;
            this.gpNoti.TabStop = false;
            this.gpNoti.Text = "Estado";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(1279, 541);
            this.Controls.Add(this.gpNoti);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.gpRegistro);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvOperaciones);
            this.Controls.Add(this.lstPila);
            this.Controls.Add(this.btnProcesarTodo);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.lstCola);
            this.Controls.Add(this.btnSimularPico);
            this.Controls.Add(this.btnRevertir);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simulador transaccional del lado del servidor de Caja Arequipa";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperaciones)).EndInit();
            this.gpRegistro.ResumeLayout(false);
            this.gpRegistro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gpNoti.ResumeLayout(false);
            this.gpNoti.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Label lblOrigen;
        private System.Windows.Forms.TextBox txtOrigen;
        private System.Windows.Forms.Label lblDestino;
        private System.Windows.Forms.TextBox txtDestino;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cbTipo;
        private System.Windows.Forms.Button btnEncolar;
        private System.Windows.Forms.Button btnProcesar;
        private System.Windows.Forms.Button btnProcesarTodo;
        private System.Windows.Forms.Button btnRevertir;
        private System.Windows.Forms.Button btnSimularPico;
        private System.Windows.Forms.ListBox lstCola;
        private System.Windows.Forms.ListBox lstPila;
        private System.Windows.Forms.DataGridView dgvOperaciones;
        private System.Windows.Forms.Label lblRecibidas;
        private System.Windows.Forms.Label lblProcesadas;
        private System.Windows.Forms.Label lblPendientes;
        private System.Windows.Forms.Label lblRevertidas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gpRegistro;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem grafoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.GroupBox gpNoti;
        private System.Windows.Forms.ToolStripMenuItem buscarToolStripMenuItem;
        private System.Windows.Forms.DateTimePicker DTPFecha;
        private System.Windows.Forms.Label label4;
    }
}

