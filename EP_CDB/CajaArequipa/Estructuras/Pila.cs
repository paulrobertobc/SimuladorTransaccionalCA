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
        private Nodo laCima;
        public int cont { get; private set; }
        public void Apilar(Transaccion transac)
        {
            Nodo nuevo = new Nodo(transac);
            nuevo.s = laCima;
            laCima = nuevo;
            cont++;
        }
        public Transaccion Desapilar()
        {
            if (esVacio()) return null;
            Transaccion transac = laCima.dato;
            laCima = laCima.s;
            cont--;
            return transac;
        }
        public Transaccion Peek()
        {
            if (esVacio()) return null;
            return laCima.dato;
        }
        public IEnumerator<Transaccion> GetEnumerator()//le ponemos el get enumerator para que a futuro se pueda usar en foreach
        {
            Nodo actual = laCima;
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
        public bool esVacio() => laCima == null;
    }
}
