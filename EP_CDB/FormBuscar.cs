using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EP_CDB.CajaArequipa.Modelos;
using EP_CDB.CajaArequipa.Servicios;

namespace EP_CDB
{
    public partial class FormBusqueda : Form
    {
        private Procesador procesador;
        private DateTime fechaElegida;
        //private IEnumerable<Transaccion> resultadosGlobales;
        private IEnumerable<Transaccion> resultadosActuales;
        private string columnaActiva = ""; //con esto podremos pintar luego algunas columnas del dgv
        public FormBusqueda(Procesador procesador)
        {
            InitializeComponent();
            dgvOperaciones.CellFormatting += dgvOperaciones_CellFormatting;
            this.procesador = procesador;
            resultadosActuales = EstructurasUnidas();

            dgvOperaciones.AutoGenerateColumns = false;
            dgvOperaciones.ReadOnly = true;
            dgvOperaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOperaciones.Columns.Clear(); // hacemos las columnas una sola vez al arrancar el formulario
            dgvOperaciones.Columns.Add("Codigo", "Código");
            dgvOperaciones.Columns.Add("Origen", "Origen");
            dgvOperaciones.Columns.Add("Destino", "Destino");
            dgvOperaciones.Columns.Add("Monto", "Monto");
            dgvOperaciones.Columns.Add("Tipo", "Tipo");
            dgvOperaciones.Columns.Add("Estado", "Estado");
            dgvOperaciones.Columns.Add("Fecha", "Fecha");

            cbMMI.Items.Clear();
            cbMMI.Items.Add("Igual");
            cbMMI.Items.Add("Mayor a");
            cbMMI.Items.Add("Menor a");
            cbMMI.SelectedIndex = -1;

            cbTipo.Items.Clear();
            cbTipo.Items.Add("Abono");
            cbTipo.Items.Add("Retiro");
            cbTipo.Items.Add("Transferencia");
            cbTipo.SelectedIndex = -1;

            cbEstados.Items.Clear();
            cbEstados.Items.Add("Pendiente");
            cbEstados.Items.Add("Procesada");
            cbEstados.Items.Add("Revertida");
            cbEstados.SelectedIndex = -1;

            LlenadoDTG(resultadosActuales);
        }
        private IEnumerable<Transaccion> EstructurasUnidas()//con esto unificamos la busqueda con el arbol y la cola
        {
            return procesador.elArbol.Concat(procesador.laCola);
        }
        private void btnBuscarCiudad_Click(object sender, EventArgs e)
        {
            string c = tbCiudad.Text.Trim();
            if (string.IsNullOrWhiteSpace(c))
            {
                MessageBox.Show("Resultados de la búsqueda: Ingrese una ciudad para buscar");
                return;
            }
            var resultados = resultadosActuales.Where(t =>
            {
                if (rbOrigen.Checked) return t.Origen.Trim().Equals(c, StringComparison.OrdinalIgnoreCase);
                else if (rbDestino.Checked) return t.Destino.Trim().Equals(c, StringComparison.OrdinalIgnoreCase);

                return false;
            });
            if (!resultados.Any())
            {
                dgvOperaciones.Rows.Clear();
                lbResultados.Text = "Resultados de la búsqueda: No se encontraron transacciones para esa ciudad";
                return;
            }
            resultadosActuales = resultados;
            columnaActiva = rbOrigen.Checked ? "Origen" : "Destino";
            LlenadoDTG(resultadosActuales);
        }
        private void btnBuscarCod_Click(object sender, EventArgs e)
        {
            string codigo = txtBusqueda.Text.Trim();
            if (string.IsNullOrWhiteSpace(codigo))
            {
                MessageBox.Show("Resultados de la búsqueda: Ingrese el código de la operación.");
                return;
            }

            Transaccion buscado;
            if (checkBoxIgnorar.Checked) buscado = procesador.buscar(codigo);
            else buscado = resultadosActuales.FirstOrDefault(t => t.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase));

            if (buscado != null)
            {
                var result = new List<Transaccion> { buscado };
                LlenadoDTG(result);
                return;
            }
            dgvOperaciones.Rows.Clear();
            lbResultados.Text = "Resultados de la búsqueda: No se encontró la operación";
        }
        private void btnBuscarMonto_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(tbMonto.Text.Trim(), out double m))
            {
                dgvOperaciones.Rows.Clear();
                lbResultados.Text = "Resultados de la búsqueda: Ingrese un monto válido";
                return;
            }

            var resultados = resultadosActuales.Where(t =>
            {
                switch (cbMMI.SelectedIndex)
                {
                    case 0: return t.Monto == m;
                    case 1: return t.Monto > m;
                    case 2: return t.Monto < m;
                    default: return false;
                }
            });

            if (!resultados.Any())
            {
                dgvOperaciones.Rows.Clear();
                lbResultados.Text = "Resultados de la búsqueda: No se encontraron transacciones con el monto especificado.";
                return;
            }
            columnaActiva = "Monto";
            resultadosActuales = resultados;
            LlenadoDTG(resultadosActuales);
        }
        private void cbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvOperaciones.Rows.Clear();
            resultadosActuales = TiposSeleccionados(resultadosActuales);
            if (!resultadosActuales.Any())
            {
                dgvOperaciones.Rows.Clear();
                lbResultados.Text = $"Resultados de la búsqueda: No se encontraron transacciones de tipo {cbTipo.SelectedItem}";
                return;
            }
            columnaActiva = "Tipo";
            LlenadoDTG(resultadosActuales);
        }
        public IEnumerable<Transaccion> TiposSeleccionados(IEnumerable<Transaccion> r)
        {
            return r.Where(t =>
            {
                switch (cbTipo.SelectedIndex)
                {
                    case 0: return t.Tipo == TipoTransaccion.Abono;
                    case 1: return t.Tipo == TipoTransaccion.Retiro;
                    case 2: return t.Tipo == TipoTransaccion.Transferencia;
                    default: return false;
                }
            });
        }
        private void cbEstados_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvOperaciones.Rows.Clear();
            resultadosActuales = EstadosSeleccionados(resultadosActuales);

            if (!resultadosActuales.Any())
            {
                lbResultados.Text = $"Resultados de la búsqueda: No se encontraron transacciones {cbEstados.SelectedItem}";
                return;
            }
            columnaActiva = "Estado";
            LlenadoDTG(resultadosActuales);
        }
        public IEnumerable<Transaccion> EstadosSeleccionados(IEnumerable<Transaccion> r)
        {
            return r.Where(t =>
            {
                switch (cbEstados.SelectedIndex)
                {
                    case 0: return t.Estado == EstadoTransaccion.Pendiente;
                    case 1: return t.Estado == EstadoTransaccion.Procesada;
                    case 2: return t.Estado == EstadoTransaccion.Revertida;
                    default: return false;
                }
            });
        }
        private void DTPFecha_ValueChanged(object sender, EventArgs e)
        { 
            fechaElegida = DTPFecha.Value.Date;
            resultadosActuales = resultadosActuales.Where(p => p.Fecha.Date.Equals(fechaElegida));
            LlenadoDTG(resultadosActuales);
        }
        public void LlenadoDTG(IEnumerable<Transaccion> r)
        {
            int t = r.Count();
            lbResultados.Text = $"Resultados de la búsqueda: {t} resultados.";
            dgvOperaciones.Rows.Clear();
            foreach (Transaccion d in r)
            {
                dgvOperaciones.Rows.Add(d.Codigo,d.Origen,d.Destino,
                    $"S/ {d.Monto:N2}",d.Tipo,d.Estado,d.Fecha.Date.ToShortDateString()
                );
            }
        }
        private void dgvOperaciones_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvOperaciones.Columns[e.ColumnIndex].Name == columnaActiva)
            {
                e.CellStyle.BackColor = Color.LightBlue;
                e.CellStyle.ForeColor = Color.Black;
                e.CellStyle.Font = new Font(dgvOperaciones.Font, FontStyle.Bold);
            }
        }
        private void reiniciarFiltrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resultadosActuales = EstructurasUnidas();
            DTPFecha.Value = DateTime.Today;
            tbCiudad.Clear();
            rbDestino.Checked = rbOrigen.Checked = checkBoxIgnorar.Checked = false;
            tbMonto.Clear();
            txtBusqueda.Text = "(415)";
            cbTipo.SelectedIndex = cbEstados.SelectedIndex = cbMMI.SelectedIndex = - 1;
            columnaActiva = "";
            LlenadoDTG(resultadosActuales);
            MessageBox.Show("Filtros reiniciados.");
        }
    }
}
