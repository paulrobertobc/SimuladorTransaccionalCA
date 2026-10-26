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
        private IEnumerable<Transaccion> resultadosGlobales;
        private IEnumerable<Transaccion> resultadosActuales;
        public FormBusqueda(Procesador procesador)
        {
            InitializeComponent();
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
            cbMMI.SelectedIndex = 0;

            cbTipo.Items.Clear();
            cbTipo.Items.Add("Abono");
            cbTipo.Items.Add("Retiro");
            cbTipo.Items.Add("Transferencia");
            cbTipo.SelectedIndex = 0;

            cbEstados.Items.Clear();
            cbEstados.Items.Add("Pendiente");
            cbEstados.Items.Add("Procesada");
            cbEstados.Items.Add("Revertida");
            cbEstados.SelectedIndex = 0;

            LlenadoDTG(resultadosActuales);
        }
        private IEnumerable<Transaccion> EstructurasUnidas()//con esto unificamos la busqueda con el arbol, la pila y cola
        {
            return procesador.elArbol.Concat(procesador.laCola);
        }
        private void btnBuscarCiudad_Click(object sender, EventArgs e)
        {
            string c = tbDatos.Text.Trim();
            if (string.IsNullOrWhiteSpace(c))
            {
                MessageBox.Show("Ingrese una ciudad para buscar.");
                return;
            }

            var resultados = resultadosActuales.Where(t =>
            {
                if (rbOrigen.Checked)
                    return t.Origen.Trim().Equals(c, StringComparison.OrdinalIgnoreCase);
                else if (rbDestino.Checked)
                    return t.Destino.Trim().Equals(c, StringComparison.OrdinalIgnoreCase);
                return false;
            });

            if (!resultados.Any())
            {
                dgvOperaciones.Rows.Clear();
                lbResultados.Text = "Resultados de la búsqueda (No se encontraron transacciones para esa ciudad.)";
                return;
            }

            resultadosActuales = resultados;
            LlenadoDTG(resultadosActuales);
        }
        private void btnBuscarCod_Click(object sender, EventArgs e)
        {
            string codigo = txtBusqueda.Text.Trim();
            if (string.IsNullOrWhiteSpace(codigo))
            {
                MessageBox.Show("Ingrese el código de la operación.");
                return;
            }
            Transaccion buscado;
            if (checkBoxIgnorar.Checked)
            {
                buscado = procesador.buscar(codigo);
            }
            else
            {
                buscado = resultadosActuales.FirstOrDefault(t => t.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase));
            }
            if (buscado != null)
            {
                var result = new List<Transaccion> { buscado };
                LlenadoDTG(result);
                return;
            }
            dgvOperaciones.Rows.Clear();
            lbResultados.Text = "Resultados de la búsqueda (No se encontró la operación.)";
        }
        private void btnBuscarMonto_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(tbMonto.Text.Trim(), out double m))
            {
                dgvOperaciones.Rows.Clear();
                lbResultados.Text = "Resultados de la búsqueda (Ingrese un monto válido.)";
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
                lbResultados.Text = "Resultados de la búsqueda (No se encontraron transacciones con el monto especificado.)";
                return;
            }

            resultadosActuales = resultados;
            LlenadoDTG(resultadosActuales);
        }
        private void cbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            var resultados = resultadosActuales.Where(t =>
            {
                switch (cbTipo.SelectedIndex)
                {
                    case 0: return t.Tipo == TipoTransaccion.Abono;
                    case 1: return t.Tipo == TipoTransaccion.Retiro;
                    case 2: return t.Tipo == TipoTransaccion.Transferencia;
                    default: return false;
                }
            });

            if (!resultados.Any())
            {
                dgvOperaciones.Rows.Clear();
                lbResultados.Text = $"Resultados de la búsqueda (No se encontraron transacciones de tipo {cbTipo.SelectedItem})";
                return;
            }

            resultadosActuales = resultados;
            LlenadoDTG(resultadosActuales);
        }
        public IEnumerable<Transaccion> ObtenerTipoSeleccionado(IEnumerable<Transaccion> r)
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
                lbResultados.Text = $"Resultados de la búsqueda (No se encontraron transacciones {cbEstados.SelectedItem})";
                return;
            }
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
            resultadosGlobales = resultadosActuales.Where(p => p.Fecha.Date == fechaElegida);
            resultadosActuales = EstadosSeleccionados(resultadosGlobales).Concat(ObtenerTipoSeleccionado(resultadosGlobales));
            LlenadoDTG(resultadosActuales);
        }
        public void LlenadoDTG(IEnumerable<Transaccion> resultados)
        {
            int total = resultados.Count();
            lbResultados.Text = $"Resultados de la búsqueda ({total} resultados.)";
            dgvOperaciones.Rows.Clear();
            foreach (Transaccion t in resultados)
            {
                dgvOperaciones.Rows.Add(t.Codigo,t.Origen,t.Destino,
                    $"S/ {t.Monto:N2}",t.Tipo,t.Estado,t.Fecha.Date.ToShortDateString()
                );
            }
        }
        private void reiniciarFiltrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resultadosActuales = EstructurasUnidas();
            resultadosGlobales = null;
            LlenadoDTG(resultadosActuales);
        }
    }
}
