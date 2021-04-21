using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Purchasing.ShipMethod.Queries.GetShipMethods;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Purchasing.ShipMethod.Queries.GetShipMethodDetail
{
    public partial class GetShipMethodDetailQueryHandler : IRequestHandler<GetShipMethodDetailQuery, ShipMethodLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetShipMethodDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ShipMethodLookupModel> Handle(GetShipMethodDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.ShipMethods
                .FindAsync(new object[] { request.ShipMethodID }, cancellationToken);

            return _mapper.Map<Domain.Entities.Purchasing.ShipMethod, ShipMethodLookupModel>(entity);
        }
    }
}
