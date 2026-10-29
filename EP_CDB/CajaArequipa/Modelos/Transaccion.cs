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
        public DateTime fecha { get; set; }
        public Transaccion(string Codigo, string Origen, string Destino, double Monto, TipoTransaccion Tipo,EstadoTransaccion Estado,
            DateTime fecha)
        {
            this.Codigo = Codigo;
            this.Origen = Origen;
            this.Destino = Destino;
            this.Monto = Monto;
            this.Tipo = Tipo;
            this.Estado = Estado;
            this.fecha = fecha;
        }
        public override string ToString() => $"¬ {Codigo} | {Origen} => {Destino}\t| {Tipo}\t| S/{Monto:N2}\t| {Estado}";
    }
}