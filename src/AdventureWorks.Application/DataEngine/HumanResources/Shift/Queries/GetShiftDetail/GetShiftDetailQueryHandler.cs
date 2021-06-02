using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.HumanResources.Shift.Queries.GetShifts;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.HumanResources.Shift.Queries.GetShiftDetail
{
    public partial class GetShiftDetailQueryHandler : IRequestHandler<GetShiftDetailQuery, ShiftLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetShiftDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ShiftLookupModel> Handle(GetShiftDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Shifts
                .FindAsync(new object[] { request.ShiftID }, cancellationToken);

            return _mapper.Map<Domain.Entities.HumanResources.Shift, ShiftLookupModel>(entity);
        }
    }
}
