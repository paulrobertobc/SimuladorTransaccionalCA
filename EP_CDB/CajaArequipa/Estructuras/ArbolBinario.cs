using EP_CDB.CajaArequipa.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_CDB.CajaArequipa.Estructuras
{
    public class ArbolBinario : IEnumerable<Transaccion>
    {
        private class Nodo
        {
            public Transaccion dato { get; set; }
            public Nodo izq { get; set; }
            public Nodo der { get; set; }
            public Nodo(Transaccion dato)
            {
                this.dato = dato;
                izq = null;
                der = null;
            }
        }
        private Nodo raiz;
        public void Insertar(Transaccion transaccion)
        {
            raiz = InsertarRecursivo(raiz, transaccion);
        }
        private Nodo InsertarRecursivo(Nodo nodo,Transaccion transaccion)
        {
            if (nodo == null) return new Nodo(transaccion);
            int comparacion = string.Compare(transaccion.Codigo,nodo.dato.Codigo,StringComparison.OrdinalIgnoreCase);
            if (comparacion < 0) nodo.izq = InsertarRecursivo(nodo.izq, transaccion);
            else if (comparacion > 0) nodo.der = InsertarRecursivo(nodo.der, transaccion);
            return nodo;
        }
        public Transaccion Buscar(string codigo)
        {
            Nodo actual = raiz;
            while (actual != null)
            {
                int comparacion = string.Compare(codigo,actual.dato.Codigo,StringComparison.OrdinalIgnoreCase);
                if (comparacion == 0) return actual.dato;
                if (comparacion < 0) actual = actual.izq;
                else actual = actual.der;
            }
            return null;
        }
        public List<Transaccion> getDatosEnOrden()
        {
            List<Transaccion> resultado = new List<Transaccion>();
            RecorrerInOrden(raiz, resultado);
            return resultado;
        }
        private void RecorrerInOrden(Nodo nodo, List<Transaccion> resultado)
        {
            if (nodo == null) return;
            RecorrerInOrden(nodo.izq, resultado);
            resultado.Add(nodo.dato);
            RecorrerInOrden(nodo.der, resultado);
        }
        public IEnumerator<Transaccion> GetEnumerator()//vamos a ponerle getenumarator para que el arbol tenga la capacidad de foreach
        {
            return getDatosEnOrden().GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        private IEnumerable<Transaccion> RecorrerInOrdenYield(Nodo nodo)
        {
            if (nodo == null) yield break;
            foreach(var item in RecorrerInOrdenYield(nodo.izq))
            {
                yield return item;
            }
            yield return nodo.dato;
            foreach (var item in RecorrerInOrdenYield(nodo.der))
            {
                yield return item;
            }
        }
        public void Vaciar()
        {
            raiz = null;
        }
        public bool esVacio() => raiz == null;
    }
}
