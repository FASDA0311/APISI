using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    internal class Orden_ReposicionEntity
    {
        public int Codigo { get; set; }
        public DateTime Fecha { get; set; }
        public string Total { get; set; }
        public int CodigoPersonalSoporte { get; set; }
        public bool Vigente { get; set; }
    }
}
