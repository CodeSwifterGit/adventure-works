using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.UnitMeasure.Queries.GetUnitMeasures;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Production.UnitMeasure.Queries.GetUnitMeasureDetail
{
    public partial class GetUnitMeasureDetailQueryHandler : IRequestHandler<GetUnitMeasureDetailQuery, UnitMeasureLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetUnitMeasureDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UnitMeasureLookupModel> Handle(GetUnitMeasureDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.UnitMeasures
                .FindAsync(new object[] { request.UnitMeasureCode }, cancellationToken);

            return _mapper.Map<Domain.Entities.Production.UnitMeasure, UnitMeasureLookupModel>(entity);
        }
    }
}
