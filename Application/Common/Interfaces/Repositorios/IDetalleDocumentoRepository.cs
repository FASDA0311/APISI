using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Repositorios
{
    public interface IDetalleDocumentoRepository
    {
        Task<IEnumerable<DetalleDocumentoEntity>> ListarDetalleDocumento();
        Task<DetalleDocumentoEntity> ObtenerDetalleDocumento(int id);
        Task<int> CrearDetalleDocumento(DetalleDocumentoEntity variable);
        Task ActualizarDetalleDocumento(DetalleDocumentoEntity variable);
    }
}

