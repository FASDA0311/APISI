using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Repositorios
{
    public interface IDocumentoRepository
    {
        Task<IEnumerable<DocumentoEntity>> ListarDocumento();
        Task<DocumentoEntity> ObtenerDocumento(int id);
        Task<int> CrearDocumento(DocumentoEntity variable);
        Task ActualizarDocumento(DocumentoEntity variable);
    }
}

