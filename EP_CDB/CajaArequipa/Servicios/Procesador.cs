using EP_CDB.CajaArequipa.Estructuras;
using EP_CDB.CajaArequipa.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EP_CDB.CajaArequipa.Servicios
{
    public class Procesador
    {
        public Cola laCola { get; private set; }
        public Pila laPila { get; private set; }
        public ArbolBinario elArbol { get; private set; }
        public Grafo elGrafo { get; private set; }
        public int totalRecibidas { get; private set; }
        public int totalProcesadas { get; private set; }
        public int totalControlZ { get; private set; }
        public Procesador()
        {
            laCola = new Cola();
            laPila = new Pila();
            elArbol = new ArbolBinario();
            elGrafo = new Grafo();
        }
        public void recibirTransaccion(Transaccion transac)
        {
            if (transac == null) return;
            transac.Estado = EstadoTransaccion.Pendiente;
            laCola.Encolar(transac);
            totalRecibidas++;
        }
        public Transaccion procesarSiguiente()
        {
            int cantidadInicial = laCola.cont;

            Transaccion transaccion = laCola.Desencolar();
            if (transaccion == null) return null;

            if (transaccion.Tipo == TipoTransaccion.Transferencia || transaccion.Tipo == TipoTransaccion.Abono ||
                transaccion.Tipo == TipoTransaccion.Retiro)// las transferencias requieren conectividad
            {
                bool puedeSincronizar = elGrafo.ExisteCaminoConectado(transaccion.Origen, transaccion.Destino);
                if (!puedeSincronizar)
                {
                    laCola.Encolar(transaccion);// sigue pendiente y vuelve al final de la cola
                    MessageBox.Show($"No existe ruta entre {transaccion.Origen} y {transaccion.Destino}");
                    return null;
                }
            }
            transaccion.Estado = EstadoTransaccion.Procesada;
            elArbol.Insertar(transaccion);
            laPila.Apilar(transaccion);
            totalProcesadas++;
            return transaccion;
        }
        public int hacerTodo()
        {
            int todoProcesado = 0;
            int cantidadInicial = laCola.cont;
            for (int i = 0; i < cantidadInicial; i++)
            {
                Transaccion transaccion = laCola.Desencolar();

                if (transaccion == null) continue;

                if (transaccion.Tipo == TipoTransaccion.Transferencia || transaccion.Tipo == TipoTransaccion.Abono 
                    || transaccion.Tipo == TipoTransaccion.Retiro)// las transferencias requieren conectividad
                {
                    bool puedeSincronizar = elGrafo.ExisteCaminoConectado(transaccion.Origen,transaccion.Destino);

                    if (!puedeSincronizar)
                    {
                        laCola.Encolar(transaccion);// sigue pendiente y vuelve al final de la cola
                        continue;
                    }
                }
                transaccion.Estado = EstadoTransaccion.Procesada;
                elArbol.Insertar(transaccion);
                laPila.Apilar(transaccion);
                totalProcesadas++;
                todoProcesado++;
            }
            return todoProcesado;
        }
        public Transaccion controlZ_ultimaOperacion()
        {
            Transaccion transac = laPila.Desapilar();
            if (transac == null) return null;
            transac.Estado = EstadoTransaccion.Revertida;
            totalControlZ++;
            return transac;
        }
        public Transaccion buscar(string cod)
        {
            if (string.IsNullOrWhiteSpace(cod)) return null;
            return elArbol.Buscar(cod);
        }
        public int getPendientes() => laCola.cont;
    }
}
