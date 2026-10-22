using EP_CDB.CajaArequipa.Estructuras;
using EP_CDB.CajaArequipa.Modelos;
using EP_CDB.CajaArequipa.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace EP_CDB
{
    public partial class Form1 : Form
    {
        private ProcesadorTransacciones procesador;
        public Form1()
        {
            InitializeComponent();
            procesador = new ProcesadorTransacciones();
            cmbTipo.Items.Clear();
            cmbTipo.Items.Add("Abono");
            cmbTipo.Items.Add("Retiro");
            cmbTipo.Items.Add("Transferencia");
            cmbTipo.SelectedIndex = 0;
            dgvOperaciones.AutoGenerateColumns = false;
            dgvOperaciones.ReadOnly = true;
            dgvOperaciones.Columns.Clear();
            dgvOperaciones.Columns.Add("Codigo", "Código");// agregamos las columnas al dgv
            dgvOperaciones.Columns.Add("Origen", "Origen");
            dgvOperaciones.Columns.Add("Destino", "Destino");
            dgvOperaciones.Columns.Add("Monto", "Monto");
            dgvOperaciones.Columns.Add("Tipo", "Tipo");
            dgvOperaciones.Columns.Add("Estado", "Estado");
            dgvOperaciones.Columns.Add("Fecha", "Fecha");

            procesador.elGrafo.AgregarRuta("Arequipa", "Lima", true);//precargamos el grafo con ciudades y conexiones de rutas
            procesador.elGrafo.AgregarRuta("Arequipa", "Cuzco", false);
            procesador.elGrafo.AgregarRuta("Cuzco", "Puno", true);
            procesador.elGrafo.AgregarRuta("Lima", "Puno", false);
            procesador.elGrafo.AgregarRuta("Lima", "Ica", true);
            procesador.elGrafo.AgregarRuta("Cajamarca", "Lima", true);
            procesador.elGrafo.AgregarRuta("Cajamarca", "Piura", false);
            procesador.elGrafo.AgregarRuta("Arequipa", "Cuzco", false);
            procesador.elGrafo.AgregarRuta("Cuzco", "Puno", true);
        }
        private Transaccion CrearTransaccionDesdeFormulario()
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text.Trim()))
            {
                MessageBox.Show("Ingrese el código de la operación.");
                return null;
            }
            if (procesador.buscar(txtCodigo.Text.Trim()) != null)
            {
                MessageBox.Show("El código de operación ya existe.");
                return null;
            }
            if (!double.TryParse(txtMonto.Text,out double monto))
            {
                MessageBox.Show("Ingrese un monto válido.");
                return null;
            }
            if (monto <= 0)
            {
                MessageBox.Show("El monto debe ser mayor que cero.");
                return null;
            }
            if (string.IsNullOrWhiteSpace(txtOrigen.Text))
            {
                MessageBox.Show("Ingrese la agencia de origen.");
                return null;
            }
            if (string.IsNullOrWhiteSpace(txtDestino.Text))
            {
                MessageBox.Show("Ingrese la agencia de destino.");
                return null;
            }
            TipoTransaccion tipo;
            if (cmbTipo.SelectedIndex == 0) tipo = TipoTransaccion.Abono;
            else if (cmbTipo.SelectedIndex == 1) tipo = TipoTransaccion.Retiro;
            else tipo = TipoTransaccion.Transferencia;

            DateTime fecha;
            if (checkBoxHoy.Checked)
            {
                fecha = DateTime.Now;
            }
            else
            {
                fecha = DTPFecha.Value;
            }
            procesador.elGrafo.AgregarRuta(txtOrigen.Text.Trim(), txtDestino.Text.Trim(), false);
            return new Transaccion(txtCodigo.Text.Trim(),txtOrigen.Text.Trim(),txtDestino.Text.Trim(),monto,tipo,
                EstadoTransaccion.Pendiente,fecha);
        }

        private void btnEncolar_Click(object sender, EventArgs e)
        {
            Transaccion nuevatransaccion = CrearTransaccionDesdeFormulario();
            if (nuevatransaccion == null) return;
            procesador.recibirTransaccion(nuevatransaccion);
            txtCodigo.Clear();
            txtMonto.Clear();
            txtOrigen.Clear();
            txtDestino.Clear();
            cmbTipo.SelectedIndex = 0;
            txtCodigo.Focus();
            ActualizarInterfaz();
            MessageBox.Show($"Operación {nuevatransaccion.Codigo} " + $"agregada a la cola.");
        }
        public void ActualizarInterfaz()
        {
            //actualizamos la listbox de la cola
            lstCola.Items.Clear();
            foreach (Transaccion t in procesador.laCola)
            {
                lstCola.Items.Add(t.ToString());
            }
            //actualizamos la listbox de la pila
            lstPila.Items.Clear();
            foreach (Transaccion t in procesador.laPila)
            {
                lstPila.Items.Add(t.ToString());
            }
            //actualizamos el dtg de las estadisticas
            dgvOperaciones.Rows.Clear();
            foreach (Transaccion t in procesador.elArbol)
            {
                dgvOperaciones.Rows.Add(t.Codigo, t.Origen, t.Destino,
                    $"S/ {t.Monto:N2}", t.Tipo, t.Estado, t.Fecha);
            }
            //actualizamos los labels de estadisticas
            lblRecibidas.Text = $"Recibidas: {procesador.totalRecibidas}";
            lblProcesadas.Text = $"Procesadas: {procesador.totalProcesadas}";
            lblPendientes.Text = $"Pendientes: {procesador.getPendientes()}";
            lblRevertidas.Text = $"Revertidas: {procesador.totalControlZ}";
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            Transaccion t = procesador.procesarSiguiente();
            if (t == null)
            {
                MessageBox.Show("No existen operaciones pendientes.");
                return;
            }
            ActualizarInterfaz();
        }

        private void btnProcesarTodo_Click(object sender, EventArgs e)
        {
            int cantidad = procesador.hacerTodo();
            ActualizarInterfaz();
            MessageBox.Show($"Procesamiento completado.\n\n" + $"Operaciones procesadas: {cantidad}");
        }
        private string generarCodigoUnico(Random random)
        {
            string codigo;
            do
            {
                codigo = "(415)" + random.Next(10000, 999999).ToString();
            }
            while (procesador.buscar(codigo) != null);
            return codigo;
        }
        private void btnRevertir_Click(object sender, EventArgs e)
        {
            Transaccion t = procesador.controlZ_ultimaOperacion();
            if (t == null)
            {
                MessageBox.Show("No existen operaciones para revertir.");
                return;
            }
            ActualizarInterfaz();
            MessageBox.Show($"Operación revertida.\n\n" + $"Código: {t.Codigo}\n" +
                $"Monto: S/ {t.Monto:N2}\n" + $"Estado: {t.Estado}");
        }
        private void btnSimularPico_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Está a punto de simular 10 000 operaciones en unos milisegundos." +
                " ¿Deseas continuar?","Simulación de pico",
                MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                Stopwatch reloj = new Stopwatch();
                Random random = new Random();
                DateTime ahora = DateTime.Now;
                List<string> agencias = procesador.elGrafo.obtenerCiudades();
                reloj.Start();
                for (int i = 1; i <= 10000; i++) //aqui empezamos la simulacion
                {
                    string codigo = generarCodigoUnico(random);
                    string origen = null;
                    string destino = null;
                    do
                    {
                        origen = agencias[random.Next(agencias.Count)];
                        destino = agencias[random.Next(agencias.Count)];
                    } while (origen == destino);
                    double monto = random.Next(10, 5001);
                    TipoTransaccion tipo = (TipoTransaccion)random.Next(0, 3);
                    Transaccion transaccion = new Transaccion(codigo,origen, destino,monto,tipo, EstadoTransaccion.Pendiente, ahora);
                    procesador.recibirTransaccion(transaccion);
                }
                int procesadas = procesador.hacerTodo();
                reloj.Stop();
                ActualizarInterfaz();
                int pendientes = procesador.getPendientes();
                MessageBox.Show(
                    $"SIMULACIÓN DE PICO COMPLETADA\n\n" + $"Operaciones generadas: {10000:N0}\n" +
                    $"Operaciones procesadas: {procesadas:N0}\n" + $"Operaciones pendientes: {pendientes:N0}\n" +
                    $"Tiempo total: {reloj.ElapsedMilliseconds:N0} ms", "Resultado de la simulación",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("Simulación cancelada.");
        }
        private void grafoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGrafo fg = new FormGrafo(procesador, this);
            fg.ShowDialog();
        }
        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBuscar fb = new FormBuscar(procesador);
            fb.ShowDialog();
        }
        private void DTPFecha_ValueChanged(object sender, EventArgs e)
        {
            checkBoxHoy.Checked = false;
        }
        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Estructura de Datos (2026 - 2)" +$"\nChristopher Diaz Bacon");
        }
    }
}