using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.ScrapReason.Queries.GetScrapReasons;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;


namespace AdventureWorks.Application.DataEngine.Production.ScrapReason.Commands.CreateScrapReason
{
    public partial class CreateScrapReasonSetCommand : IRequest<List<ScrapReasonLookupModel>>
    {
        public List<BaseScrapReason> ScrapReasons { get; set; }

        public CreateScrapReasonSetCommand()
        {
        }

        public CreateScrapReasonSetCommand(List<BaseScrapReason> model)
        {
            ScrapReasons = model;
        }

        public partial class Handler : IRequestHandler<CreateScrapReasonSetCommand, List<ScrapReasonLookupModel>>
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

            public async Task<List<ScrapReasonLookupModel>> Handle(CreateScrapReasonSetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<ScrapReasonLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.ScrapReasons)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateScrapReasonCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}