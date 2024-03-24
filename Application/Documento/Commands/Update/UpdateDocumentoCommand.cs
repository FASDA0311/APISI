using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Documento.Commands.Update
{
    public class UpdateDocumentoCommand : IRequest<Unit>
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }

        public string Archivo { get; set; }
        public bool Vigente { get; set; }
    }
}


