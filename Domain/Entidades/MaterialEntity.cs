using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class MaterialEntity
    {
        public int Codigo { get; set; }

        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public int CodigoTipoProducto { get; set; }
        public bool Vigente { get; set; }
    }
    
}
