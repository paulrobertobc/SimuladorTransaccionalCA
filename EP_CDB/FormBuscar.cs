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
    public partial class FormBuscar : Form
    {
        private ProcesadorTransacciones procesador;
        public FormBuscar(ProcesadorTransacciones procesador)
        {
            InitializeComponent();
            this.procesador = procesador;
            cbMMI.Items.Clear();
            cbMMI.Items.Add("Igual");
            cbMMI.Items.Add("Mayor a");
            cbMMI.Items.Add("Menor a");
            cbMMI.SelectedIndex = 0;
            cmbTipo.Items.Clear();
            cmbTipo.Items.Add("Abono");
            cmbTipo.Items.Add("Retiro");
            cmbTipo.Items.Add("Transferencia");
            cmbTipo.SelectedIndex = 0;
            cbEstados.Items.Clear();
            cbEstados.Items.Add("Pendiente");
            cbEstados.Items.Add("Procesada");
            cbEstados.Items.Add("Revertida");
            cbEstados.SelectedIndex = 0;
        }
        private IEnumerable<Transaccion> TodasLasEtructuras()//con esto unificamos la busqueda con el arbol, la pila y cola
        {
            return procesador.elArbol.Concat(procesador.laPila).Concat(procesador.laCola);
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            lbResultados.Items.Clear();
            string c = tbDatos.Text.Trim();
            var resultados = Enumerable.Empty<Transaccion>();
            if (rbOrigen.Checked)
            {
                resultados = TodasLasEtructuras().Where(t => t.Origen.Trim().Equals(c, StringComparison.OrdinalIgnoreCase));
            }
            else if (rbDestino.Checked)
            {
                resultados = TodasLasEtructuras().Where(t => t.Destino.Trim().Equals(c, StringComparison.OrdinalIgnoreCase));
            }
            else MessageBox.Show("Selecciona origen o destino");
            if (!resultados.Any())
            {
                lbResultados.Items.Add("No se encontraron transacciones para esa ciudad.");
                return;
            }
            LlenadoLB(resultados);
        }
        private void btnBuscarCod_Click(object sender, EventArgs e)
        {
            lbResultados.Items.Clear();
            string codigo = txtBusqueda.Text.Trim();
            if (string.IsNullOrWhiteSpace(codigo))
            {
                MessageBox.Show("Ingrese el código de la operación.");
                return;
            }
            Transaccion transac = procesador.buscar(codigo);
            if (transac != null)
            {
                lbResultados.Items.Add(transac.ToString());
                return;
            }
            lbResultados.Items.Add("No se encontró la operación.");
        }

        private void btnBuscarMonto_Click(object sender, EventArgs e)
        {
            lbResultados.Items.Clear();
            if (!double.TryParse(tbMonto.Text.Trim(), out double m))
            {
                lbResultados.Items.Add("Ingrese un monto válido.");
                return;
            }
            var resultados = TodasLasEtructuras().Where(t =>
            {
                switch (cbMMI.SelectedIndex)//vamos a usar este swith anidado al where para filtra de una forma mas limpia
                {
                    case 0:
                        return t.Monto == m;
                    case 1:
                        return t.Monto > m;
                    case 2:
                        return t.Monto < m;
                    default:
                        return false;
                }
            });
            if (!resultados.Any())
            {
                lbResultados.Items.Add("No se encontraron transacciones con el monto especificado.");
                return;
            }
            LlenadoLB(resultados);
        }

        private void btnBuscarTipo_Click(object sender, EventArgs e)
        {
            lbResultados.Items.Clear();
            var results = TodasLasEtructuras().Where(t =>
            {
                switch (cmbTipo.SelectedIndex)
                {
                    case 0:
                        return t.Tipo == TipoTransaccion.Abono;
                    case 1:
                        return t.Tipo == TipoTransaccion.Retiro;
                    case 2:
                        return t.Tipo == TipoTransaccion.Transferencia;
                    default:
                        return false;
                }
            });
            if (!results.Any())
            {
                lbResultados.Items.Add($"No se encontraron transacciones de tipo {cmbTipo.SelectedItem.ToString()}");
                return;
            }
            LlenadoLB(results);
        }
        private void btnBuscarEstado_Click(object sender, EventArgs e)
        {
            lbResultados.Items.Clear();
            var results = TodasLasEtructuras().Where(t =>
            {
                switch (cbEstados.SelectedIndex)
                {
                    case 0:
                        return t.Estado == EstadoTransaccion.Pendiente;
                    case 1:
                        return t.Estado == EstadoTransaccion.Procesada;
                    case 2:
                        return t.Estado == EstadoTransaccion.Revertida;
                    default:
                        return false;
                }
            });
            if (!results.Any())
            {
                lbResultados.Items.Add($"No se encontraron transacciones {cbEstados.SelectedItem.ToString()}");
                return;
            }
            LlenadoLB(results);
        }
        private void btnBuscarFecha_Click(object sender, EventArgs e)
        {
            lbResultados.Items.Clear();
            DateTime f;
            if (checkBoxHoy.Checked == true)
            {
                f = DateTime.Today;
            }
            else
            {
                f = DTPFecha.Value.Date;
            }
            var resultados = TodasLasEtructuras().Where(t => t.Fecha.Date == f);
            if (!resultados.Any())
            {
                lbResultados.Items.Add("No se encontraron transacciones para la fecha seleccionada.");
                return;
            }
            foreach (Transaccion t in resultados)
            {
                lbResultados.Items.Add($"{t.Fecha.ToString()}: {t.ToString()}");
            }
        }
        public void LlenadoLB(IEnumerable<Transaccion> results)
        {
            foreach (Transaccion t in results)
            {
                lbResultados.Items.Add(t.ToString());
            }
        }
        private void DTPFecha_ValueChanged(object sender, EventArgs e)
        {
            checkBoxHoy.Checked = false;
        }
    }
}
