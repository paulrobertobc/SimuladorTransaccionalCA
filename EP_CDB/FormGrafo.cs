using EP_CDB.CajaArequipa.Estructuras;
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

namespace EP_CDB
{
    public partial class FormGrafo : Form
    {
        private ProcesadorTransacciones procesador;
        public FormGrafo(ProcesadorTransacciones procesador, Form1 formularioPrincipal)
        {
            InitializeComponent();
            this.procesador = procesador;    
            ConfigurarInterfazGrafo();
        }

        private void btnConsultaRutas_Click(object sender, EventArgs e)
        {
            if (cmbAgenciaGrafo.SelectedItem == null)
            {
                MessageBox.Show("Seleccione una agencia.");
                return;
            }
            string agencia = cmbAgenciaGrafo.SelectedItem.ToString();
            List<Ruta> rutas = procesador.elGrafo.ObtenerTodasLasRutas();
            lstRutasGrafo.Items.Clear();
            foreach (Ruta ruta in rutas)
            {
                if (ruta.Origen.Equals(agencia,StringComparison.OrdinalIgnoreCase) 
                    || ruta.Destino.Equals(agencia,StringComparison.OrdinalIgnoreCase))
                {
                    lstRutasGrafo.Items.Add(ruta.ToString());
                }
            }
            if (lstRutasGrafo.Items.Count == 0) lstRutasGrafo.Items.Add("Esta agencia no tiene rutas registradas.");
        }
        private void ConfigurarInterfazGrafo()
        {
            cmbAgenciaGrafo.Items.Clear();
            foreach (string agencia in procesador.elGrafo.ObtenerAgencias())
            {
                cmbAgenciaGrafo.Items.Add(agencia);
            }
            if (cmbAgenciaGrafo.Items.Count > 0) cmbAgenciaGrafo.SelectedIndex = 0;
            ActualizarListaRutasGrafo();
        }

        private void ActualizarListaRutasGrafo()
        {
            lstRutasGrafo.Items.Clear();
            foreach (Ruta ruta in procesador.elGrafo.ObtenerTodasLasRutas())
            {
                lstRutasGrafo.Items.Add(ruta.ToString());
            }
        }

        private void btnAlternarConexion_Click(object sender, EventArgs e)
        {
            if (lstRutasGrafo.SelectedItem == null)
            {
                MessageBox.Show("Seleccione una ruta de la lista.");
                return;
            }

            string textoSeleccionado = lstRutasGrafo.SelectedItem.ToString();

            List<Ruta> rutas = procesador.elGrafo.ObtenerTodasLasRutas();

            Ruta rutaSeleccionada = rutas.Find(p => p.ToString() == textoSeleccionado);

            if (rutaSeleccionada == null)
            {
                MessageBox.Show("No se encontró la ruta.");
                return;
            }

            bool nuevoEstado = !rutaSeleccionada.EstaConectada;

            procesador.elGrafo.CambiarEstadoRuta(rutaSeleccionada.Origen,rutaSeleccionada.Destino,nuevoEstado);

            string agenciaSeleccionada = cmbAgenciaGrafo.SelectedItem?.ToString();

            if (!string.IsNullOrWhiteSpace(agenciaSeleccionada)) btnConsultaRutas_Click(sender, e);
            else ActualizarListaRutasGrafo();

            if (nuevoEstado)
            {
                int procesadas = procesador.hacerTodo();
            }
            else
            {
                MessageBox.Show($"La ruta entre {rutaSeleccionada.Origen} y " + $"{rutaSeleccionada.Destino} ahora está intermitente.");
            }
            ActualizarListaRutasGrafo();
        }

        private void btnVerTodasRutas_Click(object sender, EventArgs e)
        {
            ActualizarListaRutasGrafo();
        }
        private void crearRutaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCrearConexion fcc = new FormCrearConexion(procesador);
            fcc.ShowDialog();
            ConfigurarInterfazGrafo();
        }
    }
}
