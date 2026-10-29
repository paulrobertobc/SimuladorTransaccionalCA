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
        private Nodo laFrente;
        private Nodo elFinal;
        public int cont { get; private set; }
        public void Encolar(Transaccion transac)
        {
            Nodo nuevo = new Nodo(transac);
            if (esVacio())
            {
                laFrente = nuevo;
                elFinal = nuevo;
            }
            else
            {
                elFinal.s = nuevo;
                elFinal = nuevo;
            }
            cont++;
        }
        public Transaccion Desencolar()
        {
            if (esVacio()) return null;
            Transaccion transac = laFrente.dato;
            laFrente = laFrente.s;
            if (laFrente == null) elFinal = null;
            cont--;
            return transac;
        }
        public Transaccion Peek()
        {
            if (esVacio()) return null;
            return laFrente.dato;
        }
        public IEnumerator<Transaccion> GetEnumerator()// le ponemos el get enumerator para que haya uso de foreach 
        {
            Nodo actual = laFrente;
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
        public bool esVacio() => laFrente == null;
    }
}
