using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.PersonalDesarrollo.Queries.Listar
{
    public class ListarPersonalDesarrolloQueryHandler : IRequestHandler<ListarPersonalDesarrolloQuery, IEnumerable<PersonalDesarrolloDTO>>
    {
        private readonly IPersonalDesarrolloRepository _repository;
        private readonly IMapper _mapper;

        public ListarPersonalDesarrolloQueryHandler(IPersonalDesarrolloRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PersonalDesarrolloDTO>> Handle(ListarPersonalDesarrolloQuery request, CancellationToken cancellationToken)
        {
            var lista = await _repository.ListarPersonalDesarrollo();
            return _mapper.Map<IEnumerable<PersonalDesarrolloDTO>>(lista);
        }
    }
}

