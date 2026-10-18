using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace EP_CDB.CajaArequipa.Modelos
{
    public enum TipoTransaccion
    {
        Abono, Retiro, Transferencia
    }
    public enum EstadoTransaccion
    {
        Pendiente, Procesada, Revertida
    }
    public class Transaccion
    {
        public string Codigo {  get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public double Monto { get; set; }
        public TipoTransaccion Tipo { get; set; }
        public EstadoTransaccion Estado { get; set; }
        public DateTime Fecha { get; set; }
        public Transaccion(string codigo, string origen, string destino, double monto, TipoTransaccion tipo,EstadoTransaccion estado,
            DateTime fecha)
        {
            Codigo = codigo;
            Origen = origen;
            Destino = destino;
            Monto = monto;
            Tipo = tipo;
            Estado = estado;
            Fecha = fecha;
        }
        public override string ToString() => $"¬ [{Codigo}] | {Origen} => {Destino} | {Tipo} | S/{Monto:N2} | {Estado}";
    }
}