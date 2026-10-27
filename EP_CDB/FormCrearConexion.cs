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

namespace EP_CDB
{
    public partial class FormCrearConexion : Form
    {
        private Procesador procesador;
        public FormCrearConexion(Procesador procesador)
        {
            InitializeComponent();
            this.procesador = procesador;
        }
        private void btnCrear_Click(object sender, EventArgs e)
        {
            string origen = tbOrigen.Text.Trim();
            string destino = tbDestino.Text.Trim();
            if (string.IsNullOrWhiteSpace(destino))
            {
                MessageBox.Show("Digite bien el destino.");
                return;
            }
            if (string.IsNullOrWhiteSpace(origen))
            {
                MessageBox.Show("Digite bien el origen.");
                return;
            }
            bool puedeSincronizar = procesador.elGrafo.ExisteCaminoConectado(origen, destino);
            if (puedeSincronizar)
            {
                MessageBox.Show($"Ya existe camino entre {tbOrigen.Text} y {tbDestino.Text}");
                return;
            }
            if (rbSI.Checked == true)
            {
                procesador.elGrafo.agregarRuta(origen, destino, true);
                MessageBox.Show($"Ruta creada de {origen} a {destino} con conexion activa.");
            }
            else if (rbNO.Checked == true)
            {
                procesador.elGrafo.agregarRuta(origen, destino, false);
                MessageBox.Show($"Ruta creada de {origen} a {destino} con conexion desactivada.");
            }
            else
            {
                MessageBox.Show("Seleccione el estado de la conexion");
                return;
            }
            Close();
        }
    }
}
