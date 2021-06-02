using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Person.Contact.Queries.GetContacts;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Person.Contact.Queries.GetContactDetail
{
    public partial class GetContactDetailQueryHandler : IRequestHandler<GetContactDetailQuery, ContactLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetContactDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ContactLookupModel> Handle(GetContactDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Contacts
                .FindAsync(new object[] { request.ContactID }, cancellationToken);

            return _mapper.Map<Domain.Entities.Person.Contact, ContactLookupModel>(entity);
        }
    }
}
