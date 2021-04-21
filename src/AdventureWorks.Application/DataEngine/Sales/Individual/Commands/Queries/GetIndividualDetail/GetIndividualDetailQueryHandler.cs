using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.Individual.Queries.GetIndividuals;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Sales.Individual.Queries.GetIndividualDetail
{
    public partial class GetIndividualDetailQueryHandler : IRequestHandler<GetIndividualDetailQuery, IndividualLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetIndividualDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IndividualLookupModel> Handle(GetIndividualDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Individuals
                .FindAsync(new object[] { request.CustomerID }, cancellationToken);

            return _mapper.Map<Domain.Entities.Sales.Individual, IndividualLookupModel>(entity);
        }
    }
}
