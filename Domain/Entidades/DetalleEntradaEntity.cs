using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class DetalleEntradaEntity
    {
        public int Codigo { get; set; }
        public string Observacion { get; set; }
        public bool Vigente { get; set; }
        public int CodigoEquipo { get; set; }
        public int CodigoEntrada { get; set; }
        public int CodigoSalida { get; set; }
    }
}
