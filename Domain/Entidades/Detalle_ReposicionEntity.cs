using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class DetalleReposicionEntity
    {
        public int Codigo { get; set; }
        public string Cantidad { get; set; }
        public string PrecioUnitario { get; set; }
        public int CodigoReposicion { get; set; }
        public int CodigoMaterial { get; set; }
        public bool Vigente { get; set; }
    }

}
