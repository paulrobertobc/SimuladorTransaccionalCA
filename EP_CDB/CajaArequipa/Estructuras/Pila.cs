using EP_CDB.CajaArequipa.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_CDB.CajaArequipa.Estructuras
{
    public class Pila : IEnumerable<Transaccion>
    {
        private class Nodo
        {
            public Transaccion dato { get; set; }
            public Nodo s { get; set; }
            public Nodo(Transaccion dato)
            {
                this.dato = dato;
                s = null;
            }
        }
        private Nodo cima;
        public int cont { get; private set; }
        public void Apilar(Transaccion transac)
        {
            Nodo nuevo = new Nodo(transac);
            nuevo.s = cima;
            cima = nuevo;
            cont++;
        }
        public Transaccion Desapilar()
        {
            if (esVacio()) return null;
            Transaccion transac = cima.dato;
            cima = cima.s;
            cont--;
            return transac;
        }
        public Transaccion getCima()
        {
            if (esVacio()) return null;
            return cima.dato;
        }
        public IEnumerator<Transaccion> GetEnumerator()
        {
            Nodo actual = cima;
            while (actual != null)
            {
                yield return actual.dato;
                actual = actual.s;
            }
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public bool esVacio() => cima == null;
    }
}
