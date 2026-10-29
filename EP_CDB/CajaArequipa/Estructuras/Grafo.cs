using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_CDB.CajaArequipa.Estructuras
{
    public class Grafo //usaremos hashset para busuqedas mas rapidas
    {
        private class Nodo
        {
            //public string suAgencia { get; set; }
            public List<Nodo> susVecinos { get; set; }
            public Nodo(string suAgencia)
            {
                //this.suAgencia = suAgencia;
                susVecinos = new List<Nodo>();
            }
        }
        private Dictionary<string, Nodo> losNodos;
        private List<Ruta> lasRutas;
        public Grafo()
        {
            losNodos = new Dictionary<string, Nodo>(StringComparer.OrdinalIgnoreCase);
            lasRutas = new List<Ruta>();
        }
        public void agregarAgencia(string agencia)
        {
            if (!losNodos.ContainsKey(agencia)) losNodos.Add(agencia, new Nodo(agencia));
        }
        public void agregarRuta(string origen,string destino,bool estadoConexion)
        {
            agregarAgencia(origen);
            agregarAgencia(destino);

            bool existe = lasRutas.Exists(r =>(r.Origen.Equals(origen,StringComparison.OrdinalIgnoreCase)
            && r.Destino.Equals(destino, StringComparison.OrdinalIgnoreCase))
            || (r.Origen.Equals(destino,StringComparison.OrdinalIgnoreCase)
            && r.Destino.Equals(origen,StringComparison.OrdinalIgnoreCase)));

            if (existe) return;
            lasRutas.Add(new Ruta(origen,destino,estadoConexion));

            losNodos[origen].susVecinos.Add(losNodos[destino]);
            losNodos[destino].susVecinos.Add(losNodos[origen]);
        }
        public bool cambiarEstadoRuta(string origen,string destino,bool nuevoEst)
        {
            Ruta ruta = lasRutas.Find(r =>(r.Origen.Equals(origen,StringComparison.OrdinalIgnoreCase)
            && r.Destino.Equals(destino,StringComparison.OrdinalIgnoreCase))
            || (r.Origen.Equals(destino,StringComparison.OrdinalIgnoreCase) 
            && r.Destino.Equals(origen,StringComparison.OrdinalIgnoreCase)));

            if (ruta == null) return false;
            ruta.EstaConectada = nuevoEst;
            return true;
        }
        public List<string> ObtenerCiudades()
        {
            HashSet<string> ciudades = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (Ruta ruta in lasRutas)
            {
                ciudades.Add(ruta.Origen);
                ciudades.Add(ruta.Destino);
            }
            return new List<string>(ciudades);
        }
        public bool ExisteCaminoConectado(string origen, string destino)
        {
            if (string.IsNullOrWhiteSpace(origen) || string.IsNullOrWhiteSpace(destino)) return false;
            if (!losNodos.ContainsKey(origen) || !losNodos.ContainsKey(destino)) return false;
            if (origen.Equals(destino,StringComparison.OrdinalIgnoreCase)) return true;

            //usaremos una cola de c# porque la que hicimos no soporta strings. 
            HashSet<string> visitadas = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            Queue<string> pendientes = new Queue<string>();

            pendientes.Enqueue(origen);
            visitadas.Add(origen);

            while (pendientes.Count > 0)
            {
                string actual = pendientes.Dequeue();

                foreach (Ruta ruta in lasRutas)
                {
                    if (!ruta.EstaConectada) continue;

                    string siguiente = null;

                    if (ruta.Origen.Equals(actual,StringComparison.OrdinalIgnoreCase)) siguiente = ruta.Destino;
                    else if (ruta.Destino.Equals(actual,StringComparison.OrdinalIgnoreCase)) siguiente = ruta.Origen;

                    if (siguiente == null || !visitadas.Add(siguiente)) continue;
                    if (siguiente.Equals(destino,StringComparison.OrdinalIgnoreCase)) return true;

                    pendientes.Enqueue(siguiente);
                }
            }
            return false;
        }
        public List<string> ObtenerAgencias() => losNodos.Keys.ToList();
        public List<Ruta> ObtenerTodasLasRutas() => new List<Ruta>(lasRutas);
    }
}
