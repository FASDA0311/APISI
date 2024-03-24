using Application.ActividadDetalleEntrada.Queries.Listar;
using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ActividadDetalleEntrada.Queries.Obtener
{
    public class ObtenerActividadDetalleEntradaQueryHandler : IRequestHandler<ObtenerActividadDetalleEntradaQuery, ActividadDetalleEntradaDTO>
{
    private readonly IActividadDetalleEntradaRepository _ActividadDetalleEntradaRepository;
    private readonly IMapper _mapper;

    public ObtenerActividadDetalleEntradaQueryHandler(IActividadDetalleEntradaRepository ActividadDetalleEntradaRepository, IMapper mapper)
    {
        _ActividadDetalleEntradaRepository = ActividadDetalleEntradaRepository;
        _mapper = mapper;
    }

    public async Task<ActividadDetalleEntradaDTO> Handle(ObtenerActividadDetalleEntradaQuery request, CancellationToken cancellationToken)
    {
        var variable = await _ActividadDetalleEntradaRepository.ObtenerActividadDetalleEntrada(request.Id);
        return _mapper.Map<ActividadDetalleEntradaDTO>(variable);
    }
}
}

