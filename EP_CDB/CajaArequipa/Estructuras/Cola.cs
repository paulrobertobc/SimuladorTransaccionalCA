using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EP_CDB.CajaArequipa.Modelos;

namespace EP_CDB.CajaArequipa.Estructuras
{
    public class Cola : IEnumerable<Transaccion>
    {
        private class Nodo
        {
            public Transaccion dato { get; set; }
            public Nodo s {  get; set; }
            public Nodo(Transaccion dato)
            {
                this.dato = dato;
                s = null;
            }
        }
        private Nodo frente;
        private Nodo final;
        public int cont { get; private set; }
        public void Encolar(Transaccion transac)
        {
            Nodo nuevo = new Nodo(transac);
            if (esVacio())
            {
                frente = nuevo;
                final = nuevo;
            }
            else
            {
                final.s = nuevo;
                final = nuevo;
            }
            cont++;
        }
        public Transaccion Desencolar()
        {
            if (esVacio()) return null;
            Transaccion transac = frente.dato;
            frente = frente.s;
            if (frente == null) final = null;
            cont--;
            return transac;
        }
        public Transaccion Peek()
        {
            if (esVacio()) return null;
            return frente.dato;
        }
        public IEnumerator<Transaccion> GetEnumerator()
        {
            Nodo actual = frente;
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
        public bool esVacio() => frente == null;
    }
}
