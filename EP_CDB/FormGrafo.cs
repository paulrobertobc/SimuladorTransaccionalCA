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
        private Procesador procesador;
        public FormGrafo(Procesador procesador, Form1 formularioPrincipal)
        {
            InitializeComponent();
            this.procesador = procesador;
            ActualizarListaRutasGrafo();
        }
        private void btnConsultaRutas_Click(object sender, EventArgs e) // consultamos las rutas en el grafo
        {
            if (cbAgenciaGrafo.SelectedItem == null)
            {
                MessageBox.Show("Seleccione una agencia.");
                return;
            }
            string agencia = cbAgenciaGrafo.SelectedItem.ToString();
            List<Ruta> rutas = procesador.elGrafo.ObtenerTodasLasRutas(); //obtenemos las rutas del grafo
            lstRutasGrafo.Items.Clear();
            foreach (Ruta ruta in rutas) //identificamos y las agregamos al listview
            {
                if (ruta.Origen.Equals(agencia,StringComparison.OrdinalIgnoreCase) 
                    || ruta.Destino.Equals(agencia,StringComparison.OrdinalIgnoreCase))
                {
                    lstRutasGrafo.Items.Add(ruta.ToString());
                }
            }
        }
        private void btnAlternarConexion_Click(object sender, EventArgs e) //aqui cambiamos la conexion de las rutas
        {
            if (lstRutasGrafo.SelectedItem == null)
            {
                MessageBox.Show("Seleccione una ruta de la lista.");
                return;
            }

            string textoSeleccionado = lstRutasGrafo.SelectedItem.ToString();
            List<Ruta> rutas = procesador.elGrafo.ObtenerTodasLasRutas();
            Ruta rutaSeleccionada = rutas.Find(p => p.ToString() == textoSeleccionado);//sacamos la ruta que tengan conexion con el textbox

            if (rutaSeleccionada == null)
            {
                MessageBox.Show("No se encontró la ruta.");
                return;
            }

            bool nuevoEstado = !rutaSeleccionada.EstaConectada;//identificamos su estado y llamamos al metodo para que le cambie la conexion
            procesador.elGrafo.cambiarEstadoRuta(rutaSeleccionada.Origen,rutaSeleccionada.Destino,nuevoEstado);

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
            ActualizarListaRutasGrafo();
        }
        private void ActualizarListaRutasGrafo()// llenamos el listview y el combobox con los datos actualizados
        {
            cbAgenciaGrafo.Items.Clear();
            foreach (string agencia in procesador.elGrafo.ObtenerAgencias())
            {
                cbAgenciaGrafo.Items.Add(agencia);
            }
            lstRutasGrafo.Items.Clear();
            foreach (Ruta ruta in procesador.elGrafo.ObtenerTodasLasRutas())
            {
                lstRutasGrafo.Items.Add(ruta.ToString());
            }
            if (cbAgenciaGrafo.Items.Count > 0) cbAgenciaGrafo.SelectedIndex = 0;
        }
    }
}
