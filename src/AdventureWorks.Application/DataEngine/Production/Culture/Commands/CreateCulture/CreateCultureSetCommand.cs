using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.Culture.Queries.GetCultures;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;


namespace AdventureWorks.Application.DataEngine.Production.Culture.Commands.CreateCulture
{
    public partial class CreateCultureSetCommand : IRequest<List<CultureLookupModel>>
    {
        public List<BaseCulture> Cultures { get; set; }

        public CreateCultureSetCommand()
        {
        }

        public CreateCultureSetCommand(List<BaseCulture> model)
        {
            Cultures = model;
        }

        public partial class Handler : IRequestHandler<CreateCultureSetCommand, List<CultureLookupModel>>
        {
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;

            public Handler(IAdventureWorksContext context, IMediator mediator, IMapper mapper)
            {
                _context = context;
                _mediator = mediator;
                _mapper = mapper;
            }

            public async Task<List<CultureLookupModel>> Handle(CreateCultureSetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<CultureLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.Cultures)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateCultureCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}