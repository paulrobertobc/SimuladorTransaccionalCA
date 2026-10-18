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
            string c = tbDatos.Text.Trim();
            if (rbOrigen.Checked)
            {
                porOrigen(c);
            }
            else if (rbDestino.Checked)
            {
                porDestino(c);
            }
            else MessageBox.Show("Selecciona origen o destino");
        }
        public void porOrigen(string ciudad)
        {
            lbResultados.Items.Clear();
            var resultados = TodasLasEtructuras().Where(t => t.Origen.Trim().Equals(ciudad, StringComparison.OrdinalIgnoreCase));
            if (!resultados.Any())
            {
                lbResultados.Items.Add("No se encontraron transacciones para ese origen.");
                return;
            }
            foreach (Transaccion t in resultados)
            {
                lbResultados.Items.Add(t.ToString());
            }
        }
        public void porDestino(string ciudad)
        {
            lbResultados.Items.Clear();
            var resultados = TodasLasEtructuras().Where(t => t.Destino.Trim().Equals(ciudad, StringComparison.OrdinalIgnoreCase));
            if (!resultados.Any())
            {
                lbResultados.Items.Add("No se encontraron transacciones para ese destino.");
                return;
            }
            foreach (Transaccion t in resultados)
            {
                lbResultados.Items.Add(t.ToString());
            }
        }

        private void btnBuscarCod_Click(object sender, EventArgs e)
        {
            string codigo = txtBusqueda.Text.Trim();
            if (string.IsNullOrWhiteSpace(codigo))
            {
                MessageBox.Show("Ingrese el código de la operación.");
                return;
            }
            Transaccion transaccion = procesador.buscar(codigo);
            if (transaccion != null)
            {
                lbResultados.Items.Clear();
                lbResultados.Items.Add(transaccion.ToString());
                return;
            }
            MessageBox.Show("No se encontró la operación.");
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
            foreach (Transaccion t in resultados)
            {
                lbResultados.Items.Add(t.ToString());
            }
        }

        private void btnBuscarTipo_Click(object sender, EventArgs e)
        {
            lbResultados.Items.Clear();
            if (cmbTipo.SelectedIndex == 0)
            {
                var resultados = TodasLasEtructuras().Where(t => t.Tipo == TipoTransaccion.Abono);
                if (!resultados.Any())
                {
                    lbResultados.Items.Add("No se encontraron transacciones de tipo Abono.");
                    return;
                }
                foreach (Transaccion t in resultados)
                {
                    lbResultados.Items.Add(t.ToString());
                }
            }
            else if (cmbTipo.SelectedIndex == 1)
            {
                var resultados = TodasLasEtructuras().Where(t => t.Tipo == TipoTransaccion.Retiro);
                if (!resultados.Any())
                {
                    lbResultados.Items.Add("No se encontraron transacciones de tipo Retiro.");
                    return;
                }
                foreach (Transaccion t in resultados)
                {
                    lbResultados.Items.Add(t.ToString());
                }
            }
            else if (cmbTipo.SelectedIndex == 2)
            {
                var resultados = TodasLasEtructuras().Where(t => t.Tipo == TipoTransaccion.Transferencia);
                if (!resultados.Any())
                {
                    lbResultados.Items.Add("No se encontraron transacciones de tipo Transferencia.");
                    return;
                }
                foreach (Transaccion t in resultados)
                {
                    lbResultados.Items.Add(t.ToString());
                }
            }
        }
        private void btnBuscarEstado_Click(object sender, EventArgs e)
        {
            lbResultados.Items.Clear();
            if (cbEstados.SelectedIndex == 0)
            {
                var resultados = TodasLasEtructuras().Where(t => t.Estado == EstadoTransaccion.Pendiente);
                if (!resultados.Any())
                {
                    lbResultados.Items.Add("No se encontraron transacciones pendientes.");
                    return;
                }
                foreach (Transaccion t in resultados)
                {
                    lbResultados.Items.Add(t.ToString());
                }
            }
            else if (cbEstados.SelectedIndex == 1)
            {
                var resultados = TodasLasEtructuras().Where(t => t.Estado == EstadoTransaccion.Procesada);
                if (!resultados.Any())
                {
                    lbResultados.Items.Add("No se encontraron transacciones procesadas.");
                    return;
                }
                foreach (Transaccion t in resultados)
                {
                    lbResultados.Items.Add(t.ToString());
                }
            }
            else if (cbEstados.SelectedIndex == 2)
            {
                var resultados = TodasLasEtructuras().Where(t => t.Estado == EstadoTransaccion.Revertida);
                if (!resultados.Any())
                {
                    lbResultados.Items.Add("No se encontraron transacciones revertidas.");
                    return;
                }
                foreach (Transaccion t in resultados)
                {
                    lbResultados.Items.Add(t.ToString());
                }
            }
        }
        private void btnBuscarFecha_Click(object sender, EventArgs e)
        {
            lbResultados.Items.Clear();
            DateTime seleccion = DTPFecha.Value.Date;
            var resultados = TodasLasEtructuras().Where(t => t.Fecha.Date == seleccion);
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
        private void DTPFecha_ValueChanged(object sender, EventArgs e)
        {
            checkBoxHoy.Checked = false;
        }
    }
}
