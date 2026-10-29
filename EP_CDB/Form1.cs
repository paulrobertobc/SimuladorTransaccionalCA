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
        private Procesador elProcesador;
        Random random = new Random();
        public Form1()
        {
            InitializeComponent();
            elProcesador = new Procesador();
            cbTipo.Items.Clear();
            cbTipo.Items.Add("Abono");
            cbTipo.Items.Add("Retiro");
            cbTipo.Items.Add("Transferencia");
            cbTipo.SelectedIndex = -1;
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
            elProcesador.elGrafo.agregarRuta("Arequipa", "Lima", true);//precargamos el grafo con ciudades y conexiones de rutas
            elProcesador.elGrafo.agregarRuta("Arequipa", "Cuzco", false);
            elProcesador.elGrafo.agregarRuta("Cuzco", "Puno", true);
            elProcesador.elGrafo.agregarRuta("Lima", "Puno", false);
            elProcesador.elGrafo.agregarRuta("Lima", "Ica", true);
            elProcesador.elGrafo.agregarRuta("Cajamarca", "Lima", true);
            elProcesador.elGrafo.agregarRuta("Cajamarca", "Piura", false);
            elProcesador.elGrafo.agregarRuta("Arequipa", "Cuzco", false);
            elProcesador.elGrafo.agregarRuta("Cuzco", "Puno", true);
        }
        private void btnEncolar_Click(object sender, EventArgs e)
        {
            Transaccion nuevo = crearTransaccion();
            if (nuevo == null) return;
            elProcesador.recibirTransaccion(nuevo);
            txtMonto.Clear();
            txtOrigen.Clear();
            txtDestino.Clear();
            cbTipo.SelectedIndex = 0;
            ActualizarInterfaz();
            MessageBox.Show($"Operación agregada a la cola. Código: {nuevo.Codigo}");
        }
        private Transaccion crearTransaccion()
        {
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
            string codigo = generarCodigoUnico();
            bool conexion = txtOrigen.Text.Trim() == txtDestino.Text.Trim();
            TipoTransaccion tipo;
            if (cbTipo.SelectedIndex == 0) tipo = TipoTransaccion.Abono;
            else if (cbTipo.SelectedIndex == 1) tipo = TipoTransaccion.Retiro;
            else tipo = TipoTransaccion.Transferencia;
            DateTime fecha = DTPFecha.Value;

            elProcesador.elGrafo.agregarRuta(txtOrigen.Text.Trim(), txtDestino.Text.Trim(), conexion);
            return new Transaccion(codigo,txtOrigen.Text.Trim(),txtDestino.Text.Trim(),monto,tipo,
                EstadoTransaccion.Pendiente,fecha);
        }
        private void btnProcesar_Click(object sender, EventArgs e) //procesamos solo el primero de la cola
        {
            Transaccion t = elProcesador.procesarSiguiente();
            if (t == null)
            {
                MessageBox.Show("No existen operaciones pendientes.");
                return;
            }
            ActualizarInterfaz();
            MessageBox.Show($"{t.Codigo} ha sido procesado exitosamente.");
        }

        private void btnProcesarTodo_Click(object sender, EventArgs e)//procesamos todas las operaciones de la cola que tengan conexion
        {
            int cantidad = elProcesador.hacerTodo();
            ActualizarInterfaz();
            if (cantidad == 0)
            {
                MessageBox.Show("No se procesó ninguna.\nRevise las conexiones de las rutas.");
            }
            else MessageBox.Show($"Procesamiento completado.\nOperaciones procesadas: {cantidad}");
        }
        private string generarCodigoUnico()// hacemos un codigo que sea diferente a los demas
        {
            string codigo;
            do
            {
                codigo = "(415)" + random.Next(10000, 999999).ToString();
            }
            while (elProcesador.buscar(codigo) != null);
            return codigo;
        }
        private void btnRevertir_Click(object sender, EventArgs e) //al procesar algo se introduce a la pila, es ahi donde podemos dar ctrlZ
        {
            Transaccion t = elProcesador.controlZ_ultimaOperacion();
            if (t == null)
            {
                MessageBox.Show("No existen operaciones para revertir.");
                return;
            }
            ActualizarInterfaz();
            MessageBox.Show($"Operación revertida.\n\n" + $"Código: {t.Codigo}\n" + $"Monto: S/ {t.Monto:N2}\n" + $"Estado: {t.Estado}");
        }

        // en este meto simulamos 10,000 operacioens en unos milisgundos para tratar de imitar las millones de operaciones simultaneas
        // en la vida real
        private void btnSimularPico_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Esta a punto de simular 10 000 operaciones en unos milisegundos." +
                " ¿Desea continuar?","Simulación de pico",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                Stopwatch reloj = new Stopwatch();
                DateTime ahora = DateTime.Now;
                List<string> agencias = elProcesador.elGrafo.ObtenerCiudades();
                reloj.Start();
                for (int i = 1; i <= 10000; i++) //aqui empezamos la simulacion
                {
                    string codigo = generarCodigoUnico();
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
                    elProcesador.recibirTransaccion(transaccion);
                }
                int procesadas = elProcesador.hacerTodo();
                reloj.Stop();
                ActualizarInterfaz();
                int pendientes = elProcesador.getPendientes();
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
            FormGrafo fg = new FormGrafo(elProcesador, this);
            fg.ShowDialog();
        }
        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBusqueda fb = new FormBusqueda(elProcesador);
            fb.ShowDialog();
        }
        public void ActualizarInterfaz() //vamos a actualizar los datos que se muestran en las listas
        {
            lstCola.Items.Clear();
            foreach (Transaccion t in elProcesador.laCola) //actualizamos la listbox de la cola
            {
                lstCola.Items.Add(t.ToString());
            }

            lstPila.Items.Clear();
            foreach (Transaccion t in elProcesador.laPila) //actualizamos la listbox de la pila
            {
                lstPila.Items.Add(t.ToString());
            }

            dgvOperaciones.Rows.Clear();
            foreach (Transaccion t in elProcesador.elArbol)//actualizamos el dtg de las estadisticas
            {
                dgvOperaciones.Rows.Add(t.Codigo, t.Origen, t.Destino,
                    $"S/ {t.Monto:N2}", t.Tipo, t.Estado, t.fecha);
            }
            //actualizamos los labels de estadisticas
            lblRecibidas.Text = $"Recibidas: {elProcesador.totalRecibidas}";
            lblProcesadas.Text = $"Procesadas: {elProcesador.totalProcesadas}";
            lblPendientes.Text = $"Pendientes: {elProcesador.getPendientes()}";
            lblRevertidas.Text = $"Revertidas: {elProcesador.totalControlZ}";
        }
        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Estructura de Datos (2026 - 2)" +$"\nChristopher Diaz Bacon");
        }
    }
}