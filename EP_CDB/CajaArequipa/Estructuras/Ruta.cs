using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_CDB.CajaArequipa.Estructuras
{
    public class Ruta
    {
        public string Origen { get; set; }
        public string Destino { get; set; }
        public bool EstaConectada { get; set; }
        public Ruta(string origen, string destino, bool estado)
        {
            Origen = origen;
            Destino = destino;
            EstaConectada = estado;
        }
        public override string ToString()
        {
            string estado = EstaConectada ? "Conectada" : "Desconectada";
            return $" ¬ {Origen} => {Destino} | {estado}";
        }
    }
}
