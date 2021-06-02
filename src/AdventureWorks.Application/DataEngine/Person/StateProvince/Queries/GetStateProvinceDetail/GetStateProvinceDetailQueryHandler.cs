using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Person.StateProvince.Queries.GetStateProvinces;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Person.StateProvince.Queries.GetStateProvinceDetail
{
    public partial class GetStateProvinceDetailQueryHandler : IRequestHandler<GetStateProvinceDetailQuery, StateProvinceLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetStateProvinceDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StateProvinceLookupModel> Handle(GetStateProvinceDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.StateProvinces
                .FindAsync(new object[] { request.StateProvinceID }, cancellationToken);

            return _mapper.Map<Domain.Entities.Person.StateProvince, StateProvinceLookupModel>(entity);
        }
    }
}
