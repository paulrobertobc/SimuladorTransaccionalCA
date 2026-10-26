using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_CDB.CajaArequipa.Estructuras
{
    public class Grafo
    {
        private class Nodo
        {
            public string Agencia { get; set; }
            public List<Nodo> Vecinos { get; set; }
            public Nodo(string Agencia)
            {
                this.Agencia = Agencia;
                Vecinos = new List<Nodo>();
            }
        }
        private Dictionary<string, Nodo> nodos;
        private List<Ruta> rutas;
        public Grafo()
        {
            nodos = new Dictionary<string, Nodo>(StringComparer.OrdinalIgnoreCase);
            rutas = new List<Ruta>();
        }
        public void agregarAgencia(string agencia)
        {
            if (!nodos.ContainsKey(agencia)) nodos.Add(agencia, new Nodo(agencia));
        }
        public void agregarRuta(string origen,string destino,bool estaConectada = true)
        {
            agregarAgencia(origen);
            agregarAgencia(destino);

            bool existe = rutas.Exists(r =>(r.Origen.Equals(origen,StringComparison.OrdinalIgnoreCase)
            && r.Destino.Equals(destino, StringComparison.OrdinalIgnoreCase))
            || (r.Origen.Equals(destino,StringComparison.OrdinalIgnoreCase)
            && r.Destino.Equals(origen,StringComparison.OrdinalIgnoreCase)));

            if (existe) return;
            rutas.Add(new Ruta(origen,destino,estaConectada));

            nodos[origen].Vecinos.Add(nodos[destino]);
            nodos[destino].Vecinos.Add(nodos[origen]);
        }
        public bool cambiarEstadoRuta(string origen,string destino,bool nuevoEst)
        {
            Ruta ruta = rutas.Find(r =>(r.Origen.Equals(origen,StringComparison.OrdinalIgnoreCase)
            && r.Destino.Equals(destino,StringComparison.OrdinalIgnoreCase))
            || (r.Origen.Equals(destino,StringComparison.OrdinalIgnoreCase) 
            && r.Destino.Equals(origen,StringComparison.OrdinalIgnoreCase)));

            if (ruta == null) return false;
            ruta.EstaConectada = nuevoEst;
            return true;
        }
        public List<string> ObtenerAgencias() => nodos.Keys.ToList();
        public List<Ruta> ObtenerTodasLasRutas() => new List<Ruta>(rutas);
        public List<string> ObtenerCiudades()
        {
            HashSet<string> ciudades = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (Ruta ruta in rutas)
            {
                ciudades.Add(ruta.Origen);
                ciudades.Add(ruta.Destino);
            }
            return new List<string>(ciudades);
        }
        public bool ExisteCaminoConectado(string origen, string destino)
        {
            if (string.IsNullOrWhiteSpace(origen) || string.IsNullOrWhiteSpace(destino))
            {
                return false;
            }

            if (!nodos.ContainsKey(origen) || !nodos.ContainsKey(destino))
            {
                return false;
            }

            if (origen.Equals(destino,StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            HashSet<string> visitadas = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            Queue<string> pendientes = new Queue<string>();

            pendientes.Enqueue(origen);
            visitadas.Add(origen);

            while (pendientes.Count > 0)
            {
                string actual = pendientes.Dequeue();

                foreach (Ruta ruta in rutas)
                {
                    if (!ruta.EstaConectada)
                    {
                        continue;
                    }

                    string siguiente = null;

                    if (ruta.Origen.Equals(actual,StringComparison.OrdinalIgnoreCase))
                    {
                        siguiente = ruta.Destino;
                    }
                    else if (ruta.Destino.Equals(actual,StringComparison.OrdinalIgnoreCase))
                    {
                        siguiente = ruta.Origen;
                    }

                    if (siguiente == null || !visitadas.Add(siguiente))
                    {
                        continue;
                    }

                    if (siguiente.Equals(destino,StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }

                    pendientes.Enqueue(siguiente);
                }
            }

            return false;
        }
    }
}
