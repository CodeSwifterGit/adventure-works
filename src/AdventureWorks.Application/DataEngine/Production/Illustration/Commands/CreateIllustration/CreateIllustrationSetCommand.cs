using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.Illustration.Queries.GetIllustrations;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;


namespace AdventureWorks.Application.DataEngine.Production.Illustration.Commands.CreateIllustration
{
    public partial class CreateIllustrationSetCommand : IRequest<List<IllustrationLookupModel>>
    {
        public List<BaseIllustration> Illustrations { get; set; }

        public CreateIllustrationSetCommand()
        {
        }

        public CreateIllustrationSetCommand(List<BaseIllustration> model)
        {
            Illustrations = model;
        }

        public partial class Handler : IRequestHandler<CreateIllustrationSetCommand, List<IllustrationLookupModel>>
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

            public async Task<List<IllustrationLookupModel>> Handle(CreateIllustrationSetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<IllustrationLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.Illustrations)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateIllustrationCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}