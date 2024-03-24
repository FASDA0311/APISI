using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Documento.Commands.Crear
{
    public class CreateDocumentoCommand : IRequest<int>
    {
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public string Archivo { get; set; }
        public bool Vigente { get; set; }
    }
}

