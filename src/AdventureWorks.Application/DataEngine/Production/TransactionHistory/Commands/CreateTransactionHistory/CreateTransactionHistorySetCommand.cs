using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.TransactionHistory.Queries.GetTransactionHistories;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;


namespace AdventureWorks.Application.DataEngine.Production.TransactionHistory.Commands.CreateTransactionHistory
{
    public partial class CreateTransactionHistorySetCommand : IRequest<List<TransactionHistoryLookupModel>>
    {
        public List<BaseTransactionHistory> TransactionHistories { get; set; }

        public CreateTransactionHistorySetCommand()
        {
        }

        public CreateTransactionHistorySetCommand(List<BaseTransactionHistory> model)
        {
            TransactionHistories = model;
        }

        public partial class Handler : IRequestHandler<CreateTransactionHistorySetCommand, List<TransactionHistoryLookupModel>>
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

            public async Task<List<TransactionHistoryLookupModel>> Handle(CreateTransactionHistorySetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<TransactionHistoryLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.TransactionHistories)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateTransactionHistoryCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}