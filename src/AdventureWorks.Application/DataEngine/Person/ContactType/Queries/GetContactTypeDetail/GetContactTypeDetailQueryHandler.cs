using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Person.ContactType.Queries.GetContactTypes;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Person.ContactType.Queries.GetContactTypeDetail
{
    public partial class GetContactTypeDetailQueryHandler : IRequestHandler<GetContactTypeDetailQuery, ContactTypeLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetContactTypeDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ContactTypeLookupModel> Handle(GetContactTypeDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.ContactTypes
                .FindAsync(new object[] { request.ContactTypeID }, cancellationToken);

            return _mapper.Map<Domain.Entities.Person.ContactType, ContactTypeLookupModel>(entity);
        }
    }
}
